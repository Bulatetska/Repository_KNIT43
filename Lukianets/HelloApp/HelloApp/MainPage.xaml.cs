namespace HelloApp;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent(); // ⚡ Цей рядок обов’язковий
    }

    private void OnHelloButtonClicked(object sender, EventArgs e)
    {
        HelloButton.Text = "Ви натиснули на кнопку!";
    }
}
