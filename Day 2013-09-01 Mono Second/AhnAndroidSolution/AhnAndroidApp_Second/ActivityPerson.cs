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
using Java.Lang;

namespace AhnAndroidApp_Second
{
    [Activity(Label = "Love Declaration", MainLauncher = false, Icon = "@drawable/icon")]
    public class ActivityPerson : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Create your application here

            SetContentView(Resource.Layout.ListViewLayout);

            var person = new[]
            {
                new Person{Name="�ﱦ��",Age=24,Gender=Gender.Female,ImageId=Android.Resource.Drawable.IcInputAdd},
                new Person{Name="С����",Age=24,Gender=Gender.Male,ImageId=Android.Resource.Drawable.IcInputAdd}
            };

            var adapter = new PersonAdapter(this);
            adapter.Add(new Person { Name = "�ﱦ��", Age = 24, Gender = Gender.Female, ImageId = Android.Resource.Drawable.IcInputAdd });
            adapter.Add(new Person { Name = "С����", Age = 24, Gender = Gender.Male, ImageId = Android.Resource.Drawable.IcInputAdd });

            #region ���� ��Դ���ã�View���Ĵ���
            //adapter.Add(new Person { Name = "�ﱦ��", Age = 24, Gender = Gender.Female, ImageId = Android.Resource.Drawable.IcInputAdd });
            //adapter.Add(new Person { Name = "С����", Age = 24, Gender = Gender.Male, ImageId = Android.Resource.Drawable.IcInputAdd });
            //adapter.Add(new Person { Name = "�ﱦ��", Age = 24, Gender = Gender.Female, ImageId = Android.Resource.Drawable.IcInputAdd });
            //adapter.Add(new Person { Name = "С����", Age = 24, Gender = Gender.Male, ImageId = Android.Resource.Drawable.IcInputAdd });
            //adapter.Add(new Person { Name = "�ﱦ��", Age = 24, Gender = Gender.Female, ImageId = Android.Resource.Drawable.IcInputAdd });
            //adapter.Add(new Person { Name = "С����", Age = 24, Gender = Gender.Male, ImageId = Android.Resource.Drawable.IcInputAdd });
            //adapter.Add(new Person { Name = "�ﱦ��", Age = 24, Gender = Gender.Female, ImageId = Android.Resource.Drawable.IcInputAdd });
            //adapter.Add(new Person { Name = "С����", Age = 24, Gender = Gender.Male, ImageId = Android.Resource.Drawable.IcInputAdd });
            //adapter.Add(new Person { Name = "�ﱦ��", Age = 24, Gender = Gender.Female, ImageId = Android.Resource.Drawable.IcInputAdd });
            //adapter.Add(new Person { Name = "С����", Age = 24, Gender = Gender.Male, ImageId = Android.Resource.Drawable.IcInputAdd });
            //adapter.Add(new Person { Name = "�ﱦ��", Age = 24, Gender = Gender.Female, ImageId = Android.Resource.Drawable.IcInputAdd });
            //adapter.Add(new Person { Name = "С����", Age = 24, Gender = Gender.Male, ImageId = Android.Resource.Drawable.IcInputAdd });
            //adapter.Add(new Person { Name = "�ﱦ��", Age = 24, Gender = Gender.Female, ImageId = Android.Resource.Drawable.IcInputAdd });
            //adapter.Add(new Person { Name = "С����", Age = 24, Gender = Gender.Male, ImageId = Android.Resource.Drawable.IcInputAdd });
            //adapter.Add(new Person { Name = "�ﱦ��", Age = 24, Gender = Gender.Female, ImageId = Android.Resource.Drawable.IcInputAdd });
            //adapter.Add(new Person { Name = "С����", Age = 24, Gender = Gender.Male, ImageId = Android.Resource.Drawable.IcInputAdd });
            //adapter.Add(new Person { Name = "�ﱦ��", Age = 24, Gender = Gender.Female, ImageId = Android.Resource.Drawable.IcInputAdd });
            //adapter.Add(new Person { Name = "С����", Age = 24, Gender = Gender.Male, ImageId = Android.Resource.Drawable.IcInputAdd }); 
            #endregion

            FindViewById<ListView>(Resource.Id.listView1).Adapter = adapter;
        }

    }
}