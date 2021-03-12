package org.eldarian.relay.queries.insert;

import org.eldarian.relay.ISqlQueryable;

import java.sql.SQLException;
import java.sql.Statement;

public class AddPlayerQuery implements ISqlQueryable<Void, String[]> {
    @Override
    public Void execute(Statement statement, String[] arg) throws SQLException {
        statement.execute(String.format("CALL add_player(\"%s\", %s);", arg[0], arg[1]));
        return null;
    }
}
