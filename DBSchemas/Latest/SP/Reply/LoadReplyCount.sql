USE ITCREW;

DELIMITER $$
SET collation_connection = @@collation_database;
DROP PROCEDURE IF EXISTS load_reply_count $$
CREATE PROCEDURE load_reply_count(
IN param_subject_id BIGINT
)
BEGIN
    SELECT 
        COUNT(R.SUBJ_ID)
    FROM tb_subj_reply AS  R
    JOIN tb_subj_info AS I 
    ON R.SUBJ_ID = I.SUBJ_ID
    WHERE I.SUBJ_ID = param_subject_id AND R.ACTIVE_FLAG = 'T';
END $$

DELIMITER ;

