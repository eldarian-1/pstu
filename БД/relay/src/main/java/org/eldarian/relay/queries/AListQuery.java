package org.eldarian.relay.queries;

import org.eldarian.relay.EntityFactory;
import org.eldarian.relay.ISqlQueryable;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.Collection;

public abstract class AListQuery<TResult, TArgument> implements ISqlQueryable<Collection<TResult>, TArgument> {

    protected abstract String query(TArgument arg);
    protected abstract TResult item(EntityFactory builder) throws SQLException;

    @Override
    public Collection<TResult> execute(Statement statement, TArgument arg) throws SQLException {
        ResultSet set = statement.executeQuery(query(arg));
        Collection<TResult> list = new ArrayList<>();
        EntityFactory builder = new EntityFactory(set);
        while(set.next())
            list.add(item(builder));
        return list;
    }
}
