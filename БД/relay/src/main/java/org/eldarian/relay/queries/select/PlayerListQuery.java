package org.eldarian.relay.queries.select;

import org.eldarian.relay.EntityBuilder;
import org.eldarian.relay.ISqlQueryable;
import org.eldarian.relay.entities.Player;

import java.sql.*;
import java.util.*;

public class PlayerListQuery implements ISqlQueryable<Collection<Player>, Void> {
    @Override
    public Collection<Player> execute(Statement statement, Void v) throws SQLException {
        ResultSet set = statement.executeQuery("CALL get_player_list();");
        Collection<Player> list = new ArrayList<>();
        EntityBuilder builder = new EntityBuilder(set);
        while(set.next())
            list.add(builder.player());
        return list;
    }
}
