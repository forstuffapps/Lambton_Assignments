/* c0869346 - Vishal Reddy Guda */



CREATE OR REPLACE PROCEDURE P1001
    (p_section_id IN GL_SECTIONS_COPY.section_id%TYPE,
     p_professor_no IN GL_SECTIONS_COPY.professor_no%TYPE DEFAULT NULL,
     p_room_no IN GL_SECTIONS_COPY.room_no%TYPE DEFAULT NULL,
     p_enroll_max IN GL_SECTIONS_COPY.enroll_max%TYPE DEFAULT NULL)
IS
    v_count NUMBER;
BEGIN
    IF p_professor_no IS NOT NULL THEN
        UPDATE GL_SECTIONS_COPY
        SET professor_no = p_professor_no
        WHERE section_id = p_section_id;
        v_count := SQL%ROWCOUNT;
        IF v_count = 0 THEN
            DBMS_OUTPUT.PUT_LINE('1 sections updated');
            DBMS_OUTPUT.PUT_LINE('section_id = ' || p_section_id || ' not found');
        ELSE
            DBMS_OUTPUT.PUT_LINE(v_count || ' sections updated');
            DBMS_OUTPUT.PUT_LINE('section_id = ' || p_section_id || ' updated professor_no = ' || p_professor_no);
        END IF;
    END IF;

    IF p_room_no IS NOT NULL THEN
        UPDATE GL_SECTIONS_COPY
        SET room_no = p_room_no
        WHERE section_id = p_section_id;
        v_count := SQL%ROWCOUNT;
        IF v_count = 0 THEN
            DBMS_OUTPUT.PUT_LINE('1 sections updated');
            DBMS_OUTPUT.PUT_LINE('section_id = ' || p_section_id || ' not found');
        ELSE
            DBMS_OUTPUT.PUT_LINE(v_count || ' sections updated');
            DBMS_OUTPUT.PUT_LINE('section_id = ' || p_section_id || ' updated room_no = ' || p_room_no);
        END IF;
    END IF;

    IF p_enroll_max IS NOT NULL THEN
        UPDATE GL_SECTIONS_COPY
        SET enroll_max = p_enroll_max
        WHERE section_id = p_section_id;
        v_count := SQL%ROWCOUNT;
        IF v_count = 0 THEN
            DBMS_OUTPUT.PUT_LINE('1 sections updated');
            DBMS_OUTPUT.PUT_LINE('section_id = ' || p_section_id || ' not found');
        ELSE
            DBMS_OUTPUT.PUT_LINE(v_count || ' sections updated');
            DBMS_OUTPUT.PUT_LINE('section_id = ' || p_section_id || ' updated enroll_max = ' || p_enroll_max);
        END IF;
    END IF;

    IF v_count = 0 THEN
        RAISE_APPLICATION_ERROR(-20001, 'Section not found');
    END IF;

    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('1 sections updated');
            DBMS_OUTPUT.PUT_LINE('section_id = ' || p_section_id || ' not found');
        WHEN OTHERS THEN
            DBMS_OUTPUT.PUT_LINE('Error: ' || SQLCODE || ' - ' || SQLERRM);
END;