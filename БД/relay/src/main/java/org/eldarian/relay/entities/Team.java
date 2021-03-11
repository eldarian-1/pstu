package org.eldarian.relay.entities;

public class Team {
    private int _teamId;
    private String _teamName;
    private String _trainers;

    public int getTeamId() {
        return _teamId;
    }

    public void setTeamId(int teamId) {
        _teamId = teamId;
    }

    public String getTeamName() {
        return _teamName;
    }

    public void setTeamName(String teamName) {
        _teamName = teamName;
    }

    public String getTrainers() {
        return _trainers;
    }

    public void setTrainers(String trainers) {
        _trainers = trainers;
    }
}
