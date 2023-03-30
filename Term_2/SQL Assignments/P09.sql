--  Vishal Reddy Guda
-- C0869346


    /* Step 1: Drop, create and alter gl_professors_copy table */
    DROP TABLE gl_professors_copy;

    CREATE TABLE gl_professors_copy AS
    (SELECT professor_no, first_name, last_name, office_ext, office_no 
    FROM gl_professors);

    ALTER TABLE gl_professors_copy 
    ADD PRIMARY KEY (professor_no);

    /*  Step 2: a
        Package specification */
    CREATE OR REPLACE PACKAGE college_pkg IS 
    PROCEDURE get_professor
    (p_professor_no IN gl_professors_copy.professor_no%TYPE,
    p_prof_rec OUT gl_professors_copy%ROWTYPE);
    PROCEDURE add_professor
    (p_professor_no IN gl_professors_copy.professor_no%TYPE, 
    p_first_name IN gl_professors_copy.first_name%TYPE,
    p_last_name IN gl_professors_copy.last_name%TYPE,
    p_office_ext IN gl_professors_copy.office_ext%TYPE,
    p_office_no IN gl_professors_copy.office_no%TYPE);
    PROCEDURE delete_professor(p_professor_no IN gl_professors_copy.professor_no%TYPE);
    END college_pkg;

    /*  Step 2: b
        Package body */
    CREATE OR REPLACE PACKAGE BODY college_pkg IS 
    /* procedure 1 */
    PROCEDURE get_professor 
    (p_professor_no IN gl_professors_copy.professor_no%TYPE,
    p_prof_rec OUT gl_professors_copy%ROWTYPE) IS 
    BEGIN
    SELECT * INTO p_prof_rec FROM gl_professors_copy WHERE professor_no = p_professor_no;
    END get_professor;
    /* procedure 2 */
    PROCEDURE add_professor
    (p_professor_no IN gl_professors_copy.professor_no%TYPE, 
    p_first_name IN gl_professors_copy.first_name%TYPE,
    p_last_name IN gl_professors_copy.last_name%TYPE,
    p_office_ext IN gl_professors_copy.office_ext%TYPE,
    p_office_no IN gl_professors_copy.office_no%TYPE) IS 
    BEGIN
    INSERT INTO gl_professors_copy(professor_no, first_name, last_name, office_ext, office_no) 
    VALUES(p_professor_no, p_first_name, p_last_name, p_office_ext, p_office_no);
    END add_professor;
    /* procedure 3 */
    PROCEDURE delete_professor(p_professor_no IN gl_professors_copy.professor_no%TYPE) IS 
    BEGIN
    DELETE FROM gl_professors_copy
    WHERE WHERE professor_no = p_professor_no;
    END delete_professor;
    END college_pkg;

    /* Anonymous blockc */
    /* To test the get_professor procedure */
    DECLARE
    v_prof_rec gl_professors_copy%ROWTYPE;
    v_prof_no gl_professors_copy.professor_no%TYPE := :ENTER_PROFESSOR_NO;
    BEGIN
    college_pkg.get_professor(v_prof_no, v_prof_rec);
    DBMS_OUTPUT.PUT_LINE('No: ' || v_prof_rec.professor_no);
    DBMS_OUTPUT.PUT_LINE('Name: ' || v_prof_rec.first_name || ' ' || v_prof_rec.last_name);
    DBMS_OUTPUT.PUT_LINE('Office ext: ' || v_prof_rec.office_ext);
    DBMS_OUTPUT.PUT_LINE('Office no: ' || v_prof_rec.office_no);
    EXCEPTION
    WHEN NO_DATA_FOUND THEN 
    DBMS_OUTPUT.PUT_LINE('Professor ' || v_prof_no || ' does not exist in the professor''s table');
    END;
    /* To test the add_professor procedure */
    DECLARE
    v_prof_no gl_professors_copy.professor_no%TYPE := :ENTER_PROFESSOR_NO;
    v_first_name gl_professors_copy.first_name%TYPE := :ENTER_FIRST_NAME;
    v_last_name gl_professors_copy.last_name%TYPE := :ENTER_LAST_NAME;
    v_office_ext gl_professors_copy.office_ext%TYPE := :ENTER_OFFICE_EXT;
    v_office_no gl_professors_copy.office_no%TYPE := :ENTER_OFFICE_NO;
    v_prof_rec gl_professors_copy%ROWTYPE;   
    e_prof_not_found EXCEPTION;
    BEGIN
    college_pkg.add_professor(v_prof_no, v_first_name, v_last_name, v_office_ext, v_office_no);
    SELECT * INTO v_prof_rec FROM gl_professors_copy WHERE professor_no = v_prof_no;
    --if insertion unsuccessful - return to the calling environment
    IF SQL%NOTFOUND THEN
    RAISE e_prof_not_found;
    ELSE
    --if insert successful
    DBMS_OUTPUT.PUT_LINE('Inserted 1 row');
    DBMS_OUTPUT.PUT_LINE('Professor: ' || v_prof_no || '- ' || v_first_name || ' ' || v_last_name);
    DBMS_OUTPUT.PUT_LINE('Office ext: ' || v_office_ext);
    DBMS_OUTPUT.PUT_LINE('Office no: ' || v_office_no);
    END IF;
    EXCEPTION 
    WHEN e_prof_not_found THEN
    DBMS_OUTPUT.PUT_LINE('Input (duplicate professor): ');
    WHEN DUP_VAL_ON_INDEX THEN
    DBMS_OUTPUT.PUT_LINE('Professor ' || v_prof_no || 'already exists in the professors tabel');
    END;
    /* To test the delete_professor procedure */
    DECLARE
    v_prof_no gl_professors_copy.professor_no%TYPE := :ENTER_PROFESSOR_NO;
    BEGIN
    college_pkg.delete_professor(v_prof_no);
    IF SQL$NOTFOUND THEN
    RAISE_APPLICATION_ERROR(-20500, 'Professor ' || v_prof_no || 'does not exist in the professors tabel');
    END IF;
    END;


    /* overload package specification */
    CREATE OR REPLACE PACKAGE overload_pkg IS
    PROCEDURE overproc(donor_id IN INTEGER);
    PROCEDURE overproc(registration_code IN VARCHAR2);
    END overload_pkg;

    /* overload package body */
    CREATE OR REPLACE PACKAGE overload_pkg IS
    PROCEDURE overproc(donor_id IN INTEGER) IS
    BEGIN
    v_donor_id gl_donors.donor_id%TYPE := :ENTER_DONOR;
    v_donor_rec gl_donors%ROWTYPE;
    SELECT * INTO v_donor_rec FROM gl_donors WHERE donor_id = v_donor_id;
    DBMS_OUTPUT.PUT_LINE('Donor name: ' || v_donor_rec.donor_name);
    DBMS_OUTPUT.PUT_LINE('Donor type: ' || v_donor_rec.donor_type);
    DBMS_OUTPUT.PUT_LINE('Pledge amount: ' || v_donor_rec.monthly_pledge_amount);
    DBMS_OUTPUT.PUT_LINE('Pledge months: ' || v_donor_rec.pledge_months);
    DBMS_OUTPUT.PUT_LINE('Total amounts: ' || v_donor_rec.monthly_pledge_amount*v_donor_rec.pledge_months);
    DBMS_OUTPUT.PUT_LINE('Donor request by donor id completed');
    END overproc;
    PROCEDURE overproc(registration_code IN VARCHAR2) IS
    BEGIN
    v_reg_code gl_donors.registration_code%TYPE := :ENTER_REGISTRATION_CODE;
    v_donor_rec gl_donors%ROWTYPE;
    DBMS_OUTPUT.PUT_LINE('Donor name: ' || v_donor_rec.donor_name);
    DBMS_OUTPUT.PUT_LINE('Donor type: ' || v_donor_rec.donor_type);
    DBMS_OUTPUT.PUT_LINE('Pledge amount: ' || v_donor_rec.monthly_pledge_amount);
    DBMS_OUTPUT.PUT_LINE('Pledge months: ' || v_donor_rec.pledge_months);
    DBMS_OUTPUT.PUT_LINE('Total amounts: ' || v_donor_rec.monthly_pledge_amount*v_donor_rec.pledge_months);
    DBMS_OUTPUT.PUT_LINE('Donor request by registration code completed');
    END overproc;
    END overload_pkg;

    /* anonymous blocks */
    BEGIN
    overload_pkg.overproc(v_donor_id);
    EXCEPTION
    WHEN NO_DATA_FOUND THEN
    DBMS_OUTPUT.PUT_LINE('Donor not found');
    END;

    BEGIN
    overload_pkg.overproc(v_reg_code);
    EXCEPTION
    WHEN NO_DATA_FOUND THEN
    DBMS_OUTPUT.PUT_LINE('Donor not found');
    END;

-- P0803