package org.eldarian.relay.queries.select.list;

import org.eldarian.relay.EntityFactory;
import org.eldarian.relay.entities.Team;
import org.eldarian.relay.queries.AListQuery;

import java.sql.SQLException;

public class NotIncludedRelayTeamQuery extends AListQuery<Team, String> {
    @Override
    protected String query(String arg) {
        return String.format("CALL not_relay_team_list(%s);", arg);
    }

    @Override
    protected Team item(EntityFactory builder) throws SQLException {
        return builder.team();
    }
}
