
// This file has been generated by the GUI designer. Do not modify.
namespace MonoDevelop.Ide.Gui.Components
{
	public partial class StringTagSelectorButton
	{
		private global::Gtk.Button button;

		private global::Gtk.Arrow arrow1;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget MonoDevelop.Ide.Gui.Components.StringTagSelectorButton
			global::Stetic.BinContainer.Attach (this);
			this.Name = "MonoDevelop.Ide.Gui.Components.StringTagSelectorButton";
			// Container child MonoDevelop.Ide.Gui.Components.StringTagSelectorButton.Gtk.Container+ContainerChild
			this.button = new global::Gtk.Button ();
			this.button.CanFocus = true;
			this.button.Name = "button";
			// Container child button.Gtk.Container+ContainerChild
			this.arrow1 = new global::Gtk.Arrow (((global::Gtk.ArrowType)(1)), ((global::Gtk.ShadowType)(2)));
			this.arrow1.Name = "arrow1";
			this.button.Add (this.arrow1);
			this.button.Label = null;
			this.Add (this.button);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Hide ();
			this.button.Clicked += new global::System.EventHandler (this.OnButtonClicked);
		}
	}
}
