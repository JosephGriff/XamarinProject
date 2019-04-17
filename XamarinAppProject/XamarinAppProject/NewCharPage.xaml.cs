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
	public partial class NewCharPage : ContentPage
	{
		public NewCharPage ()
		{
			InitializeComponent ();
		}

        //When clicked/tapped the inputted data is sent to the database
        private void Button_Clicked(object sender, EventArgs e)
        {
            Character character = new Character()
            {
                Name = nameEntry.Text,
                Class = classEntry.Text
            

            };

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<Character>();
                // .Insert is an inbuilt function in SQlite that Inserts the selected values into the database
                var numberOfRows = conn.Insert(character);

                //Displays a alert box depending on the result
                if (numberOfRows > 0)
                    DisplayAlert("Success", "Character Created!", "Great");
                else
                    DisplayAlert("Failure", "Failed to make Character", "Try again");

              
            }
            
            

        }
    }
}