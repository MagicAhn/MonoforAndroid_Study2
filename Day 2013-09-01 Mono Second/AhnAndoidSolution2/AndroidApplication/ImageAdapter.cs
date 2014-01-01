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
    class ImageAdapter : ArrayAdapter<String>
    {
        public ImageAdapter(Context context)
            : base(context, 0)
        {
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            ImageView view = (ImageView)convertView ?? new ImageView(Context);

            var option = new BitmapFactory.Options { InSampleSize = 5 };

            var bitmap = BitmapFactory.DecodeFile(GetItem(position), option);

            //view.SetImageURI(Android.Net.Uri.Parse(GetItem(position)));

            view.SetImageBitmap(bitmap);

            //if (!bitmap.IsRecycled)
            //{ bitmap.Recycle(); }

            return view;
        }
    }
}