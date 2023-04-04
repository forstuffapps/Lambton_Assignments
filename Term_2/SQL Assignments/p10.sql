


-- P0901


/* Step_1 */
CREATE TABLE GL_PRO_AUDIT_LOG (
  user_id VARCHAR2(30) DEFAULT USER,
  last_change_date DATE DEFAULT SYSDATE,
  trigger_name VARCHAR2(15),
  log_action VARCHAR2(30)
);

CREATE OR REPLACE TRIGGER GL_PRO_AUDIT_TRG
AFTER INSERT OR UPDATE OR DELETE ON GL_PROFESSORS_COPY
FOR EACH ROW
BEGIN
  IF INSERTING THEN
    INSERT INTO GL_PRO_AUDIT_LOG (trigger_name, log_action)
    VALUES ('GL_PRO_INSERT', 'Inserting a row into GL_PROFESSORS_COPY');
  ELSIF UPDATING THEN
    INSERT INTO GL_PRO_AUDIT_LOG (trigger_name, log_action)
    VALUES ('GL_PRO_UPDATE', 'Updating a row in GL_PROFESSORS_COPY');
  ELSIF DELETING THEN
    INSERT INTO GL_PRO_AUDIT_LOG (trigger_name, log_action)
    VALUES ('GL_PRO_DELETE', 'Deleting a row from GL_PROFESSORS_COPY');
  END IF;
END;






/* Step_2 */
CREATE OR REPLACE TRIGGER GL_PROFESSOR_TRG
AFTER INSERT ON GL_PROFESSORS_COPY
BEGIN
  INSERT INTO GL_PRO_AUDIT_LOG (user_id, trigger_name, log_action)
  VALUES (USER, 'gl_professor_trg', 'INSERT');
END;







/* Step_3 */
DECLARE
  v_school_code VARCHAR2(10);
  v_first_name VARCHAR2(50);
  v_last_name VARCHAR2(50);
  v_prof_number VARCHAR2(10);
BEGIN
  -- Prompt for input data using bind/host variables
  :v_prof_number := INITCAP(enter_professor_number);
  :v_first_name := INITCAP(enter_first_name);
  :v_last_name := INITCAP(enter_last_name); 
  :v_office_no :=  
  :v_school_code := UPPER(enter_school_code);
  
  -- Call ADD_PROFESSOR procedure to generate professor number and insert row
  BEGIN
    ADD_PROFESSOR(:v_prof_number, v_school_code, v_first_name, v_last_name);
    INSERT INTO gl_professors_copy (professor_number, school_code, first_name, last_name)
    VALUES (v_prof_number, v_school_code, v_first_name, v_last_name);
    COMMIT;
    DBMS_OUTPUT.PUT_LINE('Professor added successfully with number ' || v_prof_number);
  EXCEPTION
    WHEN DUP_VAL_ON_INDEX THEN
      ROLLBACK;
      DBMS_OUTPUT.PUT_LINE('Error: Professor already exists');
    WHEN OTHERS THEN
      ROLLBACK;
      DBMS_OUTPUT.PUT_LINE('Error: ' || SQLERRM);
  END;
END;





/* Step_4 */
SELECT audit_id, professor_number, event_date FROM GL_PRO_AUDIT_LOG;







-- P0902


/* Step_1 */
CREATE OR REPLACE FUNCTION convert_numeric_grade(p_numeric_grade IN NUMBER)
  RETURN VARCHAR2
IS
  v_letter_grade VARCHAR2(2);
BEGIN
  CASE
    WHEN p_numeric_grade >= 90 THEN v_letter_grade := 'A+';
    WHEN p_numeric_grade >= 85 THEN v_letter_grade := 'A';
    WHEN p_numeric_grade >= 80 THEN v_letter_grade := 'A-';
    WHEN p_numeric_grade >= 75 THEN v_letter_grade := 'B+';
    WHEN p_numeric_grade >= 70 THEN v_letter_grade := 'B';
    WHEN p_numeric_grade >= 65 THEN v_letter_grade := 'B-';
    WHEN p_numeric_grade >= 60 THEN v_letter_grade := 'C+';
    WHEN p_numeric_grade >= 55 THEN v_letter_grade := 'C';
    WHEN p_numeric_grade >= 50 THEN v_letter_grade := 'C-';
    WHEN p_numeric_grade >= 45 THEN v_letter_grade := 'D+';
    WHEN p_numeric_grade >= 40 THEN v_letter_grade := 'D';
    ELSE v_letter_grade := 'F';
  END CASE;
  
  RETURN v_letter_grade;
END;



