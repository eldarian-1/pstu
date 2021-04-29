package org.eldarian.relay.queries.update;

import org.eldarian.relay.queries.AUpdateQuery;

public class UpdateResultQuery extends AUpdateQuery<String[]> {
    @Override
    protected String query(String[] arg) {
        return String.format("CALL update_result(%s, %s, %s, %s, %s, %s);",
                arg[0], arg[1], arg[2], arg[3], arg[4], arg[5]);
    }
}
