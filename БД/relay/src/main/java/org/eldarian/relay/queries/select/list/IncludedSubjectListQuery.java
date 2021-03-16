package org.eldarian.relay.queries.select.list;

import org.eldarian.relay.EntityBuilder;
import org.eldarian.relay.entities.Subject;
import org.eldarian.relay.queries.AListQuery;

import java.sql.SQLException;

public class IncludedSubjectListQuery extends AListQuery<Subject, Void> {
    @Override
    protected String query(Void arg) {
        return "CALL get_subject_list();";
    }

    @Override
    protected Subject item(EntityBuilder builder) throws SQLException {
        return builder.subject();
    }
}
