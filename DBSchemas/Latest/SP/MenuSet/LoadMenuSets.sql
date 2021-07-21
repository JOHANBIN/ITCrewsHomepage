USE ITCREW;

DELIMITER $$
SET collation_connection = @@collation_database;
DROP PROCEDURE IF EXISTS load_menu_sets $$
CREATE PROCEDURE load_menu_sets(
IN param_type VARCHAR(50)
)
BEGIN
   SELECT
        M.SEQ_NO as MenuId,
        M.Parent_Id as ParentId,
        M.DEPTH1 as Title,
        M.DEPTH1 as SubTitle,
        M.Parent_Id as ParentId,
        M.Url,
        M.Chg_USR_NO AS UserNo,
        U.USER_ID AS UserId
    FROM tb_menu_set AS M
    JOIN tb_user_info AS U
    ON U.USER_NO = M.CHG_USR_NO AND M.`Type` = U.`TYPE`
    WHERE M.`TYPE` = param_type AND ACTIVE_FLAG = 'T';
END $$

DELIMITER ;

