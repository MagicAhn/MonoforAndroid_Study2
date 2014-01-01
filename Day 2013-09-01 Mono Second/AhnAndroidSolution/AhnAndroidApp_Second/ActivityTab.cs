using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AhnAndroidApp_Second
{
    [Activity(Label = "@string/love", MainLauncher = false, Icon = "@drawable/icon")]
    public class ActivityTab : TabActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Create your application here
            var loveu = new String[]
                {
                    GetString(Resource.String.love1), GetString(Resource.String.love2),
                    GetString(Resource.String.love3)
                };
            var loveme = new string[]
            {
                GetString(Resource.String.love4),GetString(Resource.String.love5),GetString(Resource.String.love6)
            };

            //这个不可少
            LayoutInflater.From(this).Inflate(Resource.Layout.TabLayout, TabHost.TabContentView, true);

            TabHost.AddTab(TabHost.NewTabSpec(GetString(Resource.String.loveFeng)).SetIndicator(GetString(Resource.String.loveFeng), Resources.GetDrawable(Resource.Drawable.Icon)).SetContent(Resource.Id.LoveTab1));
            FindViewById<Spinner>(Resource.Id.MySpinner1).Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerItem, loveu);
            FindViewById<Spinner>(Resource.Id.MySpinner1).ItemSelected += (sender, args) => Toast.MakeText(this, loveu[args.Position], ToastLength.Short).Show();
            FindViewById<Spinner>(Resource.Id.MySpinner2).Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerItem, loveme);
            FindViewById<Spinner>(Resource.Id.MySpinner2).ItemSelected += (sender, args) => Toast.MakeText(this, loveme[args.Position], ToastLength.Short).Show();

            TabHost.AddTab(TabHost.NewTabSpec(GetString(Resource.String.loveAhn)).SetIndicator(GetString(Resource.String.loveAhn), Resources.GetDrawable(Resource.Drawable.Icon)).SetContent(Resource.Id.LoveTab2));
            FindViewById<Spinner>(Resource.Id.MySpinner3).Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerItem, loveme);
            FindViewById<Spinner>(Resource.Id.MySpinner3).ItemSelected += (sender, args) => Toast.MakeText(this, loveme[args.Position], ToastLength.Short).Show();
            FindViewById<Spinner>(Resource.Id.MySpinner4).Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerItem, loveu);
            FindViewById<Spinner>(Resource.Id.MySpinner4).ItemSelected += (sender, args) => Toast.MakeText(this, loveu[args.Position], ToastLength.Short).Show();
        }
    }
}