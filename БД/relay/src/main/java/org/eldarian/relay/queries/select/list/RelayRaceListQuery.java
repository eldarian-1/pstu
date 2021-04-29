package org.eldarian.relay.queries.select.list;

import org.eldarian.relay.EntityFactory;
import org.eldarian.relay.entities.RelayRace;
import org.eldarian.relay.queries.AListQuery;

import java.sql.SQLException;

public class RelayRaceListQuery extends AListQuery<RelayRace, Void> {
    @Override
    protected String query(Void arg) {
        return "CALL get_relay_race_list();";
    }

    @Override
    protected RelayRace item(EntityFactory builder) throws SQLException {
        return builder.relayRace();
    }
}
