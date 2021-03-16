package org.eldarian.relay.queries.insert;

import org.eldarian.relay.ISqlQueryable;

import java.sql.SQLException;
import java.sql.Statement;

public class AddResultListQuery implements ISqlQueryable<Void, String> {
    @Override
    public Void execute(Statement statement, String arg) throws SQLException {
        statement.execute(String.format("CALL start_result_list(%s);", arg));
        return null;
    }
}
