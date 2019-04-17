using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinAppProject
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CharRosterPage : ContentPage
	{
		public CharRosterPage()
		{
			InitializeComponent ();
		}

        //displays the information from the database in listform using listview.
        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<Character>();

                var character = conn.Table<Character>().ToList();
                characterListView.ItemsSource = character;
            }
        }

        //when clicked/tapped navigates the user to the update/delete page
        private void CharacterListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedCharacter = characterListView.SelectedItem as Character;

            if (selectedCharacter != null)
            {
                Navigation.PushAsync(new UpdateCharPage(selectedCharacter));
            }
        }
    }
}