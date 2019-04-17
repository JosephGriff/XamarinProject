using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinAppProject
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        
        //Navigates to character Creation page
        private void Clicked_Add(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewCharPage());
        }

        //Navigates to character Roster page
        private void Clicked_Roster(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CharRosterPage());
        }

        //Navigates to character Races page
        private void Clicked_Races(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RacesPage());
        }

        //Navigates to character Classes page
        private void Clicked_Classes(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ClassesPage());

        }
    }
}
