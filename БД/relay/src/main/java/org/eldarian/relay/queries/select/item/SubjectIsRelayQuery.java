package org.eldarian.relay.queries.select.item;

import org.eldarian.relay.EntityFactory;
import org.eldarian.relay.queries.AItemQuery;

import java.sql.SQLException;

public class SubjectIsRelayQuery extends AItemQuery<Boolean, String[]> {
    @Override
    protected String query(String[] arg) {
        return String.format("CALL subject_is_relay(%s, %s);", arg[0], arg[1]);
    }

    @Override
    protected Boolean item(EntityFactory builder) throws SQLException {
        return builder.bool();
    }
}
