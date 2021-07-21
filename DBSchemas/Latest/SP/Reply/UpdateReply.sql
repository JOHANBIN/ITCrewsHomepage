USE ITCREW;

DELIMITER $$
SET collation_connection = @@collation_database;
DROP PROCEDURE IF EXISTS update_reply $$
CREATE PROCEDURE update_reply(
IN param_reply_id BIGINT,
IN param_user_no BIGINT,
IN param_desc VARCHAR(50)
)
BEGIN
    update tb_subj_reply set
    `Desc` = param_desc,
    LAST_CHG_USR = param_user_no
    WHERE REPLY_ID = param_reply_id;

END $$

DELIMITER ;

