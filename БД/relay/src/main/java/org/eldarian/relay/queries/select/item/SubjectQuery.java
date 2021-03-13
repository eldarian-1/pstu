package org.eldarian.relay.queries.select.item;

import org.eldarian.relay.EntityBuilder;
import org.eldarian.relay.entities.Subject;
import org.eldarian.relay.queries.select.AItemQuery;

import java.sql.SQLException;

public class SubjectQuery extends AItemQuery<Subject, String> {
    @Override
    protected String query(String arg) {
        return String.format("CALL find_subject(%s);", arg);
    }

    @Override
    protected Subject item(EntityBuilder builder) throws SQLException {
        return builder.subject();
    }
}
