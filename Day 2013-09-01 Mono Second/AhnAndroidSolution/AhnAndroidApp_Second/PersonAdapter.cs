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

        //convertView指的是 被复用的 View 
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            //得到要画的数据模型
            var person = GetItem(position);

            //实例化 Layout
            //优化：判断View是否可以被复用，如果可以，则直接用 可复用的View，否则，使用 新建的View
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