package org.eldarian.relay.queries.select;

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
            Player item = new Player();
            item.setPlayerId(set.getInt("player_id"));
            item.setTeamId(set.getInt("team_id"));
            item.setPlayerName(set.getString("player_name"));
            item.setTeamName(set.getString("team_name"));
            list.add(item);
        }
        return list;
    }
}
