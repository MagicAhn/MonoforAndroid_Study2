using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Versioning;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace AhnNote
{
    [Activity(Label = "AhnNote", MainLauncher = true, Icon = "@drawable/icon")]
    public class Activity1 : Activity
    {
        private const Int32 MENU_ADD = 1;
        private const Int32 MENU_REFRESH = 2;
        private const Int32 MENU_REMOVE = 3;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //扫描磁盘上的 /SDcard/note 文件夹
            //没有SDcard，没有note文件夹
            //也可以使用 java代码
            if (!Directory.Exists("/sdcard/"))
            {
                Toast.MakeText(this, Resource.String.NoSDcard, ToastLength.Short).Show();
                return;
            }
            if (!Directory.Exists("/sdcard/note/"))
            {
                Directory.CreateDirectory("/sdcard/note/");
            }

            var listView = FindViewById<ListView>(Resource.Id.listView);

            listView.ItemClick += (sender, args) =>
            {
                var adapter = listView.Adapter;
                var item = ((NoteItemAdapter)adapter).GetItem(args.Position);

                var builder = new AlertDialog.Builder(this);
                builder.SetTitle(Resource.String.view);

                var editDlgView = LayoutInflater.From(this).Inflate(Resource.Layout.layoutEditDialog, null);
                builder.SetView(editDlgView);

                var editTitle = editDlgView.FindViewById<EditText>(Resource.Id.editTitle);
                var editContent = editDlgView.FindViewById<EditText>(Resource.Id.editContent);
                editTitle.Enabled = false;
                editTitle.Text = ((NoteItem) item).Title;
                editContent.Text = File.ReadAllText("/sdcard/note/" + ((NoteItem)item).Title + ".txt");

                builder.SetPositiveButton(Android.Resource.String.Ok, (sender1, args1) =>
                {
                    var title = editTitle.Text;
                    var content = editContent.Text;

                    File.WriteAllText("/sdcard/note/" + title + ".txt", content);

                    ReloadData();
                });
                builder.SetNegativeButton(Android.Resource.String.No, (IDialogInterfaceOnClickListener)null);

                builder.Show();
            };

            listView.ChoiceMode = ChoiceMode.Multiple;

            RegisterForContextMenu(listView);

            ReloadData();
        }

        private void ReloadData()
        {
            var listView = FindViewById<ListView>(Resource.Id.listView);

            var adapter = new NoteItemAdapter(this, listView);
            foreach (var filename in Directory.GetFiles("/sdcard/note/", "*.txt"))
            {
                var noteitem = new NoteItem();
                noteitem.Title = Path.GetFileNameWithoutExtension(filename);
                noteitem.Content = File.ReadAllText(filename);
                noteitem.UpdateTime = File.GetLastWriteTime(filename);

                adapter.Add(noteitem);
            }

            listView.Adapter = adapter;
        }

        public override Boolean OnCreateOptionsMenu(IMenu menu)
        {
            menu.Add(0, MENU_ADD, 0, Resource.String.menu_add);
            menu.Add(0, MENU_REFRESH, 1, Resource.String.menu_refresh);
            menu.Add(0, MENU_REMOVE, 2, Resource.String.menu_remove);

            return true;
        }

        public override Boolean OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == MENU_ADD)
            {
                var view = LayoutInflater.From(this).Inflate(Resource.Layout.layoutEditDialog, null);

                var builder = new AlertDialog.Builder(this);

                builder.SetTitle(Resource.String.title_menu_add);
                builder.SetView(view);
                //DialogClickEventArgs
                builder.SetPositiveButton(Android.Resource.String.Ok, (sender, args) =>
                {
                    var title = view.FindViewById<EditText>(Resource.Id.editTitle).Text;
                    var content = view.FindViewById<EditText>(Resource.Id.editContent).Text;

                    File.WriteAllText("/sdcard/note/" + title + ".txt", content);

                    ReloadData();
                });
                builder.SetNegativeButton(Android.Resource.String.Cancel, (IDialogInterfaceOnClickListener)null);

                builder.Show();
            }

            else if (item.ItemId == MENU_REFRESH)
            {
                ReloadData();
            }

            else if (item.ItemId == MENU_REMOVE)
            {
                var builder = new AlertDialog.Builder(this);

                builder.SetTitle(Resource.String.title_menu_remove);
                builder.SetMessage(Resource.String.confirm_batchremove);

                builder.SetPositiveButton(Android.Resource.String.Ok, (sender, args) =>
                {
                    var adapter = FindViewById<ListView>(Resource.Id.listView).Adapter;

                    var checkedPositions = FindViewById<ListView>(Resource.Id.listView).CheckedItemPositions;

                    for (int i = 0; i < checkedPositions.Size(); i++)
                    {
                        Int32 index = checkedPositions.KeyAt(i);
                        NoteItem noteitem = ((NoteItemAdapter)adapter).GetItem(index);

                        File.Delete("/sdcard/" + noteitem.Title + ".txt");
                    }
                });

                builder.SetNegativeButton(Android.Resource.String.No, (IDialogInterfaceOnClickListener)null);

                builder.Show();
            }
            return true;
        }

        public override void OnCreateContextMenu(IContextMenu menu, View v, IContextMenuContextMenuInfo menuInfo)
        {
            var view = FindViewById<ListView>(Resource.Id.listView);
            if (v == view)
            {
                menu.Add(0, MENU_REMOVE, 0, Resource.String.remove);
            }
        }

        public override Boolean OnContextItemSelected(IMenuItem item)
        {
            if (item.ItemId == MENU_REMOVE)
            {
                //取得 listView 绑定的数据源
                var adapter = FindViewById<ListView>(Resource.Id.listView).Adapter;
                //所选的 菜单信息
                var menuInfo = (Android.Widget.AdapterView.AdapterContextMenuInfo)item.MenuInfo;
                //根据所选弹出菜单的 Position 得到具体的 note
                NoteItem note = ((NoteItemAdapter)adapter).GetItem(menuInfo.Position);

                //弹出框
                var builderConfirm = new AlertDialog.Builder(this);
                //设置 弹出框的按钮
                builderConfirm.SetTitle(Resource.String.prompt);
                String msg = String.Format(Resources.GetString(Resource.String.confirm_remove), note.Title);
                builderConfirm.SetMessage(msg);
                builderConfirm.SetPositiveButton(Android.Resource.String.Yes, (sender, args) =>
                {
                    File.Delete("/sdcard/note/" + note.Title + ".txt");
                    ReloadData();
                });
                builderConfirm.SetNegativeButton(Android.Resource.String.No, (IDialogInterfaceOnClickListener)null);

                builderConfirm.Show();
            }

            return true;
        }
    }
}

