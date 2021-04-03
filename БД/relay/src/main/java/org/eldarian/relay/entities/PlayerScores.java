package org.eldarian.relay.entities;

public class PlayerScores {
    private int _resultListId;
    private int _subjectId;
    private int _playerId;
    private String _subjectName;
    private String _playerName;
    private double _subjectScore;

    public int getResultListId() {
        return _resultListId;
    }

    public void setResultListId(int resultListId) {
        _resultListId = resultListId;
    }

    public int getSubjectId() {
        return _subjectId;
    }

    public void setSubjectId(int subjectId) {
        _subjectId = subjectId;
    }

    public int getPlayerId() {
        return _playerId;
    }

    public void setPlayerId(int playerId) {
        _playerId = playerId;
    }

    public String getSubjectName() {
        return _subjectName;
    }

    public void setSubjectName(String subjectName) {
        _subjectName = subjectName;
    }

    public String getPlayerName() {
        return _playerName;
    }

    public void setPlayerName(String playerName) {
        _playerName = playerName;
    }

    public double getSubjectScore() {
        return _subjectScore;
    }

    public void setSubjectScore(double subjectScore) {
        _subjectScore = subjectScore;
    }
}
