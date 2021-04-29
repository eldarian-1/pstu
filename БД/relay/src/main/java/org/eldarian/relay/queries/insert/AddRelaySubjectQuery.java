package org.eldarian.relay.queries.insert;

import org.eldarian.relay.queries.AInsertQuery;

public class AddRelaySubjectQuery extends AInsertQuery<String[]> {
    @Override
    protected String query(String[] arg) {
        return String.format("CALL add_relay_subject(%s, %s);", arg[0], arg[1]);
    }
}
