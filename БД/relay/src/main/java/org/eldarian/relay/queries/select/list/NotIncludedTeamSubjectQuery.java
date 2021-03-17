package org.eldarian.relay.queries.select.list;

import org.eldarian.relay.EntityBuilder;
import org.eldarian.relay.entities.Subject;
import org.eldarian.relay.queries.AListQuery;

import java.sql.SQLException;

public class NotIncludedTeamSubjectQuery extends AListQuery<Subject, String> {
    @Override
    protected String query(String arg) {
        return String.format("CALL get_not_team_subject_list(%s);", arg);
    }

    @Override
    protected Subject item(EntityBuilder builder) throws SQLException {
        return builder.subject();
    }
}
