package org.eldarian.relay.queries;

import org.eldarian.relay.ISqlQueryable;

import java.sql.*;

public abstract class AUpdateQuery<TArgument> implements ISqlQueryable<Void, TArgument> {

    protected abstract String query(TArgument arg);

    @Override
    public Void execute(Statement statement, TArgument arg) throws SQLException {
        statement.execute(query(arg));
        return null;
    }
}
