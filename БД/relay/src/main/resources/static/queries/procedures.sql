USE testdb;

DELIMITER //
CREATE PROCEDURE get_player_list()
    BEGIN
        SELECT * FROM player_views;
    END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE add_player(IN arg_name VARCHAR(30))
    BEGIN
        INSERT INTO players (player_name) VALUES (arg_name);
    END //
DELIMITER ;

DROP PROCEDURE IF EXISTS get_player_list;
DROP PROCEDURE IF EXISTS add_player;