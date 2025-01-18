using Library.CustomControls;
using System.Drawing.Imaging;

namespace Library.StaticClasses
{
    public static class FileHelper
    {
        public static bool LastVersionSaved { get; set; } = true;

        public static string DefaultName { get; set; } = "Без імені";

        public static string CurrentFilePath { get; set; } = string.Empty;

        public static void CreateImage(CanvasView Target, ref Bitmap canvas, ref Graphics canvasGraphics)
        {
            if (!LastVersionSaved)
            {
                string temp = CurrentFilePath != string.Empty ? Path.GetFileName(CurrentFilePath) : DefaultName;
                DialogResult dr = MessageBox.Show("Зберегти зміни в " + temp + "?", "CopyOfPaint", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                    Save(canvas);
                else if (dr == DialogResult.Cancel)
                    return;
            }  
            canvas = new Bitmap(AppState.DefaultCanvasSize.Width, AppState.DefaultCanvasSize.Height);
            canvasGraphics = Graphics.FromImage(canvas);
            canvasGraphics.Clear(Color.White);
            Target.Image = canvas;
            AppState.ZoomFactor = 1.0f;
            ZoomHelper.Activate(Target);
            CurrentFilePath = string.Empty;
            LastVersionSaved = true;
        }

        public static void OpenImage(CanvasView Target, ref Bitmap canvas, ref Graphics canvasGraphics)
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
                if (!LastVersionSaved)
                {
                    string temp = CurrentFilePath != string.Empty ? Path.GetFileName(CurrentFilePath) : DefaultName;
                    DialogResult dr = MessageBox.Show("Зберегти зміни в " + temp + "?", "CopyOfPaint", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                        Save(canvas);
                    else if (dr == DialogResult.Cancel)
                        return;
                }
                canvas = new Bitmap(ofd.FileName);
                canvasGraphics = Graphics.FromImage(canvas);
                Target.Image = canvas;
                AppState.ZoomFactor = 1.0f;
                ZoomHelper.Activate(Target);
                CurrentFilePath = ofd.FileName;
                LastVersionSaved = true;
            }
        }

        public static void Save(Bitmap canvas)
        {
            if (LastVersionSaved)
                return;

            if (CurrentFilePath == string.Empty)
                SaveHow(canvas);
            else
            {
                switch (Path.GetExtension(CurrentFilePath).ToLower())
                {
                    case ".bmp":
                        canvas.Save(CurrentFilePath, ImageFormat.Bmp);
                        break;
                    case ".gif":
                        canvas.Save(CurrentFilePath, ImageFormat.Gif);
                        break;
                    case ".jpeg":
                        canvas.Save(CurrentFilePath, ImageFormat.Jpeg);
                        break;
                    case ".png":
                        canvas.Save(CurrentFilePath, ImageFormat.Png);
                        break;
                    case ".tiff":
                        canvas.Save(CurrentFilePath, ImageFormat.Tiff);
                        break;
                    case ".ico":
                        canvas.Save(CurrentFilePath, ImageFormat.Icon);
                        break;
                }
            }
            LastVersionSaved = true;
        }

        public static void SaveHow(Bitmap canvas)
        {
            using var sfd = new SaveFileDialog();
            sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            sfd.Filter = "Bitmap (*.bmp)|*.bmp|"
                        + "GIF (*.gif)|*.gif|"
                        + "JPEG (*.jpeg)|*.jpeg;|"
                        + "PNG (*.png)|*.png|"
                        + "TIFF (*.tiff)|*.tiff|"
                        + "Icon (*.ico)|*.ico";
            sfd.FilterIndex = 4;
            sfd.FileName = CurrentFilePath != string.Empty ? Path.GetFileName(CurrentFilePath) : DefaultName;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                switch (Path.GetExtension(sfd.FileName).ToLower())
                {
                    case ".bmp":
                        canvas.Save(sfd.FileName, ImageFormat.Bmp);
                        break;
                    case ".gif":
                        canvas.Save(sfd.FileName, ImageFormat.Gif);
                        break;
                    case ".jpeg":
                        canvas.Save(sfd.FileName, ImageFormat.Jpeg);
                        break;
                    case ".png":
                        canvas.Save(sfd.FileName, ImageFormat.Png);
                        break;
                    case ".tiff":
                        canvas.Save(sfd.FileName, ImageFormat.Tiff);
                        break;
                    case ".ico":
                        canvas.Save(sfd.FileName, ImageFormat.Icon);
                        break;
                }
            }
            CurrentFilePath = sfd.FileName;
        }

        public static void CheckIfSavedBeforeExit(Bitmap canvas, FormClosingEventArgs e)
        {
            if (!LastVersionSaved)
            {
                string temp = CurrentFilePath != string.Empty ? Path.GetFileName(CurrentFilePath) : DefaultName;
                DialogResult dr = MessageBox.Show("Зберегти зміни в " + temp + "?", "CopyOfPaint", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                    Save(canvas);
                else if (dr == DialogResult.Cancel)
                    e.Cancel = true;
            }
        }
    }
}
