namespace PathfinderRaceBuilder
{
    partial class RaceBuilderForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label lblName;
            System.Windows.Forms.Label lblNamePlural;
            System.Windows.Forms.Label lblTotalPoints;
            System.Windows.Forms.Label lblCreatureType;
            System.Windows.Forms.Label lblSize;
            System.Windows.Forms.Label lblBaseSpeed;
            System.Windows.Forms.Label lblAttributes;
            System.Windows.Forms.Label lblLanguages;
            System.Windows.Forms.Label lblPowerLevel;
            System.Windows.Forms.Label lblSubtype;
            System.Windows.Forms.Label lblSelectedTraitDescription;
            System.Windows.Forms.Label lblRaceDescription;
            System.Windows.Forms.Label lblPhysicalAppearance;
            System.Windows.Forms.Label lblRaceAdjective;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RaceBuilderForm));
            this.lblSelectedTraitPrerequisites = new System.Windows.Forms.Label();
            this.lblSelectedTraitSpecial = new System.Windows.Forms.Label();
            this.txtRaceName = new System.Windows.Forms.TextBox();
            this.txtRacePlural = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mniSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.mniNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mniSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mniLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.mniExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mniAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.txtTotalPoints = new System.Windows.Forms.TextBox();
            this.tbcMain = new System.Windows.Forms.TabControl();
            this.tabDesign = new System.Windows.Forms.TabPage();
            this.gbxFlavor = new System.Windows.Forms.GroupBox();
            this.txtPhysicalAppearance = new System.Windows.Forms.TextBox();
            this.txtRaceFlavorText = new System.Windows.Forms.TextBox();
            this.btnEditLanguages = new System.Windows.Forms.Button();
            this.gbxRacialTraits = new System.Windows.Forms.GroupBox();
            this.gbxSelectedTraits = new System.Windows.Forms.GroupBox();
            this.pnlSelectedTraits = new System.Windows.Forms.Panel();
            this.gbxTraitPool = new System.Windows.Forms.GroupBox();
            this.pnlTraitInfo = new System.Windows.Forms.Panel();
            this.btnAddSelectedTrait = new System.Windows.Forms.Button();
            this.txtSelectedTraitSpecial = new System.Windows.Forms.TextBox();
            this.txtSelectedTraitDescription = new System.Windows.Forms.TextBox();
            this.txtSelectedTraitPrerequisites = new System.Windows.Forms.TextBox();
            this.lblSelectedTraitName = new System.Windows.Forms.Label();
            this.lstTraitPool = new System.Windows.Forms.ListBox();
            this.cbxTraitCategory = new System.Windows.Forms.ComboBox();
            this.txtSubtype = new System.Windows.Forms.TextBox();
            this.cbxPowerLevel = new System.Windows.Forms.ComboBox();
            this.cbxLanguages = new System.Windows.Forms.ComboBox();
            this.gbxAttributes = new System.Windows.Forms.GroupBox();
            this.cbxAttributeSelection = new System.Windows.Forms.ComboBox();
            this.cbxSpeedQuality = new System.Windows.Forms.ComboBox();
            this.cbxSize = new System.Windows.Forms.ComboBox();
            this.cbxCreatureType = new System.Windows.Forms.ComboBox();
            this.tabDisplay = new System.Windows.Forms.TabPage();
            this.brsDisplayWindow = new System.Windows.Forms.WebBrowser();
            this.ttpInfo = new System.Windows.Forms.ToolTip(this.components);
            this.lblRaceStatus = new System.Windows.Forms.Label();
            this.ttpQuickReference = new System.Windows.Forms.ToolTip(this.components);
            this.txtRaceAdjective = new System.Windows.Forms.TextBox();
            this.mniDeleteRaces = new System.Windows.Forms.ToolStripMenuItem();
            this.atcSTR = new PathfinderRaceBuilder.AttributeControl();
            this.atcCHA = new PathfinderRaceBuilder.AttributeControl();
            this.atcDEX = new PathfinderRaceBuilder.AttributeControl();
            this.atcWIS = new PathfinderRaceBuilder.AttributeControl();
            this.atcCON = new PathfinderRaceBuilder.AttributeControl();
            this.atcINT = new PathfinderRaceBuilder.AttributeControl();
            lblName = new System.Windows.Forms.Label();
            lblNamePlural = new System.Windows.Forms.Label();
            lblTotalPoints = new System.Windows.Forms.Label();
            lblCreatureType = new System.Windows.Forms.Label();
            lblSize = new System.Windows.Forms.Label();
            lblBaseSpeed = new System.Windows.Forms.Label();
            lblAttributes = new System.Windows.Forms.Label();
            lblLanguages = new System.Windows.Forms.Label();
            lblPowerLevel = new System.Windows.Forms.Label();
            lblSubtype = new System.Windows.Forms.Label();
            lblSelectedTraitDescription = new System.Windows.Forms.Label();
            lblRaceDescription = new System.Windows.Forms.Label();
            lblPhysicalAppearance = new System.Windows.Forms.Label();
            lblRaceAdjective = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.tbcMain.SuspendLayout();
            this.tabDesign.SuspendLayout();
            this.gbxFlavor.SuspendLayout();
            this.gbxRacialTraits.SuspendLayout();
            this.gbxSelectedTraits.SuspendLayout();
            this.gbxTraitPool.SuspendLayout();
            this.pnlTraitInfo.SuspendLayout();
            this.gbxAttributes.SuspendLayout();
            this.tabDisplay.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblName.Location = new System.Drawing.Point(12, 30);
            lblName.Name = "lblName";
            lblName.Size = new System.Drawing.Size(39, 13);
            lblName.TabIndex = 0;
            lblName.Text = "Name";
            // 
            // lblNamePlural
            // 
            lblNamePlural.AutoSize = true;
            lblNamePlural.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblNamePlural.Location = new System.Drawing.Point(163, 30);
            lblNamePlural.Name = "lblNamePlural";
            lblNamePlural.Size = new System.Drawing.Size(39, 13);
            lblNamePlural.TabIndex = 2;
            lblNamePlural.Text = "Plural";
            // 
            // lblTotalPoints
            // 
            lblTotalPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            lblTotalPoints.AutoSize = true;
            lblTotalPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblTotalPoints.Location = new System.Drawing.Point(871, 30);
            lblTotalPoints.Name = "lblTotalPoints";
            lblTotalPoints.Size = new System.Drawing.Size(75, 13);
            lblTotalPoints.TabIndex = 7;
            lblTotalPoints.Text = "Total Points";
            // 
            // lblCreatureType
            // 
            lblCreatureType.AutoSize = true;
            lblCreatureType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblCreatureType.Location = new System.Drawing.Point(8, 36);
            lblCreatureType.Name = "lblCreatureType";
            lblCreatureType.Size = new System.Drawing.Size(35, 13);
            lblCreatureType.TabIndex = 4;
            lblCreatureType.Text = "Type";
            // 
            // lblSize
            // 
            lblSize.AutoSize = true;
            lblSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblSize.Location = new System.Drawing.Point(6, 89);
            lblSize.Name = "lblSize";
            lblSize.Size = new System.Drawing.Size(31, 13);
            lblSize.TabIndex = 6;
            lblSize.Text = "Size";
            // 
            // lblBaseSpeed
            // 
            lblBaseSpeed.AutoSize = true;
            lblBaseSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblBaseSpeed.Location = new System.Drawing.Point(6, 118);
            lblBaseSpeed.Name = "lblBaseSpeed";
            lblBaseSpeed.Size = new System.Drawing.Size(75, 13);
            lblBaseSpeed.TabIndex = 8;
            lblBaseSpeed.Text = "Base Speed";
            // 
            // lblAttributes
            // 
            lblAttributes.AutoSize = true;
            lblAttributes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblAttributes.Location = new System.Drawing.Point(8, 145);
            lblAttributes.Name = "lblAttributes";
            lblAttributes.Size = new System.Drawing.Size(61, 13);
            lblAttributes.TabIndex = 11;
            lblAttributes.Text = "Attributes";
            // 
            // lblLanguages
            // 
            lblLanguages.AutoSize = true;
            lblLanguages.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblLanguages.Location = new System.Drawing.Point(6, 172);
            lblLanguages.Name = "lblLanguages";
            lblLanguages.Size = new System.Drawing.Size(69, 13);
            lblLanguages.TabIndex = 19;
            lblLanguages.Text = "Languages";
            // 
            // lblPowerLevel
            // 
            lblPowerLevel.AutoSize = true;
            lblPowerLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblPowerLevel.Location = new System.Drawing.Point(6, 9);
            lblPowerLevel.Name = "lblPowerLevel";
            lblPowerLevel.Size = new System.Drawing.Size(77, 13);
            lblPowerLevel.TabIndex = 21;
            lblPowerLevel.Text = "Power Level";
            // 
            // lblSubtype
            // 
            lblSubtype.AutoSize = true;
            lblSubtype.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblSubtype.Location = new System.Drawing.Point(8, 63);
            lblSubtype.Name = "lblSubtype";
            lblSubtype.Size = new System.Drawing.Size(67, 13);
            lblSubtype.TabIndex = 23;
            lblSubtype.Text = "Subtype(s)";
            // 
            // lblSelectedTraitDescription
            // 
            lblSelectedTraitDescription.AutoSize = true;
            lblSelectedTraitDescription.Location = new System.Drawing.Point(3, 57);
            lblSelectedTraitDescription.Name = "lblSelectedTraitDescription";
            lblSelectedTraitDescription.Size = new System.Drawing.Size(63, 13);
            lblSelectedTraitDescription.TabIndex = 5;
            lblSelectedTraitDescription.Text = "Description:";
            // 
            // lblRaceDescription
            // 
            lblRaceDescription.AutoSize = true;
            lblRaceDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblRaceDescription.Location = new System.Drawing.Point(6, 16);
            lblRaceDescription.Name = "lblRaceDescription";
            lblRaceDescription.Size = new System.Drawing.Size(51, 13);
            lblRaceDescription.TabIndex = 27;
            lblRaceDescription.Text = "General";
            // 
            // lblPhysicalAppearance
            // 
            lblPhysicalAppearance.AutoSize = true;
            lblPhysicalAppearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblPhysicalAppearance.Location = new System.Drawing.Point(6, 111);
            lblPhysicalAppearance.Name = "lblPhysicalAppearance";
            lblPhysicalAppearance.Size = new System.Drawing.Size(75, 13);
            lblPhysicalAppearance.TabIndex = 29;
            lblPhysicalAppearance.Text = "Appearance";
            // 
            // lblRaceAdjective
            // 
            lblRaceAdjective.AutoSize = true;
            lblRaceAdjective.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblRaceAdjective.Location = new System.Drawing.Point(317, 30);
            lblRaceAdjective.Name = "lblRaceAdjective";
            lblRaceAdjective.Size = new System.Drawing.Size(60, 13);
            lblRaceAdjective.TabIndex = 10;
            lblRaceAdjective.Text = "Adjective";
            // 
            // lblSelectedTraitPrerequisites
            // 
            this.lblSelectedTraitPrerequisites.AutoSize = true;
            this.lblSelectedTraitPrerequisites.Location = new System.Drawing.Point(3, 31);
            this.lblSelectedTraitPrerequisites.Name = "lblSelectedTraitPrerequisites";
            this.lblSelectedTraitPrerequisites.Size = new System.Drawing.Size(70, 13);
            this.lblSelectedTraitPrerequisites.TabIndex = 1;
            this.lblSelectedTraitPrerequisites.Text = "Prerequisites:";
            this.ttpInfo.SetToolTip(this.lblSelectedTraitPrerequisites, "Prerequisites are not enforced in the program; there is always room for GM except" +
        "ions, after all.");
            // 
            // lblSelectedTraitSpecial
            // 
            this.lblSelectedTraitSpecial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSelectedTraitSpecial.AutoSize = true;
            this.lblSelectedTraitSpecial.Location = new System.Drawing.Point(3, 151);
            this.lblSelectedTraitSpecial.Name = "lblSelectedTraitSpecial";
            this.lblSelectedTraitSpecial.Size = new System.Drawing.Size(42, 13);
            this.lblSelectedTraitSpecial.TabIndex = 6;
            this.lblSelectedTraitSpecial.Text = "Special";
            // 
            // txtRaceName
            // 
            this.txtRaceName.Location = new System.Drawing.Point(57, 27);
            this.txtRaceName.Name = "txtRaceName";
            this.txtRaceName.Size = new System.Drawing.Size(100, 20);
            this.txtRaceName.TabIndex = 0;
            this.txtRaceName.TextChanged += new System.EventHandler(this.txtRaceName_TextChanged);
            this.txtRaceName.Leave += new System.EventHandler(this.txtRaceName_Leave);
            // 
            // txtRacePlural
            // 
            this.txtRacePlural.Location = new System.Drawing.Point(208, 27);
            this.txtRacePlural.Name = "txtRacePlural";
            this.txtRacePlural.Size = new System.Drawing.Size(100, 20);
            this.txtRacePlural.TabIndex = 1;
            this.txtRacePlural.TextChanged += new System.EventHandler(this.txtRacePlural_TextChanged);
            this.txtRacePlural.Enter += new System.EventHandler(this.txtRacePlural_Enter);
            this.txtRacePlural.Leave += new System.EventHandler(this.txtRacePlural_Leave);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniSystem,
            this.mniAbout});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(984, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mniSystem
            // 
            this.mniSystem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniNew,
            this.mniSave,
            this.mniLoad,
            this.mniDeleteRaces,
            this.mniExit});
            this.mniSystem.Name = "mniSystem";
            this.mniSystem.Size = new System.Drawing.Size(37, 20);
            this.mniSystem.Text = "&File";
            // 
            // mniNew
            // 
            this.mniNew.Name = "mniNew";
            this.mniNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.mniNew.Size = new System.Drawing.Size(149, 22);
            this.mniNew.Text = "&New";
            this.mniNew.Click += new System.EventHandler(this.mniNew_Click);
            // 
            // mniSave
            // 
            this.mniSave.Enabled = false;
            this.mniSave.Name = "mniSave";
            this.mniSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mniSave.Size = new System.Drawing.Size(149, 22);
            this.mniSave.Text = "&Save";
            this.mniSave.Click += new System.EventHandler(this.mniSave_Click);
            // 
            // mniLoad
            // 
            this.mniLoad.Name = "mniLoad";
            this.mniLoad.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.mniLoad.Size = new System.Drawing.Size(149, 22);
            this.mniLoad.Text = "&Load";
            this.mniLoad.Click += new System.EventHandler(this.mniLoad_Click);
            // 
            // mniExit
            // 
            this.mniExit.Name = "mniExit";
            this.mniExit.Size = new System.Drawing.Size(149, 22);
            this.mniExit.Text = "E&xit";
            this.mniExit.Click += new System.EventHandler(this.mniExit_Click);
            // 
            // mniAbout
            // 
            this.mniAbout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mniAbout.Name = "mniAbout";
            this.mniAbout.Padding = new System.Windows.Forms.Padding(0);
            this.mniAbout.Size = new System.Drawing.Size(16, 20);
            this.mniAbout.Text = "?";
            this.mniAbout.ToolTipText = "About this program...";
            this.mniAbout.Click += new System.EventHandler(this.mniAbout_Click);
            // 
            // txtTotalPoints
            // 
            this.txtTotalPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalPoints.Location = new System.Drawing.Point(952, 27);
            this.txtTotalPoints.Name = "txtTotalPoints";
            this.txtTotalPoints.ReadOnly = true;
            this.txtTotalPoints.Size = new System.Drawing.Size(23, 20);
            this.txtTotalPoints.TabIndex = 8;
            this.txtTotalPoints.TabStop = false;
            this.txtTotalPoints.Text = "0";
            this.txtTotalPoints.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbcMain
            // 
            this.tbcMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbcMain.Controls.Add(this.tabDesign);
            this.tbcMain.Controls.Add(this.tabDisplay);
            this.tbcMain.Location = new System.Drawing.Point(0, 53);
            this.tbcMain.Name = "tbcMain";
            this.tbcMain.SelectedIndex = 0;
            this.tbcMain.Size = new System.Drawing.Size(984, 478);
            this.tbcMain.TabIndex = 9;
            this.tbcMain.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tbcMain_Selecting);
            this.tbcMain.Selected += new System.Windows.Forms.TabControlEventHandler(this.tbcMain_Selected);
            // 
            // tabDesign
            // 
            this.tabDesign.BackColor = System.Drawing.SystemColors.Control;
            this.tabDesign.Controls.Add(this.gbxFlavor);
            this.tabDesign.Controls.Add(this.btnEditLanguages);
            this.tabDesign.Controls.Add(this.gbxRacialTraits);
            this.tabDesign.Controls.Add(this.txtSubtype);
            this.tabDesign.Controls.Add(lblSubtype);
            this.tabDesign.Controls.Add(this.cbxPowerLevel);
            this.tabDesign.Controls.Add(this.cbxLanguages);
            this.tabDesign.Controls.Add(lblPowerLevel);
            this.tabDesign.Controls.Add(lblLanguages);
            this.tabDesign.Controls.Add(this.gbxAttributes);
            this.tabDesign.Controls.Add(lblAttributes);
            this.tabDesign.Controls.Add(this.cbxAttributeSelection);
            this.tabDesign.Controls.Add(this.cbxSpeedQuality);
            this.tabDesign.Controls.Add(lblBaseSpeed);
            this.tabDesign.Controls.Add(this.cbxSize);
            this.tabDesign.Controls.Add(lblSize);
            this.tabDesign.Controls.Add(this.cbxCreatureType);
            this.tabDesign.Controls.Add(lblCreatureType);
            this.tabDesign.Location = new System.Drawing.Point(4, 22);
            this.tabDesign.Name = "tabDesign";
            this.tabDesign.Padding = new System.Windows.Forms.Padding(3);
            this.tabDesign.Size = new System.Drawing.Size(976, 452);
            this.tabDesign.TabIndex = 0;
            this.tabDesign.Text = "Design";
            // 
            // gbxFlavor
            // 
            this.gbxFlavor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxFlavor.Controls.Add(lblRaceDescription);
            this.gbxFlavor.Controls.Add(this.txtPhysicalAppearance);
            this.gbxFlavor.Controls.Add(this.txtRaceFlavorText);
            this.gbxFlavor.Controls.Add(lblPhysicalAppearance);
            this.gbxFlavor.Location = new System.Drawing.Point(431, 0);
            this.gbxFlavor.Name = "gbxFlavor";
            this.gbxFlavor.Size = new System.Drawing.Size(536, 208);
            this.gbxFlavor.TabIndex = 31;
            this.gbxFlavor.TabStop = false;
            this.gbxFlavor.Text = "Description";
            // 
            // txtPhysicalAppearance
            // 
            this.txtPhysicalAppearance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPhysicalAppearance.Location = new System.Drawing.Point(9, 127);
            this.txtPhysicalAppearance.Multiline = true;
            this.txtPhysicalAppearance.Name = "txtPhysicalAppearance";
            this.txtPhysicalAppearance.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPhysicalAppearance.Size = new System.Drawing.Size(521, 75);
            this.txtPhysicalAppearance.TabIndex = 15;
            this.ttpInfo.SetToolTip(this.txtPhysicalAppearance, resources.GetString("txtPhysicalAppearance.ToolTip"));
            this.txtPhysicalAppearance.TextChanged += new System.EventHandler(this.Generic_ProcessChange);
            this.txtPhysicalAppearance.Leave += new System.EventHandler(this.txtPhysicalAppearance_Leave);
            // 
            // txtRaceFlavorText
            // 
            this.txtRaceFlavorText.AcceptsReturn = true;
            this.txtRaceFlavorText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRaceFlavorText.Location = new System.Drawing.Point(9, 32);
            this.txtRaceFlavorText.Multiline = true;
            this.txtRaceFlavorText.Name = "txtRaceFlavorText";
            this.txtRaceFlavorText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRaceFlavorText.Size = new System.Drawing.Size(521, 75);
            this.txtRaceFlavorText.TabIndex = 14;
            this.ttpInfo.SetToolTip(this.txtRaceFlavorText, resources.GetString("txtRaceFlavorText.ToolTip"));
            this.txtRaceFlavorText.TextChanged += new System.EventHandler(this.Generic_ProcessChange);
            this.txtRaceFlavorText.Leave += new System.EventHandler(this.txtRaceFlavorText_Leave);
            // 
            // btnEditLanguages
            // 
            this.btnEditLanguages.Enabled = false;
            this.btnEditLanguages.Location = new System.Drawing.Point(191, 169);
            this.btnEditLanguages.Name = "btnEditLanguages";
            this.btnEditLanguages.Size = new System.Drawing.Size(53, 23);
            this.btnEditLanguages.TabIndex = 10;
            this.btnEditLanguages.Text = "Edit";
            this.btnEditLanguages.UseVisualStyleBackColor = true;
            this.btnEditLanguages.Click += new System.EventHandler(this.btnEditLanguages_Click);
            // 
            // gbxRacialTraits
            // 
            this.gbxRacialTraits.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxRacialTraits.Controls.Add(this.gbxSelectedTraits);
            this.gbxRacialTraits.Controls.Add(this.gbxTraitPool);
            this.gbxRacialTraits.Enabled = false;
            this.gbxRacialTraits.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxRacialTraits.Location = new System.Drawing.Point(3, 214);
            this.gbxRacialTraits.Name = "gbxRacialTraits";
            this.gbxRacialTraits.Size = new System.Drawing.Size(970, 238);
            this.gbxRacialTraits.TabIndex = 25;
            this.gbxRacialTraits.TabStop = false;
            this.gbxRacialTraits.Text = "Racial Traits";
            // 
            // gbxSelectedTraits
            // 
            this.gbxSelectedTraits.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxSelectedTraits.Controls.Add(this.pnlSelectedTraits);
            this.gbxSelectedTraits.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxSelectedTraits.Location = new System.Drawing.Point(611, 19);
            this.gbxSelectedTraits.Name = "gbxSelectedTraits";
            this.gbxSelectedTraits.Size = new System.Drawing.Size(353, 216);
            this.gbxSelectedTraits.TabIndex = 1;
            this.gbxSelectedTraits.TabStop = false;
            this.gbxSelectedTraits.Text = "Selected Traits";
            // 
            // pnlSelectedTraits
            // 
            this.pnlSelectedTraits.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSelectedTraits.AutoScroll = true;
            this.pnlSelectedTraits.BackColor = System.Drawing.Color.Transparent;
            this.pnlSelectedTraits.Location = new System.Drawing.Point(2, 12);
            this.pnlSelectedTraits.Name = "pnlSelectedTraits";
            this.pnlSelectedTraits.Size = new System.Drawing.Size(349, 201);
            this.pnlSelectedTraits.TabIndex = 0;
            // 
            // gbxTraitPool
            // 
            this.gbxTraitPool.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxTraitPool.Controls.Add(this.pnlTraitInfo);
            this.gbxTraitPool.Controls.Add(this.lstTraitPool);
            this.gbxTraitPool.Controls.Add(this.cbxTraitCategory);
            this.gbxTraitPool.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxTraitPool.Location = new System.Drawing.Point(6, 19);
            this.gbxTraitPool.Name = "gbxTraitPool";
            this.gbxTraitPool.Size = new System.Drawing.Size(599, 216);
            this.gbxTraitPool.TabIndex = 0;
            this.gbxTraitPool.TabStop = false;
            this.gbxTraitPool.Text = "Trait Pool";
            // 
            // pnlTraitInfo
            // 
            this.pnlTraitInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTraitInfo.Controls.Add(this.btnAddSelectedTrait);
            this.pnlTraitInfo.Controls.Add(this.lblSelectedTraitSpecial);
            this.pnlTraitInfo.Controls.Add(lblSelectedTraitDescription);
            this.pnlTraitInfo.Controls.Add(this.txtSelectedTraitSpecial);
            this.pnlTraitInfo.Controls.Add(this.txtSelectedTraitDescription);
            this.pnlTraitInfo.Controls.Add(this.txtSelectedTraitPrerequisites);
            this.pnlTraitInfo.Controls.Add(this.lblSelectedTraitPrerequisites);
            this.pnlTraitInfo.Controls.Add(this.lblSelectedTraitName);
            this.pnlTraitInfo.Location = new System.Drawing.Point(228, 10);
            this.pnlTraitInfo.Name = "pnlTraitInfo";
            this.pnlTraitInfo.Size = new System.Drawing.Size(365, 196);
            this.pnlTraitInfo.TabIndex = 23;
            // 
            // btnAddSelectedTrait
            // 
            this.btnAddSelectedTrait.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddSelectedTrait.Location = new System.Drawing.Point(79, 170);
            this.btnAddSelectedTrait.Name = "btnAddSelectedTrait";
            this.btnAddSelectedTrait.Size = new System.Drawing.Size(75, 23);
            this.btnAddSelectedTrait.TabIndex = 13;
            this.btnAddSelectedTrait.Text = "Add ->";
            this.btnAddSelectedTrait.UseVisualStyleBackColor = true;
            this.btnAddSelectedTrait.Click += new System.EventHandler(this.btnAddSelectedTrait_Click);
            // 
            // txtSelectedTraitSpecial
            // 
            this.txtSelectedTraitSpecial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSelectedTraitSpecial.Location = new System.Drawing.Point(79, 144);
            this.txtSelectedTraitSpecial.Name = "txtSelectedTraitSpecial";
            this.txtSelectedTraitSpecial.ReadOnly = true;
            this.txtSelectedTraitSpecial.Size = new System.Drawing.Size(283, 20);
            this.txtSelectedTraitSpecial.TabIndex = 4;
            this.txtSelectedTraitSpecial.TabStop = false;
            // 
            // txtSelectedTraitDescription
            // 
            this.txtSelectedTraitDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSelectedTraitDescription.Location = new System.Drawing.Point(79, 54);
            this.txtSelectedTraitDescription.Multiline = true;
            this.txtSelectedTraitDescription.Name = "txtSelectedTraitDescription";
            this.txtSelectedTraitDescription.ReadOnly = true;
            this.txtSelectedTraitDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSelectedTraitDescription.Size = new System.Drawing.Size(283, 84);
            this.txtSelectedTraitDescription.TabIndex = 3;
            this.txtSelectedTraitDescription.TabStop = false;
            // 
            // txtSelectedTraitPrerequisites
            // 
            this.txtSelectedTraitPrerequisites.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSelectedTraitPrerequisites.Location = new System.Drawing.Point(79, 28);
            this.txtSelectedTraitPrerequisites.Name = "txtSelectedTraitPrerequisites";
            this.txtSelectedTraitPrerequisites.ReadOnly = true;
            this.txtSelectedTraitPrerequisites.Size = new System.Drawing.Size(283, 20);
            this.txtSelectedTraitPrerequisites.TabIndex = 2;
            this.txtSelectedTraitPrerequisites.TabStop = false;
            // 
            // lblSelectedTraitName
            // 
            this.lblSelectedTraitName.AutoSize = true;
            this.lblSelectedTraitName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedTraitName.Location = new System.Drawing.Point(10, 9);
            this.lblSelectedTraitName.Name = "lblSelectedTraitName";
            this.lblSelectedTraitName.Size = new System.Drawing.Size(123, 13);
            this.lblSelectedTraitName.TabIndex = 0;
            this.lblSelectedTraitName.Text = "Selected Trait Name";
            // 
            // lstTraitPool
            // 
            this.lstTraitPool.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstTraitPool.FormattingEnabled = true;
            this.lstTraitPool.Location = new System.Drawing.Point(6, 46);
            this.lstTraitPool.Name = "lstTraitPool";
            this.lstTraitPool.Size = new System.Drawing.Size(216, 160);
            this.lstTraitPool.TabIndex = 12;
            this.ttpQuickReference.SetToolTip(this.lstTraitPool, "Double click to add traits quickly.");
            this.lstTraitPool.SelectedIndexChanged += new System.EventHandler(this.lstTraitPool_SelectedIndexChanged);
            this.lstTraitPool.DoubleClick += new System.EventHandler(this.lstTraitPool_DoubleClick);
            // 
            // cbxTraitCategory
            // 
            this.cbxTraitCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTraitCategory.FormattingEnabled = true;
            this.cbxTraitCategory.Items.AddRange(new object[] {
            "All Traits",
            "Ability Score Racial Traits",
            "Defense Racial Traits",
            "Feat And Skill Racial Traits",
            "Magical Racial Traits",
            "Movement Racial Traits",
            "Offense Racial Traits",
            "Senses Racial Traits",
            "Weakness Racial Traits",
            "Other Racial Traits"});
            this.cbxTraitCategory.Location = new System.Drawing.Point(6, 19);
            this.cbxTraitCategory.Name = "cbxTraitCategory";
            this.cbxTraitCategory.Size = new System.Drawing.Size(216, 21);
            this.cbxTraitCategory.TabIndex = 11;
            this.cbxTraitCategory.SelectedIndexChanged += new System.EventHandler(this.cbxTraitCategory_SelectedIndexChanged);
            // 
            // txtSubtype
            // 
            this.txtSubtype.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtSubtype.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtSubtype.Enabled = false;
            this.txtSubtype.Location = new System.Drawing.Point(87, 60);
            this.txtSubtype.Name = "txtSubtype";
            this.txtSubtype.Size = new System.Drawing.Size(153, 20);
            this.txtSubtype.TabIndex = 5;
            this.ttpInfo.SetToolTip(this.txtSubtype, "Separate these with a comma - for example, a half-elf would use \"human,elf\"");
            this.txtSubtype.TextChanged += new System.EventHandler(this.Generic_ProcessChange);
            this.txtSubtype.Leave += new System.EventHandler(this.txtSubtype_Leave);
            // 
            // cbxPowerLevel
            // 
            this.cbxPowerLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPowerLevel.FormattingEnabled = true;
            this.cbxPowerLevel.Items.AddRange(new object[] {
            "Standard (1-10 pts.)",
            "Advanced (11-20 pts.)",
            "Monstrous (20+ pts.)"});
            this.cbxPowerLevel.Location = new System.Drawing.Point(89, 6);
            this.cbxPowerLevel.Name = "cbxPowerLevel";
            this.cbxPowerLevel.Size = new System.Drawing.Size(129, 21);
            this.cbxPowerLevel.TabIndex = 3;
            this.cbxPowerLevel.SelectedIndexChanged += new System.EventHandler(this.cbxPowerLevel_SelectedIndexChanged);
            // 
            // cbxLanguages
            // 
            this.cbxLanguages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLanguages.FormattingEnabled = true;
            this.cbxLanguages.Items.AddRange(new object[] {
            "Linguist - 1 pt.",
            "Standard - 0 pts.",
            "Xenophobic - 0 pts."});
            this.cbxLanguages.Location = new System.Drawing.Point(87, 169);
            this.cbxLanguages.Name = "cbxLanguages";
            this.cbxLanguages.Size = new System.Drawing.Size(98, 21);
            this.cbxLanguages.TabIndex = 9;
            this.cbxLanguages.SelectedIndexChanged += new System.EventHandler(this.cbxLanguages_SelectedIndexChanged);
            // 
            // gbxAttributes
            // 
            this.gbxAttributes.Controls.Add(this.atcSTR);
            this.gbxAttributes.Controls.Add(this.atcCHA);
            this.gbxAttributes.Controls.Add(this.atcDEX);
            this.gbxAttributes.Controls.Add(this.atcWIS);
            this.gbxAttributes.Controls.Add(this.atcCON);
            this.gbxAttributes.Controls.Add(this.atcINT);
            this.gbxAttributes.Location = new System.Drawing.Point(250, 0);
            this.gbxAttributes.Name = "gbxAttributes";
            this.gbxAttributes.Size = new System.Drawing.Size(175, 208);
            this.gbxAttributes.TabIndex = 18;
            this.gbxAttributes.TabStop = false;
            this.gbxAttributes.Text = "Attribute Settings";
            // 
            // cbxAttributeSelection
            // 
            this.cbxAttributeSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAttributeSelection.FormattingEnabled = true;
            this.cbxAttributeSelection.Items.AddRange(new object[] {
            "Advanced - 4 pts.",
            "Flexible - 2 pts.",
            "Greater Paragon - 2 pts.",
            "Greater Weakness - -3 pts.",
            "Human Heritage - 0 pts.",
            "Mixed Weakness - -2pts.",
            "Paragon - 1 pt.",
            "Specialized - 1 pt.",
            "Standard - 0 pts.",
            "Weakness - -1 pt."});
            this.cbxAttributeSelection.Location = new System.Drawing.Point(87, 142);
            this.cbxAttributeSelection.Name = "cbxAttributeSelection";
            this.cbxAttributeSelection.Size = new System.Drawing.Size(155, 21);
            this.cbxAttributeSelection.TabIndex = 8;
            this.cbxAttributeSelection.SelectedIndexChanged += new System.EventHandler(this.cbxAttributeSelection_SelectedIndexChanged);
            // 
            // cbxSpeedQuality
            // 
            this.cbxSpeedQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSpeedQuality.FormattingEnabled = true;
            this.cbxSpeedQuality.Items.AddRange(new object[] {
            "Normal - 0pts.",
            "Slow - -1 pt."});
            this.cbxSpeedQuality.Location = new System.Drawing.Point(87, 115);
            this.cbxSpeedQuality.Name = "cbxSpeedQuality";
            this.cbxSpeedQuality.Size = new System.Drawing.Size(88, 21);
            this.cbxSpeedQuality.TabIndex = 7;
            this.cbxSpeedQuality.SelectedIndexChanged += new System.EventHandler(this.cbxSpeedQuality_SelectedIndexChanged);
            // 
            // cbxSize
            // 
            this.cbxSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSize.FormattingEnabled = true;
            this.cbxSize.Items.AddRange(new object[] {
            "Large - 7 pts.",
            "Medium - 0 pts.",
            "Small - 0 pts.",
            "Tiny - 4 pts."});
            this.cbxSize.Location = new System.Drawing.Point(87, 86);
            this.cbxSize.Name = "cbxSize";
            this.cbxSize.Size = new System.Drawing.Size(98, 21);
            this.cbxSize.TabIndex = 6;
            this.cbxSize.SelectedIndexChanged += new System.EventHandler(this.cbxSize_SelectedIndexChanged);
            // 
            // cbxCreatureType
            // 
            this.cbxCreatureType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCreatureType.FormattingEnabled = true;
            this.cbxCreatureType.Location = new System.Drawing.Point(89, 33);
            this.cbxCreatureType.Name = "cbxCreatureType";
            this.cbxCreatureType.Size = new System.Drawing.Size(151, 21);
            this.cbxCreatureType.TabIndex = 4;
            this.cbxCreatureType.SelectedIndexChanged += new System.EventHandler(this.cbxCreatureType_SelectedIndexChanged);
            // 
            // tabDisplay
            // 
            this.tabDisplay.BackColor = System.Drawing.SystemColors.Control;
            this.tabDisplay.Controls.Add(this.brsDisplayWindow);
            this.tabDisplay.ForeColor = System.Drawing.SystemColors.Control;
            this.tabDisplay.Location = new System.Drawing.Point(4, 22);
            this.tabDisplay.Name = "tabDisplay";
            this.tabDisplay.Padding = new System.Windows.Forms.Padding(3);
            this.tabDisplay.Size = new System.Drawing.Size(976, 452);
            this.tabDisplay.TabIndex = 1;
            this.tabDisplay.Text = "Rulebook Entry";
            // 
            // brsDisplayWindow
            // 
            this.brsDisplayWindow.AllowNavigation = false;
            this.brsDisplayWindow.AllowWebBrowserDrop = false;
            this.brsDisplayWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.brsDisplayWindow.IsWebBrowserContextMenuEnabled = false;
            this.brsDisplayWindow.Location = new System.Drawing.Point(6, 6);
            this.brsDisplayWindow.MinimumSize = new System.Drawing.Size(20, 20);
            this.brsDisplayWindow.Name = "brsDisplayWindow";
            this.brsDisplayWindow.Size = new System.Drawing.Size(970, 443);
            this.brsDisplayWindow.TabIndex = 0;
            this.brsDisplayWindow.Url = new System.Uri("about:blank", System.UriKind.Absolute);
            // 
            // ttpInfo
            // 
            this.ttpInfo.AutoPopDelay = 30000;
            this.ttpInfo.InitialDelay = 500;
            this.ttpInfo.IsBalloon = true;
            this.ttpInfo.ReshowDelay = 500;
            // 
            // lblRaceStatus
            // 
            this.lblRaceStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRaceStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblRaceStatus.Font = new System.Drawing.Font("Wingdings", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.lblRaceStatus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblRaceStatus.Location = new System.Drawing.Point(954, 50);
            this.lblRaceStatus.Name = "lblRaceStatus";
            this.lblRaceStatus.Size = new System.Drawing.Size(23, 23);
            this.lblRaceStatus.TabIndex = 12;
            this.lblRaceStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ttpQuickReference
            // 
            this.ttpQuickReference.AutomaticDelay = 100;
            this.ttpQuickReference.AutoPopDelay = 10000;
            this.ttpQuickReference.InitialDelay = 100;
            this.ttpQuickReference.ReshowDelay = 20;
            // 
            // txtRaceAdjective
            // 
            this.txtRaceAdjective.Location = new System.Drawing.Point(383, 27);
            this.txtRaceAdjective.Name = "txtRaceAdjective";
            this.txtRaceAdjective.Size = new System.Drawing.Size(100, 20);
            this.txtRaceAdjective.TabIndex = 2;
            this.txtRaceAdjective.Leave += new System.EventHandler(this.txtRaceAdjective_Leave);
            // 
            // mniDeleteRaces
            // 
            this.mniDeleteRaces.Enabled = false;
            this.mniDeleteRaces.Name = "mniDeleteRaces";
            this.mniDeleteRaces.Size = new System.Drawing.Size(149, 22);
            this.mniDeleteRaces.Text = "&Delete Races...";
            this.mniDeleteRaces.Click += new System.EventHandler(this.mniDeleteRaces_Click);
            // 
            // atcSTR
            // 
            this.atcSTR.ForeColor = System.Drawing.SystemColors.ControlText;
            this.atcSTR.Location = new System.Drawing.Point(6, 19);
            this.atcSTR.MaximumSize = new System.Drawing.Size(163, 31);
            this.atcSTR.MinimumSize = new System.Drawing.Size(163, 31);
            this.atcSTR.Name = "atcSTR";
            this.atcSTR.Size = new System.Drawing.Size(163, 31);
            this.atcSTR.TabIndex = 12;
            this.atcSTR.SelectionUpdated += new System.EventHandler(this.AttributeControl_SelectionUpdated);
            // 
            // atcCHA
            // 
            this.atcCHA.ForeColor = System.Drawing.SystemColors.ControlText;
            this.atcCHA.Location = new System.Drawing.Point(6, 169);
            this.atcCHA.MaximumSize = new System.Drawing.Size(163, 31);
            this.atcCHA.MinimumSize = new System.Drawing.Size(163, 31);
            this.atcCHA.Name = "atcCHA";
            this.atcCHA.Size = new System.Drawing.Size(163, 31);
            this.atcCHA.TabIndex = 17;
            this.atcCHA.SelectionUpdated += new System.EventHandler(this.AttributeControl_SelectionUpdated);
            // 
            // atcDEX
            // 
            this.atcDEX.ForeColor = System.Drawing.SystemColors.ControlText;
            this.atcDEX.Location = new System.Drawing.Point(6, 49);
            this.atcDEX.MaximumSize = new System.Drawing.Size(163, 31);
            this.atcDEX.MinimumSize = new System.Drawing.Size(163, 31);
            this.atcDEX.Name = "atcDEX";
            this.atcDEX.Size = new System.Drawing.Size(163, 31);
            this.atcDEX.TabIndex = 13;
            this.atcDEX.SelectionUpdated += new System.EventHandler(this.AttributeControl_SelectionUpdated);
            // 
            // atcWIS
            // 
            this.atcWIS.ForeColor = System.Drawing.SystemColors.ControlText;
            this.atcWIS.Location = new System.Drawing.Point(6, 139);
            this.atcWIS.MaximumSize = new System.Drawing.Size(163, 31);
            this.atcWIS.MinimumSize = new System.Drawing.Size(163, 31);
            this.atcWIS.Name = "atcWIS";
            this.atcWIS.Size = new System.Drawing.Size(163, 31);
            this.atcWIS.TabIndex = 16;
            this.atcWIS.SelectionUpdated += new System.EventHandler(this.AttributeControl_SelectionUpdated);
            // 
            // atcCON
            // 
            this.atcCON.ForeColor = System.Drawing.SystemColors.ControlText;
            this.atcCON.Location = new System.Drawing.Point(6, 79);
            this.atcCON.MaximumSize = new System.Drawing.Size(163, 31);
            this.atcCON.MinimumSize = new System.Drawing.Size(163, 31);
            this.atcCON.Name = "atcCON";
            this.atcCON.Size = new System.Drawing.Size(163, 31);
            this.atcCON.TabIndex = 14;
            this.atcCON.SelectionUpdated += new System.EventHandler(this.AttributeControl_SelectionUpdated);
            // 
            // atcINT
            // 
            this.atcINT.ForeColor = System.Drawing.SystemColors.ControlText;
            this.atcINT.Location = new System.Drawing.Point(6, 109);
            this.atcINT.MaximumSize = new System.Drawing.Size(163, 31);
            this.atcINT.MinimumSize = new System.Drawing.Size(163, 31);
            this.atcINT.Name = "atcINT";
            this.atcINT.Size = new System.Drawing.Size(163, 31);
            this.atcINT.TabIndex = 15;
            this.atcINT.SelectionUpdated += new System.EventHandler(this.AttributeControl_SelectionUpdated);
            // 
            // RaceBuilderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 528);
            this.Controls.Add(this.lblRaceStatus);
            this.Controls.Add(this.txtRaceAdjective);
            this.Controls.Add(lblRaceAdjective);
            this.Controls.Add(this.tbcMain);
            this.Controls.Add(this.txtTotalPoints);
            this.Controls.Add(lblTotalPoints);
            this.Controls.Add(this.txtRacePlural);
            this.Controls.Add(lblNamePlural);
            this.Controls.Add(this.txtRaceName);
            this.Controls.Add(lblName);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(800, 566);
            this.Name = "RaceBuilderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pathfinder Race Builder";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RaceBuilderForm_FormClosing);
            this.Shown += new System.EventHandler(this.RaceBuilderForm_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RaceBuilderForm_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tbcMain.ResumeLayout(false);
            this.tabDesign.ResumeLayout(false);
            this.tabDesign.PerformLayout();
            this.gbxFlavor.ResumeLayout(false);
            this.gbxFlavor.PerformLayout();
            this.gbxRacialTraits.ResumeLayout(false);
            this.gbxSelectedTraits.ResumeLayout(false);
            this.gbxTraitPool.ResumeLayout(false);
            this.pnlTraitInfo.ResumeLayout(false);
            this.pnlTraitInfo.PerformLayout();
            this.gbxAttributes.ResumeLayout(false);
            this.tabDisplay.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRaceName;
        private System.Windows.Forms.TextBox txtRacePlural;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mniSystem;
        private System.Windows.Forms.TextBox txtTotalPoints;
        private System.Windows.Forms.ToolStripMenuItem mniNew;
        private System.Windows.Forms.ToolStripMenuItem mniSave;
        private System.Windows.Forms.ToolStripMenuItem mniLoad;
        private System.Windows.Forms.ToolStripMenuItem mniExit;
        private System.Windows.Forms.TabControl tbcMain;
        private System.Windows.Forms.TabPage tabDesign;
        private System.Windows.Forms.TabPage tabDisplay;
        private System.Windows.Forms.ComboBox cbxCreatureType;
        private System.Windows.Forms.ToolTip ttpInfo;
        private System.Windows.Forms.ComboBox cbxSize;
        private System.Windows.Forms.ComboBox cbxSpeedQuality;
        private System.Windows.Forms.ComboBox cbxAttributeSelection;
        private AttributeControl atcCHA;
        private AttributeControl atcWIS;
        private AttributeControl atcINT;
        private AttributeControl atcCON;
        private AttributeControl atcDEX;
        private AttributeControl atcSTR;
        private System.Windows.Forms.GroupBox gbxAttributes;
        private System.Windows.Forms.ComboBox cbxLanguages;
        private System.Windows.Forms.ComboBox cbxPowerLevel;
        private System.Windows.Forms.TextBox txtSubtype;
        private System.Windows.Forms.GroupBox gbxRacialTraits;
        private System.Windows.Forms.GroupBox gbxSelectedTraits;
        private System.Windows.Forms.GroupBox gbxTraitPool;
        private System.Windows.Forms.ComboBox cbxTraitCategory;
        private System.Windows.Forms.ListBox lstTraitPool;
        private System.Windows.Forms.Panel pnlTraitInfo;
        private System.Windows.Forms.TextBox txtSelectedTraitSpecial;
        private System.Windows.Forms.TextBox txtSelectedTraitDescription;
        private System.Windows.Forms.TextBox txtSelectedTraitPrerequisites;
        private System.Windows.Forms.Label lblSelectedTraitName;
        private System.Windows.Forms.Button btnAddSelectedTrait;
        private System.Windows.Forms.Label lblSelectedTraitPrerequisites;
        private System.Windows.Forms.Label lblSelectedTraitSpecial;
        private System.Windows.Forms.ToolTip ttpQuickReference;
        private System.Windows.Forms.Panel pnlSelectedTraits;
        private System.Windows.Forms.WebBrowser brsDisplayWindow;
        private System.Windows.Forms.TextBox txtRaceFlavorText;
        private System.Windows.Forms.Button btnEditLanguages;
        private System.Windows.Forms.TextBox txtPhysicalAppearance;
        private System.Windows.Forms.GroupBox gbxFlavor;
        private System.Windows.Forms.TextBox txtRaceAdjective;
        private System.Windows.Forms.Label lblRaceStatus;
        private System.Windows.Forms.ToolStripMenuItem mniAbout;
        private System.Windows.Forms.ToolStripMenuItem mniDeleteRaces;
    }
}

