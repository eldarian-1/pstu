USE testdb;

CREATE TABLE teams (
    team_id INT PRIMARY KEY AUTO_INCREMENT,
    team_name VARCHAR(50) NOT NULL,
    trainers VARCHAR(50) NOT NULL
);

CREATE TABLE players (
    player_id INT PRIMARY KEY AUTO_INCREMENT,
    team_id INT NOT NULL
    player_name VARCHAR(50) NOT NULL,
    is_chosen BOOL NOT NULL,
    FOREIGN KEY (team_id) REFERENCES teams (team_id) ON DELETE CASCADE
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
    result_list_date DATE NOT NULL,
    FOREIGN KEY (team_id) REFERENCES teams (team_id) ON DELETE CASCADE
);

CREATE TABLE relay_races (
    relay_id INT PRIMARY KEY AUTO_INCREMENT,
    relay_name VARCHAR(50) NOT NULL
);

CREATE TABLE team_participations (
    team_id INT NOT NULL,
    relay_id INT NOT NULL,
    FOREIGN KEY (team_id) REFERENCES teams (team_id) ON DELETE CASCADE,
    FOREIGN KEY (relay_id) REFERENCES relays (relay_id) ON DELETE CASCADE
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
    FOREIGN KEY (relay_id) REFERENCES relays (relay_id) ON DELETE CASCADE,
    FOREIGN KEY (subject_id) REFERENCES subjects (subject_id) ON DELETE CASCADE
);

CREATE TABLE team_results (
    result_list_id INT NOT NULL,
    team_id INT NOT NULL,
    relay_id INT NOT NULL,
    team_points DOUBLE NOT NULL,
    FOREIGN KEY (result_list_id) REFERENCES result_lists (result_list_id) ON DELETE CASCADE,
    FOREIGN KEY (team_id) REFERENCES teams (team_id) ON DELETE CASCADE,
    FOREIGN KEY (relay_id) REFERENCES relays (relay_id) ON DELETE CASCADE
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

CREATE VIEW team_views
(team_id, player_id, player_name, is_chosen)
AS SELECT team_id, player_id, player_name, is_chosen FROM teams
JOIN players ON team_id = players.team_id;

CREATE VIEW national_team_views
(team_id, player_id, player_name)
AS SELECT team_id, player_id, player_name FROM team_views
WHERE is_chosen = TRUE;

CREATE VIEW team_subject_views
(team_id, subject_id, subject_name)
AS SELECT team_id, subject_id, subject_name FROM team_subjects
JOIN subjects ON subject_id = subjects.subject_id;

CREATE VIEW relay_subject_views
(relay_id, subject_id, subject_name)
AS SELECT relay_id, subject_id, subject_name FROM relay_subjects
JOIN subjects ON subject_id = subjects.subject_id;

CREATE VIEW participating_team_views
(relay_id, team_id, team_name, result_list_id)
AS SELECT relay_id, team_id, team_name, result_list_id, team_points FROM team_participations
JOIN teams ON team_id = teams.team_id
JOIN team_results ON team_id = team_results.team_id;

CREATE VIEW player_views
(player_id, player_name, team_id, team_name, trainers)
AS SELECT player_id, player_name, team_id, team_name, trainers FROM players
JOIN teams ON team_id = teams.team_id;

CREATE VIEW player_result_views
(player_id, subject_id, result_list_id, player_name, subject_name, result_value, subject_unit, result_score, result_date)
AS SELECT player_id, subject_id, result_list_id, subject_name, result_value, subject_unit,
    result_value*subject_multiplier AS result_score, result_date FROM results
JOIN players ON player_id = players.player_id
JOIN subjects ON subject_id = subjects.subject_id;

