USE ITCREW;

DELIMITER $$
SET collation_connection = @@collation_database;
DROP PROCEDURE IF EXISTS load_subject_info $$
CREATE PROCEDURE load_subject_info(
IN param_subject_id BIGINT
)
BEGIN
    SELECT 
        S.subj_id as ID,
        S.TYPE,
        S.`DESC`,
        S.TITLE,
        U.USER_ID as UserId,
        S.CHG_DATE as ChangeDateTime,
        L.IMG_URL as UserImg
    FROM tb_subj_info AS S
    JOIN tb_user_info AS U
    ON S.CHG_USER_NO = U.USER_NO
    LEFT OUTER JOIN tb_user_login_info AS L
    ON U.USER_NO = L.USER_NO
    WHERE S.subj_id = param_subject_id AND S.ACTIVE_FLAG = 'T'; 
END $$

DELIMITER ;

