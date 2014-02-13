using System;
using Android.Content;
using Android.Views;

namespace Android.Dialog
{
    public abstract class Element : Java.Lang.Object
    {
        /// <summary>
        ///  Initializes the element with the given caption.
        /// </summary>
        /// <param name="caption">
        /// The caption.
        /// </param>
        public Element(string caption)
        {
            Caption = caption;
        }

        public Element(string caption, int layoutId)
        {
            Caption = caption;
            LayoutId = layoutId;
        }

        /// <summary>
        ///  The caption to display for this given element
        /// </summary>
        public string Caption { get; set; }

        public int LayoutId { get; private set; }

        /// <summary>
        ///  Handle to the container object.
        /// </summary>
        /// <remarks>
        /// For sections this points to a RootElement, for every other object this points to a Section and it is null
        /// for the root RootElement.
        /// </remarks>
        public Element Parent { get; set; }

        /// <summary>
        /// Override for click the click event
        /// </summary>
        public EventHandler Click { get; set; }

        /// <summary>
        /// Override for long click events, some elements use this for action
        /// </summary>
        public EventHandler LongClick { get; set; }

        /// <summary>
        /// Alternative alias to the click event, naming more like MonoTouch Dialog.
        /// </summary>
        public EventHandler Tapped
        {
            get { return Click; }
            set { Click = value; }
        }

        /// <summary>
        /// An Object that contains data about the element. The default is null.
        /// </summary>
        public Object Tag { get; set; }

        /// <summary>
        /// Returns a summary of the value represented by this object, suitable 
        /// for rendering as the result of a RootElement with child objects.
        /// </summary>
        /// <returns>
        /// The return value must be a short description of the value.
        /// </returns>
        public virtual string Summary()
        {
            return string.Empty;
        }

        /// <summary>
        /// Returns whether this element should be enabled in the ListView
        /// </summary>
        /// <returns>
        /// <c>true</c> if this item should be enabled in a ListView; otherwise <c>false</c>.
        /// </returns>
        public virtual bool IsSelectable
        {
            get { return false; }
        }

        /// <summary>
        /// Overriden by most derived classes, creates a View with the contents for display
        /// </summary>
        /// <param name="context"></param>
        /// <param name="convertView"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        public virtual View GetView(Context context, View convertView, ViewGroup parent)
        {
            return LayoutId == 0 ? new View(context) : null;
        }

        public virtual void Selected() { }

        public virtual bool Matches(string text)
        {
            return Caption != null && Caption.IndexOf(text, StringComparison.CurrentCultureIgnoreCase) != -1;
        }

        public Context GetContext()
        {
            var element = this;
            while (element.Parent != null)
                element = element.Parent;

            var rootElement = element as RootElement;
            return rootElement == null ? null : rootElement.Context;
        }

        #region MonoTouch Dialog Mimicry

        // Not used in any way, just there to match MT Dialog api.
        public UITableViewCellAccessory Accessory { get; set; }

        #endregion
    }
}