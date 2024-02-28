namespace PrinterConfig
{
    partial class Form1
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
            LoadPrinterListButton = new Button();
            PrintersProcessedPercentageBar = new ProgressBar();
            SendConfigButton = new Button();
            PrintersListBox = new ListBox();
            SelectConfigButton = new Button();
            OutPutListBox = new ListBox();
            AddPrinterTextBox = new TextBox();
            AddPrinterButton = new Button();
            groupBox1 = new GroupBox();
            ClearPrinterListButton = new Button();
            PrintersToProcessLabel = new Label();
            CompletedLabel = new Label();
            ConfigSendlistBox = new ListBox();
            label1 = new Label();
            label2 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // LoadPrinterListButton
            // 
            LoadPrinterListButton.BackColor = SystemColors.ButtonFace;
            LoadPrinterListButton.Location = new Point(359, 375);
            LoadPrinterListButton.Name = "LoadPrinterListButton";
            LoadPrinterListButton.Size = new Size(156, 28);
            LoadPrinterListButton.TabIndex = 0;
            LoadPrinterListButton.Text = "Load Printer List";
            LoadPrinterListButton.UseVisualStyleBackColor = false;
            LoadPrinterListButton.Click += LoadPrinterListButton_Click;
            // 
            // PrintersProcessedPercentageBar
            // 
            PrintersProcessedPercentageBar.BackColor = SystemColors.ButtonFace;
            PrintersProcessedPercentageBar.ForeColor = SystemColors.ControlDarkDark;
            PrintersProcessedPercentageBar.Location = new Point(14, 431);
            PrintersProcessedPercentageBar.Margin = new Padding(5);
            PrintersProcessedPercentageBar.MarqueeAnimationSpeed = 10;
            PrintersProcessedPercentageBar.Name = "PrintersProcessedPercentageBar";
            PrintersProcessedPercentageBar.Size = new Size(661, 21);
            PrintersProcessedPercentageBar.Step = 1;
            PrintersProcessedPercentageBar.Style = ProgressBarStyle.Continuous;
            PrintersProcessedPercentageBar.TabIndex = 1;
            // 
            // SendConfigButton
            // 
            SendConfigButton.BackColor = SystemColors.ButtonFace;
            SendConfigButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 192, 0);
            SendConfigButton.FlatAppearance.MouseOverBackColor = Color.Blue;
            SendConfigButton.Location = new Point(533, 375);
            SendConfigButton.Name = "SendConfigButton";
            SendConfigButton.Size = new Size(144, 28);
            SendConfigButton.TabIndex = 2;
            SendConfigButton.Text = "Send File To Printers";
            SendConfigButton.UseVisualStyleBackColor = false;
            SendConfigButton.Click += SendConfigButton_Click;
            // 
            // PrintersListBox
            // 
            PrintersListBox.FormattingEnabled = true;
            PrintersListBox.ItemHeight = 15;
            PrintersListBox.Location = new Point(359, 95);
            PrintersListBox.Name = "PrintersListBox";
            PrintersListBox.Size = new Size(156, 274);
            PrintersListBox.TabIndex = 3;
            // 
            // SelectConfigButton
            // 
            SelectConfigButton.BackColor = SystemColors.ButtonFace;
            SelectConfigButton.Location = new Point(12, 375);
            SelectConfigButton.Name = "SelectConfigButton";
            SelectConfigButton.Size = new Size(327, 28);
            SelectConfigButton.TabIndex = 4;
            SelectConfigButton.Text = "Select File to Send";
            SelectConfigButton.UseVisualStyleBackColor = false;
            SelectConfigButton.Click += SelectConfigButton_Click;
            // 
            // OutPutListBox
            // 
            OutPutListBox.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            OutPutListBox.ForeColor = SystemColors.WindowText;
            OutPutListBox.FormattingEnabled = true;
            OutPutListBox.ItemHeight = 15;
            OutPutListBox.Location = new Point(533, 95);
            OutPutListBox.Name = "OutPutListBox";
            OutPutListBox.Size = new Size(144, 274);
            OutPutListBox.TabIndex = 5;
            // 
            // AddPrinterTextBox
            // 
            AddPrinterTextBox.AcceptsReturn = true;
            AddPrinterTextBox.CharacterCasing = CharacterCasing.Upper;
            AddPrinterTextBox.Location = new Point(278, 31);
            AddPrinterTextBox.MaxLength = 16;
            AddPrinterTextBox.Name = "AddPrinterTextBox";
            AddPrinterTextBox.Size = new Size(132, 23);
            AddPrinterTextBox.TabIndex = 6;
            AddPrinterTextBox.KeyPress += CheckEnterKeyPress;
            // 
            // AddPrinterButton
            // 
            AddPrinterButton.Location = new Point(32, 19);
            AddPrinterButton.Name = "AddPrinterButton";
            AddPrinterButton.Size = new Size(86, 23);
            AddPrinterButton.TabIndex = 7;
            AddPrinterButton.Text = "Add Printer";
            AddPrinterButton.UseVisualStyleBackColor = true;
            AddPrinterButton.Click += AddPrinterButton_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(AddPrinterButton);
            groupBox1.Controls.Add(ClearPrinterListButton);
            groupBox1.Location = new Point(384, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(245, 57);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Manualy Add Printer";
            // 
            // ClearPrinterListButton
            // 
            ClearPrinterListButton.BackColor = SystemColors.ButtonFace;
            ClearPrinterListButton.Location = new Point(124, 14);
            ClearPrinterListButton.Name = "ClearPrinterListButton";
            ClearPrinterListButton.Size = new Size(121, 28);
            ClearPrinterListButton.TabIndex = 9;
            ClearPrinterListButton.Text = "Clear Printer List";
            ClearPrinterListButton.UseVisualStyleBackColor = false;
            ClearPrinterListButton.Click += ClearPrinterListButton_Click;
            // 
            // PrintersToProcessLabel
            // 
            PrintersToProcessLabel.AutoSize = true;
            PrintersToProcessLabel.Location = new Point(359, 77);
            PrintersToProcessLabel.Name = "PrintersToProcessLabel";
            PrintersToProcessLabel.Size = new Size(104, 15);
            PrintersToProcessLabel.TabIndex = 10;
            PrintersToProcessLabel.Text = "Printers to Process";
            // 
            // CompletedLabel
            // 
            CompletedLabel.AutoSize = true;
            CompletedLabel.Location = new Point(533, 77);
            CompletedLabel.Name = "CompletedLabel";
            CompletedLabel.Size = new Size(69, 15);
            CompletedLabel.TabIndex = 11;
            CompletedLabel.Text = "Completed ";
            // 
            // ConfigSendlistBox
            // 
            ConfigSendlistBox.FormattingEnabled = true;
            ConfigSendlistBox.HorizontalScrollbar = true;
            ConfigSendlistBox.ItemHeight = 15;
            ConfigSendlistBox.Location = new Point(12, 96);
            ConfigSendlistBox.Name = "ConfigSendlistBox";
            ConfigSendlistBox.Size = new Size(327, 274);
            ConfigSendlistBox.TabIndex = 12;
            ConfigSendlistBox.SelectedIndexChanged += ConfigSendlistBox_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 77);
            label1.Name = "label1";
            label1.Size = new Size(129, 15);
            label1.TabIndex = 13;
            label1.Text = "Preview of  File to Send";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ActiveCaption;
            label2.Location = new Point(503, 413);
            label2.Name = "label2";
            label2.Size = new Size(165, 15);
            label2.TabIndex = 14;
            label2.Text = "Send to Printer Utility IPS 1.0.0";
            label2.Click += label2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(689, 466);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(ConfigSendlistBox);
            Controls.Add(CompletedLabel);
            Controls.Add(PrintersToProcessLabel);
            Controls.Add(AddPrinterTextBox);
            Controls.Add(groupBox1);
            Controls.Add(OutPutListBox);
            Controls.Add(SelectConfigButton);
            Controls.Add(PrintersListBox);
            Controls.Add(SendConfigButton);
            Controls.Add(PrintersProcessedPercentageBar);
            Controls.Add(LoadPrinterListButton);
            Name = "Form1";
            Text = "Send File to Printer Utility";
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button LoadPrinterListButton;
        private ProgressBar PrintersProcessedPercentageBar;
        private Button SendConfigButton;
        private ListBox PrintersListBox;
        private Button SelectConfigButton;
        private ListBox OutPutListBox;
        private TextBox AddPrinterTextBox;
        private Button AddPrinterButton;
        private GroupBox groupBox1;
        private Button ClearPrinterListButton;
        private Label PrintersToProcessLabel;
        private Label CompletedLabel;
        private ListBox ConfigSendlistBox;
        private Label label1;
        private Label label2;
    }
}
