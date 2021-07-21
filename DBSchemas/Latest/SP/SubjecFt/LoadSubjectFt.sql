USE ITCREW;

DELIMITER $$
SET collation_connection = @@collation_database;
DROP PROCEDURE IF EXISTS load_subject_ft $$
CREATE PROCEDURE load_subject_ft(
IN param_subject_id BIGINT
)
BEGIN
    SELECT 
        F.subj_id as SubjectId,
        F.READ_CNT  as ReadCount,
        F.FAV_CNT as FavoritesCount
    FROM tb_subj_ft AS F
    JOIN tb_subj_info AS I
    ON F.subj_id = I.subj_id
    WHERE F.subj_id = param_subject_id;
END $$

DELIMITER ;

