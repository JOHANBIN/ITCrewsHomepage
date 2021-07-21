USE ITCREW;

DELIMITER $$
SET collation_connection = @@collation_database;
DROP PROCEDURE IF EXISTS load_replies $$
CREATE PROCEDURE load_replies(
IN param_subject_id BIGINT
)
BEGIN
    SELECT 
        R.SUBJ_ID as SubjectId,
        R.REPLY_ID as ReplyId,
        R.User_No as AuthorNo,
        U.USER_ID as AuthorId,
        R.`DESC`,
        R.PARENT_ID as ParentId,
        R.CHG_DATE as ChangeDate
    FROM tb_subj_reply AS  R
    JOIN tb_subj_info AS I 
    ON R.SUBJ_ID = I.SUBJ_ID
    JOIN tb_user_info AS U
    ON U.USER_NO = R.User_No
    WHERE R.SUBJ_ID = param_subject_id AND R.ACTIVE_FLAG = 'T';
END $$

DELIMITER ;

