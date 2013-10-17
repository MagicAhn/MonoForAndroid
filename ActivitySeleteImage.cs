using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Demo4
{
    [Activity(Label = "My Activity")]
    public class ActivitySeleteImage : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Create your application here
            SetContentView(Resource.Layout.layout1ImageSeleted);

            var adapter = new ImageAdapter(this);

            foreach (var filename in Directory.GetFiles("/sdcard/MyPicture"))
            {
                adapter.Add(filename);
            }

            FindViewById<ListView>(Resource.Id.listview).Adapter = adapter;

            FindViewById<ListView>(Resource.Id.listview).ItemClick += (sender, args) =>
            {
                String filename = adapter.GetItem(args.Position);

                var intent = new Intent();
                // 把 返回结果 放在 Result中
                intent.PutExtra("Result", filename);
                SetResult(Result.Ok,intent);

                // 关闭当前 Activity，可能返回上一个 Activity
                Finish();
            };
        }
    }
}