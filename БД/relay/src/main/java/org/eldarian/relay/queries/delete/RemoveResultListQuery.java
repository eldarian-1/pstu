package org.eldarian.relay.queries.delete;

import org.eldarian.relay.queries.AUpdateQuery;

public class RemoveResultListQuery extends AUpdateQuery<String> {
    @Override
    protected String query(String arg) {
        return String.format("CALL remove_result_list(%s);", arg);
    }
}
