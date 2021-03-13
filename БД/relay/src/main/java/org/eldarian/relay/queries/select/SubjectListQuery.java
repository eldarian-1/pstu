package org.eldarian.relay.queries.select;

import org.eldarian.relay.EntityBuilder;
import org.eldarian.relay.ISqlQueryable;
import org.eldarian.relay.entities.Subject;

import java.sql.*;
import java.util.*;

public class SubjectListQuery implements ISqlQueryable<Collection<Subject>, Void> {
    @Override
    public Collection<Subject> execute(Statement statement, Void v) throws SQLException {
        ResultSet set = statement.executeQuery("CALL get_subject_list();");
        Collection<Subject> list = new ArrayList<>();
        EntityBuilder builder = new EntityBuilder(set);
        while(set.next())
            list.add(builder.subject());
        return list;
    }
}
