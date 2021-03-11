package org.eldarian.relay.queries;

import org.eldarian.relay.ISqlQueryable;
import org.eldarian.relay.entities.Player;

import java.sql.*;

public class PlayerQuery implements ISqlQueryable<Player, String> {
    @Override
    public Player execute(Statement statement, String id) throws SQLException {
        ResultSet set = statement.executeQuery(String.format("CALL find_player(%s);", id));
        set.next();
        Player player = new Player();
        player.setPlayerId(set.getInt("player_id"));
        player.setTeamId(set.getInt("team_id"));
        player.setPlayerName(set.getString("player_name"));
        player.setTeamName(set.getString("team_name"));
        return player;
    }
}