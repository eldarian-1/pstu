package org.eldarian.relay.queries.select;

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
        Subject item = new Subject();
        item.setSubjectId(set.getInt("subject_id"));
        item.setSubjectName(set.getString("subject_name"));
        item.setSubjectUnit(set.getString("subject_unit"));
        item.setSubjectMultiplier(set.getDouble("subject_multiplier"));
        return item;
    }
}
