USE ITCREW;

DELIMITER $$
SET collation_connection = @@collation_database;
DROP PROCEDURE IF EXISTS update_email_auth_flag $$
CREATE PROCEDURE update_email_auth_flag(
	IN param_email VARCHAR(50),
    IN param_userInfo_AuthCode int,
    param_userInfo_emailFlag bit
)

BEGIN
	UPDATE tb_user_login_info
	SET ACTIVE_FLAG=param_userInfo_emailFlag
    WHERE EMAIL = param_email AND
    IMG_UR=param_userInfo_AuthCode;
END $$

DELIMITER ;

