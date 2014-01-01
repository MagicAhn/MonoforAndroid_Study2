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

namespace UIDemos
{
    [Activity(Label = "Picker", MainLauncher = true, Icon = "@drawable/icon")]
    public class ActivityPicker : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Create your application here

            SetContentView(Resource.Layout.layoutPicker);

            Int32 nowHour = 0, nowMinute = 0;

            FindViewById<Button>(Resource.Id.btnGetValue).Click += (obj, sender) =>
            {
                FindViewById<TextView>(Resource.Id.dctxtView).Text =
                    FindViewById<DigitalClock>(Resource.Id.digitalClock).Text;

                var datepicker = FindViewById<DatePicker>(Resource.Id.datepicker);

                FindViewById<TextView>(Resource.Id.dctxtView).Text =
                    new DateTime(datepicker.Year, datepicker.Month + 1, datepicker.DayOfMonth, nowHour, nowMinute, 0).ToString();
            };

            FindViewById<TimePicker>(Resource.Id.timepicker).TimeChanged += (timeObj, timeChangeSender) =>
            {
                nowHour = timeChangeSender.HourOfDay;
                nowMinute = timeChangeSender.Minute;
            };

            FindViewById<Button>(Resource.Id.btnClose).Click += (objClose, senderClose) => this.Finish();
        }

    }
}