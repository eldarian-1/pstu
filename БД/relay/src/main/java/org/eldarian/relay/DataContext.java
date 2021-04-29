package org.eldarian.relay;

import java.sql.Connection;
import java.sql.DriverManager;

public class DataContext<TResult, TArgument> {

    private ISqlQueryable<TResult, TArgument> _query;

    public DataContext(ISqlQueryable<TResult, TArgument> query) {
        _query = query;
    }

    public TResult provide(TArgument argument) {
        TResult result = null;
        try{
            String url = "jdbc:mysql://localhost/testdb?serverTimezone=Europe/Moscow&allowPublicKeyRetrieval=true&useSSL=false";
            String username = "eldarian";
            String password = "19841986";
            Class.forName("com.mysql.cj.jdbc.Driver").getDeclaredConstructor().newInstance();
            try (Connection connection = DriverManager.getConnection(url, username, password)){
                result = _query.execute(connection.createStatement(), argument);
            }
        }
        catch(Exception ex){
            System.out.println(ex);
        }
        return result;
    }

}
