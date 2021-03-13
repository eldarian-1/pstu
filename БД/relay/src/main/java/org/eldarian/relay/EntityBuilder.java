package org.eldarian.relay;

import org.eldarian.relay.entities.*;

import java.sql.ResultSet;
import java.sql.SQLException;

public class EntityBuilder {

    private ResultSet _set;

    public EntityBuilder(ResultSet set) {
        _set = set;
    }

    public Player miniPlayer() throws SQLException {
        Player item = new Player();
        item.setPlayerId(_set.getInt("player_id"));
        item.setPlayerName(_set.getString("player_name"));
        return item;
    }

    public Player player() throws SQLException {
        Player item = new Player();
        item.setPlayerId(_set.getInt("player_id"));
        item.setTeamId(_set.getInt("team_id"));
        item.setPlayerName(_set.getString("player_name"));
        item.setTeamName(_set.getString("team_name"));
        return item;
    }

    public Subject subject() throws SQLException {
        Subject item = new Subject();
        item.setSubjectId(_set.getInt("subject_id"));
        item.setSubjectName(_set.getString("subject_name"));
        item.setSubjectUnit(_set.getString("subject_unit"));
        item.setSubjectMultiplier(_set.getDouble("subject_multiplier"));
        return item;
    }

    public Team team() throws SQLException {
        Team item = new Team();
        item.setTeamId(_set.getInt("team_id"));
        item.setTeamName(_set.getString("team_name"));
        item.setTrainers(_set.getString("trainers"));
        return item;
    }

}
