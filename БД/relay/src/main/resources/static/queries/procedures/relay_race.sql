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
CREATE PROCEDURE add_relay_race(IN arg_relay_name VARCHAR(50), IN arg_team_number INT, IN arg_player_number INT)
    BEGIN
        INSERT INTO relay_races (relay_name, team_number, player_number)
        VALUES (arg_relay_name, arg_team_number, arg_player_number);
        SELECT LAST_INSERT_ID() AS 'last_insert_id';
    END //
DELIMITER ;

DROP PROCEDURE IF EXISTS get_relay_race_list;
DROP PROCEDURE IF EXISTS find_relay_race;
DROP PROCEDURE IF EXISTS add_relay_race;