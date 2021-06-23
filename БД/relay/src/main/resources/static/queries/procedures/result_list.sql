USE relaydb;

DELIMITER //
CREATE PROCEDURE start_result_list(IN arg_team_id INT)
    BEGIN
        INSERT INTO result_lists (team_id, is_open, result_list_date) VALUES (arg_team_id, TRUE, CURRENT_DATE);
        SELECT LAST_INSERT_ID() AS 'last_insert_id';
    END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE close_result_list(IN arg_result_list_id INT)
    BEGIN
        UPDATE result_lists SET is_open = FALSE WHERE result_list_id = arg_result_list_id AND is_open = TRUE;
    END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE get_result_list(IN arg_result_list_id INT)
    BEGIN
        SELECT * FROM result_list_views WHERE result_list_id = arg_result_list_id;
    END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE get_event_results(IN arg_result_list_id INT)
    BEGIN
        SELECT * FROM result_views WHERE result_list_id = arg_result_list_id;
    END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE get_team_result_lists(IN arg_team_id INT)
    BEGIN
        SELECT * FROM result_list_views WHERE team_id = arg_team_id;
    END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE get_open_result_list(IN arg_team_id INT)
    BEGIN
        SELECT * FROM result_list_views WHERE team_id = arg_team_id AND is_open = TRUE;
    END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE team_is_busy(IN arg_team_id INT)
    BEGIN
        SELECT (COUNT(*) > 0) AS is_true FROM result_list_views WHERE team_id = arg_team_id AND is_open = TRUE;
    END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE get_possible_player_list(IN arg_result_list_id INT)
    BEGIN
        SELECT * FROM result_list_player_views WHERE result_list_id = arg_result_list_id;
    END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE get_possible_subject_list(IN arg_result_list_id INT)
    BEGIN
        IF (SELECT COUNT(*) AS cnt FROM team_participations WHERE result_list_id = arg_result_list_id) = 1
        THEN
            SELECT * FROM relay_subject_views
            JOIN team_participations ON team_participations.relay_id = relay_subject_views.relay_id
            WHERE team_participations.result_list_id = arg_result_list_id;
        ELSE
            SELECT result_lists.result_list_id, result_lists.team_id, team_subjects.subject_id, subjects.subject_name,
                subjects.subject_unit, subjects.subject_multiplier FROM result_lists
            JOIN team_subjects ON team_subjects.team_id = result_lists.team_id
            JOIN subjects ON subjects.subject_id = team_subjects.subject_id
            WHERE result_lists.result_list_id = arg_result_list_id;
        END if;
    END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE remove_result_list(IN arg_result_list_id INT)
    BEGIN
        DELETE FROM result_lists WHERE result_list_id = arg_result_list_id;
    END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE find_team_participation(IN arg_team_id INT)
    BEGIN
        SELECT (COUNT(team_participations.team_id) = 1) AS is_true
        FROM team_participations
        JOIN result_lists ON result_lists.result_list_id = team_participations.result_list_id
        WHERE team_participations.team_id = 1 AND result_lists.is_open = TRUE;
    END //
DELIMITER ;

DROP PROCEDURE IF EXISTS start_result_list;
DROP PROCEDURE IF EXISTS close_result_list;
DROP PROCEDURE IF EXISTS get_result_list;
DROP PROCEDURE IF EXISTS get_event_results;
DROP PROCEDURE IF EXISTS get_team_result_lists;
DROP PROCEDURE IF EXISTS get_open_result_list;
DROP PROCEDURE IF EXISTS team_is_busy;
DROP PROCEDURE IF EXISTS get_possible_player_list;
DROP PROCEDURE IF EXISTS get_possible_subject_list;
DROP PROCEDURE IF EXISTS remove_result_list;
DROP PROCEDURE IF EXISTS find_team_participation;