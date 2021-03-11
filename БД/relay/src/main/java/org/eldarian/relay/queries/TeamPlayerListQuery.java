package org.eldarian.relay.queries;

import org.eldarian.relay.ISqlQueryable;
import org.eldarian.relay.entities.Player;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.Collection;

public class TeamPlayerListQuery implements ISqlQueryable<Collection<Player>, String> {
    @Override
    public Collection<Player> execute(Statement statement, String id) throws SQLException {
        ResultSet set = statement.executeQuery(String.format("CALL get_team_player_list(%s);", id));
        Collection<Player> list = new ArrayList<>();
        while(set.next()){
            Player player = new Player();
            player.setPlayerId(set.getInt("player_id"));
            player.setPlayerName(set.getString("player_name"));
            list.add(player);
        }
        return list;
    }
}