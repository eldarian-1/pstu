package org.eldarian.relay.queries.insert;

import org.eldarian.relay.queries.AUpdateQuery;

public class AddRelayTeamQuery extends AUpdateQuery<String[]> {
    @Override
    protected String query(String[] arg) {
        return String.format("CALL add_relay_team(%s, %s);", arg[0], arg[1]);
    }
}
