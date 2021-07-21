USE ITCREW;

DELIMITER $$
SET collation_connection = @@collation_database;
DROP PROCEDURE IF EXISTS delete_menu_set $$
CREATE PROCEDURE delete_menu_set(
IN param_seq_no BIGINT,
IN param_type VARCHAR(50),
IN param_depth_1 VARCHAR(50),
IN param_depth_2 VARCHAR(50),
IN param_parent_id BIGINT,
IN param_url VARCHAR(50),
IN param_change_user_no BIGINT,
IN param_change_date_time DATETIME
)
BEGIN
   UPDATE tb_menu_set SET
   `TYPE` = param_type,
   DEPTH1 = param_depth_1,
   DEPTH2 = param_depth_2,
   PARENT_ID = param_parent_id,
   `URL` = param_url,
   CHG_USR_NO = param_change_user_no,
   CHG_DATE = param_change_date_time
   WHERE M.SEQ_NO = param_seq_no;
END $$

DELIMITER ;

