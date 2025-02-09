using Library.CustomControls;
using Library.Enums;
using Library.StaticClasses;
using System.Drawing.Drawing2D;
using System.Reflection;
using Timer = System.Windows.Forms.Timer;

namespace Editor
{
    public partial class GraphicsEditorForm : Form
    {
        CanvasView canvasView;
        Bitmap canvas;
        Graphics canvasGraphics;
        Timer fastTimer = new();
        Timer slowTimer = new();
        ChangeSizeForm changeSizeForm;
        bool ViewNeedsAnUpdate = false;

        public GraphicsEditorForm()
        {
            InitializeComponent();

            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, MainSpace, [true]);

            canvasView = new CanvasView();
            canvasView.Size = AppManager.DefaultCanvasSize;
            canvasView.Top = 5;
            canvasView.Left = 5;
            canvasView.BackColor = Color.White;
            canvasView.MouseDown += canvasView_MouseDown;
            canvasView.MouseUp += canvasView_MouseUp;
            canvasView.Paint += canvasView_Paint;
            canvasView.SizeChanged += canvasView_SizeChanged;
            canvas = new Bitmap(canvasView.Width, canvasView.Height);
            canvasView.Image = canvas;
            canvasGraphics = Graphics.FromImage(canvas);
            canvasGraphics.Clear(Color.White);
            MainSpace.Controls.Add(canvasView);

            MainSpace.MouseWheel += MainSpace_MouseWheel;

            AddPolygonAndCurveDrawOutOfCanvasViewBoundsClickHandlerRecursive(Controls);

            pictureBoxFiller.Visible = false;
            pictureBoxRulerLeft.Visible = false;
            pictureBoxRulerTop.Visible = false;

            CustomToolStripRenderer myToolStripRenderer = new CustomToolStripRenderer();

            ViewToolStripMenuItem.DropDown.Closing += PreventDropDownFromClosing;

            ToolTip toolTip = new();
            toolTip.ToolTipTitle = "������ �������� �������";
            toolTip.SetToolTip(buttonCopy, "Ctrl + C");
            toolTip.SetToolTip(buttonPaste, "Ctrl + V");
            toolTip.SetToolTip(buttonCutOut, "Ctrl + X");

            SelectionMenuStrip.Renderer = myToolStripRenderer;
            RotateFlipMenuStrip.Renderer = myToolStripRenderer;

            foreach (Button button in ToolsGroupBox.Controls)
            {
                button.Click += (sender, e) =>
                {
                    SelectionMenuStrip.BackColor = SystemColors.Control;
                    RectangleSelectionToolStripMenuItem.BackColor = SystemColors.Control;
                    SelectAllToolStripMenuItem.BackColor = SystemColors.Control;
                    buttonCrop.BackColor = SystemColors.Control;
                    foreach (Button button in ToolsGroupBox.Controls)
                        button.BackColor = SystemColors.Control;
                    foreach (Control control in ShapesGroupBox.Controls)
                    {
                        if (control.GetType() == typeof(Button))
                            control.BackColor = SystemColors.Control;
                    }
                    ((Button)sender).BackColor = SystemColors.GradientActiveCaption;
                    switch (button.Name)
                    {
                        case "buttonArbitraryDrawing":
                            AppManager.CurrentActionMode = ActionMode.ArbitraryDrawing;
                            break;
                        case "buttonFill":
                            AppManager.CurrentActionMode = ActionMode.Fill;
                            break;
                        case "buttonDrawText":
                            AppManager.CurrentActionMode = ActionMode.DrawText;
                            break;
                        case "buttonEraser":
                            AppManager.CurrentActionMode = ActionMode.Eraser;
                            break;
                        case "buttonPipette":
                            AppManager.CurrentActionMode = ActionMode.Pipette;
                            break;
                    }
                };
            }

            SelectedPaintToolComboBox.SelectedIndex = 0;
            PaintToolThicknessComboBox.SelectedIndex = 0;

            foreach (Control control in ShapesGroupBox.Controls)
            {
                if (control.GetType() == typeof(Button))
                    control.Click += (sender, e) =>
                    {
                        SelectionMenuStrip.BackColor = SystemColors.Control;
                        RectangleSelectionToolStripMenuItem.BackColor = SystemColors.Control;
                        SelectAllToolStripMenuItem.BackColor = SystemColors.Control;
                        buttonCrop.BackColor = SystemColors.Control;
                        foreach (Button button in ToolsGroupBox.Controls)
                            button.BackColor = SystemColors.Control;
                        foreach (Control control in ShapesGroupBox.Controls)
                        {
                            if (control.GetType() == typeof(Button))
                                control.BackColor = SystemColors.Control;
                        }
                        ((Button)sender).BackColor = SystemColors.GradientActiveCaption;
                        switch (((Button)sender).Name)
                        {
                            case "buttonLine":
                                AppManager.CurrentActionMode = ActionMode.DrawOrdinaryShape;
                                AppManager.SelectedShape = OrdinaryShape.Line;
                                break;
                            case "buttonCurve":
                                AppManager.CurrentActionMode = ActionMode.DrawCurve;
                                break;
                            case "buttonEllipse":
                                AppManager.CurrentActionMode = ActionMode.DrawOrdinaryShape;
                                AppManager.SelectedShape = OrdinaryShape.Ellipse;
                                break;
                            case "buttonTriangle":
                                AppManager.CurrentActionMode = ActionMode.DrawOrdinaryShape;
                                AppManager.SelectedShape = OrdinaryShape.Triangle;
                                break;
                            case "buttonRectangle":
                                AppManager.CurrentActionMode = ActionMode.DrawOrdinaryShape;
                                AppManager.SelectedShape = OrdinaryShape.Rectangle;
                                break;
                            case "buttonRhomb":
                                AppManager.CurrentActionMode = ActionMode.DrawOrdinaryShape;
                                AppManager.SelectedShape = OrdinaryShape.Rhomb;
                                break;
                            case "buttonPolygon":
                                AppManager.CurrentActionMode = ActionMode.DrawPolygon;
                                break;
                        }
                    };
            }
            ShapeOutlineMenuStrip.Renderer = myToolStripRenderer;
            ShapeFillMenuStrip.Renderer = myToolStripRenderer;
            LinearGradientDirectionMenuStrip.Renderer = myToolStripRenderer;
            WithOutlineToolStripMenuItem.BackColor = SystemColors.GradientActiveCaption;
            NoFillToolStripMenuItem.BackColor = SystemColors.GradientActiveCaption;
            VerticalGradToolStripMenuItem.BackColor = SystemColors.GradientActiveCaption;

            buttonPrimaryColor.Paint += buttonPrimaryColorUpdate;
            buttonPrimaryColorUpdate(buttonPrimaryColor, null);
            buttonPrimaryColor.BackColor = SystemColors.GradientActiveCaption;
            buttonSecondaryColor.Paint += buttonSecondaryColorUpdate;
            buttonSecondaryColorUpdate(buttonSecondaryColor, null);

            FontEffectsMenuStrip.Renderer = myToolStripRenderer;
            FontEffectsToolStripMenuItem.DropDown.Closing += PreventDropDownFromClosing;
            labelSelectedFont.Text += " " + AppManager.FontForDrawingText.Name;
            labelFontSize.Text += " " + AppManager.FontForDrawingText.Size.ToString();

