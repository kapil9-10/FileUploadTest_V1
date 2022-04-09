
namespace WindowsFormsApp1
{
    partial class Form1
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
            this.ReportResult = new System.Windows.Forms.DataGridView();
            this.Upload = new System.Windows.Forms.Button();
            this.FileUploardText = new System.Windows.Forms.TextBox();
            this.Current_Reference = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.JsonTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ReportResult)).BeginInit();
            this.SuspendLayout();
            // 
            // ReportResult
            // 
            this.ReportResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ReportResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ReportResult.Location = new System.Drawing.Point(13, 70);
            this.ReportResult.Name = "ReportResult";
            this.ReportResult.Size = new System.Drawing.Size(623, 270);
            this.ReportResult.TabIndex = 0;
            // 
            // Upload
            // 
            this.Upload.Location = new System.Drawing.Point(240, 12);
            this.Upload.Name = "Upload";
            this.Upload.Size = new System.Drawing.Size(127, 23);
            this.Upload.TabIndex = 1;
            this.Upload.Text = "Upload File";
            this.Upload.UseVisualStyleBackColor = true;
            this.Upload.Click += new System.EventHandler(this.button1_Click);
            // 
            // FileUploardText
            // 
            this.FileUploardText.Location = new System.Drawing.Point(13, 12);
            this.FileUploardText.Name = "FileUploardText";
            this.FileUploardText.ReadOnly = true;
            this.FileUploardText.Size = new System.Drawing.Size(221, 20);
            this.FileUploardText.TabIndex = 2;
            // 
            // Current_Reference
            // 
            this.Current_Reference.AutoSize = true;
            this.Current_Reference.BackColor = System.Drawing.Color.Salmon;
            this.Current_Reference.Location = new System.Drawing.Point(398, 17);
            this.Current_Reference.Name = "Current_Reference";
            this.Current_Reference.Size = new System.Drawing.Size(0, 13);
            this.Current_Reference.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(240, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Get Report";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // JsonTextBox
            // 
            this.JsonTextBox.AcceptsReturn = true;
            this.JsonTextBox.AcceptsTab = true;
            this.JsonTextBox.Location = new System.Drawing.Point(661, 97);
            this.JsonTextBox.Multiline = true;
            this.JsonTextBox.Name = "JsonTextBox";
            this.JsonTextBox.ReadOnly = true;
            this.JsonTextBox.Size = new System.Drawing.Size(331, 243);
            this.JsonTextBox.TabIndex = 5;
            this.JsonTextBox.WordWrap = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(661, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Json Object";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 352);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.JsonTextBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Current_Reference);
            this.Controls.Add(this.FileUploardText);
            this.Controls.Add(this.Upload);
            this.Controls.Add(this.ReportResult);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ReportResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ReportResult;
        private System.Windows.Forms.Button Upload;
        private System.Windows.Forms.TextBox FileUploardText;
        private System.Windows.Forms.Label Current_Reference;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox JsonTextBox;
        private System.Windows.Forms.Label label1;
    }
}

