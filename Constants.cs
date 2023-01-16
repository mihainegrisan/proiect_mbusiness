using SQLite;

namespace TodoApp;
public static class Constants
{
    public const string DatabaseFilename = "TodoSQLite.db3";

    // The value of the variable is the result of a bitwise OR operation between the following SQLiteOpenFlags enumeration values:
    // - SQLite.SQLiteOpenFlags.ReadWrite: The database is opened for reading and writing.
    // - SQLite.SQLiteOpenFlags.Create: The database is created if it does not exist.
    // - SQLite.SQLiteOpenFlags.SharedCache: The database connection will be eligible to use shared cache mode.

    // These flags are used to specify the file opening and locking behavior when opening a database connection with SQLite.
    // SQLiteOpenFlags is an enumeration, so we can use the OR operator to combine multiple values of the enumeration.These flags are used when opening a connection to the SQLite database to specify the behavior of the connection.

    public const SQLiteOpenFlags Flags =
        SQLiteOpenFlags.ReadWrite |
        SQLiteOpenFlags.Create |
        SQLiteOpenFlags.SharedCache;

    public static string DatabasePath
    {
        get
        {
            // create the path on the filesystem
            var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            return Path.Combine(basePath, DatabaseFilename);
        }
    }
}
