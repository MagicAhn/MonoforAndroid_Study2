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

namespace AhnNote
{
    class NoteItemAdapter : ArrayAdapter<NoteItem>
    {
        private ListView _listView;

        public NoteItemAdapter(Context context, ListView listView) : base(context, 0)
        {
            this._listView = listView;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ??
                       LayoutInflater.From(this.Context).Inflate(Resource.Layout.layoutListViewItem, null);


            var noteItem = GetItem(position);

            view.FindViewById<TextView>(Resource.Id.txtTitle).Text = noteItem.Title;
            view.FindViewById<TextView>(Resource.Id.txtDate).Text = noteItem.UpdateTime.ToShortDateString();

            var cbSelect = view.FindViewById<CheckBox>(Resource.Id.chkChoose);
            cbSelect.Tag = position;
            //把 listView 某一项的选中状态设置到 cbSelect
            cbSelect.Checked = _listView.IsItemChecked(position);

            //把 cbSelect的 选择状态 更行到 listView中
            //Lambda Expression 陷阱，CSharp 闭包
            //cbSelect.CheckedChange += (obj, sender) => _listView.SetItemChecked(position, cbSelect.Selected);
            cbSelect.CheckedChange += new EventHandler<CompoundButton.CheckedChangeEventArgs>(cbSelect_CheckedChange);


            //不能通过 遍历界面上的 CheckBox 获得所有选中行，因为 GetView复用的问题
            //而是通过 读取_listView.CheckedItemPositions 来获得，编程则通过 listView.SetItemChecked(position, cbSelect.Selected) 来设定其 选中状态
            //var i = _listView.CheckedItemPositions;

            return view;
        }

        void cbSelect_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            //不要掉入 Lambda Expression 闭包的陷阱
            var cbSelect = sender as CheckBox;
            //把 cbSelect的 选择状态 更行到 listView中
            if (cbSelect != null)
            {
                var position = (Int32)cbSelect.Tag;
                _listView.SetItemChecked(position,cbSelect.Checked);
            }
        }
    }
}