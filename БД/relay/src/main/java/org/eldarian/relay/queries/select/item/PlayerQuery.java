package org.eldarian.relay.queries.select.item;

import org.eldarian.relay.EntityBuilder;
import org.eldarian.relay.entities.Player;
import org.eldarian.relay.queries.select.AItemQuery;

import java.sql.SQLException;


public class PlayerQuery extends AItemQuery<Player, String> {
    @Override
    protected String query(String arg) {
        return String.format("CALL find_player(%s);", arg);
    }

    @Override
    protected Player item(EntityBuilder builder) throws SQLException {
        return builder.player();
    }
}