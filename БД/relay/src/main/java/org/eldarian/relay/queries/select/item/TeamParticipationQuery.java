package org.eldarian.relay.queries.select.item;

import org.eldarian.relay.EntityFactory;
import org.eldarian.relay.queries.AItemQuery;

import java.sql.SQLException;

public class TeamParticipationQuery extends AItemQuery<Boolean, String> {
    @Override
    protected String query(String arg) {
        return String.format("CALL find_team_participation(%s);", arg);
    }

    @Override
    protected Boolean item(EntityFactory builder) throws SQLException {
        return builder.bool();
    }
}
