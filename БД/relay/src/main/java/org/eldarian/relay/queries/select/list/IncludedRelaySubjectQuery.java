package org.eldarian.relay.queries.select.list;

import org.eldarian.relay.EntityBuilder;
import org.eldarian.relay.entities.Subject;
import org.eldarian.relay.queries.AListQuery;

import java.sql.SQLException;

public class IncludedRelaySubjectQuery extends AListQuery<Subject, String> {
    @Override
    protected String query(String arg) {
        return String.format("CALL relay_subject_list(%s);", arg);
    }

    @Override
    protected Subject item(EntityBuilder builder) throws SQLException {
        return builder.subject();
    }
}
