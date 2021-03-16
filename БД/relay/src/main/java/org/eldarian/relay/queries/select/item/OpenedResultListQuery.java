package org.eldarian.relay.queries.select.item;

import org.eldarian.relay.EntityBuilder;
import org.eldarian.relay.entities.ResultList;
import org.eldarian.relay.queries.AItemQuery;

import java.sql.SQLException;

public class OpenedResultListQuery extends AItemQuery<ResultList, String> {
    @Override
    protected String query(String arg) {
        return String.format("CALL get_open_result_list(%s);", arg);
    }

    @Override
    protected ResultList item(EntityBuilder builder) throws SQLException {
        return builder.resultList();
    }
}
