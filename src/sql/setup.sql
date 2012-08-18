CREATE TABLE `verification` (
	`username` TEXT(12) NOT NULL,
	`password` TEXT(12) NOT NULL,
	`lastlogged` TIMESTAMP NOT NULL
)
COLLATE='latin1_swedish_ci'
ENGINE=MyISAM;