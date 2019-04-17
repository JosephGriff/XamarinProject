using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLitePCL;
using SQLite;
namespace XamarinAppProject
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UpdateCharPage : ContentPage
	{
        Character selectedCharacter;

		public UpdateCharPage (Character selectedCharacter)
		{
			InitializeComponent ();
            //selected values of the chosen item in the database
            this.selectedCharacter = selectedCharacter;

            nameEntry.Text = selectedCharacter.Name;
            classEntry.Text = selectedCharacter.Class;
		}

        //when clicked/tapped the selected items from the data base are updated.
        private void UpdateButton_Clicked(object sender, EventArgs e)
        {
            selectedCharacter.Name = nameEntry.Text;
            selectedCharacter.Class = classEntry.Text;

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<Character>();
                // .Update is an inbuilt function in SQlite that updates the selected values.
                var numberOfRows = conn.Update(selectedCharacter);

                //Displays a alert box depending on the result.
                if (numberOfRows > 0)
                    DisplayAlert("Success", "Character Updated", "Great");
                else
                    DisplayAlert("Failure", "Failed to Update Character", "Try again");


            }
        }

        //when clicked/tapped the selected items from the database are deleted.
        private void DeleteButton_Clicked(object sender, EventArgs e)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<Character>();
                // .Delete is an inbuilt function in SQlite that Deletes the selected values.
                var numberOfRows = conn.Delete(selectedCharacter);

                //Displays a alert box depending on the result.
                if (numberOfRows > 0)
                    DisplayAlert("Success", "Character Deleted", "Great");
                else
                    DisplayAlert("Failure", "Failed to Delete Character", "Try again");


            }
        }
    }
}