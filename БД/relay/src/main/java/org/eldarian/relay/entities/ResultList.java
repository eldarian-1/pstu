package org.eldarian.relay.entities;

import java.util.Date;

public class ResultList {
    private int _resultId;
    private int _teamId;
    private boolean _isOpen;
    private Date _resultListDate;

    public int getResultId() {
        return _resultId;
    }

    public void setResultId(int resultId) {
        _resultId = resultId;
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
