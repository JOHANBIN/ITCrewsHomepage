USE ITCREW;

DELIMITER $$
SET collation_connection = @@collation_database;
DROP PROCEDURE IF EXISTS load_subject_info_page_by_desc $$
CREATE PROCEDURE load_subject_info_page_by_desc(
IN param_page int,
IN param_type varchar(50),
IN param_row int,
IN param_search_word varchar(100),
OUT param_total BIGINT
)
BEGIN
    SET param_page := (param_page - 1) * param_row;
    SET @rowNum := 0;

    SELECT
        OrderTable.seq,
        OrderTable.SUBJ_ID as id,
        OrderTable.TYPE,
        OrderTable.TITLE,
        OrderTable.`DESC`,
        U.USER_ID as UserID,
        OrderTable.CHG_DATE as ChangeDateTime
    FROM 
    (
        SELECT 
			@rowNum := @rowNum + 1 AS seq,
			Temp.*
        FROM
        (
            SELECT SUBJ_ID, TYPE, TITLE, `DESC`, CHG_USER_NO, CHG_DATE
            FROM tb_subj_info
            WHERE ACTIVE_FLAG = 'T' AND `TYPE` = param_type
            ORDER BY CHG_DATE
        ) AS Temp
        ORDER BY seq DESC
    ) AS OrderTable
    JOIN TB_USER_INFO AS U
    ON OrderTable.CHG_USER_NO = U.USER_NO
    WHERE OrderTable.`DESC` LIKE CONCAT('%', CASE WHEN IFNULL(param_search_word,'') = '' THEN OrderTable.`DESC` ELSE param_search_word END, '%')
    ORDER BY seq DESC
	LIMIT param_page, param_row;

	SELECT COUNT(SUBJ_ID) INTO param_total 
   FROM tb_subj_info 
   WHERE ACTIVE_FLAG = 'T' AND `TYPE` = param_type 
   AND `DESC` LIKE CONCAT('%', CASE WHEN IFNULL(param_search_word,'') = '' THEN `DESC` ELSE param_search_word END, '%');
END $$

DELIMITER ;

