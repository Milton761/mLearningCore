using Android.App;
using Android.OS;
using Cirrious.MvvmCross.Droid.Views;
using Gcm.Client;

using MLearning.Core.ViewModels;
using System.ComponentModel;

namespace MLearning.Droid.Views
{
    [Activity(Label = "View for FirstViewModel")]
    public class MainView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.MainView);

            var vm = ViewModel as MainViewModel;

            vm.PropertyChanged += new PropertyChangedEventHandler(logout_propertyChanged);

            RegisterWithGCM();
        }


        private void RegisterWithGCM()
        {


            if (!GcmClient.IsRegistered(this))
            {
                GcmClient.CheckDevice(this);
                GcmClient.CheckManifest(this);

                // Register for push notifications
                System.Diagnostics.Debug.WriteLine("Registering...");

                
                GcmClient.Register(this, Core.Configuration.Constants.SenderID);

            }





        }


        void logout_propertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsLoggingOut" && (sender as MainViewModel).IsLoggingOut)
            {
                GcmClient.UnRegister(this);
            }
        }



    }
}