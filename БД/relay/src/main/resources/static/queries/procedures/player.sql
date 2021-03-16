USE testdb;

DELIMITER //
CREATE PROCEDURE get_player_list()
    BEGIN
        SELECT * FROM player_views;
    END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE find_player(IN arg_id INT)
    BEGIN
        SELECT * FROM player_views WHERE player_id = arg_id;
    END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE add_player(IN arg_name VARCHAR(50), IN arg_team_id INT)
    BEGIN
        INSERT INTO players (player_name, team_id) VALUES (arg_name, arg_team_id);
    END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE rename_player(IN arg_id INT, IN arg_name VARCHAR(50))
    BEGIN
        UPDATE players SET player_name = arg_name WHERE player_id = arg_id;
    END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE change_player_team(IN arg_player_id INT, IN arg_team_id INT)
    BEGIN
        UPDATE players SET team_id = arg_team_id WHERE player_id = arg_player_id;
    END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE player_results(IN arg_id INT)
    BEGIN
        SELECT * FROM player_result_views WHERE player_id = arg_id;
    END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE remove_player(IN arg_id INT)
    BEGIN
        DELETE FROM players WHERE player_id = arg_id;
    END //
DELIMITER ;

DROP PROCEDURE IF EXISTS get_player_list;
DROP PROCEDURE IF EXISTS find_player;
DROP PROCEDURE IF EXISTS add_player;
DROP PROCEDURE IF EXISTS rename_player;
DROP PROCEDURE IF EXISTS player_results;
DROP PROCEDURE IF EXISTS change_player_team;
DROP PROCEDURE IF EXISTS remove_player;