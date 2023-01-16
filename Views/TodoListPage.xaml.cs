using TodoApp.Data;
using TodoApp.Models;

namespace TodoApp.Views;

// this attribute tells Xamarin.Forms (yes, .NET MAUI uses code from Xamarin) to precompile the XAML markup for the class at build time, which can improve the performance of the application.
[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class TodoListPage : ContentPage
{
    public TodoListPage()
    {
        // initialize the visual elements defined in the XAML code.
        InitializeComponent();
    }

    // This method is called when the page is displayed. It retrieves the TodoItemDatabase instance and sets the ItemsSource to the list of to-do items retrieved from the database.
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        TodoItemDatabase database = await TodoItemDatabase.Instance;
        listView.ItemsSource = await database.GetItemsAsync();
    }

    // The OnItemAdded method is called when the user taps the "Add" button. It navigates to the TodoItemPage and passes a new TodoItem object as the binding context.
    async void OnItemAdded(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new TodoItemPage
        {
            BindingContext = new TodoItem()
        });
    }

    // The OnListItemSelected method is called when the user taps an item in the list It navigates to the TodoItemPage and passes the selected TodoItem object as the binding context.
    async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new TodoItemPage
            {
                BindingContext = e.SelectedItem as TodoItem
            });
        }
    }
}