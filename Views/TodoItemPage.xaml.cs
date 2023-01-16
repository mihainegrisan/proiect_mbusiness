using TodoApp.Data;
using TodoApp.Models;

namespace TodoApp.Views;

/// <summary>
/// The class defines three event handlers, one for each button "Save", "Delete", and "Cancel" in the XAML code.
/// [XamlCompilation(XamlCompilationOptions.Compile)] attribute tells Xamarin.Forms to precompile the XAML markup for the class at build time, which can improve the performance of the application.
/// </summary>
[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class TodoItemPage : ContentPage
{
    public TodoItemPage()
    {
        // initialize the visual elements defined in the XAML code.
        InitializeComponent();
    }

    // Called when the "Save" button is clicked. It gets the TodoItem object that is currently bound to the page's BindingContext and saves it to the TodoItemDatabase. After that, it pops the current page from the navigation stack using Navigation.PopAsync() (in order to return to the previous page).
    async void OnSaveClicked(object sender, EventArgs e)
    {
        var todoItem = (TodoItem)BindingContext;
        TodoItemDatabase database = await TodoItemDatabase.Instance;
        await database.SaveItemAsync(todoItem);
        await Navigation.PopAsync();
    }

    // Called when the "Delete" button is clicked. It gets the TodoItem object that is currently bound to the page's BindingContext and deletes it from the TodoItemDatabase. After that, it pops the current page from the navigation stack.
    async void OnDeleteClicked(object sender, EventArgs e)
    {
        var todoItem = (TodoItem)BindingContext;
        TodoItemDatabase database = await TodoItemDatabase.Instance;
        await database.DeleteItemAsync(todoItem);
        await Navigation.PopAsync();
    }

    //Called when the "Cancel" button is clicked. It simply pops the current page from the navigation stack.
    async void OnCancelClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}