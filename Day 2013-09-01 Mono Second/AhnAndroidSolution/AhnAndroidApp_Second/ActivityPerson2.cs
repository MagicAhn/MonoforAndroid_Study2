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
    [Activity(Label = "Love Declaration", MainLauncher = true, Icon = "@drawable/icon")]
    public class ActivityPerson2 : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Create your application here
            SetContentView(Resource.Layout.ListViewLayout3);

            var adapter = new PersonAdapter2(this);
            adapter.Add(new Person { Name = "·ï±¦±¦", Age = 24, Gender = Gender.Female, ImageId = Android.Resource.Drawable.IcInputAdd });
            adapter.Add(new Person { Name = "Ð¡°²×Ó", Age = 24, Gender = Gender.Male, ImageId = Android.Resource.Drawable.IcInputGet });

            FindViewById<ListView>(Resource.Id.listView).Adapter = adapter;

            FindViewById<ListView>(Resource.Id.listView).ItemClick +=
                (sender, args) => Toast.MakeText(this, adapter.GetItem(args.Position).Name, ToastLength.Long).Show();
        }
    }
}