package org.eldarian.relay.controllers;

import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.Statement;

@Controller
public class MainController {

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

    @GetMapping("/")
    public String home() {
        return "general/home";
    }

    @GetMapping("/teams")
    public String teams() {
        return "general/teams";
    }

    @GetMapping("/players")
    public String players() {
        return "general/players";
    }

    @GetMapping("/subjects")
    public String subjects() {
        return "general/subjects";
    }

    @GetMapping("/workouts")
    public String workouts() {
        return "general/workouts";
    }

    @GetMapping("/relay_races")
    public String relayRaces() {
        return "general/relay_races";
    }

    @GetMapping("/authorization")
    public String authorization() {
        return "general/authorization";
    }

}