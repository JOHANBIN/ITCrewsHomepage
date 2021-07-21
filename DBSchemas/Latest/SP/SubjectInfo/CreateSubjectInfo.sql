USE ITCREW;

DELIMITER $$
SET collation_connection = @@collation_database;
DROP PROCEDURE IF EXISTS create_subject_info $$
CREATE PROCEDURE create_subject_info(
	IN param_type varchar(50),
	IN param_title varchar(50),
	IN param_desc varchar(5000),
	IN param_chg_user_no BIGINT,
	IN param_change_date_time DATETIME,
	IN param_active_flag varchar(50)
)
BEGIN
	INSERT INTO tb_subj_info
	(
		TYPE,
		TITLE,
		`DESC`,
		CHG_USER_NO,
		CHG_DATE,
		ACTIVE_FLAG
	)
	VALUES
	(
		param_type,
		param_title,
		param_desc,
		param_chg_user_no,
		param_change_date_time,
		param_active_flag
	);
END $$

DELIMITER ;

