package org.eldarian.relay.queries;

import org.eldarian.relay.ISqlQueryable;
import org.eldarian.relay.entities.Player;

import java.sql.*;
import java.util.*;

public class PlayerListQuery implements ISqlQueryable<Collection<Player>, Void> {
    @Override
    public Collection<Player> execute(Statement statement, Void v) throws SQLException {
        ResultSet set = statement.executeQuery("CALL get_player_list();");
        Collection<Player> list = new ArrayList<>();
        while(set.next()){
            Player player = new Player();
            player.setPlayerId(set.getInt("player_id"));
            player.setTeamId(set.getInt("team_id"));
            player.setPlayerName(set.getString("player_name"));
            player.setTeamName(set.getString("team_name"));
            list.add(player);
        }
        return list;
    }
}
