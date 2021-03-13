package org.eldarian.relay.queries.select;

import org.eldarian.relay.EntityBuilder;
import org.eldarian.relay.ISqlQueryable;
import org.eldarian.relay.entities.Subject;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

public class SubjectQuery implements ISqlQueryable<Subject, String> {
    @Override
    public Subject execute(Statement statement, String id) throws SQLException {
        ResultSet set = statement.executeQuery(String.format("CALL find_subject(%s);", id));
        set.next();
        return new EntityBuilder(set).subject();
    }
}
