namespace Editor
{
    public partial class ChangeSizeForm : Form
    {
        public ChangeSizeForm(Size canvasSize)
        {
            InitializeComponent();
            canvasWidth = canvasSize.Width;
            canvasHeight = canvasSize.Height;
            maskedTextBoxWidth.Text = "100";
            maskedTextBoxHeight.Text = "100";
        }

        private readonly int canvasWidth;
        private readonly int canvasHeight;

        public Size NewSize { get; private set; }

        private void radioButtonPercents_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonPercents.Checked)
            {
                maskedTextBoxWidth.Text = "100";
                maskedTextBoxHeight.Text = "100";
            }
        }

        private void radioButtonPixels_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonPixels.Checked)
            {
                maskedTextBoxWidth.Text = canvasWidth.ToString();
                maskedTextBoxHeight.Text = canvasHeight.ToString();
            }
        }

        private void maskedTextBoxWidth_TextChanged(object sender, EventArgs e)
        {
            maskedTextBoxHeight.TextChanged -= maskedTextBoxHeight_TextChanged;
            if (maskedTextBoxWidth.Text == string.Empty && KeepTheProportionsCheckBox.Checked)
                maskedTextBoxHeight.Text = string.Empty;
            else if (KeepTheProportionsCheckBox.Checked)
            {
                if (radioButtonPixels.Checked)
                {
                    var width = int.Parse(maskedTextBoxWidth.Text);
                    var height = (int)Math.Round((float)width * canvasHeight / canvasWidth);
                    maskedTextBoxHeight.Text = height.ToString();
                }
                else
                    maskedTextBoxHeight.Text = maskedTextBoxWidth.Text;
            }
            maskedTextBoxHeight.TextChanged += maskedTextBoxHeight_TextChanged;
        }

        private void maskedTextBoxHeight_TextChanged(object sender, EventArgs e)
        {
            maskedTextBoxWidth.TextChanged -= maskedTextBoxWidth_TextChanged;
            if (maskedTextBoxHeight.Text == string.Empty && KeepTheProportionsCheckBox.Checked)
                maskedTextBoxWidth.Text = string.Empty;
            else if (KeepTheProportionsCheckBox.Checked)
            {
                if (radioButtonPixels.Checked)
                {
                    var height = int.Parse(maskedTextBoxHeight.Text);
                    var width = (int)Math.Round((float)height * canvasWidth / canvasHeight);
                    maskedTextBoxWidth.Text = width.ToString();
                }
                else
                    maskedTextBoxWidth.Text = maskedTextBoxHeight.Text;
            }
            maskedTextBoxWidth.TextChanged += maskedTextBoxWidth_TextChanged;

        }

        private bool CheckValues(MaskedTextBox maskedTextBox)
        {
            if (int.TryParse(maskedTextBox.Text, out var value))
            {
                if (radioButtonPercents.Checked && (value < 1 || value > 500))
                    ShowWarningMessage("Введіть припустиме число від 1 до 500");
                else if (value < 1 || value > 4000)
                    ShowWarningMessage("Введіть припустиме число від 1 до 4000");
                else
                    return true;
                return false;
            }
            else
                ShowWarningMessage("Щось пішло не так! Введіть значення ще раз");
            return false;

            void ShowWarningMessage(string message) => MessageBox.Show(message, "CopyOfPaint", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void ChangeSizeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                if (!CheckValues(maskedTextBoxWidth) || !CheckValues(maskedTextBoxHeight))
                    e.Cancel = true;
                else
                {
                    if (radioButtonPercents.Checked)
                        NewSize = new Size(canvasWidth * Convert.ToInt32(maskedTextBoxWidth.Text) / 100, canvasHeight * Convert.ToInt32(maskedTextBoxHeight.Text) / 100);
                    else
                        NewSize = new Size(Convert.ToInt32(maskedTextBoxWidth.Text), Convert.ToInt32(maskedTextBoxHeight.Text));
                }
            }
        }
    }
}
