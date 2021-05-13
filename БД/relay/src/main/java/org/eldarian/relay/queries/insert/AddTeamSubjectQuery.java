package org.eldarian.relay.queries.insert;

import org.eldarian.relay.queries.AUpdateQuery;

public class AddTeamSubjectQuery extends AUpdateQuery<String[]> {
    @Override
    protected String query(String[] arg) {
        return String.format("CALL add_team_subject(%s, %s);", arg[0], arg[1]);
    }
}
