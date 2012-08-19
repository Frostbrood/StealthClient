CREATE TABLE `verification` (
	`id` SMALLINT UNSIGNED NOT NULL,
	`username` TEXT(12) NOT NULL,
	`password` TEXT(12) NOT NULL,
	`lastlogged` TIMESTAMP NOT NULL
)
COLLATE='latin1_swedish_ci'
ENGINE=MyISAM;

CREATE TABLE `verification_guid` (
	`id` SMALLINT UNSIGNED NOT NULL,
	`guid` BIGINT UNSIGNED NOT NULL
)
COLLATE='latin1_swedish_ci'
ENGINE=MyISAM;