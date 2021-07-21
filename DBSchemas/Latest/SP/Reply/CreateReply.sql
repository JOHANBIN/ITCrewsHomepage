USE ITCREW;

DELIMITER $$
SET collation_connection = @@collation_database;
DROP PROCEDURE IF EXISTS create_reply $$
CREATE PROCEDURE create_reply(
IN param_subject_id BIGINT,
IN param_user_no BIGINT,
IN param_desc VARCHAR(50),
IN param_parent_id int,
IN param_created_time DATETIME,
OUT param_new_reply_id BIGINT
)
BEGIN
    INSERT INTO tb_subj_reply
    (
        SUBJ_ID,
        USER_NO,
        `DESC`,
        PARENT_ID,
        LAST_CHG_USR,
        CHG_DATE,
        ACTIVE_FLAG
    )
    VALUES
    (
        param_subject_id,
        param_user_no,
        param_desc,
        param_parent_id,
        param_user_no,
        param_created_time,
        'T'
    );
SET param_new_reply_id := LAST_INSERT_ID();

END $$

DELIMITER ;

