USE ITCREW;

SET collation_connection = @@collation_database;
DROP TABLE IF EXISTS `tb_subj_ft`;
CREATE TABLE `tb_subj_ft` (
	`SUBJ_ID` BIGINT,
	`READ_CNT` INT default 0,
	`FAV_CNT` INT default 0,
	PRIMARY KEY (`SUBJ_ID`),
	FOREIGN KEY (`SUBJ_ID`) REFERENCES `itcrew`.`tb_subj_info` (`SUBJ_ID`) ON UPDATE CASCADE ON DELETE CASCADE,
	INDEX `TB_SUBJ_FT_FK` (`SUBJ_ID`)
)
COLLATE='utf8mb4_general_ci'