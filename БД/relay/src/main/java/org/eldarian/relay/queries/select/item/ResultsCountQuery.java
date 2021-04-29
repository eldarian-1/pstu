package org.eldarian.relay.queries.select.item;

import org.eldarian.relay.EntityFactory;
import org.eldarian.relay.queries.AItemQuery;

import java.sql.SQLException;

public class ResultsCountQuery extends AItemQuery<Integer, String> {
    @Override
    protected String query(String arg) {
        return String.format("CALL results_count(%s);", arg);
    }

    @Override
    protected Integer item(EntityFactory builder) throws SQLException {
        return builder.number();
    }
}
