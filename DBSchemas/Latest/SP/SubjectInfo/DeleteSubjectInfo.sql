USE ITCREW;

DELIMITER $$
SET collation_connection = @@collation_database;
DROP PROCEDURE IF EXISTS delete_subject_info $$
CREATE PROCEDURE delete_subject_info(
	IN param_subj_id BIGINT,
	IN param_active_flag varchar(50)
)
BEGIN
	UPDATE tb_subj_info SET
		ACTIVE_FLAG = param_active_flag
    WHERE SUBJ_ID = param_subj_id;
END $$

DELIMITER ;

