USE testdb;

DELIMITER //
CREATE PROCEDURE get_relay_race_list()
    BEGIN
        SELECT * FROM relay_races;
    END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE find_relay_race(IN arg_id INT)
    BEGIN
        SELECT * FROM relay_races WHERE relay_id = arg_id;
    END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE subject_is_relay(IN arg_relay_id INT, IN arg_subject_id INT)
    BEGIN
        SELECT (COUNT(*) = TRUE) AS is_true FROM relay_subjects
        WHERE relay_id = arg_relay_id AND subject_id = arg_subject_id;
    END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE relay_results_count(IN arg_result_list_id INT)
    BEGIN
        SELECT relay_races.player_number*COUNT(relay_subjects.subject_id) AS number FROM team_participations
        JOIN relay_races ON relay_races.relay_id = team_participations.relay_id
        JOIN relay_subjects ON relay_subjects.relay_id = team_participations.relay_id
        WHERE team_participations.result_list_id = arg_result_list_id
        GROUP BY relay_races.player_number;
    END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE add_relay_race(IN arg_relay_name VARCHAR(50), IN arg_team_number INT, IN arg_player_number INT)
    BEGIN
        INSERT INTO relay_races (relay_name, team_number, player_number)
        VALUES (arg_relay_name, arg_team_number, arg_player_number);
        SELECT LAST_INSERT_ID() AS 'last_insert_id';
    END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE add_relay_team(IN arg_relay_id INT, IN arg_team_id INT)
    BEGIN
        CALL start_result_list(arg_team_id);
        INSERT INTO team_participations (relay_id, team_id, result_list_id)
        VALUES (arg_relay_id, arg_team_id, LAST_INSERT_ID());
    END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE add_relay_subject(IN arg_relay_id INT, IN arg_subject_id INT)
    BEGIN
        INSERT INTO relay_subjects (relay_id, subject_id, subject_position)
        VALUES (arg_relay_id, arg_subject_id, 1);
    END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE relay_team_list(IN arg_relay_id INT)
    BEGIN
        SELECT * FROM relay_team_views WHERE relay_id = arg_relay_id;
    END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE relay_subject_list(IN arg_relay_id INT)
    BEGIN
        SELECT * FROM relay_subject_views WHERE relay_id = arg_relay_id;
    END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE not_relay_team_list(IN arg_relay_id INT)
    BEGIN
        SELECT * FROM teams WHERE team_id NOT IN
            (SELECT team_id FROM team_participations WHERE relay_id = arg_relay_id);
    END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE not_relay_subject_list(IN arg_relay_id INT)
    BEGIN
        SELECT * FROM subjects WHERE subject_id NOT IN
            (SELECT subject_id FROM relay_subjects WHERE relay_id = arg_relay_id);
    END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE relay_is_finished(IN arg_relay_id INT)
    BEGIN
        SELECT (COUNT(team_participations.team_id) = 0) AS is_true
        FROM team_participations
        JOIN result_lists ON team_participations.result_list_id = result_lists.result_list_id
        WHERE team_participations.relay_id = arg_relay_id AND result_lists.is_open = TRUE;
    END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE close_relay_race(IN arg_relay_id INT)
    BEGIN
        UPDATE relay_races SET is_open = FALSE WHERE relay_id = arg_relay_id;
    END //
DELIMITER ;

DROP PROCEDURE IF EXISTS get_relay_race_list;
DROP PROCEDURE IF EXISTS find_relay_race;
DROP PROCEDURE IF EXISTS relay_results_count;
DROP PROCEDURE IF EXISTS subject_is_relay;
DROP PROCEDURE IF EXISTS add_relay_race;
DROP PROCEDURE IF EXISTS add_relay_team;
DROP PROCEDURE IF EXISTS add_relay_subject;
DROP PROCEDURE IF EXISTS relay_team_list;
DROP PROCEDURE IF EXISTS relay_subject_list;
DROP PROCEDURE IF EXISTS not_relay_team_list;
DROP PROCEDURE IF EXISTS not_relay_subject_list;
DROP PROCEDURE IF EXISTS relay_is_finished;
DROP PROCEDURE IF EXISTS close_relay_race;