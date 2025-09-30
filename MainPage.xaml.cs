namespace TrivialGeografico
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCapitalesClicked(object? sender, EventArgs e)
        {
            Navigation.PushAsync(new CapitalesPage());
        }

        private void OnPaisesClicked(object? sender, EventArgs e)
        {
            Navigation.PushAsync(new PaisesPage());
        }
    }
}
