package org.eldarian.relay.queries.select;

import org.eldarian.relay.EntityBuilder;
import org.eldarian.relay.ISqlQueryable;
import org.eldarian.relay.entities.Team;

import java.sql.*;
import java.util.*;

public class TeamListQuery implements ISqlQueryable<Collection<Team>, Void> {
    @Override
    public Collection<Team> execute(Statement statement, Void v) throws SQLException {
        ResultSet set = statement.executeQuery("CALL get_team_list();");
        Collection<Team> list = new ArrayList<>();
        EntityBuilder builder = new EntityBuilder(set);
        while(set.next())
            list.add(builder.team());
        return list;
    }
}
