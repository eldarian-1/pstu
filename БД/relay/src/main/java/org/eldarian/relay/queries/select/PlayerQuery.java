package org.eldarian.relay.queries.select;

import org.eldarian.relay.ISqlQueryable;
import org.eldarian.relay.entities.Player;

import java.sql.*;

public class PlayerQuery implements ISqlQueryable<Player, String> {
    @Override
    public Player execute(Statement statement, String id) throws SQLException {
        ResultSet set = statement.executeQuery(String.format("CALL find_player(%s);", id));
        set.next();
        Player item = new Player();
        item.setPlayerId(set.getInt("player_id"));
        item.setTeamId(set.getInt("team_id"));
        item.setPlayerName(set.getString("player_name"));
        item.setTeamName(set.getString("team_name"));
        return item;
    }
}