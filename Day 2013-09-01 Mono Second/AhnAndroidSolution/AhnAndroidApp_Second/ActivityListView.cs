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
    [Activity(Label = "Love Declaration", MainLauncher = false, Icon = "@drawable/icon")]
    public class ActivityListView : Activity
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

            SetContentView(Resource.Layout.ListViewLayout);

            FindViewById<ListView>(Resource.Id.listView1).Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, loveu);
            FindViewById<ListView>(Resource.Id.listView1).ItemClick += (sender, args) => Toast.MakeText(this,loveu[args.Position],ToastLength.Long).Show();
        }
    }
}