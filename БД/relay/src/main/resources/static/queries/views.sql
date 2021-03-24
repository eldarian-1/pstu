USE testdb;

CREATE VIEW player_views
(player_id, player_name, team_id, team_name)
AS SELECT players.player_id, players.player_name, players.team_id, teams.team_name
FROM players JOIN teams ON players.team_id = teams.team_id
UNION SELECT players.player_id, players.player_name, players.team_id, NULL AS team_name
FROM players WHERE players.team_id IS NULL;

CREATE VIEW result_views
(result_list_id, result_list_name, player_id, player_name, subject_id, result_value, subject_name,
    subject_unit, subject_multiplier, result_date)
AS SELECT results.result_list_id,
    CONCAT("Тренировка ", result_lists.result_list_date) AS result_list_name,
    results.player_id, players.player_name, results.subject_id, results.result_value,
    subjects.subject_name, subjects.subject_unit,
    subjects.subject_multiplier, results.result_date FROM results
JOIN players ON players.player_id = results.player_id
JOIN subjects ON subjects.subject_id = results.subject_id
JOIN result_lists ON result_lists.result_list_id = results.result_list_id
WHERE results.result_list_id NOT IN
    (SELECT team_participations.result_list_id FROM team_participations)
UNION
SELECT results.result_list_id,
    CONCAT("Эстафета ", relay_races.relay_name) AS result_list_name,
    results.player_id, players.player_name, results.subject_id, results.result_value,
    subjects.subject_name, subjects.subject_unit,
    subjects.subject_multiplier, results.result_date FROM results
JOIN players ON players.player_id = results.player_id
JOIN subjects ON subjects.subject_id = results.subject_id
JOIN result_lists ON result_lists.result_list_id = results.result_list_id
JOIN team_participations ON team_participations.result_list_id = results.result_list_id
JOIN relay_races ON relay_races.relay_id = team_participations.relay_id
WHERE results.result_list_id IN
    (SELECT team_participations.result_list_id FROM team_participations);

CREATE VIEW result_list_views
(result_list_id, result_list_name, team_id, team_name, is_open, result_list_date)
AS SELECT result_lists.result_list_id,
    CONCAT("Тренировка ", result_lists.result_list_date) AS relay_name,
    result_lists.team_id, teams.team_name, result_lists.is_open,
    result_lists.result_list_date FROM result_lists
JOIN teams ON teams.team_id = result_lists.team_id
WHERE result_lists.result_list_id NOT IN
    (SELECT team_participations.result_list_id FROM team_participations)
UNION
SELECT team_participations.result_list_id,
    CONCAT("Эстафета ", relay_races.relay_name) AS relay_name,
    team_participations.team_id, teams.team_name,
    result_lists.is_open,
    result_lists.result_list_date
FROM team_participations
JOIN result_lists ON result_lists.result_list_id = team_participations.result_list_id
JOIN teams ON teams.team_id = result_lists.team_id
JOIN relay_races ON team_participations.relay_id = relay_races.relay_id;

CREATE VIEW team_views
(team_id, player_id, player_name)
AS SELECT teams.team_id, players.player_id, players.player_name FROM teams
JOIN players ON teams.team_id = players.team_id;

CREATE VIEW team_subject_views
(team_id,subject_id, subject_name, subject_unit, subject_multiplier)
AS SELECT team_subjects.team_id, team_subjects.subject_id, subjects.subject_name, subjects.subject_unit,
    subjects.subject_multiplier FROM team_subjects
JOIN subjects ON team_subjects.subject_id = subjects.subject_id;

CREATE VIEW relay_subject_views
(relay_id, subject_id, subject_name, subject_unit, subject_multiplier, subject_position)
AS SELECT relay_subjects.relay_id, relay_subjects.subject_id,
    subjects.subject_name, subjects.subject_unit, subjects.subject_multiplier, relay_subjects.subject_position
FROM relay_subjects
JOIN subjects ON relay_subjects.subject_id = subjects.subject_id
ORDER BY relay_subjects.subject_position;

CREATE VIEW relay_team_views
(relay_id, relay_name, team_id, team_name, trainers, result_list_id, result_list_score)
AS SELECT team_participations.relay_id, relay_races.relay_name,
    team_participations.team_id, teams.team_name, teams.trainers, team_participations.result_list_id,
    SUM(results.result_value*subjects.subject_multiplier) as result_list_score
FROM team_participations
JOIN relay_races ON relay_races.relay_id = team_participations.relay_id
JOIN teams ON teams.team_id = team_participations.team_id
JOIN results ON results.result_list_id = team_participations.result_list_id
JOIN subjects ON subjects.subject_id = results.subject_id
GROUP BY team_participations.relay_id, relay_races.relay_name, team_participations.team_id, teams.team_name,
    teams.trainers, team_participations.result_list_id
UNION
SELECT team_participations.relay_id, relay_races.relay_name,
    team_participations.team_id, teams.team_name, teams.trainers, team_participations.result_list_id,
    0 as result_list_score
FROM team_participations
JOIN relay_races ON relay_races.relay_id = team_participations.relay_id
JOIN teams ON teams.team_id = team_participations.team_id
WHERE team_participations.result_list_id NOT IN (SELECT result_list_id FROM results);

CREATE VIEW result_list_player_views
(result_list_id, team_id, team_name, player_id, player_name)
AS SELECT result_lists.result_list_id, result_lists.team_id, teams.team_name, players.player_id, players.player_name
FROM result_lists
JOIN teams ON teams.team_id = result_lists.team_id
JOIN players ON players.team_id = result_lists.team_id;

DROP VIEW IF EXISTS player_views;
DROP VIEW IF EXISTS result_views;
DROP VIEW IF EXISTS result_list_views;
DROP VIEW IF EXISTS team_views;
DROP VIEW IF EXISTS team_subject_views;
DROP VIEW IF EXISTS relay_subject_views;
DROP VIEW IF EXISTS relay_team_views;
DROP VIEW IF EXISTS result_list_player_views;