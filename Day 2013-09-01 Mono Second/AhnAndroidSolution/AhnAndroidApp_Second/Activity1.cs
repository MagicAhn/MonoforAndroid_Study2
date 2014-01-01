using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace AhnAndroidApp_Second
{
    [Activity(Label = "AhnAndroidApp_Second", MainLauncher = false, Icon = "@drawable/icon")]
    public class Activity1 : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            var love = new String[]
                {
                    GetString(Resource.String.love1), GetString(Resource.String.love2),
                    GetString(Resource.String.love3)
                };


            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);

            button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };

            FindViewById<Spinner>(Resource.Id.MySpinner).Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerItem, love);
            FindViewById<Spinner>(Resource.Id.MySpinner).ItemSelected += (sender, args) => Toast.MakeText(this, love[args.Position], ToastLength.Long).Show();
        }
    }
}

