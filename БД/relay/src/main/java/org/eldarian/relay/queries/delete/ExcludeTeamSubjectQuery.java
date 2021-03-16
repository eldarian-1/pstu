package org.eldarian.relay.queries.delete;

import org.eldarian.relay.queries.AUpdateQuery;

public class ExcludeTeamSubjectQuery extends AUpdateQuery<String[]> {
    @Override
    protected String query(String[] arg) {
        return String.format("CALL exclude_team_subject(%s, %s);", arg[0], arg[1]);
    }
}
