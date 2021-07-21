USE ITCREW;

DELIMITER $$
SET collation_connection = @@collation_database;
DROP PROCEDURE IF EXISTS delete_reply $$
CREATE PROCEDURE delete_reply(
IN param_reply_id BIGINT,
IN param_active_flag VARCHAR(50),
IN param_current_actvie_flag VARCHAR(50),
)
BEGIN
    Update tb_subj_reply SET
    Active_Flag = param_active_flag
	 WHERE R.REPLY_ID = param_reply_id AND Active_Flag = param_current_actvie_flag;
END $$

DELIMITER ;