            fastTimer.Interval = 8;
            fastTimer.Tick += (sender, e) =>
            {
                var pos = canvasView.PointToClient(Cursor.Position);
                if (canvasView.ClientRectangle.Contains(pos))
                    CanvasMouseLocationToolStripStatusLabel.Text = ((int)Math.Round(pos.X / AppManager.ZoomFactor)).ToString() + ", " + ((int)Math.Round(pos.Y / AppManager.ZoomFactor)).ToString() + "���";
                else
                    CanvasMouseLocationToolStripStatusLabel.Text = "";

                if (pictureBoxRulerLeft.Visible)
                {
                    pictureBoxRulerLeft.Refresh();
                    pictureBoxRulerTop.Refresh();
                }
            };
            fastTimer.Start();

            slowTimer.Interval = 100;
            slowTimer.Tick += (sender, e) =>
            {
                if (SelectTool.AlreadySelected)
                    SelectAreaImageSizeToolStripStatusLabel.Text = ((int)Math.Round(SelectTool.SelectArea.Width / AppManager.ZoomFactor)).ToString() + " x " + ((int)Math.Round(SelectTool.SelectArea.Height / AppManager.ZoomFactor)).ToString();
                else
                    SelectAreaImageSizeToolStripStatusLabel.Text = "";

                if (!canvasView.IsResizing)
                    CanvasSizeToolStripStatusLabel.Text = canvas.Width.ToString() + " x " + canvas.Height.ToString();
                else
                    CanvasSizeToolStripStatusLabel.Text = ((int)Math.Round(canvasView.PointForResizing.X / AppManager.ZoomFactor)).ToString() + " x " + ((int)Math.Round(canvasView.PointForResizing.Y / AppManager.ZoomFactor)).ToString();

                ZoomFactorToolStripStatusLabel.Text = "�������: " + (AppManager.ZoomFactor * 100).ToString() + " %";

                if (Clipboard.ContainsImage())
                    buttonPaste.Enabled = true;
                else
                    buttonPaste.Enabled = false;

                if (SelectTool.AlreadySelected)
                {
                    buttonCopy.Enabled = true;
                    buttonCutOut.Enabled = true;
                    buttonChangeSize.Enabled = false;
                    ReverseSelectedAreaToolStripMenuItem.Enabled = true;
                    DeleteSelectAreaToolStripMenuItem.Enabled = true;
                }
                else
                {
                    buttonCopy.Enabled = false;
                    buttonCutOut.Enabled = false;
                    buttonChangeSize.Enabled = true;
                    ReverseSelectedAreaToolStripMenuItem.Enabled = false;
                    DeleteSelectAreaToolStripMenuItem.Enabled = false;
                }

                if (FileHelper.CurrentFilePath == string.Empty)
                    Text = FileHelper.DefaultName;
                else
                    Text = Path.GetFileName(FileHelper.CurrentFilePath);
                Text += " - CopyOfPaint";
            };
            slowTimer.Start();
        }

