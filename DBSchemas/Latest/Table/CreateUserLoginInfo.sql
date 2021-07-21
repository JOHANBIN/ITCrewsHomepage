USE ITCREW;

SET collation_connection = @@collation_database;
DROP TABLE IF EXISTS `tb_user_login_info`;
CREATE TABLE `tb_user_login_info` (
	`USER_NO` BIGINT NOT NULL,
	`EMAIL` VARCHAR(50) NOT NULL ,
	`NAME` VARCHAR(50) NOT NULL,
	`IMG_URL` VARCHAR(50) NULL,
	`LAST_CHG_USER` BIGINT NULL,
	`CHG_DATE` DATETIME NULL,
	`ACTIVE_FLAG` VARCHAR(50) NULL DEFAULT 'T',
	PRIMARY KEY (`USER_NO`),
	FOREIGN KEY (`USER_NO`) REFERENCES `itcrew`.`tb_user_info` (`USER_NO`) ON UPDATE CASCADE ON DELETE CASCADE
)
COLLATE='utf8mb4_general_ci'

