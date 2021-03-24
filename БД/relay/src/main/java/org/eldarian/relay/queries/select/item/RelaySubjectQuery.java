package org.eldarian.relay.queries.select.item;

import org.eldarian.relay.EntityFactory;
import org.eldarian.relay.entities.Subject;
import org.eldarian.relay.queries.AItemQuery;

import java.sql.SQLException;

public class RelaySubjectQuery extends AItemQuery<Subject, String[]> {
    @Override
    protected String query(String[] arg) {
        return String.format("CALL find_relay_subject(%s, %s);", arg[0], arg[1]);
    }

    @Override
    protected Subject item(EntityFactory builder) throws SQLException {
        return builder.subject();
    }
}