        #region Toolstrip customization
        public class CustomToolStripRenderer : ToolStripProfessionalRenderer
        {
            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                base.OnRenderMenuItemBackground(e);
                if (!e.Item.IsOnDropDown)
                    e.Graphics.FillPolygon(new SolidBrush(Color.Black), [new PointF(e.Item.Width - 10, 6), new PointF(e.Item.Width - 10, e.Item.Height - 6), new PointF(e.Item.Width - 6, e.Item.Height / 2)]);
            }
        }

        private void PreventDropDownFromClosing(object? sender, ToolStripDropDownClosingEventArgs e)
        {
            var tsdd = (ToolStripDropDown)sender;

            Point p = tsdd.PointToClient(MousePosition);
            if (tsdd.ClientRectangle.Contains(p))
                e.Cancel = true;
        }

        #endregion

        #region File menu
        private void CreateFileToolStripMenuItem_Click(object sender, EventArgs e) => FileHelper.CreateImage(canvasView, ref canvas, ref canvasGraphics);

        private void OpenFileToolStripMenuItem_Click(object sender, EventArgs e) => FileHelper.OpenImage(canvasView, ref canvas, ref canvasGraphics);

        private void SaveFileToolStripMenuItem_Click(object sender, EventArgs e) => FileHelper.Save(canvas);

        private void SaveFileHowToolStripMenuItem_Click(object sender, EventArgs e) => FileHelper.SaveHow(canvas);

        #endregion

        #region View menu
        private void ZoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AppManager.ZoomFactor < 8.0f)
            {
                AppManager.ZoomFactor *= 2;
                ZoomHelper.Activate(canvasView);
                if (TextDrawHelper.IsActive)
                    TextDrawHelper.AdjustTextArea();
            }
        }

        private void ZoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AppManager.ZoomFactor > 0.125f)
            {
                AppManager.ZoomFactor /= 2;
                ZoomHelper.Activate(canvasView);
                if (TextDrawHelper.IsActive)
                    TextDrawHelper.AdjustTextArea();
            }
        }

        private void DefaultZoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AppManager.ZoomFactor = 1.0f;
            ZoomHelper.Activate(canvasView);
            if (TextDrawHelper.IsActive)
                TextDrawHelper.AdjustTextArea();
        }

        private void RulersToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (RulersToolStripMenuItem.Checked)
            {
                pictureBoxRulerLeft.Visible = true;
                pictureBoxRulerTop.Visible = true;
                float temp = AppManager.ZoomFactor;
                AppManager.ZoomFactor = 1.0f;
                ZoomHelper.Activate(canvasView);
                canvasView.Location = new Point(30, 30);
                AppManager.ZoomFactor = temp;
                ZoomHelper.Activate(canvasView);
            }
            else
            {
                pictureBoxRulerLeft.Visible = false;
                pictureBoxRulerTop.Visible = false;
                float temp = AppManager.ZoomFactor;
                AppManager.ZoomFactor = 1.0f;
                ZoomHelper.Activate(canvasView);
                canvasView.Location = new Point(5, 5);
                AppManager.ZoomFactor = temp;
                ZoomHelper.Activate(canvasView);
            }
        }

        private void GridToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            AppManager.GridEnabled = GridToolStripMenuItem.Checked;
            canvasView.Refresh();
        }

        #endregion

        #region Undo/Redo menu
        private void RedoButton_Click(object sender, EventArgs e)
        {
            UndoRedoHelper.Redo(canvasView, ref canvas, ref canvasGraphics);
        }

        private void UndoButton_Click(object sender, EventArgs e)
        {
            UndoRedoHelper.Undo(canvasView, ref canvas, ref canvasGraphics);
        }

        #endregion

        #region Clipboard menu
        private void buttonPaste_Click(object sender, EventArgs e)
        {
            AppManager.CurrentActionMode = ActionMode.Select;
            if (SelectTool.AlreadySelected)
            {
                RemoveSelectAreaOutOfBoundsClickHandlerRecursive(Controls);
                SelectTool.SelectAreaDispose(canvasView, canvas);
            }
            Bitmap tempBitmap = new Bitmap(Clipboard.GetImage());
            Size tempSize = new Size((int)Math.Round(tempBitmap.Width * AppManager.ZoomFactor), (int)Math.Round(tempBitmap.Height * AppManager.ZoomFactor));
            if (tempSize.Width > canvasView.Width || tempSize.Height > canvasView.Width)
                canvasView.Size = tempSize;
            SelectTool.SelectPastedImage(canvasView, tempBitmap);
            AddSelectAreaOutOfBoundsClickHandlerRecursive(Controls);
        }

        private void buttonPasteFrom_Click(object sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog();
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            ofd.Filter = "Bitmap (*.bmp)|*.bmp|"
                        + "GIF (*.gif)|*.gif|"
                        + "JPEG (*.jpeg)|*.jpeg;|"
                        + "PNG (*.png)|*.png|"
                        + "TIFF (*.tiff)|*.tiff|"
                        + "Icon (*.ico)|*.ico";
            ofd.FilterIndex = 4;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                AppManager.CurrentActionMode = ActionMode.Select;
                if (SelectTool.AlreadySelected)
                {
                    RemoveSelectAreaOutOfBoundsClickHandlerRecursive(Controls);
                    SelectTool.SelectAreaDispose(canvasView, canvas);
                }
                Bitmap tempBitmap = new Bitmap(ofd.FileName);
                Size tempSize = new Size((int)Math.Round(tempBitmap.Width * AppManager.ZoomFactor), (int)Math.Round(tempBitmap.Height * AppManager.ZoomFactor));
                if (tempSize.Width > canvasView.Width || tempSize.Height > canvasView.Width)
                    canvasView.Size = tempSize;
                SelectTool.SelectPastedImage(canvasView, tempBitmap);
                AddSelectAreaOutOfBoundsClickHandlerRecursive(Controls);
            }
        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            if (SelectTool.AlreadySelected)
                Clipboard.SetImage(SelectTool.SelectArea.Image);
        }

        private void buttonCutOut_Click(object sender, EventArgs e)
        {
            Clipboard.SetImage(SelectTool.SelectArea.Image);
            RemoveSelectAreaOutOfBoundsClickHandlerRecursive(Controls);
            SelectTool.SelectAreaDisposeWithoutDrawing(canvasView);
            SelectTool.AlreadySelected = false;
        }

        #endregion

        #region ImageOperations menu
        private void RectangleSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectionMenuStrip.BackColor = SystemColors.GradientActiveCaption;
            RectangleSelectionToolStripMenuItem.BackColor = SystemColors.GradientActiveCaption;
            SelectAllToolStripMenuItem.BackColor = SystemColors.Control;
            buttonCrop.BackColor = SystemColors.Control;
            foreach (Button button in ToolsGroupBox.Controls)
                button.BackColor = SystemColors.Control;
            foreach (Control control in ShapesGroupBox.Controls)
            {
                if (control.GetType() == typeof(Button))
                    control.BackColor = SystemColors.Control;
            }
            if (SelectTool.AlreadySelected)
            {
                SelectTool.SelectAreaDispose(canvasView, canvas);
                RemoveSelectAreaOutOfBoundsClickHandlerRecursive(Controls);
            }
            AppManager.CurrentActionMode = ActionMode.Select;
        }

        private void SelectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectionMenuStrip.BackColor = SystemColors.GradientActiveCaption;
            SelectAllToolStripMenuItem.BackColor = SystemColors.GradientActiveCaption;
            RectangleSelectionToolStripMenuItem.BackColor = SystemColors.Control;
            buttonCrop.BackColor = SystemColors.Control;
            foreach (Button button in ToolsGroupBox.Controls)
                button.BackColor = SystemColors.Control;
            foreach (Control control in ShapesGroupBox.Controls)
            {
                if (control.GetType() == typeof(Button))
                    control.BackColor = SystemColors.Control;
            }
            AppManager.CurrentActionMode = ActionMode.Select;
            if (SelectTool.AlreadySelected)
            {
                SelectTool.SelectAreaDispose(canvasView, canvas);
                RemoveSelectAreaOutOfBoundsClickHandlerRecursive(Controls);
            }
            SelectTool.SelectAll(canvasView, canvas);
            AddSelectAreaOutOfBoundsClickHandlerRecursive(Controls);
        }

        private void ReverseSelectedAreaToolStripMenuItem_Click(object sender, EventArgs e) => SelectTool.ReverseSelection(canvasView, canvas);

        private void DeleteSelectAreaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectTool.SelectAreaDisposeWithoutDrawing(canvasView);
            RemoveSelectAreaOutOfBoundsClickHandlerRecursive(Controls);
            SelectTool.AlreadySelected = false;
        }

        private void NinetyDegToTheRightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectTool.AlreadySelected)
            {
                Bitmap temp = (Bitmap)SelectTool.SelectArea.Image;
                RotateAndMirrorHelper.Rotate(SelectTool.SelectArea, ref temp, 90.0f);
                SelectTool.SelectArea.Image = temp;
            }
            else
            {
                UndoRedoHelper.Save(canvas);
                RotateAndMirrorHelper.Rotate(canvasView, ref canvas, 90.0f);
            }
        }

        private void NinetyDegToTheLeftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectTool.AlreadySelected)
            {
                Bitmap temp = (Bitmap)SelectTool.SelectArea.Image;
                RotateAndMirrorHelper.Rotate(SelectTool.SelectArea, ref temp, -90.0f);
                SelectTool.SelectArea.Image = temp;
            }
            else
            {
                UndoRedoHelper.Save(canvas);
                RotateAndMirrorHelper.Rotate(canvasView, ref canvas, -90.0f);
            }
        }

        private void OneHundredEightyDegTurnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectTool.AlreadySelected)
            {
                Bitmap temp = (Bitmap)SelectTool.SelectArea.Image;
                RotateAndMirrorHelper.Rotate(SelectTool.SelectArea, ref temp, 180.0f);
                SelectTool.SelectArea.Image = temp;
            }
            else
            {
                UndoRedoHelper.Save(canvas);
                RotateAndMirrorHelper.Rotate(canvasView, ref canvas, 180.0f);
            }
        }

        private void MirrorVerticallyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectTool.AlreadySelected)
            {
                Bitmap temp = (Bitmap)SelectTool.SelectArea.Image;
                RotateAndMirrorHelper.Mirror(SelectTool.SelectArea, ref temp, false);
                SelectTool.SelectArea.Image = temp;
            }
            else
            {
                UndoRedoHelper.Save(canvas);
                RotateAndMirrorHelper.Mirror(canvasView, ref canvas, false);
            }
        }

        private void MirrorHorizontallyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectTool.AlreadySelected)
            {
                Bitmap temp = (Bitmap)SelectTool.SelectArea.Image;
                RotateAndMirrorHelper.Mirror(SelectTool.SelectArea, ref temp, true);
                SelectTool.SelectArea.Image = temp;
            }
            else
            {
                UndoRedoHelper.Save(canvas);
                RotateAndMirrorHelper.Mirror(canvasView, ref canvas, true);
            }
        }

        private void buttonCrop_Click(object sender, EventArgs e)
        {
            if (SelectTool.AlreadySelected)
            {
                CropTool.Activate(canvasView, ref canvas, ref canvasGraphics, true);
                RemoveSelectAreaOutOfBoundsClickHandlerRecursive(Controls);
                SelectTool.AlreadySelected = false;
            }
            else
            {
                SelectAllToolStripMenuItem.BackColor = SystemColors.Control;
                RectangleSelectionToolStripMenuItem.BackColor = SystemColors.Control;
                foreach (Button button in ToolsGroupBox.Controls)
                    button.BackColor = SystemColors.Control;
                foreach (Control control in ShapesGroupBox.Controls)
                {
                    if (control.GetType() == typeof(Button))
                        control.BackColor = SystemColors.Control;
                }
                buttonCrop.BackColor = SystemColors.GradientActiveCaption;
                AppManager.CurrentActionMode = ActionMode.Crop;
            }

        }

        private void buttonChangeSize_Click(object sender, EventArgs e)
        {
            changeSizeForm = new ChangeSizeForm(canvas.Size);
            if (DialogResult.OK == changeSizeForm.ShowDialog())
            {
                UndoRedoHelper.Save(canvas);
                ResizeHelper.Activate(canvasView, ref canvas, ref canvasGraphics, changeSizeForm.NewSize);
            }
        }

        #endregion

        #region Paint tools menu
        private void SelectedPaintToolComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedPaintToolComboBox.SelectedIndex == 0)
                AppManager.SelectedTool = PaintTools.Pencil;
            else if (SelectedPaintToolComboBox.SelectedIndex == 1)
                AppManager.SelectedTool = PaintTools.Pen;
        }

        private void PaintToolThicknessComboBox_SelectedIndexChanged(object sender, EventArgs e) => AppManager.ToolThickness = PaintToolThicknessComboBox.SelectedIndex + 1;

        #endregion

        #region Shapes menu
        private void WithoutOutlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WithOutlineToolStripMenuItem.BackColor = SystemColors.Control;
            WithoutOutlineToolStripMenuItem.BackColor = SystemColors.GradientActiveCaption;
            if (NoFillToolStripMenuItem.BackColor == SystemColors.GradientActiveCaption)
                AppManager.SelectedShapeDrawMode = ShapeDrawMode.NoOutlineAndFill;
            else
                AppManager.SelectedShapeDrawMode = ShapeDrawMode.OnlyFill;
        }

        private void WithOutlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WithoutOutlineToolStripMenuItem.BackColor = SystemColors.Control;
            WithOutlineToolStripMenuItem.BackColor = SystemColors.GradientActiveCaption;
            if (NoFillToolStripMenuItem.BackColor == SystemColors.GradientActiveCaption)
                AppManager.SelectedShapeDrawMode = ShapeDrawMode.OnlyOutline;
            else
                AppManager.SelectedShapeDrawMode = ShapeDrawMode.OutlineAndFill;
        }

        private void NoFillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SolidColorFillToolStripMenuItem.BackColor = SystemColors.Control;
            LinearGradientFillToolStripMenuItem.BackColor = SystemColors.Control;
            NoFillToolStripMenuItem.BackColor = SystemColors.GradientActiveCaption;
            if (WithoutOutlineToolStripMenuItem.BackColor == SystemColors.GradientActiveCaption)
                AppManager.SelectedShapeDrawMode = ShapeDrawMode.NoOutlineAndFill;
            else
                AppManager.SelectedShapeDrawMode = ShapeDrawMode.OnlyOutline;
        }

        private void SolidColorFillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NoFillToolStripMenuItem.BackColor = SystemColors.Control;
            LinearGradientFillToolStripMenuItem.BackColor = SystemColors.Control;
            SolidColorFillToolStripMenuItem.BackColor = SystemColors.GradientActiveCaption;
            if (WithoutOutlineToolStripMenuItem.BackColor == SystemColors.GradientActiveCaption)
                AppManager.SelectedShapeDrawMode = ShapeDrawMode.OnlyFill;
            else
                AppManager.SelectedShapeDrawMode = ShapeDrawMode.OutlineAndFill;
            AppManager.SelectedShapeFillMode = ShapeFillMode.Solid;
        }

        private void LinearGradientFillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NoFillToolStripMenuItem.BackColor = SystemColors.Control;
            SolidColorFillToolStripMenuItem.BackColor = SystemColors.Control;
            if (WithoutOutlineToolStripMenuItem.BackColor == SystemColors.GradientActiveCaption)
                AppManager.SelectedShapeDrawMode = ShapeDrawMode.OnlyFill;
            else
                AppManager.SelectedShapeDrawMode = ShapeDrawMode.OutlineAndFill;
            AppManager.SelectedShapeFillMode = ShapeFillMode.LinearGradient;
        }

        private void VerticalGradToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HorizontalGradToolStripMenuItem.BackColor = SystemColors.Control;
            ForwardDiagonalGradToolStripMenuItem.BackColor = SystemColors.Control;
            BackwardDiagonalGradToolStripMenuItem.BackColor = SystemColors.Control;
            AppManager.SelectedShapeFillLinearGradientMode = LinearGradientMode.Vertical;
            VerticalGradToolStripMenuItem.BackColor = SystemColors.GradientActiveCaption;
        }

        private void HorizontalGradToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VerticalGradToolStripMenuItem.BackColor = SystemColors.Control;
            ForwardDiagonalGradToolStripMenuItem.BackColor = SystemColors.Control;
            BackwardDiagonalGradToolStripMenuItem.BackColor = SystemColors.Control;
            AppManager.SelectedShapeFillLinearGradientMode = LinearGradientMode.Horizontal;
            HorizontalGradToolStripMenuItem.BackColor = SystemColors.GradientActiveCaption;
        }

        private void ForwardDiagonalGradToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VerticalGradToolStripMenuItem.BackColor = SystemColors.Control;
            HorizontalGradToolStripMenuItem.BackColor = SystemColors.Control;
            BackwardDiagonalGradToolStripMenuItem.BackColor = SystemColors.Control;
            AppManager.SelectedShapeFillLinearGradientMode = LinearGradientMode.ForwardDiagonal;
            ForwardDiagonalGradToolStripMenuItem.BackColor = SystemColors.GradientActiveCaption;
        }

        private void BackwardDiagonalGradToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VerticalGradToolStripMenuItem.BackColor = SystemColors.Control;
            HorizontalGradToolStripMenuItem.BackColor = SystemColors.Control;
            ForwardDiagonalGradToolStripMenuItem.BackColor = SystemColors.Control;
            AppManager.SelectedShapeFillLinearGradientMode = LinearGradientMode.BackwardDiagonal;
            BackwardDiagonalGradToolStripMenuItem.BackColor = SystemColors.GradientActiveCaption;
        }

        #endregion

        #region Colors menu
        private void buttonPrimaryColor_Click(object sender, EventArgs e)
        {
            buttonPrimaryColor.BackColor = SystemColors.GradientActiveCaption;
            buttonSecondaryColor.BackColor = SystemColors.Control;
        }

        private void buttonPrimaryColorUpdate(object? sender, PaintEventArgs? e)
        {
            Graphics g = Graphics.FromImage(((Button)sender).Image);
            g.FillRectangle(new SolidBrush(AppManager.PrimaryColor), new Rectangle(3, 3, 17, 17));
        }

        private void buttonSecondaryColor_Click(object sender, EventArgs e)
        {
            buttonSecondaryColor.BackColor = SystemColors.GradientActiveCaption;
            buttonPrimaryColor.BackColor = SystemColors.Control;
        }

        private void buttonSecondaryColorUpdate(object? sender, PaintEventArgs? e)
        {
            Graphics g = Graphics.FromImage(((Button)sender).Image);
            g.FillRectangle(new SolidBrush(AppManager.SecondaryColor), new Rectangle(3, 3, 17, 17));
        }

        private void buttonChangeColors_Click(object sender, EventArgs e)
        {
            using var cd = new ColorDialog();
            cd.AnyColor = true;
            cd.FullOpen = true;
            if (cd.ShowDialog() == DialogResult.OK)
            {
                if (buttonPrimaryColor.BackColor == SystemColors.GradientActiveCaption)
                {
                    AppManager.PrimaryColor = cd.Color;
                    buttonPrimaryColor.Refresh();
                    buttonPrimaryColor.BackColor = SystemColors.GradientInactiveCaption;
                }
                else
                {
                    AppManager.SecondaryColor = cd.Color;
                    buttonSecondaryColor.Refresh();
                    buttonSecondaryColor.BackColor = SystemColors.GradientInactiveCaption;
                }
            }
        }

        #endregion

        #region Text menu
        private void BoldFontToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (BoldFontToolStripMenuItem.Checked)
                AppManager.FontForDrawingText = new Font(AppManager.FontForDrawingText, AppManager.FontForDrawingText.Style | FontStyle.Bold);
            else
                AppManager.FontForDrawingText = new Font(AppManager.FontForDrawingText, AppManager.FontForDrawingText.Style & (~FontStyle.Bold));
            if (TextDrawHelper.IsActive)
                TextDrawHelper.ApplyFont();
        }

        private void ItalicFontToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (ItalicFontToolStripMenuItem.Checked)
                AppManager.FontForDrawingText = new Font(AppManager.FontForDrawingText, AppManager.FontForDrawingText.Style | FontStyle.Italic);
            else
                AppManager.FontForDrawingText = new Font(AppManager.FontForDrawingText, AppManager.FontForDrawingText.Style & (~FontStyle.Italic));
            if (TextDrawHelper.IsActive)
                TextDrawHelper.ApplyFont();
        }

        private void UnderlinedTextToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (UnderlinedTextToolStripMenuItem.Checked)
                AppManager.FontForDrawingText = new Font(AppManager.FontForDrawingText, AppManager.FontForDrawingText.Style | FontStyle.Underline);
            else
                AppManager.FontForDrawingText = new Font(AppManager.FontForDrawingText, AppManager.FontForDrawingText.Style & (~FontStyle.Underline));
            if (TextDrawHelper.IsActive)
                TextDrawHelper.ApplyFont();
        }

        private void CrossedOutTextToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (CrossedOutTextToolStripMenuItem.Checked)
                AppManager.FontForDrawingText = new Font(AppManager.FontForDrawingText, AppManager.FontForDrawingText.Style | FontStyle.Strikeout);
            else
                AppManager.FontForDrawingText = new Font(AppManager.FontForDrawingText, AppManager.FontForDrawingText.Style & (~FontStyle.Strikeout));
            if (TextDrawHelper.IsActive)
                TextDrawHelper.ApplyFont();
        }

        private void buttonChangeFont_Click(object sender, EventArgs e)
        {
            using var fd = new FontDialog();
            fd.Font = AppManager.FontForDrawingText;
            fd.FontMustExist = true;
            fd.MinSize = 1;
            fd.MaxSize = 100;
            fd.ShowApply = true;
            fd.Apply += (sender, e) =>
            {
                if (TextDrawHelper.IsActive)
                    TextDrawHelper.TextArea.Font = fd.Font;
            };

            if (fd.ShowDialog() == DialogResult.OK)
            {
                AppManager.FontForDrawingText = fd.Font;
                labelSelectedFont.Text = "������� �����: " + fd.Font.Name;
                labelFontSize.Text = "�����: " + fd.Font.Size.ToString();

                BoldFontToolStripMenuItem.CheckedChanged -= BoldFontToolStripMenuItem_CheckedChanged;
                ItalicFontToolStripMenuItem.CheckedChanged -= ItalicFontToolStripMenuItem_CheckedChanged;
                UnderlinedTextToolStripMenuItem.CheckedChanged -= UnderlinedTextToolStripMenuItem_CheckedChanged;
                CrossedOutTextToolStripMenuItem.CheckedChanged -= CrossedOutTextToolStripMenuItem_CheckedChanged;

                BoldFontToolStripMenuItem.Checked = fd.Font.Bold;
                ItalicFontToolStripMenuItem.Checked = fd.Font.Italic;
                CrossedOutTextToolStripMenuItem.Checked = fd.Font.Strikeout;
                UnderlinedTextToolStripMenuItem.Checked = fd.Font.Underline;

                BoldFontToolStripMenuItem.CheckedChanged += BoldFontToolStripMenuItem_CheckedChanged;
                ItalicFontToolStripMenuItem.CheckedChanged += ItalicFontToolStripMenuItem_CheckedChanged;
                UnderlinedTextToolStripMenuItem.CheckedChanged += UnderlinedTextToolStripMenuItem_CheckedChanged;
                CrossedOutTextToolStripMenuItem.CheckedChanged += CrossedOutTextToolStripMenuItem_CheckedChanged;
            }
            if (TextDrawHelper.IsActive)
                TextDrawHelper.ApplyFont();
        }

        #endregion

        #region canvasView events
        private void canvasView_MouseDown(object? sender, MouseEventArgs e)
        {
            MouseTracker.RegisterDown(e);

            if (canvasView.IsResizing)
            {
                UndoRedoHelper.Save(canvas);
                return;
            }

            switch (AppManager.CurrentActionMode)
            {
                case ActionMode.ArbitraryDrawing:
                    UndoRedoHelper.Save(canvas);
                    ArbitraryDrawingHelper.Activate(canvasGraphics, false);
                    break;
                case ActionMode.Crop:
                case ActionMode.DrawOrdinaryShape:
                    UndoRedoHelper.Save(canvas);
                    break;
                case ActionMode.DrawCurve:
                    if (CurveDrawHelper.CurveDrawNotStarted)
                    {
                        CurveDrawHelper.Activate();
                        UndoRedoHelper.Save(canvas);
                    }
                    break;
                case ActionMode.DrawPolygon:
                    if (PolygonDrawHelper.PolygonDrawNotStarted)
                    {
                        PolygonDrawHelper.Activate();
                        UndoRedoHelper.Save(canvas);
                    }
                    break;
                case ActionMode.DrawText:
                    if (!TextDrawHelper.IsActive)
                    {
                        AddTextAreaOutOfBoundsClickHandlerRecursive(Controls);
                        TextDrawHelper.CreateTextArea(canvasView);
                    }
                    else
                        TextDrawHelper.IsActive = false;
                    break;
                case ActionMode.Eraser:
                    UndoRedoHelper.Save(canvas);
                    EraserTool.Activate(canvasGraphics, false);
                    break;
                case ActionMode.Fill:
                    UndoRedoHelper.Save(canvas);
                    FillTool.Activate(canvas);
                    break;
                case ActionMode.Pipette:
                    PipetteTool.Activate(canvas);
                    buttonPrimaryColor.Refresh();
                    buttonPrimaryColor.Refresh();
                    buttonSecondaryColor.Refresh();
                    buttonSecondaryColor.Refresh();
                    break;
            }

            canvasView.MouseMove += canvasView_MouseMove;
        }

        private void canvasView_MouseMove(object? sender, MouseEventArgs e)
        {
            MouseTracker.RegisterMove(e);

            switch (AppManager.CurrentActionMode)
            {
                case ActionMode.ArbitraryDrawing:
                    ArbitraryDrawingHelper.Activate(canvasGraphics, true);
                    break;
                case ActionMode.Eraser:
                    EraserTool.Activate(canvasGraphics, true);
                    break;
                case ActionMode.Crop:
                case ActionMode.DrawCurve:
                case ActionMode.DrawOrdinaryShape:
                case ActionMode.DrawPolygon:
                    ViewNeedsAnUpdate = true;
                    break;
                case ActionMode.Select:
                    if (!SelectTool.AlreadySelected)
                        ViewNeedsAnUpdate = true;
                    break;
            }

            canvasView.Refresh();
        }

        private void canvasView_MouseUp(object? sender, MouseEventArgs e)
        {
            if (canvasView.IsResizing)
                return;

            MouseTracker.RegisterUp(e);

            switch (AppManager.CurrentActionMode)
            {
                case ActionMode.Crop:
                    CropTool.Activate(canvasView, ref canvas, ref canvasGraphics);
                    break;
                case ActionMode.DrawCurve:
                    CurveDrawHelper.CreateCurve(canvasGraphics);
                    break;
                case ActionMode.DrawOrdinaryShape:
                    OrdinaryShapeDrawHelper.Activate(canvasGraphics, true);
                    break;
                case ActionMode.DrawPolygon:
                    PolygonDrawHelper.DrawOnCanvas(canvas, canvasGraphics);
                    break;
                case ActionMode.Select:
                    if (!SelectTool.AlreadySelected)
                    {
                        UndoRedoHelper.Save(canvas);
                        SelectTool.SelectSomeArea(canvasView, canvas);
                        AddSelectAreaOutOfBoundsClickHandlerRecursive(Controls);
                    }
                    else
                        SelectTool.AlreadySelected = false;
                    break;
            }

            canvasView.Refresh();

            canvasView.MouseMove -= canvasView_MouseMove;
        }

        private void canvasView_Paint(object? sender, PaintEventArgs e)
        {
            GraphicsState temp = e.Graphics.Save();
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            if (AppManager.ZoomFactor >= 1)
                e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            else
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Clear(Color.White);
            e.Graphics.DrawImage(canvas, 0, 0, canvasView.Width, canvasView.Height);

            e.Graphics.Restore(temp);

            if (AppManager.GridEnabled)
            {
                using Pen p = new Pen(Color.LightGray);

                int cellSizeLength;

                if (AppManager.ZoomFactor == 8)
                    cellSizeLength = 8;
                else if (AppManager.ZoomFactor == 4)
                    cellSizeLength = 4;
                else if (AppManager.ZoomFactor == 2)
                    cellSizeLength = 8;
                else
                    cellSizeLength = 10;

                for (int x = 0; x <= Width; x += cellSizeLength)
                    e.Graphics.DrawLine(p, x, 0, x, Height);

                for (int y = 0; y <= Height; y += cellSizeLength)
                    e.Graphics.DrawLine(p, 0, y, Width, y);
            }

            if (ViewNeedsAnUpdate)
            {
                switch (AppManager.CurrentActionMode)
                {
                    case ActionMode.DrawOrdinaryShape:
                        OrdinaryShapeDrawHelper.Activate(e.Graphics, false);
                        break;
                    case ActionMode.Crop:
                        CropTool.DrawPreviewBorder(canvasView, e.Graphics);
                        break;
                    case ActionMode.Select:
                        SelectTool.DrawPreviewBorder(canvasView, e.Graphics);
                        break;
                    case ActionMode.DrawPolygon:
                        PolygonDrawHelper.DrawOnCanvasView(e.Graphics);
                        break;
                    case ActionMode.DrawCurve:
                        CurveDrawHelper.CreateTemporaryCurve(e.Graphics);
                        break;
                }
                ViewNeedsAnUpdate = false;
            }
            else if (!CurveDrawHelper.CurveDrawNotStarted)
                CurveDrawHelper.DrawCurrentCurveOnCanvasView(e.Graphics);
        }

        private void canvasView_SizeChanged(object? sender, EventArgs e)
        {
            if (ZoomHelper.ZoomHappened)
            {
                canvasView.Refresh();
                ZoomHelper.ZoomHappened = false;
            }
            else if (CropTool.CropHappened)
                CropTool.CropHappened = false;
            else if (RotateAndMirrorHelper.RotateHappened)
            {
                RotateAndMirrorHelper.RotateHappened = false;
                ResizeHelper.Activate(canvasView, ref canvas, ref canvasGraphics);
                canvasView.Refresh();
            }
            else if (ResizeHelper.ResizeWithoutCropHappened)
            {
                ResizeHelper.ResizeWithoutCropHappened = false;
                canvasView.Refresh();
            }
            else if (UndoRedoHelper.UndoRedoHappened)
                canvasView.Refresh();
            else
            {
                ResizeHelper.Activate(canvasView, ref canvas, ref canvasGraphics);
                canvasView.Refresh();
            }
        }

        #endregion

        #region MainSpace events
        private void MainSpace_Paint(object sender, PaintEventArgs e)
        {
            var pos = MainSpace.PointToClient(Cursor.Position);
            if (canvasView.DragHandle == DragHandle.RightSide)
                ControlPaint.DrawBorder(e.Graphics, new Rectangle(canvasView.Left, canvasView.Top, pos.X - canvasView.Left, canvasView.Height), Color.Black, ButtonBorderStyle.Dotted);
            if (canvasView.DragHandle == DragHandle.BottomSide)
                ControlPaint.DrawBorder(e.Graphics, new Rectangle(canvasView.Left, canvasView.Top, canvasView.Width, pos.Y - canvasView.Top), Color.Black, ButtonBorderStyle.Dotted);
            else if (canvasView.DragHandle == DragHandle.BottomRightCorner)
                ControlPaint.DrawBorder(e.Graphics, new Rectangle(canvasView.Left, canvasView.Top, pos.X - canvasView.Left, pos.Y - canvasView.Top), Color.Black, ButtonBorderStyle.Dotted);
        }

        private void MainSpace_MouseWheel(object? sender, MouseEventArgs e)
        {
            if (ModifierKeys == Keys.Control)
            {
                MainSpace.AutoScroll = false;
                if (e.Delta > 0)
                    ZoomInToolStripMenuItem.PerformClick();
                else if (e.Delta < 0)
                    ZoomOutToolStripMenuItem.PerformClick();
                MainSpace.AutoScroll = true;
            }
        }

        #endregion

        #region SelectArea, TextArea, PolygonAndCurveDraw out of bounds click handling
        private void AddSelectAreaOutOfBoundsClickHandlerRecursive(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control.Name == "SelectionMenuStrip" || control.Name == "RotateFlipMenuStrip"
                 || control.Name == "buttonCopy" || control.Name == "buttonPaste"
                 || control.Name == "buttonPasteFrom" || control.Name == "buttonCutOut"
                 || control.Name == "buttonCrop" || control.Name == "FileAndViewMenuStrip")
                    continue;

                if (control.GetType() == typeof(Button) || control.GetType() == typeof(ComboBox)
                 || control.GetType() == typeof(CheckBox) || control.GetType() == typeof(MenuStrip)
                 || control.GetType() == typeof(ToolStrip) || control.Name == "MainSpace"
                 || control.GetType() == typeof(CanvasView))
                    control.Click += ClickHandlerForSelectArea;

                if (control.HasChildren)
                    AddSelectAreaOutOfBoundsClickHandlerRecursive(control.Controls);
                else if (control.GetType() == typeof(MenuStrip) || control.GetType() == typeof(ToolStrip))
                    AddSelectAreaOutOfBoundsClickHandlerRecursiveForTSI(((ToolStrip)control).Items);
            }

            ZoomToolStripMenuItem.Click += ClickHandlerForSelectArea;
            ZoomInToolStripMenuItem.Click += ClickHandlerForSelectArea;
            ZoomOutToolStripMenuItem.Click += ClickHandlerForSelectArea;
            DefaultZoomToolStripMenuItem.Click += ClickHandlerForSelectArea;
            FileToolStripMenuItem.Click += ClickHandlerForSelectArea;
            CreateFileToolStripMenuItem.Click += ClickHandlerForSelectArea;
            OpenFileToolStripMenuItem.Click += ClickHandlerForSelectArea;
            SaveFileHowToolStripMenuItem.Click += ClickHandlerForSelectArea;
            SaveFileHowToolStripMenuItem.Click += ClickHandlerForSelectArea;

            void AddSelectAreaOutOfBoundsClickHandlerRecursiveForTSI(ToolStripItemCollection items)
            {
                foreach (ToolStripItem item in items)
                {
                    item.Click += ClickHandlerForSelectArea;
                    if (item.GetType() == typeof(ToolStripMenuItem))
                        AddSelectAreaOutOfBoundsClickHandlerRecursiveForTSI(((ToolStripMenuItem)item).DropDownItems);
                }
            }
        }

        private void RemoveSelectAreaOutOfBoundsClickHandlerRecursive(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                control.Click -= ClickHandlerForSelectArea;

                if (control.HasChildren)
                    RemoveSelectAreaOutOfBoundsClickHandlerRecursive(control.Controls);
                else if (control.GetType() == typeof(MenuStrip) || control.GetType() == typeof(ToolStrip))
                    RemoveSelectAreaOutOfBoundsClickHandlerRecursiveForTSI(((ToolStrip)control).Items);
            }

            ZoomToolStripMenuItem.Click -= ClickHandlerForSelectArea;
            ZoomInToolStripMenuItem.Click -= ClickHandlerForSelectArea;
            ZoomOutToolStripMenuItem.Click -= ClickHandlerForSelectArea;
            DefaultZoomToolStripMenuItem.Click -= ClickHandlerForSelectArea;
            FileToolStripMenuItem.Click -= ClickHandlerForSelectArea;
            CreateFileToolStripMenuItem.Click -= ClickHandlerForSelectArea;
            OpenFileToolStripMenuItem.Click -= ClickHandlerForSelectArea;
            SaveFileHowToolStripMenuItem.Click -= ClickHandlerForSelectArea;
            SaveFileHowToolStripMenuItem.Click -= ClickHandlerForSelectArea;

            void RemoveSelectAreaOutOfBoundsClickHandlerRecursiveForTSI(ToolStripItemCollection items)
            {
                foreach (ToolStripItem item in items)
                {
                    item.Click -= ClickHandlerForSelectArea;
                    if (item.GetType() == typeof(ToolStripMenuItem))
                        RemoveSelectAreaOutOfBoundsClickHandlerRecursiveForTSI(((ToolStripMenuItem)item).DropDownItems);
                }
            }
        }

        private void ClickHandlerForSelectArea(object? sender, EventArgs e)
        {
            UndoRedoHelper.Save(canvas);
            SelectTool.SelectAreaDispose(canvasView, canvas);
            RemoveSelectAreaOutOfBoundsClickHandlerRecursive(Controls);
            if (sender.GetType() != typeof(CanvasView))
                SelectTool.AlreadySelected = false;
        }

        private void AddTextAreaOutOfBoundsClickHandlerRecursive(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control.Name == "buttonChangeFont" || control.Name == "buttonChangeColors"
                 || control.Name == "buttonPrimaryColor" || control.Name == "buttonSecondaryColor"
                 || control.Name == "FontEffectsMenuStrip" || control.Name == "FileAndViewMenuStrip")
                    continue;

                control.Click += ClickHandlerForTextArea;

                if (control.HasChildren)
                    AddTextAreaOutOfBoundsClickHandlerRecursive(control.Controls);
                else if (control.GetType() == typeof(MenuStrip) || control.GetType() == typeof(ToolStrip))
                    AddTextAreaOutOfBoundsClickHandlerRecursiveForTSI(((ToolStrip)control).Items);
            }

            FileToolStripMenuItem.Click += ClickHandlerForTextArea;
            CreateFileToolStripMenuItem.Click += ClickHandlerForTextArea;
            OpenFileToolStripMenuItem.Click += ClickHandlerForTextArea;
            SaveFileHowToolStripMenuItem.Click += ClickHandlerForTextArea;
            SaveFileHowToolStripMenuItem.Click += ClickHandlerForTextArea;

            void AddTextAreaOutOfBoundsClickHandlerRecursiveForTSI(ToolStripItemCollection items)
            {
                foreach (ToolStripItem item in items)
                {
                    item.Click += ClickHandlerForTextArea;
                    if (item.GetType() == typeof(ToolStripMenuItem))
                        AddTextAreaOutOfBoundsClickHandlerRecursiveForTSI(((ToolStripMenuItem)item).DropDownItems);
                }
            }
        }

        private void RemoveTextAreaOutOfBoundsClickHandlerRecursive(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                control.Click -= ClickHandlerForTextArea;

                if (control.HasChildren)
                    RemoveTextAreaOutOfBoundsClickHandlerRecursive(control.Controls);
                else if (control.GetType() == typeof(MenuStrip) || control.GetType() == typeof(ToolStrip))
                    RemoveTextAreaOutOfBoundsClickHandlerRecursiveForTSI(((ToolStrip)control).Items);
            }

            FileToolStripMenuItem.Click -= ClickHandlerForTextArea;
            CreateFileToolStripMenuItem.Click -= ClickHandlerForTextArea;
            OpenFileToolStripMenuItem.Click -= ClickHandlerForTextArea;
            SaveFileHowToolStripMenuItem.Click -= ClickHandlerForTextArea;
            SaveFileHowToolStripMenuItem.Click -= ClickHandlerForTextArea;

            void RemoveTextAreaOutOfBoundsClickHandlerRecursiveForTSI(ToolStripItemCollection items)
            {
                foreach (ToolStripItem item in items)
                {
                    item.Click -= ClickHandlerForTextArea;
                    if (item.GetType() == typeof(ToolStripMenuItem))
                        RemoveTextAreaOutOfBoundsClickHandlerRecursiveForTSI(((ToolStripMenuItem)item).DropDownItems);
                }
            }
        }

        private void ClickHandlerForTextArea(object? sender, EventArgs e)
        {
            UndoRedoHelper.Save(canvas);
            TextDrawHelper.TextAreaDispose(canvasView, canvas);
            RemoveTextAreaOutOfBoundsClickHandlerRecursive(Controls);
            if (sender.GetType() != typeof(CanvasView))
                TextDrawHelper.IsActive = false;
        }

        private void AddPolygonAndCurveDrawOutOfCanvasViewBoundsClickHandlerRecursive(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control.GetType() != typeof(CanvasView))
                    control.Click += (sender, e) =>
                    {
                        if (!PolygonDrawHelper.PolygonDrawNotStarted)
                            PolygonDrawHelper.PolygonDrawNotStarted = true;
                        if (!CurveDrawHelper.CurveDrawNotStarted)
                        {
                            CurveDrawHelper.DrawCurrentCurveOnCanvas(canvasGraphics);
                            CurveDrawHelper.CurveDrawNotStarted = true;
                            canvasView.Refresh();
                        }
                    };

                if (control.HasChildren)
                    AddPolygonAndCurveDrawOutOfCanvasViewBoundsClickHandlerRecursive(control.Controls);
                else if (control.GetType() == typeof(MenuStrip) || control.GetType() == typeof(ToolStrip))
                    AddPolygonAndCurveDrawOutOfCanvasViewBoundsClickHandlerRecursiveForTSI(((ToolStrip)control).Items);
            }

            void AddPolygonAndCurveDrawOutOfCanvasViewBoundsClickHandlerRecursiveForTSI(ToolStripItemCollection items)
            {
                foreach (ToolStripItem item in items)
                {
                    item.Click += (sender, e) =>
                    {
                        if (!PolygonDrawHelper.PolygonDrawNotStarted)
                            PolygonDrawHelper.PolygonDrawNotStarted = true;
                        if (!CurveDrawHelper.CurveDrawNotStarted)
                        {
                            CurveDrawHelper.DrawCurrentCurveOnCanvas(canvasGraphics);
                            CurveDrawHelper.CurveDrawNotStarted = true;
                            canvasView.Refresh();
                        }
                            
                    };
                    if (item.GetType() == typeof(ToolStripMenuItem))
                        AddPolygonAndCurveDrawOutOfCanvasViewBoundsClickHandlerRecursiveForTSI(((ToolStripMenuItem)item).DropDownItems);
                }
            }
        }

        #endregion

        #region Form events
        private void GraphicsEditorForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.C:
                        buttonCopy.PerformClick();
                        break;
                    case Keys.V:
                        buttonPaste.PerformClick();
                        break;
                    case Keys.X:
                        buttonCutOut.PerformClick();
                        break;
                    case Keys.Z:
                        UndoButton.PerformClick();
                        break;
                    case Keys.Y:
                        RedoButton.PerformClick();
                        break;
                    case Keys.N:
                        CreateFileToolStripMenuItem.PerformClick();
                        break;
                    case Keys.O:
                        OpenFileToolStripMenuItem.PerformClick();
                        break;
                    case Keys.S:
                        SaveFileToolStripMenuItem.PerformClick();
                        break;
                    case Keys.R:
                        RulersToolStripMenuItem.PerformClick();
                        break;
                    case Keys.G:
                        GridToolStripMenuItem.PerformClick();
                        break;
                    case Keys.A:
                        SelectAllToolStripMenuItem.PerformClick();
                        break;
                }
            }
            else if (e.KeyCode == Keys.Delete)
            {
                if (TextDrawHelper.IsActive)
                {
                    TextDrawHelper.TextAreaDisposeWithoutDrawing(canvasView);
                    RemoveTextAreaOutOfBoundsClickHandlerRecursive(Controls);
                    if (sender.GetType() != typeof(CanvasView))
                        TextDrawHelper.IsActive = false;
                }
                else
                    DeleteSelectAreaToolStripMenuItem.PerformClick();
            }
            else if (e.KeyCode == Keys.F12)
                SaveFileHowToolStripMenuItem.PerformClick();
        }

        private void GraphicsEditorForm_FormClosing(object sender, FormClosingEventArgs e) => FileHelper.CheckIfSavedBeforeExit(canvas, e);

        #endregion

        #region Paint events for displaying and updating rulers
        private void pictureBoxRulerTop_Paint(object sender, PaintEventArgs e)
        {
            using Pen p = new Pen(Color.LightGray);

            using Font f = new Font(DefaultFont.FontFamily, DefaultFont.Size - 1);

            int step;

            if (AppManager.ZoomFactor == 8)
                step = 8;
            else if (AppManager.ZoomFactor == 4)
                step = 8;
            else if (AppManager.ZoomFactor == 2)
                step = 8;
            else
                step = 10;

            for (float i = 0, x = 0; x <= pictureBoxRulerTop.Width; ++i, x += step)
            {
                if (i % 10 == 0)
                {
                    e.Graphics.DrawLine(Pens.Black, x, 0, x, 15);
                    e.Graphics.DrawString(((int)Math.Floor(x / AppManager.ZoomFactor)).ToString(), f, Brushes.Black, new PointF(x - 2, 17));
                }
                else
                    e.Graphics.DrawLine(p, x, 5, x, 15);
            }

            var pos = canvasView.PointToClient(Cursor.Position);
            e.Graphics.DrawLine(Pens.IndianRed, pos.X, 0, pos.X, 15);
        }

        private void pictureBoxRulerLeft_Paint(object sender, PaintEventArgs e)
        {
            using Pen p = new Pen(Color.LightGray);

            using Font f = new Font(DefaultFont.FontFamily, DefaultFont.Size - 1);

            int step;

            if (AppManager.ZoomFactor == 8)
                step = 8;
            else if (AppManager.ZoomFactor == 4)
                step = 8;
            else if (AppManager.ZoomFactor == 2)
                step = 8;
            else
                step = 10;

            for (float i = 0, y = 0; y <= pictureBoxRulerLeft.Height; ++i, y += step)
            {
                if (i % 10 == 0)
                {
                    e.Graphics.DrawLine(Pens.Black, 0, y, 15, y);
                    string temp = ((int)Math.Floor(y / AppManager.ZoomFactor)).ToString();
                    e.Graphics.RotateTransform(-90);
                    e.Graphics.TranslateTransform(17, y + TextRenderer.MeasureText(temp, f).Width, MatrixOrder.Append);
                    e.Graphics.DrawString(temp, f, Brushes.Black, new PointF(0, 0));
                    e.Graphics.ResetTransform();
                }
                else
                    e.Graphics.DrawLine(p, 5, y, 15, y);
            }

            var pos = canvasView.PointToClient(Cursor.Position);
            e.Graphics.DrawLine(Pens.IndianRed, 0, pos.Y, 15, pos.Y);
        }
        #endregion
    }
}
