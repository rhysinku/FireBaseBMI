using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FireBaseBMI
{
    public partial class MainPage : ContentPage
    {

        FirebaseHelper firebasedb = new FirebaseHelper();
        public MainPage()
        {
            InitializeComponent();
        }


        private async void addClicked (object sender, EventArgs e)
        {
            string status;
            double bmi;

            bmi = Math.Round((double.Parse(Weight.Text) / double.Parse(Height.Text) / double.Parse(Height.Text)) * 10000 ,2);

            if (bmi < 18.50)
            {
                status = "UnderWeight";
            }
            else if (bmi < 24.99)
            {
                status = "Normal Weight";
            }
            else if (bmi < 29.99)
            {
                status = "Over Weight";
            }
            else
            {
                status = "Obese";
            }

            

            await firebasedb.AddData(Name.Text, double.Parse(Weight.Text), double.Parse(Height.Text),status, bmi);
            

            string display = "\n Name: "+Name.Text+
                "\n Weight: "+Weight.Text+
                "\n Height: "+Height.Text+
                "\n BMI: " +bmi+
                "\n Status: " +status;
            await DisplayAlert("Success", "Data Inserted" +display, "OK");

            Name.Text = string.Empty;
            Weight.Text = string.Empty;
            Height.Text = string.Empty;
        }
    }
}
