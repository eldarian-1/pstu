package org.eldarian.relay.queries.select.list;

import org.eldarian.relay.EntityBuilder;
import org.eldarian.relay.entities.Player;
import org.eldarian.relay.queries.AListQuery;

import java.sql.SQLException;

public class PlayerListQuery extends AListQuery<Player, Void> {
    @Override
    protected String query(Void arg) {
        return "CALL get_player_list();";
    }

    @Override
    protected Player item(EntityBuilder builder) throws SQLException {
        return builder.player();
    }
}
