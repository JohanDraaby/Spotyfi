USE `spotyfi`;

#############################SONGS########################################################################################

# Dahler Mendi
INSERT INTO song(`id`, `name`, `path`, `track_duration_seconds`) VALUES (1, 'Tunak Tun', 'C:\\music_db\\1.mp3', 303);
# Eminem
INSERT INTO song(`id`, `name`, `path`, `track_duration_seconds`) VALUES (2, 'Without Me', 'C:\\music_db\\2.mp3', 290);
# Evanescense
INSERT INTO song(`id`, `name`, `path`, `track_duration_seconds`) VALUES (3, 'Bring Me To Life', 'C:\\music_db\\3.mp3', 235);
# Ace hood, Future, Rick Ross
INSERT INTO song(`id`, `name`, `path`, `track_duration_seconds`) VALUES (4, 'Bugatti', 'C:\\music_db\\4.mp3', 269);
# Kanye West
INSERT INTO song(`id`, `name`, `path`, `track_duration_seconds`) VALUES (5, 'POWER', 'C:\\music_db\\5.mp3', 292);
# Post Malone, Swae Lee
INSERT INTO song(`id`, `name`, `path`, `track_duration_seconds`) VALUES (6, 'Sunflower - Spider-Man: Into the Spider-Verse', 'C:\\music_db\\6.mp3', 158);

##########################ARTISTS##########################################################################################

INSERT INTO artist(`id`, artist.real_name, artist.artist_name) VALUES (1, 'Dahler Mendi', 'Dahler Mendi');
INSERT INTO artist(`id`, artist.real_name, artist.artist_name) VALUES (2, 'Marshall Bruce Mathers III', 'Eminem');
INSERT INTO artist(`id`, artist.real_name, artist.artist_name) VALUES (3, 'Amy Lee', 'Evanescense');
INSERT INTO artist(`id`, artist.real_name, artist.artist_name) VALUES (4, 'Antoine McColister', 'Ace Hood');
INSERT INTO artist(`id`, artist.real_name, artist.artist_name) VALUES (5, 'Nayvadius DeMun Wilburn', 'Future');
INSERT INTO artist(`id`, artist.real_name, artist.artist_name) VALUES (6, 'William Leonard Roberts II', 'Rick Ross');
INSERT INTO artist(`id`, artist.real_name, artist.artist_name) VALUES (7, 'Kanye West', 'Kanye West');
INSERT INTO artist(`id`, artist.real_name, artist.artist_name) VALUES (8, 'Austin Richard Post', 'Post Malone');
INSERT INTO artist(`id`, artist.real_name, artist.artist_name) VALUES (9, 'Khalif Malik Ibn Shaman Brown', 'Swae Lee');

##########################ALBUMS###########################################################################################

INSERT INTO `album` (`id`, `name`, `description`, `image_path`) VALUES
	(1, 'Tunak Tunak Tun', 'N/A', '/Images/Albums/tunaktuncover.jfif'),
	(2, 'The Eminem Show', 'N/A', '/Images/Albums/the-eminem-show-cover.jpg'),
	(3, 'Fallen', 'N/A', '/Images/Albums/fallen-evanescence-cover.jpg'),
	(4, 'Trials and Tribulations', 'N/A', '/Images/Albums/trials-and-tribulations-cover.jpg'),
	(5, 'My Beautiful Dark Twisted Fantasy', 'N/A', '/Images/Albums/my-beautiful-dark-twisted-fantasy-cover.jpg'),
	(6, 'Spider-Man: Into the Spider-Verse', 'N/A', '/Images/Albums/spider-man-into-the-spider-verse-cover.jpg');

##########################album_song########################################################################################

INSERT INTO album_song(album_song.album_id, album_song.song_id) VALUES (1, 1);
INSERT INTO album_song(album_song.album_id, album_song.song_id) VALUES (2, 2);
INSERT INTO album_song(album_song.album_id, album_song.song_id) VALUES (3, 3);
INSERT INTO album_song(album_song.album_id, album_song.song_id) VALUES (4, 4);
INSERT INTO album_song(album_song.album_id, album_song.song_id) VALUES (5, 5);
INSERT INTO album_song(album_song.album_id, album_song.song_id) VALUES (6, 6);

###########################album_artist######################################################################################

INSERT INTO album_artist(album_artist.album_id, album_artist.artist_id) VALUES (1,1);
INSERT INTO album_artist(album_artist.album_id, album_artist.artist_id) VALUES (2,2);
INSERT INTO album_artist(album_artist.album_id, album_artist.artist_id) VALUES (3,3);
INSERT INTO album_artist(album_artist.album_id, album_artist.artist_id) VALUES (4,4);
INSERT INTO album_artist(album_artist.album_id, album_artist.artist_id) VALUES (4,5);
INSERT INTO album_artist(album_artist.album_id, album_artist.artist_id) VALUES (4,6);
INSERT INTO album_artist(album_artist.album_id, album_artist.artist_id) VALUES (5,7);
INSERT INTO album_artist(album_artist.album_id, album_artist.artist_id) VALUES (6,8);
INSERT INTO album_artist(album_artist.album_id, album_artist.artist_id) VALUES (6,9);

############################song_artist#######################################################################################

INSERT INTO song_artist(song_artist.song_id, song_artist.artist_id) VALUES (1, 1);
INSERT INTO song_artist(song_artist.song_id, song_artist.artist_id) VALUES (2, 2);
INSERT INTO song_artist(song_artist.song_id, song_artist.artist_id) VALUES (3, 3);
INSERT INTO song_artist(song_artist.song_id, song_artist.artist_id) VALUES (4, 4);
INSERT INTO song_artist(song_artist.song_id, song_artist.artist_id) VALUES (4, 5);
INSERT INTO song_artist(song_artist.song_id, song_artist.artist_id) VALUES (4, 6);
INSERT INTO song_artist(song_artist.song_id, song_artist.artist_id) VALUES (5, 7);
INSERT INTO song_artist(song_artist.song_id, song_artist.artist_id) VALUES (6, 8);
INSERT INTO song_artist(song_artist.song_id, song_artist.artist_id) VALUES (6, 9);