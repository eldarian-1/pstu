USE testdb;

DELIMITER //
CREATE PROCEDURE get_player_list()
    BEGIN
        SELECT * FROM player_views;
    END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE add_player(IN arg_name VARCHAR(50))
    BEGIN
        INSERT INTO players (player_name) VALUES (arg_name);
    END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE get_team_list()
    BEGIN
        SELECT * FROM teams;
    END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE add_team(IN arg_name VARCHAR(50), IN arg_trainer VARCHAR(50))
    BEGIN
        INSERT INTO teams (team_name, trainers) VALUES (arg_name, arg_trainer);
    END //
DELIMITER ;

DROP PROCEDURE IF EXISTS get_player_list;
DROP PROCEDURE IF EXISTS add_player;
DROP PROCEDURE IF EXISTS get_team_list;
DROP PROCEDURE IF EXISTS add_team;