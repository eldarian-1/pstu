USE labs;
CREATE TABLE lab2 (
	EmployeeId INT (10) AUTO_INCREMENT,
	FirstName VARCHAR (30)DEFAULT "",
	LastName VARCHAR (30)DEFAULT "",
	PhoneNumber VARCHAR (20)DEFAULT "",
	Salary INT (10) DEFAULT 0,
	Address VARCHAR (255) DEFAULT "",
	Expirience INT(2) DEFAULT 0,
	PRIMARY KEY (EmployeeId));