USE ITCREW;

DELIMITER $$
SET collation_connection = @@collation_database;
DROP PROCEDURE IF EXISTS update_subject_info $$
CREATE PROCEDURE update_subject_info(
    IN param_subject_id BIGINT,
	IN param_title varchar(50),
	IN param_desc varchar(5000),
	IN param_chg_user_no BIGINT,
	IN param_change_date_time datetime
)
BEGIN
	UPDATE tb_subj_info SET
		TITLE = param_title,
		`DESC` = param_desc,
		CHG_USER_NO = param_chg_user_no,
		CHG_DATE = param_change_date_time
    WHERE SUBJ_ID = param_subject_id;
END $$

DELIMITER ;

