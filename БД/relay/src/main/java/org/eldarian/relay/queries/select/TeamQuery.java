package org.eldarian.relay.queries.select;

import org.eldarian.relay.EntityBuilder;
import org.eldarian.relay.ISqlQueryable;
import org.eldarian.relay.entities.Team;

import java.sql.*;

public class TeamQuery implements ISqlQueryable<Team, String> {
    @Override
    public Team execute(Statement statement, String id) throws SQLException {
        ResultSet set = statement.executeQuery(String.format("CALL find_team(%s);", id));
        set.next();
        return new EntityBuilder(set).team();
    }
}