USE ITCREW;

DELIMITER $$
SET collation_connection = @@collation_database;
DROP PROCEDURE IF EXISTS delete_menu_set $$
CREATE PROCEDURE delete_menu_set(
IN param_seq_no BIGINT
)
BEGIN
   UPDATE tb_menu_set SET
   ACTIVE_FLAG = 'F'
   WHERE M.SEQ_NO = param_seq_no;
END $$

DELIMITER ;

