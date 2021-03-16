USE testdb;

DELIMITER //
CREATE PROCEDURE start_result_list(IN arg_team_id INT)
    BEGIN
        INSERT INTO result_lists (team_id, is_open, result_list_date) VALUES (arg_team_id, TRUE, CURRENT_DATE);
    END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE close_result_list(IN arg_team_id INT)
    BEGIN
        UPDATE result_lists SET is_open = FALSE WHERE team_id = arg_team_id AND is_open = TRUE;
    END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE get_open_result_list(IN arg_team_id INT)
    BEGIN
        SELECT * FROM result_lists WHERE team_id = arg_team_id AND is_open = TRUE;
    END //
DELIMITER ;

DROP PROCEDURE IF EXISTS start_result_list;
DROP PROCEDURE IF EXISTS close_result_list;
DROP PROCEDURE IF EXISTS get_open_result_list;