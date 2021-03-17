package org.eldarian.relay.queries.insert;

import org.eldarian.relay.queries.AInsertQuery;

public class AddRelayRaceQuery extends AInsertQuery<String[]> {
    @Override
    protected String query(String[] arg) {
        return String.format("CALL add_relay_race(\"%s\", %s, %s);", arg[0], arg[1], arg[2]);
    }
}
