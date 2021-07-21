USE ITCREW;

SET collation_connection = @@collation_database;
DROP TABLE IF EXISTS `tb_user_info`;
CREATE TABLE `tb_user_info` (
	`USER_NO` BIGINT NOT NULL AUTO_INCREMENT,
	`USER_ID` VARCHAR(50) NULL,
	`TYPE` VARCHAR(50) NULL,
	`PW` VARCHAR(50) NULL,
	`AUTO_LOG_CHECK` VARCHAR(50) NULL,
	`LAST_CHG_USER_NO` BIGINT NULL,
	`CHG_DATE` DATETIME NULL,
	`ACTIVE_FLAG` VARCHAR(50) NULL,
	PRIMARY KEY (`USER_NO`)
)
COLLATE='utf8mb4_general_ci'


