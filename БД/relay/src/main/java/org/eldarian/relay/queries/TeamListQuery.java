package org.eldarian.relay.queries;

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
            Team team = new Team();
            team.setTeamId(set.getInt("team_id"));
            team.setTeamName(set.getString("team_name"));
            team.setTrainers(set.getString("trainers"));
            list.add(team);
        }
        return list;
    }
}
