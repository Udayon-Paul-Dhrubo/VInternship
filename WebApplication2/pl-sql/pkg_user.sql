CREATE OR REPLACE PACKAGE pkg_user AS
    PROCEDURE user_insert (
        p_username IN VARCHAR2,
        p_user_password IN VARCHAR2,
        p_first_name IN VARCHAR2,
        p_last_name IN VARCHAR2,
        p_email IN VARCHAR2,
        p_cursor OUT SYS_REFCURSOR
    );
    PROCEDURE UserLogin (
    p_userid IN VARCHAR2,
    p_password IN VARCHAR2,sys
    p_cursor OUT SYS_REFCURSOR
);
END pkg_user;
/

CREATE OR REPLACE PACKAGE BODY pkg_user AS

PROCEDURE user_insert (
    p_username IN VARCHAR2,
    p_user_password IN VARCHAR2,
    p_first_name IN VARCHAR2,
    p_last_name IN VARCHAR2,
    p_email IN VARCHAR2,
    p_cursor OUT SYS_REFCURSOR
)
AS
   v_id NUMBER;
        v_count NUMBER;
        v_status  NUMBER :=600;
        v_message VARCHAR2(200) := 'Failed to insert';
BEGIN
    -- Generate unique id using a sequence
    DECLARE
     
    BEGIN

        select count(*) into v_count from tia_users  WHERE username = p_username;

        if v_count>0
        Then
            v_status := 601;
            v_message := 'Already exists';
             OPEN p_cursor FOR
               SELECT v_status AS status,v_message AS message FROM dual;
            RETURN;
        end if;

        SELECT seq_users.NEXTVAL INTO v_id FROM DUAL;

        -- Insert sample dummy data with unique id
        INSERT INTO tia_users (id, username, password, first_name, last_name, email)
        VALUES (v_id, p_username,p_user_password,p_first_name, p_last_name, p_email);

            v_status := 200;
            v_message := 'Success';
      
        -- Create cursor for status and success 
            OPEN p_cursor FOR
               SELECT v_status AS status,v_message AS message FROM dual;

        -- Commit the transaction
        COMMIT;
    END;
EXCEPTION
    WHEN OTHERS THEN
        -- Rollback the transaction on error
        ROLLBACK;
            v_status := 603;
            v_message := 'Error ROLLBACK';
      
        -- Create cursor for status and success 
            OPEN p_cursor FOR
               SELECT v_status AS status,v_message AS message FROM dual;
        RAISE;
END user_insert;

PROCEDURE UserLogin (
    p_userid IN VARCHAR2,
    p_password IN VARCHAR2,
    p_cursor OUT SYS_REFCURSOR
)
AS
    v_status NUMBER := 400;
    v_message VARCHAR2(100) := 'Failure login';
BEGIN
    -- Check if the userid and password match a record in the table
    SELECT COUNT(*) INTO v_status
    FROM tia_users
    WHERE username = p_userid
    AND password = p_password;

    -- Set the status and message based on the result
    IF v_status = 1 THEN
        v_status := 200;
        v_message := 'Success';
    END IF;

    -- Create cursor for status and message
    OPEN p_cursor FOR
    SELECT v_status AS status, v_message AS message FROM DUAL;
EXCEPTION
    WHEN OTHERS THEN
        -- Raise an exception with the error details
        ROLLBACK;
        RAISE;
END UserLogin;
 

END pkg_user;
/
