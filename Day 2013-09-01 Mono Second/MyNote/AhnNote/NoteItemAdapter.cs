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
            //�� listView ĳһ���ѡ��״̬���õ� cbSelect
            cbSelect.Checked = _listView.IsItemChecked(position);

            //�� cbSelect�� ѡ��״̬ ���е� listView��
            //Lambda Expression ���壬CSharp �հ�
            //cbSelect.CheckedChange += (obj, sender) => _listView.SetItemChecked(position, cbSelect.Selected);
            cbSelect.CheckedChange += new EventHandler<CompoundButton.CheckedChangeEventArgs>(cbSelect_CheckedChange);


            //����ͨ�� ���������ϵ� CheckBox �������ѡ���У���Ϊ GetView���õ�����
            //����ͨ�� ��ȡ_listView.CheckedItemPositions ����ã������ͨ�� listView.SetItemChecked(position, cbSelect.Selected) ���趨�� ѡ��״̬
            //var i = _listView.CheckedItemPositions;

            return view;
        }

        void cbSelect_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            //��Ҫ���� Lambda Expression �հ�������
            var cbSelect = sender as CheckBox;
            //�� cbSelect�� ѡ��״̬ ���е� listView��
            if (cbSelect != null)
            {
                var position = (Int32)cbSelect.Tag;
                _listView.SetItemChecked(position,cbSelect.Checked);
            }
        }
    }
}