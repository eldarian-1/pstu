USE testdb;

DELIMITER //
CREATE PROCEDURE add_result(IN arg_result_id INT, IN arg_subject_id INT,
    IN arg_player_id INT, IN arg_result_value DOUBLE)
    BEGIN
        INSERT INTO results (result_list_id, subject_id, player_id, result_value, result_date)
        VALUES (arg_result_id, arg_subject_id, arg_player_id, arg_result_value, CURRENT_DATE);
    END //
DELIMITER ;

DROP PROCEDURE IF EXISTS add_result;