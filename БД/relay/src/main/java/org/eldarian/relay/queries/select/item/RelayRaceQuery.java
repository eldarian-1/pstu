package org.eldarian.relay.queries.select.item;

import org.eldarian.relay.EntityBuilder;
import org.eldarian.relay.entities.RelayRace;
import org.eldarian.relay.queries.AItemQuery;

import java.sql.SQLException;

public class RelayRaceQuery extends AItemQuery<RelayRace, String> {
    @Override
    protected String query(String arg) {
        return String.format("CALL find_relay_race(%s);", arg);
    }

    @Override
    protected RelayRace item(EntityBuilder builder) throws SQLException {
        return builder.relayRace();
    }
}
