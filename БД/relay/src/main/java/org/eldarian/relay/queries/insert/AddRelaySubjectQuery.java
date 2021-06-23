package org.eldarian.relay.queries.insert;

import org.eldarian.relay.queries.AUpdateQuery;

public class AddRelaySubjectQuery extends AUpdateQuery<String[]> {
    @Override
    protected String query(String[] arg) {
        return String.format("CALL add_relay_subject(%s, %s);", arg[0], arg[1]);
    }
}
