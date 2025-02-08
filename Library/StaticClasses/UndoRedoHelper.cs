using Library.CustomControls;

namespace Library.StaticClasses
{
    public static class UndoRedoHelper
    {
        public static bool UndoRedoHappened { get; set; }

        private static Stack<Bitmap> UndoStack;

        private static Stack<Bitmap> RedoStack;

        static UndoRedoHelper()
        {
            UndoStack = new Stack<Bitmap>();
            RedoStack = new Stack<Bitmap>();
        }

        public static void Save(Bitmap canvas)
        {
            UndoStack.Push(new Bitmap(canvas));
            RedoStack.Clear();
            FileHelper.LastVersionSaved = false;
        }

        public static void Redo(CanvasView canvasView, ref Bitmap canvas, ref Graphics canvasGraphics)
        {
            if (RedoStack.Count > 0)
            {
                UndoStack.Push(new Bitmap(canvas));
                canvas = RedoStack.Pop();
                canvasGraphics = Graphics.FromImage(canvas);
                canvasView.Image = canvas;
                UndoRedoHappened = true;
                canvasView.Size = new Size((int)Math.Round(canvas.Width * AppManager.ZoomFactor), (int)Math.Round(canvas.Height * AppManager.ZoomFactor));
                UndoRedoHappened = false;
                FileHelper.LastVersionSaved = false;
            }
        }

        public static void Undo(CanvasView canvasView, ref Bitmap canvas, ref Graphics canvasGraphics)
        {
            if (UndoStack.Count > 0)
            {
                RedoStack.Push(new Bitmap(canvas));
                canvas = UndoStack.Pop();
                canvasGraphics = Graphics.FromImage(canvas);
                canvasView.Image = canvas;
                UndoRedoHappened = true;
                canvasView.Size = new Size((int)Math.Round(canvas.Width * AppManager.ZoomFactor), (int)Math.Round(canvas.Height * AppManager.ZoomFactor));
                UndoRedoHappened = false;
                FileHelper.LastVersionSaved = false;
            }
        }
    }
}
