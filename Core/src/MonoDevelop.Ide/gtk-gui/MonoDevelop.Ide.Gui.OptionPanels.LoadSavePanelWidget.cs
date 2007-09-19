// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.42
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace MonoDevelop.Ide.Gui.OptionPanels {
    
    
    internal partial class LoadSavePanelWidget {
        
        private Gtk.VBox vbox17;
        
        private Gtk.VBox vbox26;
        
        private Gtk.Label locationLabel;
        
        private MonoDevelop.Components.FolderEntry folderEntry;
        
        private Gtk.VBox vbox18;
        
        private Gtk.Label loadLabel;
        
        private Gtk.HBox hbox14;
        
        private Gtk.Label label25;
        
        private Gtk.HBox hbox10;
        
        private Gtk.VBox vbox65;
        
        private Gtk.CheckButton loadUserDataCheckButton;
        
        private Gtk.CheckButton loadPrevProjectCheckButton;
        
        private Gtk.VBox vbox19;
        
        private Gtk.Label saveLabel;
        
        private Gtk.HBox hbox11;
        
        private Gtk.Label label21;
        
        private Gtk.VBox vbox20;
        
        private Gtk.CheckButton createBackupCopyCheckButton;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget MonoDevelop.Ide.Gui.OptionPanels.LoadSavePanelWidget
            Stetic.BinContainer.Attach(this);
            this.Name = "MonoDevelop.Ide.Gui.OptionPanels.LoadSavePanelWidget";
            // Container child MonoDevelop.Ide.Gui.OptionPanels.LoadSavePanelWidget.Gtk.Container+ContainerChild
            this.vbox17 = new Gtk.VBox();
            this.vbox17.Name = "vbox17";
            this.vbox17.Spacing = 6;
            // Container child vbox17.Gtk.Box+BoxChild
            this.vbox26 = new Gtk.VBox();
            this.vbox26.Name = "vbox26";
            this.vbox26.Spacing = 6;
            // Container child vbox26.Gtk.Box+BoxChild
            this.locationLabel = new Gtk.Label();
            this.locationLabel.Name = "locationLabel";
            this.locationLabel.Xalign = 0F;
            this.locationLabel.Yalign = 0F;
            this.locationLabel.LabelProp = Mono.Unix.Catalog.GetString("Default _Solution location");
            this.locationLabel.UseUnderline = true;
            this.vbox26.Add(this.locationLabel);
            Gtk.Box.BoxChild w1 = ((Gtk.Box.BoxChild)(this.vbox26[this.locationLabel]));
            w1.Position = 0;
            w1.Expand = false;
            w1.Fill = false;
            // Container child vbox26.Gtk.Box+BoxChild
            this.folderEntry = new MonoDevelop.Components.FolderEntry();
            this.folderEntry.Name = "folderEntry";
            this.vbox26.Add(this.folderEntry);
            Gtk.Box.BoxChild w2 = ((Gtk.Box.BoxChild)(this.vbox26[this.folderEntry]));
            w2.Position = 1;
            w2.Expand = false;
            w2.Fill = false;
            this.vbox17.Add(this.vbox26);
            Gtk.Box.BoxChild w3 = ((Gtk.Box.BoxChild)(this.vbox17[this.vbox26]));
            w3.Position = 0;
            w3.Expand = false;
            // Container child vbox17.Gtk.Box+BoxChild
            this.vbox18 = new Gtk.VBox();
            this.vbox18.Name = "vbox18";
            this.vbox18.Spacing = 6;
            // Container child vbox18.Gtk.Box+BoxChild
            this.loadLabel = new Gtk.Label();
            this.loadLabel.Name = "loadLabel";
            this.loadLabel.Xalign = 0F;
            this.loadLabel.Yalign = 0F;
            this.loadLabel.LabelProp = Mono.Unix.Catalog.GetString("<b>Load</b>");
            this.loadLabel.UseMarkup = true;
            this.vbox18.Add(this.loadLabel);
            Gtk.Box.BoxChild w4 = ((Gtk.Box.BoxChild)(this.vbox18[this.loadLabel]));
            w4.Position = 0;
            w4.Expand = false;
            w4.Fill = false;
            // Container child vbox18.Gtk.Box+BoxChild
            this.hbox14 = new Gtk.HBox();
            this.hbox14.Name = "hbox14";
            this.hbox14.Spacing = 6;
            // Container child hbox14.Gtk.Box+BoxChild
            this.label25 = new Gtk.Label();
            this.label25.Name = "label25";
            this.label25.Xalign = 0F;
            this.label25.Yalign = 0F;
            this.label25.LabelProp = "    ";
            this.hbox14.Add(this.label25);
            Gtk.Box.BoxChild w5 = ((Gtk.Box.BoxChild)(this.hbox14[this.label25]));
            w5.Position = 0;
            w5.Expand = false;
            w5.Fill = false;
            // Container child hbox14.Gtk.Box+BoxChild
            this.hbox10 = new Gtk.HBox();
            this.hbox10.Name = "hbox10";
            this.hbox10.Spacing = 6;
            // Container child hbox10.Gtk.Box+BoxChild
            this.vbox65 = new Gtk.VBox();
            this.vbox65.Name = "vbox65";
            this.vbox65.Spacing = 6;
            // Container child vbox65.Gtk.Box+BoxChild
            this.loadUserDataCheckButton = new Gtk.CheckButton();
            this.loadUserDataCheckButton.Name = "loadUserDataCheckButton";
            this.loadUserDataCheckButton.Label = Mono.Unix.Catalog.GetString("Load user-specific settings with the document");
            this.loadUserDataCheckButton.DrawIndicator = true;
            this.loadUserDataCheckButton.UseUnderline = true;
            this.vbox65.Add(this.loadUserDataCheckButton);
            Gtk.Box.BoxChild w6 = ((Gtk.Box.BoxChild)(this.vbox65[this.loadUserDataCheckButton]));
            w6.Position = 0;
            w6.Expand = false;
            w6.Fill = false;
            // Container child vbox65.Gtk.Box+BoxChild
            this.loadPrevProjectCheckButton = new Gtk.CheckButton();
            this.loadPrevProjectCheckButton.Name = "loadPrevProjectCheckButton";
            this.loadPrevProjectCheckButton.Label = Mono.Unix.Catalog.GetString("_Load previous solution on startup");
            this.loadPrevProjectCheckButton.DrawIndicator = true;
            this.loadPrevProjectCheckButton.UseUnderline = true;
            this.vbox65.Add(this.loadPrevProjectCheckButton);
            Gtk.Box.BoxChild w7 = ((Gtk.Box.BoxChild)(this.vbox65[this.loadPrevProjectCheckButton]));
            w7.Position = 1;
            w7.Expand = false;
            w7.Fill = false;
            this.hbox10.Add(this.vbox65);
            Gtk.Box.BoxChild w8 = ((Gtk.Box.BoxChild)(this.hbox10[this.vbox65]));
            w8.Position = 0;
            w8.Expand = false;
            w8.Fill = false;
            this.hbox14.Add(this.hbox10);
            Gtk.Box.BoxChild w9 = ((Gtk.Box.BoxChild)(this.hbox14[this.hbox10]));
            w9.Position = 1;
            this.vbox18.Add(this.hbox14);
            Gtk.Box.BoxChild w10 = ((Gtk.Box.BoxChild)(this.vbox18[this.hbox14]));
            w10.Position = 1;
            this.vbox17.Add(this.vbox18);
            Gtk.Box.BoxChild w11 = ((Gtk.Box.BoxChild)(this.vbox17[this.vbox18]));
            w11.Position = 1;
            w11.Expand = false;
            // Container child vbox17.Gtk.Box+BoxChild
            this.vbox19 = new Gtk.VBox();
            this.vbox19.Name = "vbox19";
            this.vbox19.Spacing = 6;
            // Container child vbox19.Gtk.Box+BoxChild
            this.saveLabel = new Gtk.Label();
            this.saveLabel.Name = "saveLabel";
            this.saveLabel.Xalign = 0F;
            this.saveLabel.Yalign = 0F;
            this.saveLabel.LabelProp = Mono.Unix.Catalog.GetString("<b>Save</b>");
            this.saveLabel.UseMarkup = true;
            this.vbox19.Add(this.saveLabel);
            Gtk.Box.BoxChild w12 = ((Gtk.Box.BoxChild)(this.vbox19[this.saveLabel]));
            w12.Position = 0;
            w12.Expand = false;
            w12.Fill = false;
            // Container child vbox19.Gtk.Box+BoxChild
            this.hbox11 = new Gtk.HBox();
            this.hbox11.Name = "hbox11";
            this.hbox11.Spacing = 6;
            // Container child hbox11.Gtk.Box+BoxChild
            this.label21 = new Gtk.Label();
            this.label21.Name = "label21";
            this.label21.Xalign = 0F;
            this.label21.Yalign = 0F;
            this.label21.LabelProp = "    ";
            this.hbox11.Add(this.label21);
            Gtk.Box.BoxChild w13 = ((Gtk.Box.BoxChild)(this.hbox11[this.label21]));
            w13.Position = 0;
            w13.Expand = false;
            w13.Fill = false;
            // Container child hbox11.Gtk.Box+BoxChild
            this.vbox20 = new Gtk.VBox();
            this.vbox20.Name = "vbox20";
            this.vbox20.Spacing = 6;
            // Container child vbox20.Gtk.Box+BoxChild
            this.createBackupCopyCheckButton = new Gtk.CheckButton();
            this.createBackupCopyCheckButton.Name = "createBackupCopyCheckButton";
            this.createBackupCopyCheckButton.Label = Mono.Unix.Catalog.GetString("Always create backup copy");
            this.createBackupCopyCheckButton.DrawIndicator = true;
            this.createBackupCopyCheckButton.UseUnderline = true;
            this.vbox20.Add(this.createBackupCopyCheckButton);
            Gtk.Box.BoxChild w14 = ((Gtk.Box.BoxChild)(this.vbox20[this.createBackupCopyCheckButton]));
            w14.Position = 0;
            w14.Expand = false;
            w14.Fill = false;
            this.hbox11.Add(this.vbox20);
            Gtk.Box.BoxChild w15 = ((Gtk.Box.BoxChild)(this.hbox11[this.vbox20]));
            w15.Position = 1;
            this.vbox19.Add(this.hbox11);
            Gtk.Box.BoxChild w16 = ((Gtk.Box.BoxChild)(this.vbox19[this.hbox11]));
            w16.Position = 1;
            this.vbox17.Add(this.vbox19);
            Gtk.Box.BoxChild w17 = ((Gtk.Box.BoxChild)(this.vbox17[this.vbox19]));
            w17.Position = 2;
            this.Add(this.vbox17);
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.Show();
        }
    }
}
