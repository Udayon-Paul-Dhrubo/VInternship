CREATE OR REPLACE PACKAGE auth_pkg_user AS		
    -- Procedure to insert a new user
    PROCEDURE user_insert (
        p_username IN VARCHAR2,
        p_user_password IN VARCHAR2,
        p_cursor OUT SYS_REFCURSOR
    );

	-- Procedure to verify a user
    PROCEDURE user_verify (
    p_userid IN VARCHAR2,
    p_password IN VARCHAR2,
    p_cursor OUT SYS_REFCURSOR
    );

END auth_pkg_user;


CREATE OR REPLACE PACKAGE BODY auth_pkg_user AS   

	-- ......................... # User Insert # ...................... --	
	PROCEDURE user_insert (
		p_username IN VARCHAR2,
        p_user_password IN VARCHAR2,
        p_cursor OUT SYS_REFCURSOR
	)
	IS
		v_id NUMBER;
		v_count NUMBER;
		v_status  NUMBER := 600;
		v_message VARCHAR2(200) := 'Failed to insert';

	BEGIN

 		select count(*) into v_count 
		from fm_users  
		WHERE username = p_username;
 
		if v_count>0
		Then
			v_status := 601;
			v_message := 'Already exists';

			OPEN p_cursor FOR
				SELECT v_status AS status,v_message AS message FROM dual;
			RETURN;
		end if;
 
		SELECT seq_users.NEXTVAL INTO v_id 
		FROM DUAL;
 
		-- Insert sample dummy data with unique id
		INSERT INTO fm_users (id, username, password)
		VALUES (v_id, p_username,p_user_password);
 
		v_status := 200;
		v_message := 'Success';
 
		-- Create cursor for status and success
		OPEN p_cursor FOR
				SELECT v_status AS status,v_message AS message FROM dual;
 
		-- Commit the transaction
		COMMIT;

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

	-- ................ # user login # ................ --
	PROCEDURE user_verify (
		p_userid IN VARCHAR2,
		p_password IN VARCHAR2,
		p_cursor OUT SYS_REFCURSOR
	)
	IS
		v_status NUMBER := 400;
		v_message VARCHAR2(100) := 'null';
	BEGIN
		-- Check if the userid and password match a record in the table
		SELECT COUNT(*) INTO v_status
		FROM fm_users
		WHERE username = p_userid;
		
 
		-- Set the status and message based on the result
		IF v_status = 1 
		THEN
			v_status := 200;
			SELECT password INTO v_message
			FROM fm_users
			WHERE username = p_userid;
		END IF;
 
		-- Create cursor for status and message
		OPEN p_cursor FOR
			SELECT v_status AS status, v_message AS message FROM DUAL;

	EXCEPTION
		WHEN OTHERS THEN
			-- Raise an exception with the error details
			ROLLBACK;
			RAISE;
	END user_verify;


END auth_pkg_user;

commit;