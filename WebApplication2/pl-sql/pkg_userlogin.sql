CREATE OR REPLACE PROCEDURE UserLogin (
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
END;
/
