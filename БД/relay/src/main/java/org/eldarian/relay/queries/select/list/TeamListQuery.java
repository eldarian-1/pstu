package org.eldarian.relay.queries.select.list;

import org.eldarian.relay.EntityFactory;
import org.eldarian.relay.entities.Team;
import org.eldarian.relay.queries.AListQuery;

import java.sql.SQLException;


public class TeamListQuery extends AListQuery<Team, Void> {
    @Override
    protected String query(Void arg) {
        return "CALL get_team_list();";
    }

    @Override
    protected Team item(EntityFactory builder) throws SQLException {
        return builder.team();
    }
}
