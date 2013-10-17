using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Demo4
{
    [Activity(Label = "Demo4", MainLauncher = true, Icon = "@drawable/icon")]
    public class Activity1 : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);

            button.Click += (sender, args) =>
            {
                var intent = new Intent();
                intent.SetClass(this, typeof(ActivitySeleteImage));

                // 当调用的Activity返回之后，会把 返回结果 调用 OnActivityResult 通知
                // 最后一个参数 传递到 OnActivityResult 的 第一个参数，用来区分 StartActivityForResult 的返回结果
                // 区分：是选择图片 还是选择音乐
                StartActivityForResult(intent, 222);
            };
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (requestCode == 222 && resultCode == Result.Ok)
            {
                String filename = data.GetStringExtra("Result");
                Toast.MakeText(this, filename, ToastLength.Long).Show();
            }
        }

        protected override void OnStart()
        {
            base.OnStart();
            Log.Debug("", "OnStart");
        }

        protected override void OnResume()
        {
            base.OnResume();
            Log.Debug("", "OnResume");
        }

        protected override void OnRestart()
        {
            base.OnRestart();
            Log.Debug("", "OnRestart");
        }
    }
}

