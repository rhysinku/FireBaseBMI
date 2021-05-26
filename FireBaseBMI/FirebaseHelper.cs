using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using FireBaseBMI.Model;

namespace FireBaseBMI
{
    class FirebaseHelper
    {
        FirebaseClient firebase = new FirebaseClient("https://fir-bmi-fa52f-default-rtdb.firebaseio.com/");

        public async Task<List<Database>> getdata()
        {

            return (await firebase
                .Child("Data")
                .OnceAsync<Database>()).Select(item => new Database
                {
                    Name = item.Object.Name,
                    Height = item.Object.Height,
                    Weight = item.Object.Weight,
                    Status = item.Object.Status,
                    BMI = item.Object.BMI

                }).ToList();
        }

        public async Task AddData (string name, double weight, double height, string status, double bmi)
        {
            await firebase
                .Child("Data")
                .PostAsync(new Database() { Name = name, Weight = weight, Height = height, Status = status, BMI = bmi });
        }
    }
}
