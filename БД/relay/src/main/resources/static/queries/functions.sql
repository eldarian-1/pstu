USE testdb;

DELIMITER //
CREATE FUNCTION get_list_name(sought_result_list_id INT)
    RETURNS CHAR(250)
	DETERMINISTIC
    BEGIN
        DECLARE relay_number INT;
        DECLARE team_name VARCHAR(50);
        DECLARE relay_name VARCHAR(50);
        DECLARE result_date DATE;
        DECLARE result_text VARCHAR(250);

        SET relay_number = (SELECT COUNT(*) AS num FROM relay_races WHERE result_list_id = sought_result_list_id);

        SET team_name = (SELECT teams.team_name FROM result_lists JOIN teams
            ON teams.team_id = result_lists.team_id WHERE result_list_id = sought_result_list_id);

        SET relay_name = (SELECT relay_races.relay_name FROM team_participations JOIN relay_races
            ON team_participations.relay_id = relay_races.relay_id
            WHERE result_list_id = sought_result_list_id);

        SET result_date = (SELECT result_date FROM results WHERE result_list_id = sought_result_list_id);

        IF relay_number = 0 THEN
            SET result_text = CONCAT("Workout \"", team_name, "\" ", result_date);
        ELSE
            SET result_text = CONCAT("Relay race \"", relay_name, "\" ", result_date);
        END IF;
        RETURN result_text;
    END //
DELIMITER ;

DROP FUNCTION IF EXISTS get_list_name;