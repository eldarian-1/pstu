package org.eldarian.relay.entities;

public class RelayTeam extends Team{
    private int _resultListId;
    private double _resultListScore;

    public RelayTeam() {}

    public RelayTeam(Team team) {
        setTeamId(team.getTeamId());
        setTeamName(team.getTeamName());
        setTrainers(team.getTrainers());
    }

    public int getResultListId() {
        return _resultListId;
    }

    public void setResultListId(int resultListId) {
        _resultListId = resultListId;
    }

    public double getResultListScore() {
        return _resultListScore;
    }

    public void setResultListScore(double resultListScore) {
        _resultListScore = resultListScore;
    }
}
