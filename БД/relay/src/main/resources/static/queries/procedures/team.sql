USE relaydb;

DELIMITER //
CREATE PROCEDURE get_team_list()
    BEGIN
        SELECT * FROM teams;
    END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE find_team(IN arg_team_id INT)
    BEGIN
        SELECT * FROM teams WHERE team_id = arg_team_id;
    END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE subject_is_team(IN arg_team_id INT, IN arg_subject_id INT)
    BEGIN
        SELECT (COUNT(*) = 1) AS is_true FROM team_subjects
        WHERE team_id = arg_team_id AND subject_id = arg_subject_id;
    END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE add_team(IN arg_name VARCHAR(50), IN arg_trainer VARCHAR(50))
    BEGIN
        INSERT INTO teams (team_name, trainers) VALUES (arg_name, arg_trainer);
        SELECT LAST_INSERT_ID() AS 'last_insert_id';
    END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE add_team_subject(IN arg_team_id INT, IN arg_subject_id INT)
    BEGIN
        INSERT INTO team_subjects (team_id, subject_id) VALUES (arg_team_id, arg_subject_id);
    END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE remove_team_subject(IN arg_team_id INT, IN arg_subject_id INT)
    BEGIN
        DELETE FROM team_subjects WHERE team_id = arg_team_id AND subject_id = arg_subject_id;
    END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE get_team_player_list(IN arg_team_id INT)
    BEGIN
        SELECT * FROM players WHERE team_id = arg_team_id;
    END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE get_team_subject_list(IN arg_team_id INT)
    BEGIN
        SELECT * FROM team_subject_views WHERE team_id = arg_team_id;
    END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE get_not_team_subject_list(IN arg_team_id INT)
    BEGIN
        SELECT * FROM subjects
        WHERE subject_id NOT IN (
            SELECT subject_id
        	FROM team_subject_views
        	WHERE team_id = arg_team_id);
    END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE update_team(IN arg_id INT, IN arg_name VARCHAR(50), IN arg_trainer VARCHAR(50))
    BEGIN
        UPDATE teams
        SET team_name = arg_name, trainers = arg_trainer
        WHERE team_id = arg_id;
    END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE remove_team(IN arg_id INT)
    BEGIN
        DELETE FROM teams WHERE team_id = arg_id;
    END //
DELIMITER ;

DROP PROCEDURE IF EXISTS get_team_list;
DROP PROCEDURE IF EXISTS find_team;
DROP PROCEDURE IF EXISTS subject_is_team;
DROP PROCEDURE IF EXISTS add_team;
DROP PROCEDURE IF EXISTS add_team_subject;
DROP PROCEDURE IF EXISTS remove_team_subject;
DROP PROCEDURE IF EXISTS get_team_player_list;
DROP PROCEDURE IF EXISTS get_team_subject_list;
DROP PROCEDURE IF EXISTS get_not_team_subject_list;
DROP PROCEDURE IF EXISTS update_team;
DROP PROCEDURE IF EXISTS remove_team;