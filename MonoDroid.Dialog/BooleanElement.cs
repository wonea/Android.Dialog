﻿using System;
using Android.Content;
using Android.Text;
using Android.Views;
using Android.Widget;

namespace MonoDroid.Dialog
{
    public abstract class BoolElement : Element
    {
        private bool val;

        public bool Value
        {
            get { return val; }
            set
            {
                bool emit = val != value;
                val = value;
                if (emit && ValueChanged != null)
                    ValueChanged(this, EventArgs.Empty);
            }
        }

        public event EventHandler ValueChanged;

        public BoolElement(string caption, bool value)
            : base(caption)
        {
            val = value;
        }

        public override string Summary()
        {
            return val ? "On" : "Off";
        }
    }

    /// <summary>
    /// Used to display toggle button on the screen.
    /// </summary>
    public class BooleanElement : BoolElement
    {
        private readonly Context _context;
        private static string bkey = "BooleanElement";
        private ToggleButton sw;
        private TextView tv;

        public BooleanElement(Context context, string caption, bool value)
            : base(caption, value)
        {
            _context = context;
        }

        public BooleanElement(Context context, string caption, bool value, string key)
            : this(context, caption, value)
        {
        }

        public override View GetView()
        {
            var view = new RelativeLayout(_context);

            var parms = new RelativeLayout.LayoutParams(ViewGroup.LayoutParams.WrapContent,
                                                        ViewGroup.LayoutParams.WrapContent);
            parms.SetMargins(5, 3, 5, 0);
            parms.AddRule((int) LayoutRules.CenterVertical);

            tv = new TextView(_context) {Text = Caption, TextSize = 16f};
            view.AddView(tv, parms);

            var sparms = new RelativeLayout.LayoutParams(ViewGroup.LayoutParams.WrapContent,
                                                         ViewGroup.LayoutParams.WrapContent);
            sparms.SetMargins(5, 3, 5, 0);
            sparms.AddRule((int) LayoutRules.CenterVertical);
            sparms.AddRule((int) LayoutRules.AlignParentRight);

            sw = new ToggleButton(_context) {Tag = 1, Checked = Value};

            view.AddView(sw, sparms);
            return view;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                sw.Dispose();
                sw = null;
                tv.Dispose();
                tv = null;
            }
        }
    }
}