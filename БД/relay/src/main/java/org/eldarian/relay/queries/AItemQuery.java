package org.eldarian.relay.queries;

import org.eldarian.relay.EntityBuilder;
import org.eldarian.relay.ISqlQueryable;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

public abstract class AItemQuery<TResult, TArgument> implements ISqlQueryable<TResult, TArgument> {

    protected abstract String query(TArgument arg);
    protected abstract TResult item(EntityBuilder builder) throws SQLException;

    @Override
    public TResult execute(Statement statement, TArgument arg) throws SQLException {
        ResultSet set = statement.executeQuery(query(arg));
        if(set.next())
            return item(new EntityBuilder(set));
        else
            return null;
    }
}
