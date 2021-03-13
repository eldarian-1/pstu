package org.eldarian.relay.queries.delete;

import org.eldarian.relay.queries.AUpdateQuery;

public class RemoveTeamQuery extends AUpdateQuery<String> {
    @Override
    protected String query(String arg) {
        return String.format("CALL remove_team(%s);", arg);
    }
}
