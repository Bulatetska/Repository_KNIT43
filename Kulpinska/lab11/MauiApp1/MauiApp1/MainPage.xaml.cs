namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }


        private void OnHelloButtonClicked(object sender, EventArgs e)
        {
            HelloButton.Text = "Ви натиснули на кнопку!";
        }
    }
}
