package org.eldarian.relay.queries.delete;

import org.eldarian.relay.queries.AUpdateQuery;

public class RemoveSubjectQuery extends AUpdateQuery<String> {
    @Override
    protected String query(String arg) {
        return String.format("CALL remove_subject(%s);", arg);
    }
}
