using SQLite;
using TodoApp.Models;

namespace TodoApp.Data;

public class TodoItemDatabase
{
    static SQLiteAsyncConnection Database;

    // The class that accesses the DB
    // Create a property called "Instance" of type AsyncLazy<TodoItemDatabase>. The property initializes an instance of TodoItemDatabase using an asynchronous lambda function that attempts to create a table for the TodoItem class in a database, and returns the instance of TodoItemDatabase. If an exception is thrown in the process, it is thrown again.
    public static readonly AsyncLazy<TodoItemDatabase> Instance =
        new AsyncLazy<TodoItemDatabase>(async () =>
        {
            var instance = new TodoItemDatabase();

            try
            {
                CreateTableResult result = await Database.CreateTableAsync<TodoItem>();
            }
            catch (Exception ex) { throw; }

            return instance;
        });

    public TodoItemDatabase()
    {
        Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
    }

    public Task<List<TodoItem>> GetItemsAsync()
    {
        return Database.Table<TodoItem>().ToListAsync();
    }

    //public Task<List<TodoItem>> GetItemsNotDoneAsync()
    //{
    //    return Database.Table<TodoItem>().Where(item => item.Done == false).ToListAsync();
    //}

    public Task<TodoItem> GetItemAsync(int id)
    {
        return Database.Table<TodoItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
    }

    public Task<int> SaveItemAsync(TodoItem item)
    {
        if (item.ID != 0)
        {
            return Database.UpdateAsync(item);
        }
        else
        {
            return Database.InsertAsync(item);
        }
    }

    public Task<int> DeleteItemAsync(TodoItem item)
    {
        return Database.DeleteAsync(item);
    }
}
