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

    public RelayTeam relayTeam() throws SQLException {
        RelayTeam item = new RelayTeam(team());
        item.setResultListId(_set.getInt("result_list_id"));
        item.setResultListScore(_set.getDouble("result_list_score"));
        return item;
    }

    public Result result() throws SQLException {
        Result item = new Result();
        item.setResultListId(_set.getInt("result_list_id"));
        item.setResultListName(_set.getString("result_list_name"));
        item.setPlayerId(_set.getInt("player_id"));
        item.setPlayerName(_set.getString("player_name"));
        item.setSubjectId(_set.getInt("subject_id"));
        item.setSubjectName(_set.getString("subject_name"));
        item.setResultValue(_set.getDouble("result_value"));
        item.setSubjectUnit(_set.getString("subject_unit"));
        item.setSubjectMultiplier(_set.getDouble("subject_multiplier"));
        item.setResultDate(_set.getDate("result_date"));
        return item;
    }

    public ResultList resultList() throws SQLException {
        ResultList item = new ResultList();
        item.setTeamId(_set.getInt("team_id"));
        item.setResultListId(_set.getInt("result_list_id"));
        item.setResultListName(_set.getString("result_list_name"));
        item.setResultListDate(_set.getDate("result_list_date"));
        item.setOpen(_set.getBoolean("is_open"));
        return item;
    }

    public RelayRace relayRace() throws SQLException {
        RelayRace item = new RelayRace();
        item.setRelayId(_set.getInt("relay_id"));
        item.setRelayName(_set.getString("relay_name"));
        item.setTeamNumber(_set.getInt("team_number"));
        item.setPlayerNumber(_set.getInt("player_number"));
        return item;
    }

}
