package org.eldarian.relay.queries.update;

import org.eldarian.relay.queries.AUpdateQuery;

public class RenamePlayerQuery extends AUpdateQuery<String[]> {
    @Override
    protected String query(String[] arg) {
        return String.format("CALL rename_player(%s, \"%s\");", arg[0], arg[1]);
    }
}
