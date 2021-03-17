package org.eldarian.relay.queries.select.list;

import org.eldarian.relay.EntityBuilder;
import org.eldarian.relay.entities.RelayTeam;
import org.eldarian.relay.queries.AListQuery;

import java.sql.SQLException;

public class IncludedRelayTeamQuery extends AListQuery<RelayTeam, String> {
    @Override
    protected String query(String arg) {
        return String.format("CALL relay_team_list(%s);", arg);
    }

    @Override
    protected RelayTeam item(EntityBuilder builder) throws SQLException {
        return builder.relayTeam();
    }
}
