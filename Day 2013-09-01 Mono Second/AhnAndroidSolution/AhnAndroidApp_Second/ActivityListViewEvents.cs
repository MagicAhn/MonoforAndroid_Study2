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
using Java.Security;

namespace AhnAndroidApp_Second
{
    [Activity(Label = "My Activity", MainLauncher = false, Icon = "@drawable/icon")]
    public class ActivityListViewEvents : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Create your application here
            SetContentView(Resource.Layout.ListViewLayout3);

            var loveme = new string[]
            {
                GetString(Resource.String.love4),GetString(Resource.String.love5),GetString(Resource.String.love6)
            };

            var adapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, loveme);
            FindViewById<ListView>(Resource.Id.listView).Adapter = adapter;

            //args.Position 为当前点击的 位置
            FindViewById<ListView>(Resource.Id.listView).ItemClick += (sender, args) => Toast.MakeText(this, adapter.GetItem(args.Position), ToastLength.Long).Show();

            //ContextMenu
            RegisterForContextMenu(FindViewById<ListView>(Resource.Id.listView));
        }

        public override void OnCreateContextMenu(IContextMenu menu, View v, IContextMenuContextMenuInfo menuInfo)
        {
            //base.OnCreateContextMenu(menu, v, menuInfo);
            var listView = FindViewById<ListView>(Resource.Id.listView);
            if (v != listView) return;
            menu.Add(0, (Int32)PunishMethod.DishWashing, 0, GetString(Resource.String.punish1));
            menu.Add(0, (Int32)PunishMethod.MoppingTheFloor, 1, GetString(Resource.String.punish2));
        }

        public override Boolean OnContextItemSelected(IMenuItem item)
        {
            var listView = FindViewById<ListView>(Resource.Id.listView);
            var menuInfo = (Android.Widget.AdapterView.AdapterContextMenuInfo)item.MenuInfo;

            if (item.ItemId == (Int32)PunishMethod.DishWashing)
            {
                Toast.MakeText(this, GetString(Resource.String.punish1) + GetString(Resource.String.feedback), ToastLength.Short).Show();
            }
            else if (item.ItemId == (Int32)PunishMethod.MoppingTheFloor)
            {
                Toast.MakeText(this, GetString(Resource.String.punish2) + GetString(Resource.String.feedback), ToastLength.Short).Show();
            }
            return true;
            //return base.OnContextItemSelected(item);
        }
    }

    public enum PunishMethod
    {
        DishWashing = 100,
        MoppingTheFloor
    }
}