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
    [Activity(Label = "Hello My Feng", MainLauncher = false, Icon = "@drawable/icon")]
    public class ActivityItemChoose : Activity
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

            SetContentView(Resource.Layout.ListViewLayout2);

            var listView1 = FindViewById<ListView>(Resource.Id.listView1);
            listView1.Adapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItemMultipleChoice, loveu);
            listView1.ItemsCanFocus = true;
            listView1.ChoiceMode = ChoiceMode.Multiple;

            FindViewById<Button>(Resource.Id.btnChoose).Click += (sender, args) =>
            {
                #region Code 不够精简
                //var items = listView1.CheckedItemPositions;
                //StringBuilder sb = new StringBuilder();


                //items.Size()为选中的总条数
                //for (var i = 0; i < items.Size(); i++)
                //{
                // 第i条选中项在 listview中的 position
                //    Int32 position = items.KeyAt(i);
                //    var adapter = (ArrayAdapter<String>)FindViewById<ListView>(Resource.Id.listView1).Adapter;
                //    String str = adapter.GetItem(position);
                //    sb.Append(str);
                //}
                //Toast.MakeText(this, sb.ToString(), ToastLength.Long).Show(); 
                #endregion

                StringBuilder sb = new StringBuilder();
                for (Int32 i = 0; i < listView1.CheckedItemPositions.Size(); i++)
                {
                    sb.Append(((ArrayAdapter<String>)listView1.Adapter).GetItem(listView1.CheckedItemPositions.KeyAt(i)));
                }
                Toast.MakeText(this, sb.ToString(), ToastLength.Long).Show();
            };
        }
    }
}