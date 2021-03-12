USE testdb;

DELIMITER //
CREATE PROCEDURE get_workout_list()
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
CREATE PROCEDURE add_team(IN arg_name VARCHAR(50), IN arg_trainer VARCHAR(50))
    BEGIN
        INSERT INTO teams (team_name, trainers) VALUES (arg_name, arg_trainer);
    END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE get_team_player_list(IN arg_team_id INT)
    BEGIN
        SELECT * FROM players WHERE team_id = arg_team_id;
    END //
DELIMITER ;

DROP PROCEDURE IF EXISTS get_team_list;
DROP PROCEDURE IF EXISTS find_team;
DROP PROCEDURE IF EXISTS add_team;
DROP PROCEDURE IF EXISTS get_team_player_list;