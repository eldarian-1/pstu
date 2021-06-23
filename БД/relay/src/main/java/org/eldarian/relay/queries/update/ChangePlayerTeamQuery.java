package org.eldarian.relay.queries.update;

import org.eldarian.relay.queries.AUpdateQuery;

public class ChangePlayerTeamQuery extends AUpdateQuery<String[]> {
    @Override
    protected String query(String[] arg) {
        return String.format("CALL change_player_team(%s, %s);", arg[0], arg[1]);
    }
}
