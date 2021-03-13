package org.eldarian.relay.queries.delete;

import org.eldarian.relay.queries.ADeleteQuery;

public class RemoveTeamQuery extends ADeleteQuery<String> {
    @Override
    protected String query(String arg) {
        return String.format("CALL remove_team(%s);", arg);
    }
}
