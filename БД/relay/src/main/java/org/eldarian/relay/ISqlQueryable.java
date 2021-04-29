package org.eldarian.relay;

import java.sql.SQLException;
import java.sql.Statement;

public interface ISqlQueryable<TResult, TArgument> {
    TResult execute(Statement statement, TArgument arg) throws SQLException;
}
