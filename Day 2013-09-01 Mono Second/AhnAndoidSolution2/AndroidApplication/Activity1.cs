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

namespace AndroidApplication
{
    [Activity(Label = "My Activity", MainLauncher = true)]
    public class Activity1 : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Create your application here
            SetContentView(Resource.Layout.layout1);

            FindViewById<Button>(Resource.Id.btn1).Click += (obj, sender) =>
            {
                var intent = new Intent();
                intent.SetClass(this, typeof(Activity2));
                StartActivity(intent);
                //如果不调用 Finish，还可以后退
                Finish();
            };
        }
    }
}