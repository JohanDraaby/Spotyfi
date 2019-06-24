# Create Database SQL Script

CREATE DATABASE IF NOT EXISTS `spotyfi`;

USE `spotify`;

DROP TABLE IF EXISTS album_artist;
DROP TABLE IF EXISTS album_song;
DROP TABLE IF EXISTS song_artist;
DROP TABLE IF EXISTS artist;
DROP TABLE IF EXISTS album;
DROP TABLE IF EXISTS song;

CREATE TABLE song
(
	id INT AUTO_INCREMENT,
	`name` VARCHAR(64),
	`path` VARCHAR(256),
	`track_duration_seconds` INT,
	PRIMARY KEY (id)
);

CREATE TABLE album
(
	`id` INT AUTO_INCREMENT,
	`name` VARCHAR(64),
	`description` VARCHAR(256),
	PRIMARY KEY (`id`)
);

CREATE TABLE artist
(
	`id` INT AUTO_INCREMENT,
	`real_name` VARCHAR(256),
	`artist_name` VARCHAR(256),
	PRIMARY KEY (`id`)
);

CREATE TABLE song_artist
(
	`song_id` INT NOT NULL,
	`artist_id` INT NOT NULL,
	PRIMARY KEY(`song_id`, `artist_id`),
	FOREIGN KEY (song_id) REFERENCES song(id),
	FOREIGN KEY (artist_id) REFERENCES artist(id)
);

CREATE TABLE album_song
(
	`album_id` INT NOT NULL,
	`song_id` INT NOT NULL,
	PRIMARY KEY(`album_id`, `song_id`),
	FOREIGN KEY (album_id) REFERENCES album(id),
	FOREIGN KEY (song_id) REFERENCES song(id)
);

CREATE TABLE album_artist
(
	`album_id` INT NOT NULL,
	`artist_id` INT NOT NULL,
	PRIMARY KEY(`album_id`, `artist_id`),
	FOREIGN KEY (album_id) REFERENCES album(id),
	FOREIGN KEY (artist_id) REFERENCES artist(id)
);

#########################################################################################################################################