package org.eldarian.relay.queries.delete;

import org.eldarian.relay.queries.AUpdateQuery;

public class RemovePlayerQuery extends AUpdateQuery<String> {
    @Override
    protected String query(String arg) {
        return String.format("CALL remove_player(%s);", arg);
    }
}
