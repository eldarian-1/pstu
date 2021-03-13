package org.eldarian.relay.queries;

import org.eldarian.relay.EntityBuilder;
import org.eldarian.relay.ISqlQueryable;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.Collection;

public abstract class AListQuery<TResult, TArgument> implements ISqlQueryable<Collection<TResult>, TArgument> {

    protected abstract String query(TArgument arg);
    protected abstract TResult item(EntityBuilder builder) throws SQLException;

    @Override
    public Collection<TResult> execute(Statement statement, TArgument arg) throws SQLException {
        ResultSet set = statement.executeQuery(query(arg));
        Collection<TResult> list = new ArrayList<>();
        EntityBuilder builder = new EntityBuilder(set);
        while(set.next())
            list.add(item(builder));
        return list;
    }
}
