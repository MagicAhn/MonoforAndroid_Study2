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
    internal class PersonAdapter2 : ArrayAdapter<Person>
    {
        public PersonAdapter2(Context context) : base(context, 0) { }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var person = GetItem(position);

            var view = convertView ?? LayoutInflater.From(Context).Inflate(Resource.Layout.LayoutPerson2, null);

            view.FindViewById<ImageView>(Resource.Id.imgPerson).SetImageResource(person.ImageId);
            view.FindViewById<TextView>(Resource.Id.txtName).Text = person.Name;
            view.FindViewById<TextView>(Resource.Id.txtAge).Text = person.Age.ToString();
            view.FindViewById<TextView>(Resource.Id.txtGender).Text = person.Gender.ToString();
            //view.FindViewById<CheckBox>(Resource.Id.chkBox);

            return view;
        }
    }
}