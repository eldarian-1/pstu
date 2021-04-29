package org.eldarian.relay.queries.select.item;

import org.eldarian.relay.EntityFactory;
import org.eldarian.relay.entities.Result;
import org.eldarian.relay.queries.AItemQuery;

import java.sql.SQLException;

public class ResultQuery extends AItemQuery<Result, String[]> {
    @Override
    protected String query(String[] arg) {
        return String.format("CALL find_result(%s, %s, %s);", arg[0], arg[1], arg[2]);
    }

    @Override
    protected Result item(EntityFactory builder) throws SQLException {
        return builder.result();
    }
}
