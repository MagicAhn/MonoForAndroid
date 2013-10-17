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

namespace Demo4
{
    class ImageAdapter : ArrayAdapter<String>
    {
        public ImageAdapter(Context context) : base(context, 0) { }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = (ImageView)convertView ?? new ImageView(Context);

            String filename = GetItem(position);
            view.SetImageURI(Android.Net.Uri.Parse(filename));

            return view;
        }
    }
}