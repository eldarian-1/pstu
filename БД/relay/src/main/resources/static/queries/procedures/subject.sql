USE relaydb;

DELIMITER //
CREATE PROCEDURE get_subject_list()
    BEGIN
        SELECT * FROM subjects;
    END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE find_subject(IN arg_subject_id INT)
    BEGIN
        SELECT * FROM subjects WHERE subject_id = arg_subject_id;
    END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE add_subject(IN arg_name VARCHAR(20), IN arg_unit VARCHAR(5), IN arg_multiplier DOUBLE)
    BEGIN
        INSERT INTO subjects (subject_name, subject_unit, subject_multiplier) VALUES (arg_name, arg_unit, arg_multiplier);
        SELECT LAST_INSERT_ID() AS 'last_insert_id';
    END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE update_subject(IN arg_id INT,
    IN arg_name VARCHAR(20), IN arg_unit VARCHAR(5), IN arg_multiplier DOUBLE)
    BEGIN
        UPDATE subjects
        SET subject_name = arg_name, subject_unit = arg_unit, subject_multiplier = arg_multiplier
        WHERE subject_id = arg_id;
    END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE remove_subject(IN arg_id INT)
    BEGIN
        DELETE FROM subjects WHERE subject_id = arg_id;
    END //
DELIMITER ;

DROP PROCEDURE IF EXISTS get_subject_list;
DROP PROCEDURE IF EXISTS find_subject;
DROP PROCEDURE IF EXISTS add_subject;
DROP PROCEDURE IF EXISTS update_subject;
DROP PROCEDURE IF EXISTS remove_subject;