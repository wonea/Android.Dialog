using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content.PM;

using Android.Dialog;
using Android.Graphics;

namespace DialogSampleApp
{
    [Activity(Label = "MonoDroidDialogApp",
        WindowSoftInputMode = SoftInput.AdjustPan,
        ConfigurationChanges = ConfigChanges.KeyboardHidden | ConfigChanges.Orientation,
        LaunchMode = LaunchMode.SingleTop)]
    public class Activity2 : DialogActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            InitializeRoot();

            base.OnCreate(bundle);
        }

        void InitializeRoot()
        {
			var imageView = new ImageView(this);
			imageView.SetImageResource (Resource.Drawable.icon);

			this.Root = new RootElement("Elements")
            {
                new Section("Element w/Format Overrides")
                {
					new CheckboxElement("CheckboxElement", true, "", Resource.Layout.dialog_boolfieldsubright),
					new StringElement("String Element", "Value", Resource.Layout.dialog_labelfieldbelow),
					new EntryElement("EntryElement", "", Resource.Layout.dialog_textfieldbelow) { Hint = "Plain" },
					new EntryElement("PasswordEntryElement", "Va", Resource.Layout.dialog_textfieldbelow) { Hint = "Password", Password = true },
					new EntryElement("EntryElement2", "Val", Resource.Layout.dialog_textfieldbelow) { Hint = "Plain3" },
				},
                new Section("Section")
                {
                    new BooleanElement("BooleanElement", true),
                    new StringElement("StringElement", "Value"),
                    new EntryElement("EntryElement", "") { Hint = "Pain 2" },
                    new EntryElement("PasswordEntryElement", "") { Hint = "Password 2", Password = true },
                    new DateTimeElement("DateTimeElement", DateTime.Now),
                    new DateElement("DateElement", DateTime.Now),
                    new TimeElement("TimeElement", DateTime.Now),
                    new CheckboxElement("CheckboxElement", true),
					new HtmlElement("HtmlElement (Link)","http://www.google.com"),
					new ImageElement(imageView),
                    new MultilineElement("MultiLineElement", "The quick brown fox jumped over the lazy horse, the quick brown fox jumped over the lazy horse"),
                    new FloatElement("Range"),
				},
				new Section("Groups")
                {
					new [] {
						new RootElement("Radio Group", new Android.Dialog.RadioGroup("desert", 2))
						{
							new Section ()
		                        {
		                            new RadioElement ("Ice Cream", "desert"),
		                            new RadioElement ("Milkshake", "desert"),
		                            new RadioElement ("Chocolate Cake", "desert")
							},
							new Section ()
	                        {
	                            new RadioElement ("Ice Cream", "desert"),
	                            new RadioElement ("Milkshake", "desert"),
	                            new RadioElement ("Chocolate Cake", "desert")
	                        }
						}
					}
				}
            };
        }
    }
}

