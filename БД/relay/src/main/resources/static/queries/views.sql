USE testdb;

CREATE VIEW player_views
(player_id, player_name, team_id, team_name)
AS SELECT players.player_id, players.player_name, players.team_id, teams.team_name FROM players
JOIN teams ON teams.team_id = players.team_id;

CREATE VIEW player_result_views
(player_id, result_list_id, subject_id, subject_name, result_value, subject_unit)
AS SELECT results.player_id, results.result_list_id, results.subject_id, subjects.subject_name, results.result_value,
    subjects.subject_unit FROM results
JOIN subjects ON subjects.subject_id = results.subject_id;

CREATE VIEW team_views
(team_id, player_id, player_name)
AS SELECT teams.team_id, players.player_id, players.player_name FROM teams
JOIN players ON teams.team_id = players.team_id;

CREATE VIEW team_result_views
(team_id, result_list_id, list_name)
AS SELECT result_lists.team_id, result_lists.result_list_id, get_list_name(result_lists.result_list_id)
FROM result_lists;

CREATE VIEW team_subject_views
(team_id, subject_id, subject_name)
AS SELECT team_subjects.team_id, team_subjects.subject_id, subjects.subject_name FROM team_subjects
JOIN subjects ON team_subjects.subject_id = subjects.subject_id;

CREATE VIEW relay_subject_views
(relay_id, subject_id, subject_name, subject_position)
AS SELECT relay_subjects.relay_id, relay_subjects.subject_id, subjects.subject_name, relay_subjects.subject_position
FROM relay_subjects
JOIN subjects ON relay_subjects.subject_id = subjects.subject_id
ORDER BY relay_subjects.subject_position;

DROP VIEW IF EXISTS player_views;
DROP VIEW IF EXISTS player_result_views;
DROP VIEW IF EXISTS team_views;
DROP VIEW IF EXISTS team_result_views;
DROP VIEW IF EXISTS team_subject_views;
DROP VIEW IF EXISTS relay_subject_views;