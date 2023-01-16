using System.Runtime.CompilerServices;

namespace TodoApp;

/// <summary>
/// The class has two constructor, one takes a Func<T> and the other takes a Func<Task<T>>. Both constructors create an instance of Lazy<Task<T>> using the factory  passed to it.
/// </summary>
/// <typeparam name="T"></typeparam>
public class AsyncLazy<T>
{
    readonly Lazy<Task<T>> instance;

    public AsyncLazy(Func<Task<T>> factory) {
        instance = new Lazy<Task<T>>(() => Task.Run(factory));
    }
    
    public TaskAwaiter<T> GetAwaiter()
    {
        // It returns the TaskAwaiter for the Lazy<Task<T>> instance.
        // It allows us to await the lazy-initialized task.
        return instance.Value.GetAwaiter();
    }

    public void Start()
    {
        // This will trigger the factory method and start the task.
        var unused = instance.Value;
    }
}
