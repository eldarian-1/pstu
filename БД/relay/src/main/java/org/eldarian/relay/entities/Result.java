package org.eldarian.relay.entities;

public class Result {
    private int _playerId;
    private int _resultListId;
    private String _resultListName;
    private int _subjectId;
    private String _subjectName;
    private double _resultValue;
    private String _subjectUnit;

    public int getPlayerId() {
        return _playerId;
    }

    public void setPlayerId(int playerId) {
        _playerId = playerId;
    }

    public int getResultListId() {
        return _resultListId;
    }

    public void setResultListId(int resultListId) {
        _resultListId = resultListId;
    }

    public String getResultListName() {
        return _resultListName;
    }

    public void setResultListName(String resultListName) {
        _resultListName = resultListName;
    }

    public int getSubjectId() {
        return _subjectId;
    }

    public void setSubjectId(int subjectId) {
        _subjectId = subjectId;
    }

    public String getSubjectName() {
        return _subjectName;
    }

    public void setSubjectName(String subjectName) {
        _subjectName = subjectName;
    }

    public double getResultValue() {
        return _resultValue;
    }

    public void setResultValue(double resultValue) {
        _resultValue = resultValue;
    }

    public String getSubjectUnit() {
        return _subjectUnit;
    }

    public void setSubjectUnit(String subjectUnit) {
        _subjectUnit = subjectUnit;
    }
}
