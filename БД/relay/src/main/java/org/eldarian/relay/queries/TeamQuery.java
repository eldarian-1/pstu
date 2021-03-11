package org.eldarian.relay.queries;

import org.eldarian.relay.ISqlQueryable;
import org.eldarian.relay.entities.Team;

import java.sql.*;

public class TeamQuery implements ISqlQueryable<Team, String> {
    @Override
    public Team execute(Statement statement, String id) throws SQLException {
        ResultSet set = statement.executeQuery(String.format("CALL find_team(%s);", id));
        set.next();
        Team team = new Team();
        team.setTeamId(set.getInt("team_id"));
        team.setTeamName(set.getString("team_name"));
        team.setTrainers(set.getString("trainers"));
        return team;
    }
}