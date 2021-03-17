package org.eldarian.relay.queries.select.list;

import org.eldarian.relay.EntityBuilder;
import org.eldarian.relay.entities.Player;
import org.eldarian.relay.queries.AListQuery;

import java.sql.SQLException;

public class PossiblePlayerListQuery extends AListQuery<Player, String> {
    @Override
    protected String query(String arg) {
        return String.format("CALL get_possible_player_list(%s);", arg);
    }

    @Override
    protected Player item(EntityBuilder builder) throws SQLException {
        return builder.player();
    }
}
