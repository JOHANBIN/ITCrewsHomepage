USE ITCREW;

DELIMITER $$
SET collation_connection = @@collation_database;
DROP PROCEDURE IF EXISTS check_duplicate_email $$
CREATE PROCEDURE check_duplicate_email(
	IN param_email VARCHAR(50)
)

BEGIN
	SELECT LT.EMAIL
	FROM TB_USER_LOGIN_INFO as LI
    WHERE LT.EMAIL = param_email;
END $$

DELIMITER ;

