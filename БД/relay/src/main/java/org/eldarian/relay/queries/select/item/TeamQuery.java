package org.eldarian.relay.queries.select.item;

import org.eldarian.relay.EntityFactory;
import org.eldarian.relay.entities.Team;
import org.eldarian.relay.queries.AItemQuery;

import java.sql.SQLException;

public class TeamQuery extends AItemQuery<Team, String> {
    @Override
    protected String query(String arg) {
        return String.format("CALL find_team(%s);", arg);
    }

    @Override
    protected Team item(EntityFactory builder) throws SQLException {
        return builder.team();
    }
}