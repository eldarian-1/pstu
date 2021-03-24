USE testdb;

DELIMITER //
CREATE PROCEDURE add_result(IN arg_result_id INT, IN arg_subject_id INT,
    IN arg_player_id INT, IN arg_result_value DOUBLE)
    BEGIN
        INSERT INTO results (result_list_id, subject_id, player_id, result_value, result_date)
        VALUES (arg_result_id, arg_subject_id, arg_player_id, arg_result_value, CURRENT_DATE);
    END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE find_result(IN arg_result_id INT, IN arg_player_id INT, IN arg_subject_id INT)
    BEGIN
        SELECT * FROM result_views
        WHERE result_list_id = arg_result_id AND player_id = arg_player_id AND subject_id = arg_subject_id;
    END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE find_results_of_list(IN arg_result_id INT)
    BEGIN
        SELECT * FROM result_views
        WHERE result_list_id = arg_result_id ;
    END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE update_result(IN arg_result_id INT, IN prev_player_id INT, IN next_player_id INT,
    IN prev_subject_id INT, IN next_subject_id INT, IN arg_result_value DOUBLE)
    BEGIN
        UPDATE results SET player_id = next_player_id, subject_id = next_subject_id, result_value = arg_result_value
        WHERE result_list_id = arg_result_id AND player_id = prev_player_id AND subject_id = prev_subject_id;
    END //
DELIMITER ;

DROP PROCEDURE IF EXISTS add_result;
DROP PROCEDURE IF EXISTS find_result;
DROP PROCEDURE IF EXISTS find_results_of_list;
DROP PROCEDURE IF EXISTS update_result;