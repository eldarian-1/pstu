package org.eldarian.relay.queries.update;

import org.eldarian.relay.queries.AUpdateQuery;

public class UpdateTeamQuery extends AUpdateQuery<String[]> {
    @Override
    protected String query(String[] arg) {
        return String.format("CALL update_team(%s, \"%s\", \"%s\");", arg[0], arg[1], arg[2]);
    }
}
