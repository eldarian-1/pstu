package org.eldarian.relay.queries.update;

import org.eldarian.relay.queries.AUpdateQuery;

public class CloseRelayRaceQuery extends AUpdateQuery<String> {
    @Override
    protected String query(String arg) {
        return String.format("CALL close_relay_race(%s);", arg);
    }
}
