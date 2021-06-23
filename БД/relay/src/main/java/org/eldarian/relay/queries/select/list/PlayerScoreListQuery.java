package org.eldarian.relay.queries.select.list;

import org.eldarian.relay.EntityFactory;
import org.eldarian.relay.entities.PlayerScores;
import org.eldarian.relay.queries.AListQuery;

import java.sql.SQLException;

public class PlayerScoreListQuery extends AListQuery<PlayerScores, String> {
    @Override
    protected String query(String arg) {
        return String.format("CALL all_scores(%s);", arg);
    }

    @Override
    protected PlayerScores item(EntityFactory builder) throws SQLException {
        return builder.playerScores();
    }
}
