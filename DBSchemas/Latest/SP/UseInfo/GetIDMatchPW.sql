USE ITCREW;

DELIMITER $$
SET collation_connection = @@collation_database;
DROP PROCEDURE IF EXISTS get_id_match_pw $$
CREATE PROCEDURE get_id_match_pw(
	IN param_userId VARCHAR(50)
)

BEGIN
	SELECT USER_NO,PW
	FROM tb_user_info
    WHERE USER_ID=param_userId;
END $$

DELIMITER ;

