CREATE VIEW professor_section_view AS
SELECT gl_professors.professor_no, COUNT(gl_sections.section_id) AS total_sections
FROM gl_professors
LEFT JOIN gl_sections ON gl_professors.professor_no = gl_sections.professor_no
GROUP BY gl_professors.professor_no;


DELETE FROM professor_section_view
WHERE professor_no = 5008;

DELETE FROM professor_section_view
WHERE professor_no = 5001;

CREATE OR REPLACE TRIGGER professor_delete_trg
INSTEAD OF DELETE ON professor_section_view
FOR EACH ROW
DECLARE
  v_professor_no NUMBER := :OLD.professor_no;
BEGIN
  DELETE FROM gl_professors_copy WHERE professor_no = v_professor_no;
  DELETE FROM gl_sections_copy WHERE professor_no = v_professor_no;
  DBMS_OUTPUT.PUT_LINE('Professor ' || v_professor_no || ' has been deleted along with all assigned sections.');
END;


DELETE FROM professor_section_view
WHERE professor_no = 5001;



SELECT *
FROM professor_section_view
WHERE professor_no = 5001;

SELECT *
FROM gl_professors_copy
WHERE professor_no = 5001;

SELECT *
FROM gl_sections
WHERE professor_no = 5001;