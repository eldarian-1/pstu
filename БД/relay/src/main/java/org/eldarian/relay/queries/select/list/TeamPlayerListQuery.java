package org.eldarian.relay.queries.select.list;

import org.eldarian.relay.EntityFactory;
import org.eldarian.relay.entities.Player;
import org.eldarian.relay.queries.AListQuery;

import java.sql.SQLException;

public class TeamPlayerListQuery extends AListQuery<Player, String> {
    @Override
    protected String query(String arg) {
        return String.format("CALL get_team_player_list(%s);", arg);
    }

    @Override
    protected Player item(EntityFactory builder) throws SQLException {
        return builder.miniPlayer();
    }
}