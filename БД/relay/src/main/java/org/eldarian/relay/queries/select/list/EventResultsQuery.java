package org.eldarian.relay.queries.select.list;

import org.eldarian.relay.EntityBuilder;
import org.eldarian.relay.entities.Result;
import org.eldarian.relay.queries.AListQuery;

import java.sql.SQLException;

public class EventResultsQuery extends AListQuery<Result, String> {
    @Override
    protected String query(String arg) {
        return String.format("CALL get_event_results(%s);", arg);
    }

    @Override
    protected Result item(EntityBuilder builder) throws SQLException {
        return builder.result();
    }
}
