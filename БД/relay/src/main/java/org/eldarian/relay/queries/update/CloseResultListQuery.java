package org.eldarian.relay.queries.update;

import org.eldarian.relay.queries.AUpdateQuery;

public class CloseResultListQuery extends AUpdateQuery<String> {
    @Override
    protected String query(String arg) {
        return String.format("CALL close_result_list(%s);", arg);
    }
}
