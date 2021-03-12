package org.eldarian.relay.queries.select;

import org.eldarian.relay.ISqlQueryable;
import org.eldarian.relay.entities.Team;

import java.sql.*;
import java.util.*;

public class TeamListQuery implements ISqlQueryable<Collection<Team>, Void> {
    @Override
    public Collection<Team> execute(Statement statement, Void v) throws SQLException {
        ResultSet set = statement.executeQuery("CALL get_team_list();");
        Collection<Team> list = new ArrayList<>();
        while(set.next()){
            Team item = new Team();
            item.setTeamId(set.getInt("team_id"));
            item.setTeamName(set.getString("team_name"));
            item.setTrainers(set.getString("trainers"));
            list.add(item);
        }
        return list;
    }
}
