package org.eldarian.relay.queries;

import org.eldarian.relay.ISqlQueryable;

import java.sql.SQLException;
import java.sql.Statement;

public class AddPlayerQuery implements ISqlQueryable<Void, String> {
    @Override
    public Void execute(Statement statement, String name) throws SQLException {
        statement.execute(String.format("CALL add_player(%s);", name));
        return null;
    }
}
