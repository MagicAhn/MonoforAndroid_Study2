using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AndroidApplication
{
    [Activity(Label = "My Activity", MainLauncher = false)]
    public class ActivityImgView : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Create your application here

            SetContentView(Resource.Layout.layoutImageView);

            var imgView = FindViewById<ImageView>(Resource.Id.imgView);
            imgView.SetImageBitmap(BitmapFactory.DecodeFile("/sdcard/DCIM/ForTest/2013_07_22_13_07_08.jpg", new BitmapFactory.Options { InSampleSize = 4 }));
        }
    }
}