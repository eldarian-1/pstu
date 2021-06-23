package org.eldarian.relay.queries.insert;

import org.eldarian.relay.queries.AUpdateQuery;

public class AddResultQuery extends AUpdateQuery<String[]> {
    @Override
    protected String query(String[] arg) {
        return String.format("CALL add_result(%s, %s, %s, %s);", arg[0], arg[1], arg[2], arg[3]);
    }
}
