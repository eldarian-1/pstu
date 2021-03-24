USE testdb;

CREATE TABLE teams (
    team_id INT PRIMARY KEY AUTO_INCREMENT,
    team_name VARCHAR(50) NOT NULL,
    trainers VARCHAR(50) NOT NULL
);

CREATE TABLE players (
    player_id INT PRIMARY KEY AUTO_INCREMENT,
    team_id INT NULL,
    player_name VARCHAR(50) NOT NULL,
    FOREIGN KEY (team_id) REFERENCES teams (team_id)
);

CREATE TABLE subjects (
    subject_id INT PRIMARY KEY AUTO_INCREMENT,
    subject_name VARCHAR(20) NOT NULL,
    subject_multiplier DOUBLE NOT NULL,
    subject_unit VARCHAR(5) NOT NULL
);

CREATE TABLE result_lists (
    result_list_id INT PRIMARY KEY AUTO_INCREMENT,
    team_id INT NOT NULL,
    is_open BOOLEAN NOT NULL DEFAULT(TRUE),
    result_list_date DATE NOT NULL,
    FOREIGN KEY (team_id) REFERENCES teams (team_id) ON DELETE CASCADE
);

CREATE TABLE relay_races (
    relay_id INT PRIMARY KEY AUTO_INCREMENT,
    relay_name VARCHAR(50) NOT NULL,
    team_number INT NOT NULL,
    player_number INT NOT NULL,
    is_open BOOLEAN NOT NULL DEFAULT(TRUE)
);

CREATE TABLE team_participations (
    team_id INT NOT NULL,
    relay_id INT NOT NULL,
    result_list_id INT NOT NULL,
    FOREIGN KEY (team_id) REFERENCES teams (team_id) ON DELETE CASCADE,
    FOREIGN KEY (relay_id) REFERENCES relay_races (relay_id) ON DELETE CASCADE,
    FOREIGN KEY (result_list_id) REFERENCES result_lists (result_list_id) ON DELETE CASCADE
);

CREATE TABLE team_subjects (
    team_id INT NOT NULL,
    subject_id INT NOT NULL,
    FOREIGN KEY (team_id) REFERENCES teams (team_id) ON DELETE CASCADE,
    FOREIGN KEY (subject_id) REFERENCES subjects (subject_id) ON DELETE CASCADE
);

CREATE TABLE relay_subjects (
    relay_id INT NOT NULL,
    subject_id INT NOT NULL,
    subject_position INT NOT NULL,
    FOREIGN KEY (relay_id) REFERENCES relay_races (relay_id) ON DELETE CASCADE,
    FOREIGN KEY (subject_id) REFERENCES subjects (subject_id) ON DELETE CASCADE
);

CREATE TABLE player_positions (
    relay_id INT NOT NULL,
    player_id INT NOT NULL,
    player_position INT NOT NULL,
    FOREIGN KEY (relay_id) REFERENCES relay_races (relay_id) ON DELETE CASCADE,
    FOREIGN KEY (player_id) REFERENCES players (player_id) ON DELETE CASCADE
);

CREATE TABLE results (
    result_list_id INT NOT NULL,
    player_id INT NOT NULL,
    subject_id INT NOT NULL,
    result_value DOUBLE NOT NULL,
    result_date DATE NOT NULL,
    FOREIGN KEY (result_list_id) REFERENCES result_lists (result_list_id) ON DELETE CASCADE,
    FOREIGN KEY (player_id) REFERENCES players (player_id) ON DELETE CASCADE,
    FOREIGN KEY (subject_id) REFERENCES subjects (subject_id) ON DELETE CASCADE
);

DROP TABLE IF EXISTS results;
DROP TABLE IF EXISTS player_positions;
DROP TABLE IF EXISTS relay_subjects;
DROP TABLE IF EXISTS team_subjects;
DROP TABLE IF EXISTS team_participations;
DROP TABLE IF EXISTS relay_races;
DROP TABLE IF EXISTS result_lists;
DROP TABLE IF EXISTS subjects;
DROP TABLE IF EXISTS players;
DROP TABLE IF EXISTS teams;