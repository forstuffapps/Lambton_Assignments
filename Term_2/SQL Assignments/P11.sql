/* c0869346 - Vishal Reddy */


Step 1: Set-up

DROP TABLE gl_sections_copy;
DROP TABLE gl_professors_copy;

CREATE TABLE gl_professors_copy AS(SELECT*FROM gl_professors);

ALTER TABLE gl_professors_copy ADD CONSTRAINT gl_professors_copy_pk PRIMARY KEY (professor_no);

CREATE TABLE gl_sections_copy AS(SELECT*FROM gl_sections);

ALTER TABLE gl_sections_copy ADD CONSTRAINT gl_sections_copy_pk PRIMARY KEY (section_id);

ALTER TABLE gl_sections_copy_professor_no_fk FOREIGN KEY (professor_no) REFERENCES gl_professors_copy (professor_no);

SELECT*FROM gl_professors_copy;

SELECT*FROM gl_sections_copy;


Step 2: Create view

Create a view called professor_section_view that generates a list of professors and the total sections each professor is assigned. List all professors even if no sections are assigned. Sample output from view:

PROFESSOR NO TOTAL_SECTIONS
5001	3
5002	3
5003	3
5004	3
5005	1
5006	1
5007	0
5008	0
5009	0
1010	62

solution:

CREATE VIEW professor_section_view AS
SELECT gl_professors_copy.professor_no,
gl_professors_copy.first_name,
gl_professors_copy.last_name,
COUNT(gl_sections_copy.section_id) AS total_sections
FROM gl_professors_copy
LEFT JOIN gl_sections_copy ON gl_professors_copy.professor_no = gl_sections_copy.professor_no
GROUP BY gl_professors_copy.professor_no, gl_professors_copy.first_name, gl_professors_copy.last_name;

SELECT * FROM professor_section_view;


Step 3: Delete professor

Delete professor 5008 from the professor_section_view. What happens?

Deleting a professor from the professor_section_view view would not delete the actual row from the underlying gl_professors_copy table. It would only remove the professor's information from the view.

However, if professor 5008 has any associated sections in the gl_sections_copy table, those sections will now be associated with a non-existent professor in the professor_section_view, resulting in a null value for the professor's name and an inaccurate count of total sections assigned to that professor. This can cause data integrity issues and affect the accuracy of any analysis or reporting based on the professor_section_view.

To delete professor 5008 from the gl_professors_copy table and maintain data integrity, it would be necessary to also delete any associated sections in the gl_sections_copy table before deleting the professor.


Step 4: Delete professor

Delete professor 5001 from the professor_section_view. What happens?

Deleting professor 5001 from the professor_section_view would only remove the professor's information from the view. It would not delete the actual row from the underlying gl_professors_copy table.

If professor 5001 has any associated sections in the gl_sections_copy table, those sections will still be associated with the professor, but the count of total sections assigned to the professor in the professor_section_view will be reduced by the number of sections associated with that professor. This will accurately reflect the updated number of sections assigned to the remaining professors in the view.

It's important to note that deleting a professor from the gl_professors_copy table can still have implications on the accuracy of the professor_section_view, as described in the previous answer.


Step 5: Create trigger

Create an INSTEAD OF trigger called professor_delete_trg that deleted a professor from the gl_professors_copy table and also deleted any sections assigned to that professor from the gl_sections_copy table.

CREATE OR REPLACE TRIGGER professor_delete_trg
INSTEAD OF DELETE ON gl_professors_copy
FOR EACH ROW
BEGIN
  -- Delete any sections assigned to the professor being deleted
  DELETE FROM gl_sections_copy
  WHERE professor_no = :OLD.professor_no;

  -- Delete the professor row from the gl_professors_copy table
  DELETE FROM gl_professors_copy
  WHERE professor_no = :OLD.professor_no;
END;



Step 6: Delete professor

Delete professor 5001 from the professor_section_view. What happens?


Step 7: Verify results

Execute the following statements to verify the results of the INSTEAD OF trigger

SELECT*FROM professor_section_view WHERE professor_no = 5001;

SELECT*FROM gl_professors_copy WHERE professors_no = 5001;

SELECT*FROM gl_sections_copy WHERE professor_no = 5001;