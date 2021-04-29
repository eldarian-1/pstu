package org.eldarian.relay.queries.insert;

import org.eldarian.relay.queries.AInsertQuery;

public class AddTeamQuery extends AInsertQuery<String[]> {
    @Override
    protected String query(String[] arg) {
        return String.format("CALL add_team(\"%s\", \"%s\");", arg[0], arg[1]);
    }
}
