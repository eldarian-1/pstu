package org.eldarian.relay.queries;

import org.eldarian.relay.ISqlQueryable;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

public abstract class AInsertQuery<TArg> implements ISqlQueryable<Integer, TArg> {

    protected abstract String query(TArg arg);

    @Override
    public Integer execute(Statement statement, TArg arg) throws SQLException {
        ResultSet set = statement.executeQuery(query(arg));
        set.next();
        return set.getInt("last_insert_id");
    }
}
