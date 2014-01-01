using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.IO;

namespace AndroidApplication
{
    [Activity(Label = "ImageGallery", MainLauncher = false, Icon = "@drawable/icon")]
    public class ActivityGallery : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Create your application here
            SetContentView(Resource.Layout.layout_GridView);

            var filenameList = new List<String>();
            LoadImage("/sdcard/DCIM/ForTest", filenameList);
            var imgAdapter = new ImageAdapter(this);

            foreach (var filename in filenameList)
            {
                imgAdapter.Add(filename);
            }

            //FindViewById<GridView>(Resource.Id.imgGrdiView).Adapter = imgAdapter;
            FindViewById<Gallery>(Resource.Id.imgGrdiView).Adapter = imgAdapter;
        }

        private static void LoadImage(String dir, List<String> filenameList)
        {
            var file = new Java.IO.File(dir);
            if (file.CanRead())
            {
                filenameList.AddRange(Directory.GetFiles(dir, "*.jpg"));
                filenameList.AddRange(Directory.GetFiles(dir, "*.png"));

                foreach (var subDir in Directory.GetDirectories(dir))
                {
                    LoadImage(subDir, filenameList);
                }
            }
        }
    }
}