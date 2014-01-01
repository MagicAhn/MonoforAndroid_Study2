using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AhnAndroidApp_Second
{
    internal class PersonAdapter : ArrayAdapter<Person>
    {
        public PersonAdapter(Context context) : base(context, 0) { }

        //convertViewָ���� �����õ� View 
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            //�õ�Ҫ��������ģ��
            var person = GetItem(position);

            //ʵ���� Layout
            //�Ż����ж�View�Ƿ���Ա����ã�������ԣ���ֱ���� �ɸ��õ�View������ʹ�� �½���View
            View view;
            view = convertView ?? LayoutInflater.From(Context).Inflate(Resource.Layout.LayoutPerson, null);

            view.FindViewById<ImageView>(Resource.Id.imgPerson).SetImageResource(person.ImageId);
            view.FindViewById<TextView>(Resource.Id.txtName).Text = person.Name;
            view.FindViewById<TextView>(Resource.Id.txtAge).Text = person.Age.ToString();
            view.FindViewById<TextView>(Resource.Id.txtGender).Text = person.Gender.ToString();

            return view;
        }
    }
}