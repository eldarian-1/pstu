package org.eldarian.relay.queries.select;

import org.eldarian.relay.EntityBuilder;
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
        EntityBuilder builder = new EntityBuilder(set);
        while(set.next())
            list.add(builder.miniPlayer());
        return list;
    }
}