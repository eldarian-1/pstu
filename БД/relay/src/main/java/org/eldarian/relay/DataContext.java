package org.eldarian.relay;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.Statement;

public class DataContext {

    private void MySQLTest() {
        try{
            String url = "jdbc:mysql://localhost/testdb?serverTimezone=Europe/Moscow&allowPublicKeyRetrieval=true&useSSL=false";
            String username = "eldarian";
            String password = "19841986";
            Class.forName("com.mysql.cj.jdbc.Driver").getDeclaredConstructor().newInstance();
            String sqlCommand = "CREATE TABLE products (Id INT PRIMARY KEY AUTO_INCREMENT, ProductName VARCHAR(20), Price INT)";
            try (Connection conn = DriverManager.getConnection(url, username, password)){
                Statement statement = conn.createStatement();
                statement.executeUpdate(sqlCommand);
                System.out.println("Database has been created!");
            }
        }
        catch(Exception ex){
            System.out.println("Connection failed...");
            System.out.println(ex);
        }
    }

}