/* Step_2 */
CREATE TABLE GL_ENROLL_UPDATE_LOG (
  log_id          NUMBER GENERATED ALWAYS AS IDENTITY,
  enrollment_id   NUMBER NOT NULL,
  event_date      DATE DEFAULT SYSDATE,
  old_grade       VARCHAR2(2),
  new_grade       VARCHAR2(2),
  action          VARCHAR2(20)
);



/* Step_3 */
CREATE OR REPLACE TRIGGER GL_ENROLL_UPDATE_TRG
AFTER UPDATE OF letter_grade ON gl_enrollments_copy
FOR EACH ROW
DECLARE
  v_action VARCHAR2(20);
BEGIN
  IF :OLD.letter_grade = :NEW.letter_grade THEN
    v_action := 'grade is the same';
  ELSIF :OLD.letter_grade < :NEW.letter_grade THEN
    v_action := 'grade went up';
  ELSE
    v_action := 'grade went down';
  END IF;
  
  INSERT INTO GL_ENROLL_UPDATE_LOG (enrollment_id, old_grade, new_grade, action)
  VALUES (:OLD.enrollment_id, :OLD.letter_grade, :NEW.letter_grade, v_action);
END;



/* Step_4 */
-- Insert row for John Doe
DEFINE enter_school_code = 'ABC';
DEFINE enter_first_name = 'John';
DEFINE enter_last_name = 'Doe';
EXECUTE
BEGIN
  DECLARE
    v_school_code VARCHAR2(10);
    v_first_name VARCHAR2(50);
    v_last_name VARCHAR2(50);
    v_prof_number VARCHAR2(10);
  BEGIN
    :v_school_code := UPPER(&enter_school_code);
    :v_first_name := INITCAP(&enter_first_name);
    :v_last_name := INITCAP(&enter_last_name);
    ADD_PROFESSOR(:v_prof_number, v_school_code, v_first_name, v_last_name);
    INSERT INTO gl_professors_copy (professor_number, school_code, first_name, last_name)
    VALUES (v_prof_number, v_school_code, v_first_name, v_last_name);
    COMMIT;
    DBMS_OUTPUT.PUT_LINE('Professor added successfully with number ' || v_prof_number);
  EXCEPTION
    WHEN DUP_VAL_ON_INDEX THEN
      ROLLBACK;
      DBMS_OUTPUT.PUT_LINE('Error: Professor already exists');
    WHEN OTHERS THEN
      ROLLBACK;
      DBMS_OUTPUT.PUT_LINE('Error: ' || SQLERRM);
  END;
END;
/

-- Insert row for Jane Smith
DEFINE enter_school_code = 'DEF';
DEFINE enter_first_name = 'Jane';
DEFINE enter_last_name = 'Smith';
EXECUTE
BEGIN
  DECLARE
    v_school_code VARCHAR2(10);
    v_first_name VARCHAR2(50);






-- P0903


/* Step_2 */
CREATE VIEW professor_section_view AS
SELECT p.professor_no, p.professor_name, COUNT(s.section_no) AS total_sections
FROM gl_professors p
LEFT JOIN gl_sections s
ON p.professor_no = s.professor_no
GROUP BY p.professor_no;

/* Step_3 */
DELETE FROM professor_section_view
WHERE professor_no = 5008;

/* Step_4 */
DELETE FROM professor_section_view
WHERE professor_no = 5001;

/* Step_5 */
CREATE TRIGGER professor_delete_trg
INSTEAD OF DELETE ON gl_professors_copy
FOR EACH ROW
BEGIN
    DELETE FROM gl_sections_copy WHERE professor_no = OLD.professor_no;
    DELETE FROM gl_professors_copy WHERE professor_no = OLD.professor_no;
END;

/* Step_6 */
DELETE FROM professor_section_view
WHERE professor_no = 5001;

/* Step_7 */
Execute the following statements to verify the results of the results of the INSTEAD OF trigger
SELECT *
FROM professor_section_view
WHERE professor_no = 5001;

SELECT *
FROM gl_professors_copy
WHERE professor_no = 5001;

SELECT *
FROM gl_sections_copy
WHERE professor_no = 5001;
To verify the results of the professor_delete_trg trigger, you can use the following SQL queries:

sql
Copy code
SELECT *
FROM professor_section_view
WHERE professor_no = 5001;
This query should return an empty result set, since professor 5001 has been deleted from the view.

sql
Copy code
SELECT *
FROM gl_professors_copy
WHERE professor_no = 5001;
This query should also return an empty result set, since professor 5001 has been deleted from the gl_professors_copy table by the trigger.

sql
Copy code
SELECT *
FROM gl_sections_copy
WHERE professor_no = 5001;
This query should also return an empty result set, since all sections assigned to professor 5001 have been deleted from the gl_sections_copy table by the trigger.