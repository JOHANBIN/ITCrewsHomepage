USE ITCREW;

DELIMITER $$
SET collation_connection = @@collation_database;
DROP PROCEDURE IF EXISTS upsert_subect_ft_fav_count $$
CREATE PROCEDURE upsert_subect_ft_fav_count(
IN param_subject_id BIGINT,
IN param_update_value INT
)
BEGIN
    INSERT INTO tb_subj_ft
    (
        subj_id,
        READ_CNT,
        FAV_CNT
    )
    VALUES
    (
        param_subject_id, 
        0,
        0
    )
    ON DUPLICATE KEY UPDATE FAV_CNT = param_update_value;
END $$

DELIMITER ;

