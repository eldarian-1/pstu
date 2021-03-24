package org.eldarian.relay.queries.select.list;

import org.eldarian.relay.EntityFactory;
import org.eldarian.relay.entities.Subject;
import org.eldarian.relay.queries.AListQuery;

import java.sql.SQLException;

public class NotIncludedRelaySubjectQuery extends AListQuery<Subject, String> {
    @Override
    protected String query(String arg) {
        return String.format("CALL not_relay_subject_list(%s);", arg);
    }

    @Override
    protected Subject item(EntityFactory builder) throws SQLException {
        return builder.subject();
    }
}
