package org.eldarian.relay.entities;

import java.util.Date;

public class ResultList {
    private int _resultListId;
    private String _resultListName;
    private int _teamId;
    private boolean _isOpen;
    private Date _resultListDate;

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

    public int getTeamId() {
        return _teamId;
    }

    public void setTeamId(int teamId) {
        _teamId = teamId;
    }

    public boolean isOpen() {
        return _isOpen;
    }

    public void setOpen(boolean isOpen) {
        _isOpen = isOpen;
    }

    public Date getResultListDate() {
        return _resultListDate;
    }

    public void setResultListDate(Date resultListDate) {
        _resultListDate = resultListDate;
    }
}
