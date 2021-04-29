package org.eldarian.relay.queries.insert;

import org.eldarian.relay.queries.AInsertQuery;

public class AddResultListQuery extends AInsertQuery<String> {
    @Override
    protected String query(String arg) {
        return String.format("CALL start_result_list(%s);", arg);
    }
}
