namespace Editor
{
    partial class ChangeSizeForm
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
            label1 = new Label();
            radioButtonPercents = new RadioButton();
            radioButtonPixels = new RadioButton();
            label2 = new Label();
            label3 = new Label();
            KeepTheProportionsCheckBox = new CheckBox();
            label4 = new Label();
            label5 = new Label();
            buttonOK = new Button();
            buttonCancel = new Button();
            maskedTextBoxHeight = new MaskedTextBox();
            maskedTextBoxWidth = new MaskedTextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 14);
            label1.Name = "label1";
            label1.Size = new Size(25, 15);
            label1.TabIndex = 0;
            label1.Text = "На:";
            // 
            // radioButtonPercents
            // 
            radioButtonPercents.AutoSize = true;
            radioButtonPercents.Checked = true;
            radioButtonPercents.Location = new Point(53, 12);
            radioButtonPercents.Name = "radioButtonPercents";
            radioButtonPercents.Size = new Size(72, 19);
            radioButtonPercents.TabIndex = 1;
            radioButtonPercents.TabStop = true;
            radioButtonPercents.Text = "Відсотки";
            radioButtonPercents.UseVisualStyleBackColor = true;
            radioButtonPercents.CheckedChanged += radioButtonPercents_CheckedChanged;
            // 
            // radioButtonPixels
            // 
            radioButtonPixels.AutoSize = true;
            radioButtonPixels.Location = new Point(141, 12);
            radioButtonPixels.Name = "radioButtonPixels";
            radioButtonPixels.Size = new Size(65, 19);
            radioButtonPixels.TabIndex = 2;
            radioButtonPixels.TabStop = true;
            radioButtonPixels.Text = "Пікселі";
            radioButtonPixels.UseVisualStyleBackColor = true;
            radioButtonPixels.CheckedChanged += radioButtonPixels_CheckedChanged;
            // 
            // label2
            // 
            label2.Image = Properties.Resources.ChangeWidth;
            label2.Location = new Point(12, 43);
            label2.Name = "label2";
            label2.Size = new Size(38, 42);
            label2.TabIndex = 3;
            // 
            // label3
            // 
            label3.Image = Properties.Resources.ChangeHeight;
            label3.Location = new Point(12, 98);
            label3.Name = "label3";
            label3.Size = new Size(38, 42);
            label3.TabIndex = 4;
            // 
            // KeepTheProportionsCheckBox
            // 
            KeepTheProportionsCheckBox.AutoSize = true;
            KeepTheProportionsCheckBox.Checked = true;
            KeepTheProportionsCheckBox.CheckState = CheckState.Checked;
            KeepTheProportionsCheckBox.Location = new Point(12, 160);
            KeepTheProportionsCheckBox.Name = "KeepTheProportionsCheckBox";
            KeepTheProportionsCheckBox.Size = new Size(134, 19);
            KeepTheProportionsCheckBox.TabIndex = 5;
            KeepTheProportionsCheckBox.Text = "Зберегти пропорції";
            KeepTheProportionsCheckBox.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(56, 61);
            label4.Name = "label4";
            label4.Size = new Size(95, 15);
            label4.TabIndex = 6;
            label4.Text = "По горизонталі:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(56, 112);
            label5.Name = "label5";
            label5.Size = new Size(82, 15);
            label5.TabIndex = 7;
            label5.Text = "По вертикалі:";
            // 
            // buttonOK
            // 
            buttonOK.DialogResult = DialogResult.OK;
            buttonOK.FlatStyle = FlatStyle.Flat;
            buttonOK.Location = new Point(76, 187);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(75, 32);
            buttonOK.TabIndex = 10;
            buttonOK.Text = "ОК";
            buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            buttonCancel.DialogResult = DialogResult.Cancel;
            buttonCancel.FlatStyle = FlatStyle.Flat;
            buttonCancel.Location = new Point(167, 187);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 32);
            buttonCancel.TabIndex = 11;
            buttonCancel.Text = "Скасувати";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // maskedTextBoxHeight
            // 
            maskedTextBoxHeight.Location = new Point(157, 109);
            maskedTextBoxHeight.Mask = "0000";
            maskedTextBoxHeight.Name = "maskedTextBoxHeight";
            maskedTextBoxHeight.PromptChar = ' ';
            maskedTextBoxHeight.Size = new Size(85, 23);
            maskedTextBoxHeight.TabIndex = 12;
            maskedTextBoxHeight.ValidatingType = typeof(int);
            maskedTextBoxHeight.TextChanged += maskedTextBoxHeight_TextChanged;
            // 
            // maskedTextBoxWidth
            // 
            maskedTextBoxWidth.Location = new Point(157, 58);
            maskedTextBoxWidth.Mask = "0000";
            maskedTextBoxWidth.Name = "maskedTextBoxWidth";
            maskedTextBoxWidth.PromptChar = ' ';
            maskedTextBoxWidth.Size = new Size(85, 23);
            maskedTextBoxWidth.TabIndex = 13;
            maskedTextBoxWidth.ValidatingType = typeof(int);
            maskedTextBoxWidth.TextChanged += maskedTextBoxWidth_TextChanged;
            // 
            // ChangeSizeForm
            // 
            AcceptButton = buttonOK;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new Size(254, 231);
            Controls.Add(maskedTextBoxWidth);
            Controls.Add(maskedTextBoxHeight);
            Controls.Add(buttonCancel);
            Controls.Add(buttonOK);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(KeepTheProportionsCheckBox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(radioButtonPixels);
            Controls.Add(radioButtonPercents);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MaximumSize = new Size(270, 270);
            MinimizeBox = false;
            MinimumSize = new Size(270, 270);
            Name = "ChangeSizeForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Змінення розміру";
            FormClosing += ChangeSizeForm_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private RadioButton radioButtonPercents;
        private RadioButton radioButtonPixels;
        private Label label2;
        private Label label3;
        private CheckBox KeepTheProportionsCheckBox;
        private Label label4;
        private Label label5;
        private Button buttonOK;
        private Button buttonCancel;
        private MaskedTextBox maskedTextBoxHeight;
        private MaskedTextBox maskedTextBoxWidth;
    }
}