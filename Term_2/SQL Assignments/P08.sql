--  Vishal Reddy Guda
-- C0869346



/* 1 */

CREATE OR REPLACE FUNCTION convert_numeric_grade(
    numeric_grade NUMBER
) RETURN VARCHAR2 IS
    letter_grade VARCHAR2(2);
BEGIN
    CASE
        WHEN numeric_grade >= 90 THEN
            letter_grade := 'A';
        WHEN numeric_grade >= 80 AND numeric_grade < 90 THEN
            letter_grade := 'B';
        WHEN numeric_grade >= 70 AND numeric_grade < 80 THEN
            letter_grade := 'C';
        WHEN numeric_grade >= 60 AND numeric_grade < 70 THEN
            letter_grade := 'D';
        ELSE
            letter_grade := 'F';
    END CASE;
    
    RETURN letter_grade;
END;

DECLARE
 numeric_grade NUMBER := :Enter_Numeric_Grade;
    -- numeric_grade NUMBER;
    letter_grade VARCHAR2(10);
BEGIN
    -- Prompt user for numeric grade
    numeric_grade := :Enter_Numeric_Grade;
    
    -- Call convert_numeric_grade function
    letter_grade := convert_numeric_grade(numeric_grade);
    
    -- Output letter grade
    DBMS_OUTPUT.PUT_LINE('Numeric Grade: ' || numeric_grade);
    DBMS_OUTPUT.PUT_LINE('Letter Grade: ' || letter_grade);
END;



/* 2 */

CREATE FUNCTION get_numeric_grade (section_id INT, student_number INT)
RETURNS DECIMAL(10,2)
BEGIN
    DECLARE grade DECIMAL(10,2);
    SELECT numeric_grade INTO grade FROM GL_EMROLLMENTS
    WHERE section_id = section_id AND student_number = student_number;
    RETURN grade;
END;

/* 3 */

CREATE FUNCTION get_letter_grade (section_id INT, student_number INT)
RETURNS CHAR(1)
BEGIN
    DECLARE grade DECIMAL(10,2);
    SELECT numeric_grade INTO grade FROM GL_EMROLLMENTS
    WHERE section_id = section_id AND student_number = student_number;
    DECLARE letter_grade CHAR(1);
    IF grade >= 90 THEN SET letter_grade = 'A';
    ELSEIF grade >= 80 THEN SET letter_grade = 'B';
    ELSEIF grade >= 70 THEN SET letter_grade = 'C';
    ELSEIF grade >= 60 THEN SET letter_grade = 'D';
    ELSE SET letter_grade = 'F';
    END IF;
    RETURN letter_grade;
END;

/* 4 */

CREATE FUNCTION get_full_name (student_number INT)
RETURNS VARCHAR(100)
BEGIN
    DECLARE first_name VARCHAR(50);
    DECLARE last_name VARCHAR(50);
    DECLARE full_name VARCHAR(100);
    
    BEGIN
        SELECT first_name, last_name INTO first_name, last_name FROM STUDENTS
        WHERE number = student_number;
        SET full_name = CONCAT(first_name, ' ', last_name);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            SET full_name = NULL;
    END;
    
    RETURN full_name;
END;

DECLARE
  v_student_id NUMBER;
  v_full_name VARCHAR2(100);
BEGIN
  -- Prompt for student ID
  v_student_id := &Enter_Student_ID;

  -- Call get_full_name function
  v_full_name := get_full_name(v_student_id);

  -- Display full name if found, otherwise display message
  IF v_full_name IS NULL THEN
    DBMS_OUTPUT.PUT_LINE('Student ID ' || v_student_id || ' not found');
  ELSE
    DBMS_OUTPUT.PUT_LINE('Student full name is ' || v_full_name);
  END IF;
END;
/


/* 5 */

DECLARE
  v_section_id NUMBER;
  v_student_id NUMBER;
  v_full_name VARCHAR2(100);
  v_numeric_grade NUMBER;
  v_letter_grade VARCHAR2(2);
BEGIN
  -- Prompt for section id and student id
  v_section_id := &Enter_Section_ID;
  v_student_id := &Enter_Student_ID;

  -- Call get_full_name and get_numeric_grade functions
  SELECT get_full_name(v_student_id)
  INTO v_full_name
  FROM students
  WHERE student_id = v_student_id
    AND section_id = v_section_id;

  SELECT get_numeric_grade(v_student_id)
  INTO v_numeric_grade
  FROM students
  WHERE student_id = v_student_id
    AND section_id = v_section_id;

  -- Determine letter grade
  IF v_numeric_grade >= 90 THEN
    v_letter_grade := 'A';
  ELSIF v_numeric_grade >= 80 THEN
    v_letter_grade := 'B';
  ELSIF v_numeric_grade >= 70 THEN
    v_letter_grade := 'C';
  ELSIF v_numeric_grade >= 60 THEN
    v_letter_grade := 'D';
  ELSE
    v_letter_grade := 'F';
  END IF;

  -- Output results
  IF v_full_name IS NOT NULL THEN
    DBMS_OUTPUT.PUT_LINE('Student: ' || v_full_name);
    DBMS_OUTPUT.PUT_LINE('Numeric Grade: ' || v_numeric_grade);
    DBMS_OUTPUT.PUT_LINE('Letter Grade: ' || v_letter_grade);
  ELSE
    DBMS_OUTPUT.PUT_LINE('Student not found.');
  END IF;

EXCEPTION
  WHEN OTHERS THEN
    DBMS_OUTPUT.PUT_LINE('An error occurred: ' || SQLERRM);
END;



