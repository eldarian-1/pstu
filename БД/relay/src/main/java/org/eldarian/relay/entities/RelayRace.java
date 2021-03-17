package org.eldarian.relay.entities;

public class RelayRace {
    private int _relayId;
    private String _relayName;
    private int _teamNumber;
    private int _playerNumber;

    public int getRelayId() {
        return _relayId;
    }

    public void setRelayId(int relayId) {
        _relayId = relayId;
    }

    public String getRelayName() {
        return _relayName;
    }

    public void setRelayName(String relayName) {
        _relayName = relayName;
    }

    public int getTeamNumber() {
        return _teamNumber;
    }

    public void setTeamNumber(int teamNumber) {
        _teamNumber = teamNumber;
    }

    public int getPlayerNumber() {
        return _playerNumber;
    }

    public void setPlayerNumber(int playerNumber) {
        _playerNumber = playerNumber;
    }
}
