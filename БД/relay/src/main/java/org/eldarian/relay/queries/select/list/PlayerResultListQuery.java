package org.eldarian.relay.queries.select.list;

import org.eldarian.relay.EntityBuilder;
import org.eldarian.relay.entities.Result;
import org.eldarian.relay.queries.select.AListQuery;

import java.sql.SQLException;

public class PlayerResultListQuery extends AListQuery<Result, String> {
    @Override
    protected String query(String arg) {
        return String.format("CALL player_results(%s);", arg);
    }

    @Override
    protected Result item(EntityBuilder builder) throws SQLException {
        return builder.result();
    }
}
