using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace lab13
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PassengersPage : ContentPage
    {

        public PassengersPage()
        {
            InitializeComponent();
        }

        private void SavePassenger(object sender, EventArgs e)
        {
            var passenger = (Passenger)BindingContext;
            if (!String.IsNullOrEmpty(passenger.Name))
            {
                using (AppDbContext db = new AppDbContext())
                {

                    if (passenger.PassengerId == 0)
                        db.Passengers.Add(passenger);
                    else
                    {
                        db.Passengers.Update(passenger);
                    }
                    db.SaveChanges();
                }
            }
            this.Navigation.PopAsync();
        }
        private void DeletePassenger(object sender, EventArgs e)
        {
            var passenger = (Passenger)BindingContext;
            using (AppDbContext db = new AppDbContext())
            {
                db.Passengers.Remove(passenger);
                db.SaveChanges();
            }
            this.Navigation.PopAsync();
        }
    }
}

