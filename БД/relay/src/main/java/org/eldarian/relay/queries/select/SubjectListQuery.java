package org.eldarian.relay.queries.select;

import org.eldarian.relay.ISqlQueryable;
import org.eldarian.relay.entities.Subject;

import java.sql.*;
import java.util.*;

public class SubjectListQuery implements ISqlQueryable<Collection<Subject>, Void> {
    @Override
    public Collection<Subject> execute(Statement statement, Void v) throws SQLException {
        ResultSet set = statement.executeQuery("CALL get_subject_list();");
        Collection<Subject> list = new ArrayList<>();
        while(set.next()){
            Subject item = new Subject();
            item.setSubjectId(set.getInt("subject_id"));
            item.setSubjectName(set.getString("subject_name"));
            item.setSubjectUnit(set.getString("subject_unit"));
            item.setSubjectMultiplier(set.getDouble("subject_multiplier"));
            list.add(item);
        }
        return list;
    }
}
