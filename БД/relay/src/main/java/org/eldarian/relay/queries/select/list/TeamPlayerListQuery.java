package org.eldarian.relay.queries.select.list;

import org.eldarian.relay.EntityBuilder;
import org.eldarian.relay.entities.Player;
import org.eldarian.relay.queries.select.AListQuery;

import java.sql.SQLException;

public class TeamPlayerListQuery extends AListQuery<Player, String> {
    @Override
    protected String query(String arg) {
        return String.format("CALL get_team_player_list(%s);", arg);
    }

    @Override
    protected Player item(EntityBuilder builder) throws SQLException {
        return builder.miniPlayer();
    }
}