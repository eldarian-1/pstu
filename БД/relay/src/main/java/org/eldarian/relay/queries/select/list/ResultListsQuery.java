package org.eldarian.relay.queries.select.list;

import org.eldarian.relay.EntityBuilder;
import org.eldarian.relay.entities.ResultList;
import org.eldarian.relay.queries.AListQuery;

import java.sql.SQLException;

public class ResultListsQuery extends AListQuery<ResultList, String> {
    @Override
    protected String query(String arg) {
        return String.format("CALL get_team_result_lists(%s);", arg);
    }

    @Override
    protected ResultList item(EntityBuilder builder) throws SQLException {
        return builder.resultList();
    }
}
