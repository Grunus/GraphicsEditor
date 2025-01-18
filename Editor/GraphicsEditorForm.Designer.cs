
namespace Editor
{
    partial class GraphicsEditorForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Menu = new Panel();
            PanelMenu = new Panel();
            TextGroupBox = new GroupBox();
            buttonChangeFont = new Button();
            FontEffectsMenuStrip = new MenuStrip();
            FontEffectsToolStripMenuItem = new ToolStripMenuItem();
            BoldFontToolStripMenuItem = new ToolStripMenuItem();
            ItalicFontToolStripMenuItem = new ToolStripMenuItem();
            UnderlinedTextToolStripMenuItem = new ToolStripMenuItem();
            CrossedOutTextToolStripMenuItem = new ToolStripMenuItem();
            labelFontSize = new Label();
            labelSelectedFont = new Label();
            ColorsGroupBox = new GroupBox();
            buttonPrimaryColor = new Button();
            buttonSecondaryColor = new Button();
            buttonChangeColors = new Button();
            ShapesGroupBox = new GroupBox();
            LinearGradientDirectionMenuStrip = new MenuStrip();
            LinearGradientDirectionToolStripMenuItem = new ToolStripMenuItem();
            VerticalGradToolStripMenuItem = new ToolStripMenuItem();
            HorizontalGradToolStripMenuItem = new ToolStripMenuItem();
            ForwardDiagonalGradToolStripMenuItem = new ToolStripMenuItem();
            BackwardDiagonalGradToolStripMenuItem = new ToolStripMenuItem();
            ShapeFillMenuStrip = new MenuStrip();
            ShapeFillToolStripMenuItem = new ToolStripMenuItem();
            NoFillToolStripMenuItem = new ToolStripMenuItem();
            SolidColorFillToolStripMenuItem = new ToolStripMenuItem();
            LinearGradientFillToolStripMenuItem = new ToolStripMenuItem();
            ShapeOutlineMenuStrip = new MenuStrip();
            ShapeOutlineToolStripMenuItem = new ToolStripMenuItem();
            WithoutOutlineToolStripMenuItem = new ToolStripMenuItem();
            WithOutlineToolStripMenuItem = new ToolStripMenuItem();
            buttonPolygon = new Button();
            buttonRhomb = new Button();
            buttonRectangle = new Button();
            buttonTriangle = new Button();
            buttonEllipse = new Button();
            buttonCurve = new Button();
            buttonLine = new Button();
            DrawingGroupBox = new GroupBox();
            PaintToolThicknessComboBox = new ComboBox();
            labelPaintToolThickness = new Label();
            labelSelectedPaintTool = new Label();
            SelectedPaintToolComboBox = new ComboBox();
            ToolsGroupBox = new GroupBox();
            buttonPipette = new Button();
            buttonEraser = new Button();
            buttonDrawText = new Button();
            buttonFill = new Button();
            buttonArbitraryDrawing = new Button();
            CanvasGroupBox = new GroupBox();
            SelectionMenuStrip = new MenuStrip();
            SelectionToolStripMenuItem = new ToolStripMenuItem();
            RectangleSelectionToolStripMenuItem = new ToolStripMenuItem();
            SelectAllToolStripMenuItem = new ToolStripMenuItem();
            ReverseSelectedAreaToolStripMenuItem = new ToolStripMenuItem();
            DeleteSelectAreaToolStripMenuItem = new ToolStripMenuItem();
            RotateFlipMenuStrip = new MenuStrip();
            RotateFlipToolStripMenuItem = new ToolStripMenuItem();
            NinetyDegToTheRightToolStripMenuItem = new ToolStripMenuItem();
            NinetyDegToTheLeftToolStripMenuItem = new ToolStripMenuItem();
            OneHundredEightyDegTurnToolStripMenuItem = new ToolStripMenuItem();
            MirrorVerticallyToolStripMenuItem = new ToolStripMenuItem();
            MirrorHorizontallyToolStripMenuItem = new ToolStripMenuItem();
            buttonChangeSize = new Button();
            buttonCrop = new Button();
            ClipboardGroupBox = new GroupBox();
            buttonCutOut = new Button();
            buttonCopy = new Button();
            buttonPasteFrom = new Button();
            buttonPaste = new Button();
            StripMenu = new Panel();
            UndoRedoToolStrip = new ToolStrip();
            UndoButton = new ToolStripButton();
            RedoButton = new ToolStripButton();
            FileAndViewMenuStrip = new MenuStrip();
            FileToolStripMenuItem = new ToolStripMenuItem();
            CreateFileToolStripMenuItem = new ToolStripMenuItem();
            OpenFileToolStripMenuItem = new ToolStripMenuItem();
            SaveFileToolStripMenuItem = new ToolStripMenuItem();
            SaveFileHowToolStripMenuItem = new ToolStripMenuItem();
            ViewToolStripMenuItem = new ToolStripMenuItem();
            ZoomToolStripMenuItem = new ToolStripMenuItem();
            ZoomInToolStripMenuItem = new ToolStripMenuItem();
            ZoomOutToolStripMenuItem = new ToolStripMenuItem();
            DefaultZoomToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            RulersToolStripMenuItem = new ToolStripMenuItem();
            GridToolStripMenuItem = new ToolStripMenuItem();
            InfoStatusStrip = new StatusStrip();
            CanvasMouseLocationToolStripStatusLabel = new ToolStripStatusLabel();
            SelectAreaImageSizeToolStripStatusLabel = new ToolStripStatusLabel();
            CanvasSizeToolStripStatusLabel = new ToolStripStatusLabel();
            ZoomFactorToolStripStatusLabel = new ToolStripStatusLabel();
            MainSpace = new Panel();
            pictureBoxRulerLeft = new PictureBox();
            pictureBoxRulerTop = new PictureBox();
            pictureBoxFiller = new PictureBox();
            Menu.SuspendLayout();
            PanelMenu.SuspendLayout();
            TextGroupBox.SuspendLayout();
            FontEffectsMenuStrip.SuspendLayout();
            ColorsGroupBox.SuspendLayout();
            ShapesGroupBox.SuspendLayout();
            LinearGradientDirectionMenuStrip.SuspendLayout();
            ShapeFillMenuStrip.SuspendLayout();
            ShapeOutlineMenuStrip.SuspendLayout();
            DrawingGroupBox.SuspendLayout();
            ToolsGroupBox.SuspendLayout();
            CanvasGroupBox.SuspendLayout();
            SelectionMenuStrip.SuspendLayout();
            RotateFlipMenuStrip.SuspendLayout();
            ClipboardGroupBox.SuspendLayout();
            StripMenu.SuspendLayout();
            UndoRedoToolStrip.SuspendLayout();
            FileAndViewMenuStrip.SuspendLayout();
            InfoStatusStrip.SuspendLayout();
            MainSpace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRulerLeft).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRulerTop).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxFiller).BeginInit();
            SuspendLayout();
            // 
            // Menu
            // 
            Menu.Controls.Add(PanelMenu);
            Menu.Controls.Add(StripMenu);
            Menu.Dock = DockStyle.Top;
            Menu.Location = new Point(0, 0);
            Menu.Name = "Menu";
            Menu.Size = new Size(1264, 153);
            Menu.TabIndex = 0;
            // 
            // PanelMenu
            // 
            PanelMenu.Controls.Add(TextGroupBox);
            PanelMenu.Controls.Add(ColorsGroupBox);
            PanelMenu.Controls.Add(ShapesGroupBox);
            PanelMenu.Controls.Add(DrawingGroupBox);
            PanelMenu.Controls.Add(ToolsGroupBox);
            PanelMenu.Controls.Add(CanvasGroupBox);
            PanelMenu.Controls.Add(ClipboardGroupBox);
            PanelMenu.Dock = DockStyle.Fill;
            PanelMenu.Location = new Point(0, 24);
            PanelMenu.Name = "PanelMenu";
            PanelMenu.Size = new Size(1264, 129);
            PanelMenu.TabIndex = 1;
            // 
            // TextGroupBox
            // 
            TextGroupBox.Controls.Add(buttonChangeFont);
            TextGroupBox.Controls.Add(FontEffectsMenuStrip);
            TextGroupBox.Controls.Add(labelFontSize);
            TextGroupBox.Controls.Add(labelSelectedFont);
            TextGroupBox.Location = new Point(961, 0);
            TextGroupBox.Name = "TextGroupBox";
            TextGroupBox.Size = new Size(303, 129);
            TextGroupBox.TabIndex = 6;
            TextGroupBox.TabStop = false;
            TextGroupBox.Text = "Текст";
            // 
            // buttonChangeFont
            // 
            buttonChangeFont.BackColor = SystemColors.Control;
            buttonChangeFont.FlatAppearance.BorderSize = 0;
            buttonChangeFont.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            buttonChangeFont.FlatStyle = FlatStyle.Flat;
            buttonChangeFont.Location = new Point(2, 98);
            buttonChangeFont.Name = "buttonChangeFont";
            buttonChangeFont.Size = new Size(104, 24);
            buttonChangeFont.TabIndex = 14;
            buttonChangeFont.Text = "Змінити шрифт";
            buttonChangeFont.TextAlign = ContentAlignment.MiddleLeft;
            buttonChangeFont.UseVisualStyleBackColor = false;
            buttonChangeFont.Click += buttonChangeFont_Click;
            // 
            // FontEffectsMenuStrip
            // 
            FontEffectsMenuStrip.AutoSize = false;
            FontEffectsMenuStrip.Dock = DockStyle.None;
            FontEffectsMenuStrip.Items.AddRange(new ToolStripItem[] { FontEffectsToolStripMenuItem });
            FontEffectsMenuStrip.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
            FontEffectsMenuStrip.Location = new Point(4, 65);
            FontEffectsMenuStrip.Name = "FontEffectsMenuStrip";
            FontEffectsMenuStrip.Padding = new Padding(0, 6, 0, 0);
            FontEffectsMenuStrip.Size = new Size(65, 27);
            FontEffectsMenuStrip.TabIndex = 12;
            FontEffectsMenuStrip.Text = "Контур";
            // 
            // FontEffectsToolStripMenuItem
            // 
            FontEffectsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { BoldFontToolStripMenuItem, ItalicFontToolStripMenuItem, UnderlinedTextToolStripMenuItem, CrossedOutTextToolStripMenuItem });
            FontEffectsToolStripMenuItem.Name = "FontEffectsToolStripMenuItem";
            FontEffectsToolStripMenuItem.Size = new Size(64, 19);
            FontEffectsToolStripMenuItem.Text = "Ефекти";
            FontEffectsToolStripMenuItem.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // BoldFontToolStripMenuItem
            // 
            BoldFontToolStripMenuItem.CheckOnClick = true;
            BoldFontToolStripMenuItem.Name = "BoldFontToolStripMenuItem";
            BoldFontToolStripMenuItem.Size = new Size(182, 22);
            BoldFontToolStripMenuItem.Text = "Жирний шрифт";
            BoldFontToolStripMenuItem.CheckedChanged += BoldFontToolStripMenuItem_CheckedChanged;
            // 
            // ItalicFontToolStripMenuItem
            // 
            ItalicFontToolStripMenuItem.CheckOnClick = true;
            ItalicFontToolStripMenuItem.Name = "ItalicFontToolStripMenuItem";
            ItalicFontToolStripMenuItem.Size = new Size(182, 22);
            ItalicFontToolStripMenuItem.Text = "Курсив";
            ItalicFontToolStripMenuItem.CheckedChanged += ItalicFontToolStripMenuItem_CheckedChanged;
            // 
            // UnderlinedTextToolStripMenuItem
            // 
            UnderlinedTextToolStripMenuItem.CheckOnClick = true;
            UnderlinedTextToolStripMenuItem.Name = "UnderlinedTextToolStripMenuItem";
            UnderlinedTextToolStripMenuItem.Size = new Size(182, 22);
            UnderlinedTextToolStripMenuItem.Text = "Підкреслений текст";
            UnderlinedTextToolStripMenuItem.CheckedChanged += UnderlinedTextToolStripMenuItem_CheckedChanged;
            // 
            // CrossedOutTextToolStripMenuItem
            // 
            CrossedOutTextToolStripMenuItem.CheckOnClick = true;
            CrossedOutTextToolStripMenuItem.Name = "CrossedOutTextToolStripMenuItem";
            CrossedOutTextToolStripMenuItem.Size = new Size(182, 22);
            CrossedOutTextToolStripMenuItem.Text = "Закреслений текст";
            CrossedOutTextToolStripMenuItem.CheckedChanged += CrossedOutTextToolStripMenuItem_CheckedChanged;
            // 
            // labelFontSize
            // 
            labelFontSize.AutoSize = true;
            labelFontSize.Location = new Point(6, 42);
            labelFontSize.Name = "labelFontSize";
            labelFontSize.Size = new Size(48, 15);
            labelFontSize.TabIndex = 3;
            labelFontSize.Text = "Розмір:";
            // 
            // labelSelectedFont
            // 
            labelSelectedFont.AutoSize = true;
            labelSelectedFont.Location = new Point(6, 18);
            labelSelectedFont.Name = "labelSelectedFont";
            labelSelectedFont.Size = new Size(102, 15);
            labelSelectedFont.TabIndex = 2;
            labelSelectedFont.Text = "Обраний шрифт:";
            // 
            // ColorsGroupBox
            // 
            ColorsGroupBox.Controls.Add(buttonPrimaryColor);
            ColorsGroupBox.Controls.Add(buttonSecondaryColor);
            ColorsGroupBox.Controls.Add(buttonChangeColors);
            ColorsGroupBox.Location = new Point(761, 0);
            ColorsGroupBox.Name = "ColorsGroupBox";
            ColorsGroupBox.Size = new Size(200, 129);
            ColorsGroupBox.TabIndex = 5;
            ColorsGroupBox.TabStop = false;
            ColorsGroupBox.Text = "Кольори";
            // 
            // buttonPrimaryColor
            // 
            buttonPrimaryColor.BackColor = SystemColors.Control;
            buttonPrimaryColor.FlatAppearance.BorderSize = 0;
            buttonPrimaryColor.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            buttonPrimaryColor.FlatStyle = FlatStyle.Flat;
            buttonPrimaryColor.Image = Properties.Resources.EditColors1;
            buttonPrimaryColor.ImageAlign = ContentAlignment.MiddleLeft;
            buttonPrimaryColor.Location = new Point(6, 19);
            buttonPrimaryColor.Name = "buttonPrimaryColor";
            buttonPrimaryColor.Size = new Size(81, 30);
            buttonPrimaryColor.TabIndex = 4;
            buttonPrimaryColor.Text = "Колір 1";
            buttonPrimaryColor.TextAlign = ContentAlignment.MiddleRight;
            buttonPrimaryColor.UseVisualStyleBackColor = false;
            buttonPrimaryColor.Click += buttonPrimaryColor_Click;
            // 
            // buttonSecondaryColor
            // 
            buttonSecondaryColor.BackColor = SystemColors.Control;
            buttonSecondaryColor.FlatAppearance.BorderSize = 0;
            buttonSecondaryColor.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            buttonSecondaryColor.FlatStyle = FlatStyle.Flat;
            buttonSecondaryColor.Image = Properties.Resources.EditColors1;
            buttonSecondaryColor.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSecondaryColor.Location = new Point(113, 19);
            buttonSecondaryColor.Name = "buttonSecondaryColor";
            buttonSecondaryColor.Size = new Size(81, 30);
            buttonSecondaryColor.TabIndex = 3;
            buttonSecondaryColor.Text = "Колір 2";
            buttonSecondaryColor.TextAlign = ContentAlignment.MiddleRight;
            buttonSecondaryColor.UseVisualStyleBackColor = false;
            buttonSecondaryColor.Click += buttonSecondaryColor_Click;
            // 
            // buttonChangeColors
            // 
            buttonChangeColors.BackColor = SystemColors.Control;
            buttonChangeColors.FlatAppearance.BorderSize = 0;
            buttonChangeColors.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            buttonChangeColors.FlatStyle = FlatStyle.Flat;
            buttonChangeColors.Image = Properties.Resources.EditColors1;
            buttonChangeColors.ImageAlign = ContentAlignment.MiddleLeft;
            buttonChangeColors.Location = new Point(31, 90);
            buttonChangeColors.Name = "buttonChangeColors";
            buttonChangeColors.Size = new Size(138, 30);
            buttonChangeColors.TabIndex = 2;
            buttonChangeColors.Text = "Змінити кольори";
            buttonChangeColors.TextAlign = ContentAlignment.MiddleRight;
            buttonChangeColors.UseVisualStyleBackColor = false;
            buttonChangeColors.Click += buttonChangeColors_Click;
            // 
            // ShapesGroupBox
            // 
            ShapesGroupBox.Controls.Add(LinearGradientDirectionMenuStrip);
            ShapesGroupBox.Controls.Add(ShapeFillMenuStrip);
            ShapesGroupBox.Controls.Add(ShapeOutlineMenuStrip);
            ShapesGroupBox.Controls.Add(buttonPolygon);
            ShapesGroupBox.Controls.Add(buttonRhomb);
            ShapesGroupBox.Controls.Add(buttonRectangle);
            ShapesGroupBox.Controls.Add(buttonTriangle);
            ShapesGroupBox.Controls.Add(buttonEllipse);
            ShapesGroupBox.Controls.Add(buttonCurve);
            ShapesGroupBox.Controls.Add(buttonLine);
            ShapesGroupBox.Location = new Point(503, 0);
            ShapesGroupBox.Name = "ShapesGroupBox";
            ShapesGroupBox.Size = new Size(258, 129);
            ShapesGroupBox.TabIndex = 4;
            ShapesGroupBox.TabStop = false;
            ShapesGroupBox.Text = "Фігури";
            // 
            // LinearGradientDirectionMenuStrip
            // 
            LinearGradientDirectionMenuStrip.AutoSize = false;
            LinearGradientDirectionMenuStrip.Dock = DockStyle.None;
            LinearGradientDirectionMenuStrip.Items.AddRange(new ToolStripItem[] { LinearGradientDirectionToolStripMenuItem });
            LinearGradientDirectionMenuStrip.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
            LinearGradientDirectionMenuStrip.Location = new Point(29, 96);
            LinearGradientDirectionMenuStrip.Name = "LinearGradientDirectionMenuStrip";
            LinearGradientDirectionMenuStrip.Padding = new Padding(0, 6, 0, 0);
            LinearGradientDirectionMenuStrip.Size = new Size(192, 28);
            LinearGradientDirectionMenuStrip.TabIndex = 12;
            LinearGradientDirectionMenuStrip.Text = "menuStrip6";
            // 
            // LinearGradientDirectionToolStripMenuItem
            // 
            LinearGradientDirectionToolStripMenuItem.AutoSize = false;
            LinearGradientDirectionToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { VerticalGradToolStripMenuItem, HorizontalGradToolStripMenuItem, ForwardDiagonalGradToolStripMenuItem, BackwardDiagonalGradToolStripMenuItem });
            LinearGradientDirectionToolStripMenuItem.Name = "LinearGradientDirectionToolStripMenuItem";
            LinearGradientDirectionToolStripMenuItem.Size = new Size(191, 20);
            LinearGradientDirectionToolStripMenuItem.Text = "Напрямок лінійного градієнту";
            LinearGradientDirectionToolStripMenuItem.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // VerticalGradToolStripMenuItem
            // 
            VerticalGradToolStripMenuItem.Name = "VerticalGradToolStripMenuItem";
            VerticalGradToolStripMenuItem.Size = new Size(300, 22);
            VerticalGradToolStripMenuItem.Text = "Зверху вниз";
            VerticalGradToolStripMenuItem.Click += VerticalGradToolStripMenuItem_Click;
            // 
            // HorizontalGradToolStripMenuItem
            // 
            HorizontalGradToolStripMenuItem.Name = "HorizontalGradToolStripMenuItem";
            HorizontalGradToolStripMenuItem.Size = new Size(300, 22);
            HorizontalGradToolStripMenuItem.Text = "Зліва направо";
            HorizontalGradToolStripMenuItem.Click += HorizontalGradToolStripMenuItem_Click;
            // 
            // ForwardDiagonalGradToolStripMenuItem
            // 
            ForwardDiagonalGradToolStripMenuItem.Name = "ForwardDiagonalGradToolStripMenuItem";
            ForwardDiagonalGradToolStripMenuItem.Size = new Size(300, 22);
            ForwardDiagonalGradToolStripMenuItem.Text = "З лівого верхнього кута в правий нижній";
            ForwardDiagonalGradToolStripMenuItem.Click += ForwardDiagonalGradToolStripMenuItem_Click;
            // 
            // BackwardDiagonalGradToolStripMenuItem
            // 
            BackwardDiagonalGradToolStripMenuItem.Name = "BackwardDiagonalGradToolStripMenuItem";
            BackwardDiagonalGradToolStripMenuItem.Size = new Size(300, 22);
            BackwardDiagonalGradToolStripMenuItem.Text = "З правого нижнього кута в лівий верхній";
            BackwardDiagonalGradToolStripMenuItem.Click += BackwardDiagonalGradToolStripMenuItem_Click;
            // 
            // ShapeFillMenuStrip
            // 
            ShapeFillMenuStrip.AutoSize = false;
            ShapeFillMenuStrip.Dock = DockStyle.None;
            ShapeFillMenuStrip.Items.AddRange(new ToolStripItem[] { ShapeFillToolStripMenuItem });
            ShapeFillMenuStrip.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
            ShapeFillMenuStrip.Location = new Point(161, 60);
            ShapeFillMenuStrip.Name = "ShapeFillMenuStrip";
            ShapeFillMenuStrip.Padding = new Padding(0, 6, 0, 0);
            ShapeFillMenuStrip.Size = new Size(91, 27);
            ShapeFillMenuStrip.TabIndex = 11;
            ShapeFillMenuStrip.Text = "menuStrip5";
            // 
            // ShapeFillToolStripMenuItem
            // 
            ShapeFillToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { NoFillToolStripMenuItem, SolidColorFillToolStripMenuItem, LinearGradientFillToolStripMenuItem });
            ShapeFillToolStripMenuItem.Image = Properties.Resources.FillStyle;
            ShapeFillToolStripMenuItem.Name = "ShapeFillToolStripMenuItem";
            ShapeFillToolStripMenuItem.Size = new Size(90, 20);
            ShapeFillToolStripMenuItem.Text = "Заливка";
            // 
            // NoFillToolStripMenuItem
            // 
            NoFillToolStripMenuItem.Image = Properties.Resources.Without;
            NoFillToolStripMenuItem.Name = "NoFillToolStripMenuItem";
            NoFillToolStripMenuItem.Size = new Size(176, 22);
            NoFillToolStripMenuItem.Text = "Без заливки";
            NoFillToolStripMenuItem.Click += NoFillToolStripMenuItem_Click;
            // 
            // SolidColorFillToolStripMenuItem
            // 
            SolidColorFillToolStripMenuItem.Image = Properties.Resources.SolidColor;
            SolidColorFillToolStripMenuItem.Name = "SolidColorFillToolStripMenuItem";
            SolidColorFillToolStripMenuItem.Size = new Size(176, 22);
            SolidColorFillToolStripMenuItem.Text = "Однотонний колір";
            SolidColorFillToolStripMenuItem.Click += SolidColorFillToolStripMenuItem_Click;
            // 
            // LinearGradientFillToolStripMenuItem
            // 
            LinearGradientFillToolStripMenuItem.Name = "LinearGradientFillToolStripMenuItem";
            LinearGradientFillToolStripMenuItem.Size = new Size(176, 22);
            LinearGradientFillToolStripMenuItem.Text = "Лінійний градієнт";
            LinearGradientFillToolStripMenuItem.Click += LinearGradientFillToolStripMenuItem_Click;
            // 
            // ShapeOutlineMenuStrip
            // 
            ShapeOutlineMenuStrip.AutoSize = false;
            ShapeOutlineMenuStrip.Dock = DockStyle.None;
            ShapeOutlineMenuStrip.Items.AddRange(new ToolStripItem[] { ShapeOutlineToolStripMenuItem });
            ShapeOutlineMenuStrip.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
            ShapeOutlineMenuStrip.Location = new Point(6, 60);
            ShapeOutlineMenuStrip.Name = "ShapeOutlineMenuStrip";
            ShapeOutlineMenuStrip.Padding = new Padding(0, 6, 0, 0);
            ShapeOutlineMenuStrip.Size = new Size(83, 27);
            ShapeOutlineMenuStrip.TabIndex = 10;
            ShapeOutlineMenuStrip.Text = "Контур";
            // 
            // ShapeOutlineToolStripMenuItem
            // 
            ShapeOutlineToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { WithoutOutlineToolStripMenuItem, WithOutlineToolStripMenuItem });
            ShapeOutlineToolStripMenuItem.Image = Properties.Resources.DrawStyle;
            ShapeOutlineToolStripMenuItem.Name = "ShapeOutlineToolStripMenuItem";
            ShapeOutlineToolStripMenuItem.Size = new Size(82, 20);
            ShapeOutlineToolStripMenuItem.Text = "Контур";
            // 
            // WithoutOutlineToolStripMenuItem
            // 
            WithoutOutlineToolStripMenuItem.Image = Properties.Resources.Without;
            WithoutOutlineToolStripMenuItem.Name = "WithoutOutlineToolStripMenuItem";
            WithoutOutlineToolStripMenuItem.Size = new Size(139, 22);
            WithoutOutlineToolStripMenuItem.Text = "Без контуру";
            WithoutOutlineToolStripMenuItem.Click += WithoutOutlineToolStripMenuItem_Click;
            // 
            // WithOutlineToolStripMenuItem
            // 
            WithOutlineToolStripMenuItem.Image = Properties.Resources.SolidColor;
            WithOutlineToolStripMenuItem.Name = "WithOutlineToolStripMenuItem";
            WithOutlineToolStripMenuItem.Size = new Size(139, 22);
            WithOutlineToolStripMenuItem.Text = "З контуром";
            WithOutlineToolStripMenuItem.Click += WithOutlineToolStripMenuItem_Click;
            // 
            // buttonPolygon
            // 
            buttonPolygon.AutoSize = true;
            buttonPolygon.BackColor = SystemColors.Control;
            buttonPolygon.FlatAppearance.BorderSize = 0;
            buttonPolygon.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            buttonPolygon.FlatStyle = FlatStyle.Flat;
            buttonPolygon.Image = Properties.Resources.Polygon;
            buttonPolygon.ImageAlign = ContentAlignment.MiddleLeft;
            buttonPolygon.Location = new Point(222, 27);
            buttonPolygon.Name = "buttonPolygon";
            buttonPolygon.Size = new Size(30, 30);
            buttonPolygon.TabIndex = 9;
            buttonPolygon.TextAlign = ContentAlignment.MiddleRight;
            buttonPolygon.UseVisualStyleBackColor = false;
            // 
            // buttonRhomb
            // 
            buttonRhomb.AutoSize = true;
            buttonRhomb.BackColor = SystemColors.Control;
            buttonRhomb.FlatAppearance.BorderSize = 0;
            buttonRhomb.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            buttonRhomb.FlatStyle = FlatStyle.Flat;
            buttonRhomb.Image = Properties.Resources.Rombus;
            buttonRhomb.ImageAlign = ContentAlignment.MiddleLeft;
            buttonRhomb.Location = new Point(186, 27);
            buttonRhomb.Name = "buttonRhomb";
            buttonRhomb.Size = new Size(30, 30);
            buttonRhomb.TabIndex = 8;
            buttonRhomb.TextAlign = ContentAlignment.MiddleRight;
            buttonRhomb.UseVisualStyleBackColor = false;
            // 
            // buttonRectangle
            // 
            buttonRectangle.AutoSize = true;
            buttonRectangle.BackColor = SystemColors.Control;
            buttonRectangle.FlatAppearance.BorderSize = 0;
            buttonRectangle.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            buttonRectangle.FlatStyle = FlatStyle.Flat;
            buttonRectangle.Image = Properties.Resources.Rectangle;
            buttonRectangle.ImageAlign = ContentAlignment.MiddleLeft;
            buttonRectangle.Location = new Point(150, 27);
            buttonRectangle.Name = "buttonRectangle";
            buttonRectangle.Size = new Size(30, 30);
            buttonRectangle.TabIndex = 7;
            buttonRectangle.TextAlign = ContentAlignment.MiddleRight;
            buttonRectangle.UseVisualStyleBackColor = false;
            // 
            // buttonTriangle
            // 
            buttonTriangle.AutoSize = true;
            buttonTriangle.BackColor = SystemColors.Control;
            buttonTriangle.FlatAppearance.BorderSize = 0;
            buttonTriangle.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            buttonTriangle.FlatStyle = FlatStyle.Flat;
            buttonTriangle.Image = Properties.Resources._60degTriangle;
            buttonTriangle.ImageAlign = ContentAlignment.MiddleLeft;
            buttonTriangle.Location = new Point(114, 27);
            buttonTriangle.Name = "buttonTriangle";
            buttonTriangle.Size = new Size(30, 30);
            buttonTriangle.TabIndex = 6;
            buttonTriangle.TextAlign = ContentAlignment.MiddleRight;
            buttonTriangle.UseVisualStyleBackColor = false;
            // 
            // buttonEllipse
            // 
            buttonEllipse.AutoSize = true;
            buttonEllipse.BackColor = SystemColors.Control;
            buttonEllipse.FlatAppearance.BorderSize = 0;
            buttonEllipse.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            buttonEllipse.FlatStyle = FlatStyle.Flat;
            buttonEllipse.Image = Properties.Resources.Ellipse;
            buttonEllipse.ImageAlign = ContentAlignment.MiddleLeft;
            buttonEllipse.Location = new Point(78, 27);
            buttonEllipse.Name = "buttonEllipse";
            buttonEllipse.Size = new Size(30, 30);
            buttonEllipse.TabIndex = 5;
            buttonEllipse.TextAlign = ContentAlignment.MiddleRight;
            buttonEllipse.UseVisualStyleBackColor = false;
            // 
            // buttonCurve
            // 
            buttonCurve.AutoSize = true;
            buttonCurve.BackColor = SystemColors.Control;
            buttonCurve.FlatAppearance.BorderSize = 0;
            buttonCurve.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            buttonCurve.FlatStyle = FlatStyle.Flat;
            buttonCurve.Image = Properties.Resources.Curve;
            buttonCurve.ImageAlign = ContentAlignment.MiddleLeft;
            buttonCurve.Location = new Point(42, 27);
            buttonCurve.Name = "buttonCurve";
            buttonCurve.Size = new Size(30, 30);
            buttonCurve.TabIndex = 4;
            buttonCurve.TextAlign = ContentAlignment.MiddleRight;
            buttonCurve.UseVisualStyleBackColor = false;
            // 
            // buttonLine
            // 
            buttonLine.AutoSize = true;
            buttonLine.BackColor = SystemColors.Control;
            buttonLine.FlatAppearance.BorderSize = 0;
            buttonLine.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            buttonLine.FlatStyle = FlatStyle.Flat;
            buttonLine.Image = Properties.Resources.Line;
            buttonLine.ImageAlign = ContentAlignment.MiddleLeft;
            buttonLine.Location = new Point(6, 27);
            buttonLine.Name = "buttonLine";
            buttonLine.Size = new Size(30, 30);
            buttonLine.TabIndex = 3;
            buttonLine.TextAlign = ContentAlignment.MiddleRight;
            buttonLine.UseVisualStyleBackColor = false;
            // 
            // DrawingGroupBox
            // 
            DrawingGroupBox.Controls.Add(PaintToolThicknessComboBox);
            DrawingGroupBox.Controls.Add(labelPaintToolThickness);
            DrawingGroupBox.Controls.Add(labelSelectedPaintTool);
            DrawingGroupBox.Controls.Add(SelectedPaintToolComboBox);
            DrawingGroupBox.Location = new Point(370, 0);
            DrawingGroupBox.Name = "DrawingGroupBox";
            DrawingGroupBox.Size = new Size(133, 129);
            DrawingGroupBox.TabIndex = 3;
            DrawingGroupBox.TabStop = false;
            DrawingGroupBox.Text = "Малювання";
            // 
            // PaintToolThicknessComboBox
            // 
            PaintToolThicknessComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            PaintToolThicknessComboBox.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
            PaintToolThicknessComboBox.Location = new Point(6, 91);
            PaintToolThicknessComboBox.Name = "PaintToolThicknessComboBox";
            PaintToolThicknessComboBox.Size = new Size(121, 23);
            PaintToolThicknessComboBox.TabIndex = 3;
            PaintToolThicknessComboBox.SelectedIndexChanged += PaintToolThicknessComboBox_SelectedIndexChanged;
            // 
            // labelPaintToolThickness
            // 
            labelPaintToolThickness.AutoSize = true;
            labelPaintToolThickness.Location = new Point(6, 72);
            labelPaintToolThickness.Name = "labelPaintToolThickness";
            labelPaintToolThickness.Size = new Size(127, 15);
            labelPaintToolThickness.TabIndex = 2;
            labelPaintToolThickness.Text = "Товщина інструменту";
            // 
            // labelSelectedPaintTool
            // 
            labelSelectedPaintTool.AutoSize = true;
            labelSelectedPaintTool.Location = new Point(6, 27);
            labelSelectedPaintTool.Name = "labelSelectedPaintTool";
            labelSelectedPaintTool.Size = new Size(121, 15);
            labelSelectedPaintTool.TabIndex = 1;
            labelSelectedPaintTool.Text = "Обраний інструмент";
            // 
            // SelectedPaintToolComboBox
            // 
            SelectedPaintToolComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            SelectedPaintToolComboBox.Items.AddRange(new object[] { "Олівець", "Ручка" });
            SelectedPaintToolComboBox.Location = new Point(6, 46);
            SelectedPaintToolComboBox.Name = "SelectedPaintToolComboBox";
            SelectedPaintToolComboBox.Size = new Size(121, 23);
            SelectedPaintToolComboBox.TabIndex = 0;
            SelectedPaintToolComboBox.SelectedIndexChanged += SelectedPaintToolComboBox_SelectedIndexChanged;
            // 
            // ToolsGroupBox
            // 
            ToolsGroupBox.Controls.Add(buttonPipette);
            ToolsGroupBox.Controls.Add(buttonEraser);
            ToolsGroupBox.Controls.Add(buttonDrawText);
            ToolsGroupBox.Controls.Add(buttonFill);
            ToolsGroupBox.Controls.Add(buttonArbitraryDrawing);
            ToolsGroupBox.Location = new Point(248, 0);
            ToolsGroupBox.Name = "ToolsGroupBox";
            ToolsGroupBox.Size = new Size(122, 129);
            ToolsGroupBox.TabIndex = 2;
            ToolsGroupBox.TabStop = false;
            ToolsGroupBox.Text = "Знаряддя";
            // 
            // buttonPipette
            // 
            buttonPipette.AutoSize = true;
            buttonPipette.BackColor = SystemColors.Control;
            buttonPipette.FlatAppearance.BorderSize = 0;
            buttonPipette.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            buttonPipette.FlatStyle = FlatStyle.Flat;
            buttonPipette.Image = Properties.Resources.Pipette;
            buttonPipette.ImageAlign = ContentAlignment.MiddleLeft;
            buttonPipette.Location = new Point(70, 75);
            buttonPipette.Name = "buttonPipette";
            buttonPipette.Size = new Size(30, 30);
            buttonPipette.TabIndex = 6;
            buttonPipette.TextAlign = ContentAlignment.MiddleRight;
            buttonPipette.UseVisualStyleBackColor = false;
            // 
            // buttonEraser
            // 
            buttonEraser.AutoSize = true;
            buttonEraser.BackColor = SystemColors.Control;
            buttonEraser.FlatAppearance.BorderSize = 0;
            buttonEraser.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            buttonEraser.FlatStyle = FlatStyle.Flat;
            buttonEraser.Image = Properties.Resources.Eraser;
            buttonEraser.ImageAlign = ContentAlignment.MiddleLeft;
            buttonEraser.Location = new Point(22, 75);
            buttonEraser.Name = "buttonEraser";
            buttonEraser.Size = new Size(30, 30);
            buttonEraser.TabIndex = 5;
            buttonEraser.TextAlign = ContentAlignment.MiddleRight;
            buttonEraser.UseVisualStyleBackColor = false;
            // 
            // buttonDrawText
            // 
            buttonDrawText.AutoSize = true;
            buttonDrawText.BackColor = SystemColors.Control;
            buttonDrawText.FlatAppearance.BorderSize = 0;
            buttonDrawText.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            buttonDrawText.FlatStyle = FlatStyle.Flat;
            buttonDrawText.Image = Properties.Resources.DrawText;
            buttonDrawText.ImageAlign = ContentAlignment.MiddleLeft;
            buttonDrawText.Location = new Point(84, 22);
            buttonDrawText.Name = "buttonDrawText";
            buttonDrawText.Size = new Size(30, 30);
            buttonDrawText.TabIndex = 4;
            buttonDrawText.TextAlign = ContentAlignment.MiddleRight;
            buttonDrawText.UseVisualStyleBackColor = false;
            // 
            // buttonFill
            // 
            buttonFill.AutoSize = true;
            buttonFill.BackColor = SystemColors.Control;
            buttonFill.FlatAppearance.BorderSize = 0;
            buttonFill.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            buttonFill.FlatStyle = FlatStyle.Flat;
            buttonFill.Image = Properties.Resources.Fill;
            buttonFill.ImageAlign = ContentAlignment.MiddleLeft;
            buttonFill.Location = new Point(46, 22);
            buttonFill.Name = "buttonFill";
            buttonFill.Size = new Size(30, 30);
            buttonFill.TabIndex = 3;
            buttonFill.TextAlign = ContentAlignment.MiddleRight;
            buttonFill.UseVisualStyleBackColor = false;
            // 
            // buttonArbitraryDrawing
            // 
            buttonArbitraryDrawing.AutoSize = true;
            buttonArbitraryDrawing.BackColor = SystemColors.GradientActiveCaption;
            buttonArbitraryDrawing.FlatAppearance.BorderSize = 0;
            buttonArbitraryDrawing.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            buttonArbitraryDrawing.FlatStyle = FlatStyle.Flat;
            buttonArbitraryDrawing.Image = Properties.Resources.ArbitraryDrawing;
            buttonArbitraryDrawing.ImageAlign = ContentAlignment.MiddleLeft;
            buttonArbitraryDrawing.Location = new Point(8, 22);
            buttonArbitraryDrawing.Name = "buttonArbitraryDrawing";
            buttonArbitraryDrawing.Size = new Size(30, 30);
            buttonArbitraryDrawing.TabIndex = 2;
            buttonArbitraryDrawing.TextAlign = ContentAlignment.MiddleRight;
            buttonArbitraryDrawing.UseVisualStyleBackColor = false;
            // 
            // CanvasGroupBox
            // 
            CanvasGroupBox.Controls.Add(SelectionMenuStrip);
            CanvasGroupBox.Controls.Add(RotateFlipMenuStrip);
            CanvasGroupBox.Controls.Add(buttonChangeSize);
            CanvasGroupBox.Controls.Add(buttonCrop);
            CanvasGroupBox.Location = new Point(113, 0);
            CanvasGroupBox.Name = "CanvasGroupBox";
            CanvasGroupBox.Size = new Size(137, 129);
            CanvasGroupBox.TabIndex = 1;
            CanvasGroupBox.TabStop = false;
            CanvasGroupBox.Text = "Зображення";
            // 
            // SelectionMenuStrip
            // 
            SelectionMenuStrip.AutoSize = false;
            SelectionMenuStrip.Dock = DockStyle.None;
            SelectionMenuStrip.Items.AddRange(new ToolStripItem[] { SelectionToolStripMenuItem });
            SelectionMenuStrip.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
            SelectionMenuStrip.Location = new Point(1, 24);
            SelectionMenuStrip.Name = "SelectionMenuStrip";
            SelectionMenuStrip.Padding = new Padding(0);
            SelectionMenuStrip.Size = new Size(135, 20);
            SelectionMenuStrip.TabIndex = 5;
            SelectionMenuStrip.Text = "menuStrip2";
            // 
            // SelectionToolStripMenuItem
            // 
            SelectionToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { RectangleSelectionToolStripMenuItem, SelectAllToolStripMenuItem, ReverseSelectedAreaToolStripMenuItem, DeleteSelectAreaToolStripMenuItem });
            SelectionToolStripMenuItem.Image = Properties.Resources.Select;
            SelectionToolStripMenuItem.Name = "SelectionToolStripMenuItem";
            SelectionToolStripMenuItem.Size = new Size(134, 20);
            SelectionToolStripMenuItem.Text = "Виділення";
            // 
            // RectangleSelectionToolStripMenuItem
            // 
            RectangleSelectionToolStripMenuItem.Image = Properties.Resources.Select;
            RectangleSelectionToolStripMenuItem.Name = "RectangleSelectionToolStripMenuItem";
            RectangleSelectionToolStripMenuItem.Size = new Size(275, 22);
            RectangleSelectionToolStripMenuItem.Text = "Виділення прямокутного фрагмента";
            RectangleSelectionToolStripMenuItem.Click += RectangleSelectionToolStripMenuItem_Click;
            // 
            // SelectAllToolStripMenuItem
            // 
            SelectAllToolStripMenuItem.Image = Properties.Resources.SelectAll;
            SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem";
            SelectAllToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.A;
            SelectAllToolStripMenuItem.Size = new Size(275, 22);
            SelectAllToolStripMenuItem.Text = "Виділити все";
            SelectAllToolStripMenuItem.Click += SelectAllToolStripMenuItem_Click;
            // 
            // ReverseSelectedAreaToolStripMenuItem
            // 
            ReverseSelectedAreaToolStripMenuItem.Image = Properties.Resources.ReverseSelecting;
            ReverseSelectedAreaToolStripMenuItem.Name = "ReverseSelectedAreaToolStripMenuItem";
            ReverseSelectedAreaToolStripMenuItem.Size = new Size(275, 22);
            ReverseSelectedAreaToolStripMenuItem.Text = "Обернути виділення";
            ReverseSelectedAreaToolStripMenuItem.Click += ReverseSelectedAreaToolStripMenuItem_Click;
            // 
            // DeleteSelectAreaToolStripMenuItem
            // 
            DeleteSelectAreaToolStripMenuItem.Image = Properties.Resources.DeleteIcon;
            DeleteSelectAreaToolStripMenuItem.Name = "DeleteSelectAreaToolStripMenuItem";
            DeleteSelectAreaToolStripMenuItem.Size = new Size(275, 22);
            DeleteSelectAreaToolStripMenuItem.Text = "Видалити";
            DeleteSelectAreaToolStripMenuItem.Click += DeleteSelectAreaToolStripMenuItem_Click;
            // 
            // RotateFlipMenuStrip
            // 
            RotateFlipMenuStrip.AutoSize = false;
            RotateFlipMenuStrip.Dock = DockStyle.None;
            RotateFlipMenuStrip.Items.AddRange(new ToolStripItem[] { RotateFlipToolStripMenuItem });
            RotateFlipMenuStrip.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
            RotateFlipMenuStrip.Location = new Point(1, 46);
            RotateFlipMenuStrip.Name = "RotateFlipMenuStrip";
            RotateFlipMenuStrip.Padding = new Padding(0);
            RotateFlipMenuStrip.Size = new Size(135, 32);
            RotateFlipMenuStrip.TabIndex = 0;
            RotateFlipMenuStrip.Text = "menuStrip3";
            // 
            // RotateFlipToolStripMenuItem
            // 
            RotateFlipToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { NinetyDegToTheRightToolStripMenuItem, NinetyDegToTheLeftToolStripMenuItem, OneHundredEightyDegTurnToolStripMenuItem, MirrorVerticallyToolStripMenuItem, MirrorHorizontallyToolStripMenuItem });
            RotateFlipToolStripMenuItem.Image = Properties.Resources._90degToTheRight;
            RotateFlipToolStripMenuItem.Margin = new Padding(0, 5, 0, 0);
            RotateFlipToolStripMenuItem.Name = "RotateFlipToolStripMenuItem";
            RotateFlipToolStripMenuItem.Size = new Size(134, 20);
            RotateFlipToolStripMenuItem.Text = "Повернути";
            // 
            // NinetyDegToTheRightToolStripMenuItem
            // 
            NinetyDegToTheRightToolStripMenuItem.Image = Properties.Resources._90degToTheRight;
            NinetyDegToTheRightToolStripMenuItem.Name = "NinetyDegToTheRightToolStripMenuItem";
            NinetyDegToTheRightToolStripMenuItem.Size = new Size(269, 22);
            NinetyDegToTheRightToolStripMenuItem.Text = "Повернути праворуч на 90 градусів";
            NinetyDegToTheRightToolStripMenuItem.Click += NinetyDegToTheRightToolStripMenuItem_Click;
            // 
            // NinetyDegToTheLeftToolStripMenuItem
            // 
            NinetyDegToTheLeftToolStripMenuItem.Image = Properties.Resources._90degToTheLeft;
            NinetyDegToTheLeftToolStripMenuItem.Name = "NinetyDegToTheLeftToolStripMenuItem";
            NinetyDegToTheLeftToolStripMenuItem.Size = new Size(269, 22);
            NinetyDegToTheLeftToolStripMenuItem.Text = "Повернути ліворуч на 90 градусів";
            NinetyDegToTheLeftToolStripMenuItem.Click += NinetyDegToTheLeftToolStripMenuItem_Click;
            // 
            // OneHundredEightyDegTurnToolStripMenuItem
            // 
            OneHundredEightyDegTurnToolStripMenuItem.Image = Properties.Resources._180degTurn;
            OneHundredEightyDegTurnToolStripMenuItem.Name = "OneHundredEightyDegTurnToolStripMenuItem";
            OneHundredEightyDegTurnToolStripMenuItem.Size = new Size(269, 22);
            OneHundredEightyDegTurnToolStripMenuItem.Text = "Повернути на 180 градусів";
            OneHundredEightyDegTurnToolStripMenuItem.Click += OneHundredEightyDegTurnToolStripMenuItem_Click;
            // 
            // MirrorVerticallyToolStripMenuItem
            // 
            MirrorVerticallyToolStripMenuItem.Image = Properties.Resources.MirrorVertically;
            MirrorVerticallyToolStripMenuItem.Name = "MirrorVerticallyToolStripMenuItem";
            MirrorVerticallyToolStripMenuItem.Size = new Size(269, 22);
            MirrorVerticallyToolStripMenuItem.Text = "Відобразити зверху вниз";
            MirrorVerticallyToolStripMenuItem.Click += MirrorVerticallyToolStripMenuItem_Click;
            // 
            // MirrorHorizontallyToolStripMenuItem
            // 
            MirrorHorizontallyToolStripMenuItem.Image = Properties.Resources.MirrorHorizontally;
            MirrorHorizontallyToolStripMenuItem.Name = "MirrorHorizontallyToolStripMenuItem";
            MirrorHorizontallyToolStripMenuItem.Size = new Size(269, 22);
            MirrorHorizontallyToolStripMenuItem.Text = "Відобразити зліва направо";
            MirrorHorizontallyToolStripMenuItem.Click += MirrorHorizontallyToolStripMenuItem_Click;
            // 
            // buttonChangeSize
            // 
            buttonChangeSize.BackColor = SystemColors.Control;
            buttonChangeSize.FlatAppearance.BorderSize = 0;
            buttonChangeSize.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            buttonChangeSize.FlatStyle = FlatStyle.Flat;
            buttonChangeSize.Image = Properties.Resources.ChangeSize;
            buttonChangeSize.ImageAlign = ContentAlignment.MiddleLeft;
            buttonChangeSize.Location = new Point(11, 99);
            buttonChangeSize.Name = "buttonChangeSize";
            buttonChangeSize.Size = new Size(118, 24);
            buttonChangeSize.TabIndex = 4;
            buttonChangeSize.Text = "Змінити розмір";
            buttonChangeSize.TextAlign = ContentAlignment.MiddleRight;
            buttonChangeSize.UseVisualStyleBackColor = false;
            buttonChangeSize.Click += buttonChangeSize_Click;
            // 
            // buttonCrop
            // 
            buttonCrop.BackColor = SystemColors.Control;
            buttonCrop.FlatAppearance.BorderSize = 0;
            buttonCrop.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            buttonCrop.FlatStyle = FlatStyle.Flat;
            buttonCrop.Image = Properties.Resources.Crop;
            buttonCrop.ImageAlign = ContentAlignment.MiddleLeft;
            buttonCrop.Location = new Point(11, 75);
            buttonCrop.Name = "buttonCrop";
            buttonCrop.Size = new Size(79, 24);
            buttonCrop.TabIndex = 3;
            buttonCrop.Text = "Обітнути";
            buttonCrop.TextAlign = ContentAlignment.MiddleRight;
            buttonCrop.UseVisualStyleBackColor = false;
            buttonCrop.Click += buttonCrop_Click;
            // 
            // ClipboardGroupBox
            // 
            ClipboardGroupBox.Controls.Add(buttonCutOut);
            ClipboardGroupBox.Controls.Add(buttonCopy);
            ClipboardGroupBox.Controls.Add(buttonPasteFrom);
            ClipboardGroupBox.Controls.Add(buttonPaste);
            ClipboardGroupBox.Location = new Point(0, 0);
            ClipboardGroupBox.Name = "ClipboardGroupBox";
            ClipboardGroupBox.Size = new Size(113, 129);
            ClipboardGroupBox.TabIndex = 0;
            ClipboardGroupBox.TabStop = false;
            ClipboardGroupBox.Text = "Буфер обміну";
            // 
            // buttonCutOut
            // 
            buttonCutOut.BackColor = SystemColors.Control;
            buttonCutOut.Enabled = false;
            buttonCutOut.FlatAppearance.BorderSize = 0;
            buttonCutOut.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            buttonCutOut.FlatStyle = FlatStyle.Flat;
            buttonCutOut.Image = Properties.Resources.CutOut;
            buttonCutOut.ImageAlign = ContentAlignment.MiddleLeft;
            buttonCutOut.Location = new Point(6, 98);
            buttonCutOut.Name = "buttonCutOut";
            buttonCutOut.Size = new Size(82, 24);
            buttonCutOut.TabIndex = 3;
            buttonCutOut.Text = "Вирізати";
            buttonCutOut.TextAlign = ContentAlignment.MiddleRight;
            buttonCutOut.UseVisualStyleBackColor = false;
            buttonCutOut.Click += buttonCutOut_Click;
            // 
            // buttonCopy
            // 
            buttonCopy.BackColor = SystemColors.Control;
            buttonCopy.Enabled = false;
            buttonCopy.FlatAppearance.BorderSize = 0;
            buttonCopy.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            buttonCopy.FlatStyle = FlatStyle.Flat;
            buttonCopy.Image = Properties.Resources.Copy;
            buttonCopy.ImageAlign = ContentAlignment.MiddleLeft;
            buttonCopy.Location = new Point(6, 74);
            buttonCopy.Name = "buttonCopy";
            buttonCopy.Size = new Size(93, 24);
            buttonCopy.TabIndex = 2;
            buttonCopy.Text = "Копіювати";
            buttonCopy.TextAlign = ContentAlignment.MiddleRight;
            buttonCopy.UseVisualStyleBackColor = false;
            buttonCopy.Click += buttonCopy_Click;
            // 
            // buttonPasteFrom
            // 
            buttonPasteFrom.BackColor = SystemColors.Control;
            buttonPasteFrom.FlatAppearance.BorderSize = 0;
            buttonPasteFrom.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            buttonPasteFrom.FlatStyle = FlatStyle.Flat;
            buttonPasteFrom.Image = Properties.Resources.InsertFrom;
            buttonPasteFrom.ImageAlign = ContentAlignment.MiddleLeft;
            buttonPasteFrom.Location = new Point(6, 48);
            buttonPasteFrom.Name = "buttonPasteFrom";
            buttonPasteFrom.Size = new Size(92, 24);
            buttonPasteFrom.TabIndex = 1;
            buttonPasteFrom.Text = "Вставити з";
            buttonPasteFrom.TextAlign = ContentAlignment.MiddleRight;
            buttonPasteFrom.UseVisualStyleBackColor = false;
            buttonPasteFrom.Click += buttonPasteFrom_Click;
            // 
            // buttonPaste
            // 
            buttonPaste.BackColor = SystemColors.Control;
            buttonPaste.FlatAppearance.BorderSize = 0;
            buttonPaste.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            buttonPaste.FlatStyle = FlatStyle.Flat;
            buttonPaste.Image = Properties.Resources.Insert1;
            buttonPaste.ImageAlign = ContentAlignment.MiddleLeft;
            buttonPaste.Location = new Point(6, 22);
            buttonPaste.Name = "buttonPaste";
            buttonPaste.Size = new Size(84, 24);
            buttonPaste.TabIndex = 0;
            buttonPaste.Text = "Вставити";
            buttonPaste.TextAlign = ContentAlignment.MiddleRight;
            buttonPaste.UseVisualStyleBackColor = false;
            buttonPaste.Click += buttonPaste_Click;
            // 
            // StripMenu
            // 
            StripMenu.Controls.Add(UndoRedoToolStrip);
            StripMenu.Controls.Add(FileAndViewMenuStrip);
            StripMenu.Dock = DockStyle.Top;
            StripMenu.Location = new Point(0, 0);
            StripMenu.Name = "StripMenu";
            StripMenu.Size = new Size(1264, 24);
            StripMenu.TabIndex = 0;
            // 
            // UndoRedoToolStrip
            // 
            UndoRedoToolStrip.Dock = DockStyle.None;
            UndoRedoToolStrip.GripStyle = ToolStripGripStyle.Hidden;
            UndoRedoToolStrip.Items.AddRange(new ToolStripItem[] { UndoButton, RedoButton });
            UndoRedoToolStrip.Location = new Point(113, 0);
            UndoRedoToolStrip.Name = "UndoRedoToolStrip";
            UndoRedoToolStrip.Padding = new Padding(0);
            UndoRedoToolStrip.Size = new Size(48, 25);
            UndoRedoToolStrip.TabIndex = 1;
            UndoRedoToolStrip.Text = "toolStrip1";
            // 
            // UndoButton
            // 
            UndoButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            UndoButton.Image = Properties.Resources.Undo;
            UndoButton.ImageTransparentColor = Color.Magenta;
            UndoButton.Name = "UndoButton";
            UndoButton.Size = new Size(23, 22);
            UndoButton.Text = "Скасувати останню дію (Ctrl + Z)";
            UndoButton.Click += UndoButton_Click;
            // 
            // RedoButton
            // 
            RedoButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            RedoButton.Image = Properties.Resources.Redo;
            RedoButton.ImageTransparentColor = Color.Magenta;
            RedoButton.Name = "RedoButton";
            RedoButton.Size = new Size(23, 22);
            RedoButton.Text = "Повторити останню дію (Ctrl + Y)";
            RedoButton.Click += RedoButton_Click;
            // 
            // FileAndViewMenuStrip
            // 
            FileAndViewMenuStrip.Dock = DockStyle.None;
            FileAndViewMenuStrip.Items.AddRange(new ToolStripItem[] { FileToolStripMenuItem, ViewToolStripMenuItem });
            FileAndViewMenuStrip.Location = new Point(0, 0);
            FileAndViewMenuStrip.Name = "FileAndViewMenuStrip";
            FileAndViewMenuStrip.Size = new Size(113, 24);
            FileAndViewMenuStrip.TabIndex = 0;
            FileAndViewMenuStrip.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            FileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { CreateFileToolStripMenuItem, OpenFileToolStripMenuItem, SaveFileToolStripMenuItem, SaveFileHowToolStripMenuItem });
            FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            FileToolStripMenuItem.Size = new Size(48, 20);
            FileToolStripMenuItem.Text = "Файл";
            // 
            // CreateFileToolStripMenuItem
            // 
            CreateFileToolStripMenuItem.Image = Properties.Resources.Create;
            CreateFileToolStripMenuItem.Name = "CreateFileToolStripMenuItem";
            CreateFileToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            CreateFileToolStripMenuItem.Size = new Size(169, 22);
            CreateFileToolStripMenuItem.Text = "Створити";
            CreateFileToolStripMenuItem.Click += CreateFileToolStripMenuItem_Click;
            // 
            // OpenFileToolStripMenuItem
            // 
            OpenFileToolStripMenuItem.Image = Properties.Resources.Open;
            OpenFileToolStripMenuItem.Name = "OpenFileToolStripMenuItem";
            OpenFileToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            OpenFileToolStripMenuItem.Size = new Size(169, 22);
            OpenFileToolStripMenuItem.Text = "Відкрити";
            OpenFileToolStripMenuItem.Click += OpenFileToolStripMenuItem_Click;
            // 
            // SaveFileToolStripMenuItem
            // 
            SaveFileToolStripMenuItem.Image = Properties.Resources.Save;
            SaveFileToolStripMenuItem.Name = "SaveFileToolStripMenuItem";
            SaveFileToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            SaveFileToolStripMenuItem.Size = new Size(169, 22);
            SaveFileToolStripMenuItem.Text = "Зберегти";
            SaveFileToolStripMenuItem.Click += SaveFileToolStripMenuItem_Click;
            // 
            // SaveFileHowToolStripMenuItem
            // 
            SaveFileHowToolStripMenuItem.Image = Properties.Resources.SaveHow;
            SaveFileHowToolStripMenuItem.Name = "SaveFileHowToolStripMenuItem";
            SaveFileHowToolStripMenuItem.ShortcutKeys = Keys.F12;
            SaveFileHowToolStripMenuItem.Size = new Size(169, 22);
            SaveFileHowToolStripMenuItem.Text = "Зберегти як";
            SaveFileHowToolStripMenuItem.Click += SaveFileHowToolStripMenuItem_Click;
            // 
            // ViewToolStripMenuItem
            // 
            ViewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ZoomToolStripMenuItem, toolStripSeparator1, RulersToolStripMenuItem, GridToolStripMenuItem });
            ViewToolStripMenuItem.Name = "ViewToolStripMenuItem";
            ViewToolStripMenuItem.Size = new Size(57, 20);
            ViewToolStripMenuItem.Text = "Вигляд";
            // 
            // ZoomToolStripMenuItem
            // 
            ZoomToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ZoomInToolStripMenuItem, ZoomOutToolStripMenuItem, DefaultZoomToolStripMenuItem });
            ZoomToolStripMenuItem.Name = "ZoomToolStripMenuItem";
            ZoomToolStripMenuItem.Size = new Size(170, 22);
            ZoomToolStripMenuItem.Text = "Масштаб";
            // 
            // ZoomInToolStripMenuItem
            // 
            ZoomInToolStripMenuItem.Image = Properties.Resources.ZoomInIcon;
            ZoomInToolStripMenuItem.Name = "ZoomInToolStripMenuItem";
            ZoomInToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Oemplus;
            ZoomInToolStripMenuItem.Size = new Size(226, 22);
            ZoomInToolStripMenuItem.Text = "Збільшити";
            ZoomInToolStripMenuItem.Click += ZoomInToolStripMenuItem_Click;
            // 
            // ZoomOutToolStripMenuItem
            // 
            ZoomOutToolStripMenuItem.Image = Properties.Resources.ZoomOutIcon;
            ZoomOutToolStripMenuItem.Name = "ZoomOutToolStripMenuItem";
            ZoomOutToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.OemMinus;
            ZoomOutToolStripMenuItem.Size = new Size(226, 22);
            ZoomOutToolStripMenuItem.Text = "Зменшити";
            ZoomOutToolStripMenuItem.Click += ZoomOutToolStripMenuItem_Click;
            // 
            // DefaultZoomToolStripMenuItem
            // 
            DefaultZoomToolStripMenuItem.Image = Properties.Resources.RestoreZoomIcon;
            DefaultZoomToolStripMenuItem.Name = "DefaultZoomToolStripMenuItem";
            DefaultZoomToolStripMenuItem.Size = new Size(226, 22);
            DefaultZoomToolStripMenuItem.Text = "100%";
            DefaultZoomToolStripMenuItem.Click += DefaultZoomToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(167, 6);
            // 
            // RulersToolStripMenuItem
            // 
            RulersToolStripMenuItem.CheckOnClick = true;
            RulersToolStripMenuItem.Name = "RulersToolStripMenuItem";
            RulersToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.R;
            RulersToolStripMenuItem.Size = new Size(170, 22);
            RulersToolStripMenuItem.Text = "Лінійки";
            RulersToolStripMenuItem.CheckedChanged += RulersToolStripMenuItem_CheckedChanged;
            // 
            // GridToolStripMenuItem
            // 
            GridToolStripMenuItem.CheckOnClick = true;
            GridToolStripMenuItem.Name = "GridToolStripMenuItem";
            GridToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.G;
            GridToolStripMenuItem.Size = new Size(170, 22);
            GridToolStripMenuItem.Text = "Лінії сітки";
            GridToolStripMenuItem.CheckedChanged += GridToolStripMenuItem_CheckedChanged;
            // 
            // InfoStatusStrip
            // 
            InfoStatusStrip.Items.AddRange(new ToolStripItem[] { CanvasMouseLocationToolStripStatusLabel, SelectAreaImageSizeToolStripStatusLabel, CanvasSizeToolStripStatusLabel, ZoomFactorToolStripStatusLabel });
            InfoStatusStrip.Location = new Point(0, 839);
            InfoStatusStrip.Name = "InfoStatusStrip";
            InfoStatusStrip.Size = new Size(1264, 22);
            InfoStatusStrip.SizingGrip = false;
            InfoStatusStrip.TabIndex = 1;
            // 
            // CanvasMouseLocationToolStripStatusLabel
            // 
            CanvasMouseLocationToolStripStatusLabel.AutoSize = false;
            CanvasMouseLocationToolStripStatusLabel.Image = Properties.Resources.CursorPosition;
            CanvasMouseLocationToolStripStatusLabel.ImageAlign = ContentAlignment.MiddleLeft;
            CanvasMouseLocationToolStripStatusLabel.Name = "CanvasMouseLocationToolStripStatusLabel";
            CanvasMouseLocationToolStripStatusLabel.Size = new Size(130, 17);
            CanvasMouseLocationToolStripStatusLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // SelectAreaImageSizeToolStripStatusLabel
            // 
            SelectAreaImageSizeToolStripStatusLabel.AutoSize = false;
            SelectAreaImageSizeToolStripStatusLabel.Image = Properties.Resources.SelectAreaSize;
            SelectAreaImageSizeToolStripStatusLabel.ImageAlign = ContentAlignment.MiddleLeft;
            SelectAreaImageSizeToolStripStatusLabel.Name = "SelectAreaImageSizeToolStripStatusLabel";
            SelectAreaImageSizeToolStripStatusLabel.Size = new Size(130, 17);
            SelectAreaImageSizeToolStripStatusLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // CanvasSizeToolStripStatusLabel
            // 
            CanvasSizeToolStripStatusLabel.AutoSize = false;
            CanvasSizeToolStripStatusLabel.Image = Properties.Resources.CanvasSize;
            CanvasSizeToolStripStatusLabel.ImageAlign = ContentAlignment.MiddleLeft;
            CanvasSizeToolStripStatusLabel.Name = "CanvasSizeToolStripStatusLabel";
            CanvasSizeToolStripStatusLabel.Size = new Size(130, 17);
            CanvasSizeToolStripStatusLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ZoomFactorToolStripStatusLabel
            // 
            ZoomFactorToolStripStatusLabel.AutoSize = false;
            ZoomFactorToolStripStatusLabel.Name = "ZoomFactorToolStripStatusLabel";
            ZoomFactorToolStripStatusLabel.Size = new Size(130, 17);
            ZoomFactorToolStripStatusLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // MainSpace
            // 
            MainSpace.AutoScroll = true;
            MainSpace.Controls.Add(pictureBoxRulerLeft);
            MainSpace.Controls.Add(pictureBoxRulerTop);
            MainSpace.Controls.Add(pictureBoxFiller);
            MainSpace.Dock = DockStyle.Fill;
            MainSpace.Location = new Point(0, 153);
            MainSpace.Name = "MainSpace";
            MainSpace.Size = new Size(1264, 686);
            MainSpace.TabIndex = 2;
            MainSpace.Paint += MainSpace_Paint;
            // 
            // pictureBoxRulerLeft
            // 
            pictureBoxRulerLeft.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            pictureBoxRulerLeft.Location = new Point(0, 30);
            pictureBoxRulerLeft.Name = "pictureBoxRulerLeft";
            pictureBoxRulerLeft.Size = new Size(30, 656);
            pictureBoxRulerLeft.TabIndex = 2;
            pictureBoxRulerLeft.TabStop = false;
            pictureBoxRulerLeft.Paint += pictureBoxRulerLeft_Paint;
            // 
            // pictureBoxRulerTop
            // 
            pictureBoxRulerTop.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pictureBoxRulerTop.Location = new Point(30, 0);
            pictureBoxRulerTop.Name = "pictureBoxRulerTop";
            pictureBoxRulerTop.Size = new Size(1234, 30);
            pictureBoxRulerTop.TabIndex = 1;
            pictureBoxRulerTop.TabStop = false;
            pictureBoxRulerTop.Paint += pictureBoxRulerTop_Paint;
            // 
            // pictureBoxFiller
            // 
            pictureBoxFiller.Location = new Point(0, 0);
            pictureBoxFiller.Name = "pictureBoxFiller";
            pictureBoxFiller.Size = new Size(30, 30);
            pictureBoxFiller.TabIndex = 0;
            pictureBoxFiller.TabStop = false;
            // 
            // GraphicsEditorForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1264, 861);
            Controls.Add(MainSpace);
            Controls.Add(InfoStatusStrip);
            Controls.Add(Menu);
            KeyPreview = true;
            MinimumSize = new Size(300, 200);
            Name = "GraphicsEditorForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CopyOfPaint";
            FormClosing += GraphicsEditorForm_FormClosing;
            KeyDown += GraphicsEditorForm_KeyDown;
            Menu.ResumeLayout(false);
            PanelMenu.ResumeLayout(false);
            TextGroupBox.ResumeLayout(false);
            TextGroupBox.PerformLayout();
            FontEffectsMenuStrip.ResumeLayout(false);
            FontEffectsMenuStrip.PerformLayout();
            ColorsGroupBox.ResumeLayout(false);
            ShapesGroupBox.ResumeLayout(false);
            ShapesGroupBox.PerformLayout();
            LinearGradientDirectionMenuStrip.ResumeLayout(false);
            LinearGradientDirectionMenuStrip.PerformLayout();
            ShapeFillMenuStrip.ResumeLayout(false);
            ShapeFillMenuStrip.PerformLayout();
            ShapeOutlineMenuStrip.ResumeLayout(false);
            ShapeOutlineMenuStrip.PerformLayout();
            DrawingGroupBox.ResumeLayout(false);
            DrawingGroupBox.PerformLayout();
            ToolsGroupBox.ResumeLayout(false);
            ToolsGroupBox.PerformLayout();
            CanvasGroupBox.ResumeLayout(false);
            SelectionMenuStrip.ResumeLayout(false);
            SelectionMenuStrip.PerformLayout();
            RotateFlipMenuStrip.ResumeLayout(false);
            RotateFlipMenuStrip.PerformLayout();
            ClipboardGroupBox.ResumeLayout(false);
            StripMenu.ResumeLayout(false);
            StripMenu.PerformLayout();
            UndoRedoToolStrip.ResumeLayout(false);
            UndoRedoToolStrip.PerformLayout();
            FileAndViewMenuStrip.ResumeLayout(false);
            FileAndViewMenuStrip.PerformLayout();
            InfoStatusStrip.ResumeLayout(false);
            InfoStatusStrip.PerformLayout();
            MainSpace.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxRulerLeft).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRulerTop).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxFiller).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel Menu;
        private Panel StripMenu;
        private MenuStrip FileAndViewMenuStrip;
        private ToolStripMenuItem FileToolStripMenuItem;
        private ToolStripMenuItem CreateFileToolStripMenuItem;
        private ToolStripMenuItem OpenFileToolStripMenuItem;
        private ToolStripMenuItem SaveFileToolStripMenuItem;
        private ToolStripMenuItem SaveFileHowToolStripMenuItem;
        private ToolStripMenuItem ViewToolStripMenuItem;
        private ToolStripMenuItem ZoomToolStripMenuItem;
        private ToolStripMenuItem ZoomInToolStripMenuItem;
        private ToolStripMenuItem ZoomOutToolStripMenuItem;
        private ToolStripMenuItem DefaultZoomToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem RulersToolStripMenuItem;
        private ToolStripMenuItem GridToolStripMenuItem;
        private ToolStrip UndoRedoToolStrip;
        private ToolStripButton UndoButton;
        private ToolStripButton RedoButton;
        private Panel PanelMenu;
        private GroupBox ClipboardGroupBox;
        private Button buttonPaste;
        private Button buttonCutOut;
        private Button buttonCopy;
        private Button buttonPasteFrom;
        private GroupBox CanvasGroupBox;
        private MenuStrip SelectionMenuStrip;
        private ToolStripMenuItem SelectionToolStripMenuItem;
        private ToolStripMenuItem RectangleSelectionToolStripMenuItem;
        private ToolStripMenuItem SelectAllToolStripMenuItem;
        private ToolStripMenuItem ReverseSelectedAreaToolStripMenuItem;
        private Button buttonChangeSize;
        private Button buttonCrop;
        private MenuStrip RotateFlipMenuStrip;
        private ToolStripMenuItem RotateFlipToolStripMenuItem;
        private ToolStripMenuItem NinetyDegToTheRightToolStripMenuItem;
        private ToolStripMenuItem NinetyDegToTheLeftToolStripMenuItem;
        private ToolStripMenuItem OneHundredEightyDegTurnToolStripMenuItem;
        private ToolStripMenuItem MirrorVerticallyToolStripMenuItem;
        private ToolStripMenuItem MirrorHorizontallyToolStripMenuItem;
        private GroupBox ToolsGroupBox;
        private Button buttonPipette;
        private Button buttonEraser;
        private Button buttonDrawText;
        private Button buttonFill;
        private Button buttonArbitraryDrawing;
        private GroupBox DrawingGroupBox;
        private Label labelSelectedPaintTool;
        private ComboBox SelectedPaintToolComboBox;
        private ComboBox PaintToolThicknessComboBox;
        private Label labelPaintToolThickness;
        private GroupBox ShapesGroupBox;
        private Button buttonLine;
        private Button buttonCurve;
        private Button buttonEllipse;
        private Button buttonTriangle;
        private Button buttonRectangle;
        private Button buttonRhomb;
        private Button buttonPolygon;
        private MenuStrip ShapeOutlineMenuStrip;
        private ToolStripMenuItem ShapeOutlineToolStripMenuItem;
        private ToolStripMenuItem WithoutOutlineToolStripMenuItem;
        private ToolStripMenuItem WithOutlineToolStripMenuItem;
        private MenuStrip ShapeFillMenuStrip;
        private ToolStripMenuItem ShapeFillToolStripMenuItem;
        private ToolStripMenuItem NoFillToolStripMenuItem;
        private ToolStripMenuItem SolidColorFillToolStripMenuItem;
        private MenuStrip LinearGradientDirectionMenuStrip;
        private ToolStripMenuItem LinearGradientDirectionToolStripMenuItem;
        private ToolStripMenuItem LinearGradientFillToolStripMenuItem;
        private ToolStripMenuItem VerticalGradToolStripMenuItem;
        private ToolStripMenuItem HorizontalGradToolStripMenuItem;
        private ToolStripMenuItem ForwardDiagonalGradToolStripMenuItem;
        private ToolStripMenuItem BackwardDiagonalGradToolStripMenuItem;
        private GroupBox ColorsGroupBox;
        private Button buttonChangeColors;
        private Button buttonPrimaryColor;
        private Button buttonSecondaryColor;
        private GroupBox TextGroupBox;
        private Label labelSelectedFont;
        private Label labelFontSize;
        private MenuStrip FontEffectsMenuStrip;
        private ToolStripMenuItem FontEffectsToolStripMenuItem;
        private ToolStripMenuItem BoldFontToolStripMenuItem;
        private ToolStripMenuItem ItalicFontToolStripMenuItem;
        private ToolStripMenuItem UnderlinedTextToolStripMenuItem;
        private ToolStripMenuItem CrossedOutTextToolStripMenuItem;
        private Button buttonChangeFont;
        private StatusStrip InfoStatusStrip;
        private Panel MainSpace;
        private ToolStripStatusLabel CanvasMouseLocationToolStripStatusLabel;
        private ToolStripStatusLabel CanvasSizeToolStripStatusLabel;
        private ToolStripStatusLabel SelectAreaImageSizeToolStripStatusLabel;
        private ToolStripStatusLabel ZoomFactorToolStripStatusLabel;
        private ToolStripMenuItem DeleteSelectAreaToolStripMenuItem;
        private PictureBox pictureBoxRulerTop;
        private PictureBox pictureBoxFiller;
        private PictureBox pictureBoxRulerLeft;
    }
}
