
namespace WinFormsLab
{
    partial class BloqForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BloqForm));
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxFile = new System.Windows.Forms.GroupBox();
            this.buttonLoadDiag = new System.Windows.Forms.Button();
            this.buttonSaveDiag = new System.Windows.Forms.Button();
            this.buttonNewDiag = new System.Windows.Forms.Button();
            this.groupBoxEdit = new System.Windows.Forms.GroupBox();
            this.textBox = new System.Windows.Forms.TextBox();
            this.labelText = new System.Windows.Forms.Label();
            this.buttonErase = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.buttonDecisionBlock = new System.Windows.Forms.Button();
            this.buttonOperationBlock = new System.Windows.Forms.Button();
            this.Canvas = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBoxFile.SuspendLayout();
            this.groupBoxEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.groupBoxFile, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBoxEdit, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(603, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(194, 444);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // groupBoxFile
            // 
            this.groupBoxFile.Controls.Add(this.buttonLoadDiag);
            this.groupBoxFile.Controls.Add(this.buttonSaveDiag);
            this.groupBoxFile.Controls.Add(this.buttonNewDiag);
            this.groupBoxFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxFile.Location = new System.Drawing.Point(3, 3);
            this.groupBoxFile.Name = "groupBoxFile";
            this.groupBoxFile.Size = new System.Drawing.Size(188, 134);
            this.groupBoxFile.TabIndex = 0;
            this.groupBoxFile.TabStop = false;
            this.groupBoxFile.Text = "File";
            // 
            // buttonLoadDiag
            // 
            this.buttonLoadDiag.AutoSize = true;
            this.buttonLoadDiag.Location = new System.Drawing.Point(3, 97);
            this.buttonLoadDiag.Margin = new System.Windows.Forms.Padding(5);
            this.buttonLoadDiag.Name = "buttonLoadDiag";
            this.buttonLoadDiag.Size = new System.Drawing.Size(182, 35);
            this.buttonLoadDiag.TabIndex = 2;
            this.buttonLoadDiag.Text = "Load Diagram";
            this.buttonLoadDiag.UseVisualStyleBackColor = true;
            this.buttonLoadDiag.Click += new System.EventHandler(this.buttonLoadDiag_Click);
            // 
            // buttonSaveDiag
            // 
            this.buttonSaveDiag.AutoSize = true;
            this.buttonSaveDiag.Location = new System.Drawing.Point(3, 57);
            this.buttonSaveDiag.Margin = new System.Windows.Forms.Padding(5);
            this.buttonSaveDiag.Name = "buttonSaveDiag";
            this.buttonSaveDiag.Size = new System.Drawing.Size(182, 35);
            this.buttonSaveDiag.TabIndex = 1;
            this.buttonSaveDiag.Text = "Save Diagram";
            this.buttonSaveDiag.UseVisualStyleBackColor = true;
            this.buttonSaveDiag.Click += new System.EventHandler(this.buttonSaveDiag_Click);
            // 
            // buttonNewDiag
            // 
            this.buttonNewDiag.AutoSize = true;
            this.buttonNewDiag.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonNewDiag.Location = new System.Drawing.Point(3, 19);
            this.buttonNewDiag.Margin = new System.Windows.Forms.Padding(5);
            this.buttonNewDiag.Name = "buttonNewDiag";
            this.buttonNewDiag.Size = new System.Drawing.Size(182, 35);
            this.buttonNewDiag.TabIndex = 0;
            this.buttonNewDiag.Text = "New Diagram";
            this.buttonNewDiag.UseVisualStyleBackColor = true;
            this.buttonNewDiag.Click += new System.EventHandler(this.buttonNewDiag_Click);
            // 
            // groupBoxEdit
            // 
            this.groupBoxEdit.Controls.Add(this.textBox);
            this.groupBoxEdit.Controls.Add(this.labelText);
            this.groupBoxEdit.Controls.Add(this.buttonErase);
            this.groupBoxEdit.Controls.Add(this.buttonStart);
            this.groupBoxEdit.Controls.Add(this.buttonStop);
            this.groupBoxEdit.Controls.Add(this.buttonConnect);
            this.groupBoxEdit.Controls.Add(this.buttonDecisionBlock);
            this.groupBoxEdit.Controls.Add(this.buttonOperationBlock);
            this.groupBoxEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxEdit.Location = new System.Drawing.Point(3, 143);
            this.groupBoxEdit.Name = "groupBoxEdit";
            this.groupBoxEdit.Size = new System.Drawing.Size(188, 298);
            this.groupBoxEdit.TabIndex = 1;
            this.groupBoxEdit.TabStop = false;
            this.groupBoxEdit.Text = "Edit";
            // 
            // textBox
            // 
            this.textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox.Enabled = false;
            this.textBox.Location = new System.Drawing.Point(7, 164);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(178, 199);
            this.textBox.TabIndex = 7;
            this.textBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // labelText
            // 
            this.labelText.AutoSize = true;
            this.labelText.Location = new System.Drawing.Point(7, 146);
            this.labelText.Name = "labelText";
            this.labelText.Size = new System.Drawing.Size(109, 15);
            this.labelText.TabIndex = 6;
            this.labelText.Text = "Selected block text:";
            // 
            // buttonErase
            // 
            this.buttonErase.BackColor = System.Drawing.Color.White;
            this.buttonErase.Image = ((System.Drawing.Image)(resources.GetObject("buttonErase.Image")));
            this.buttonErase.Location = new System.Drawing.Point(127, 81);
            this.buttonErase.Margin = new System.Windows.Forms.Padding(0);
            this.buttonErase.MaximumSize = new System.Drawing.Size(58, 58);
            this.buttonErase.MinimumSize = new System.Drawing.Size(58, 58);
            this.buttonErase.Name = "buttonErase";
            this.buttonErase.Size = new System.Drawing.Size(58, 58);
            this.buttonErase.TabIndex = 5;
            this.buttonErase.UseVisualStyleBackColor = false;
            this.buttonErase.Click += new System.EventHandler(this.buttonErase_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.Color.White;
            this.buttonStart.Image = ((System.Drawing.Image)(resources.GetObject("buttonStart.Image")));
            this.buttonStart.Location = new System.Drawing.Point(3, 17);
            this.buttonStart.MaximumSize = new System.Drawing.Size(58, 58);
            this.buttonStart.MinimumSize = new System.Drawing.Size(58, 58);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(58, 58);
            this.buttonStart.TabIndex = 4;
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.BackColor = System.Drawing.Color.White;
            this.buttonStop.Image = ((System.Drawing.Image)(resources.GetObject("buttonStop.Image")));
            this.buttonStop.Location = new System.Drawing.Point(3, 81);
            this.buttonStop.MaximumSize = new System.Drawing.Size(58, 58);
            this.buttonStop.MinimumSize = new System.Drawing.Size(58, 58);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(58, 58);
            this.buttonStop.TabIndex = 3;
            this.buttonStop.UseVisualStyleBackColor = false;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonConnect
            // 
            this.buttonConnect.BackColor = System.Drawing.Color.White;
            this.buttonConnect.Image = ((System.Drawing.Image)(resources.GetObject("buttonConnect.Image")));
            this.buttonConnect.Location = new System.Drawing.Point(127, 17);
            this.buttonConnect.MaximumSize = new System.Drawing.Size(58, 58);
            this.buttonConnect.MinimumSize = new System.Drawing.Size(58, 58);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(58, 58);
            this.buttonConnect.TabIndex = 2;
            this.buttonConnect.UseVisualStyleBackColor = false;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // buttonDecisionBlock
            // 
            this.buttonDecisionBlock.BackColor = System.Drawing.Color.White;
            this.buttonDecisionBlock.Image = ((System.Drawing.Image)(resources.GetObject("buttonDecisionBlock.Image")));
            this.buttonDecisionBlock.Location = new System.Drawing.Point(65, 81);
            this.buttonDecisionBlock.MaximumSize = new System.Drawing.Size(58, 58);
            this.buttonDecisionBlock.MinimumSize = new System.Drawing.Size(58, 58);
            this.buttonDecisionBlock.Name = "buttonDecisionBlock";
            this.buttonDecisionBlock.Size = new System.Drawing.Size(58, 58);
            this.buttonDecisionBlock.TabIndex = 1;
            this.buttonDecisionBlock.UseVisualStyleBackColor = false;
            this.buttonDecisionBlock.Click += new System.EventHandler(this.buttonDecisionBlock_Click);
            // 
            // buttonOperationBlock
            // 
            this.buttonOperationBlock.BackColor = System.Drawing.Color.White;
            this.buttonOperationBlock.Image = ((System.Drawing.Image)(resources.GetObject("buttonOperationBlock.Image")));
            this.buttonOperationBlock.Location = new System.Drawing.Point(65, 17);
            this.buttonOperationBlock.MaximumSize = new System.Drawing.Size(58, 58);
            this.buttonOperationBlock.MinimumSize = new System.Drawing.Size(58, 58);
            this.buttonOperationBlock.Name = "buttonOperationBlock";
            this.buttonOperationBlock.Size = new System.Drawing.Size(58, 58);
            this.buttonOperationBlock.TabIndex = 0;
            this.buttonOperationBlock.UseVisualStyleBackColor = false;
            this.buttonOperationBlock.Click += new System.EventHandler(this.buttonOperationBlock_Click);
            // 
            // Canvas
            // 
            this.Canvas.Location = new System.Drawing.Point(0, 0);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(594, 444);
            this.Canvas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Canvas.TabIndex = 1;
            this.Canvas.TabStop = false;
            this.Canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseDown);
            this.Canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseMove);
            this.Canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseUp);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.Canvas);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(594, 444);
            this.panel1.TabIndex = 0;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "diag";
            this.saveFileDialog.Filter = "Diagram files (*.diag) |*.diag";
            this.saveFileDialog.Title = "Save diagram";
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "diag";
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.Filter = "Diagram files (*.diag) |*.diag";
            this.openFileDialog.Title = "Load diagram";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bloq";
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBoxFile.ResumeLayout(false);
            this.groupBoxFile.PerformLayout();
            this.groupBoxEdit.ResumeLayout(false);
            this.groupBoxEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBoxFile;
        private System.Windows.Forms.Button buttonLoadDiag;
        private System.Windows.Forms.Button buttonSaveDiag;
        private System.Windows.Forms.Button buttonNewDiag;
        private System.Windows.Forms.GroupBox groupBoxEdit;
        private System.Windows.Forms.Button buttonDecisionBlock;
        private System.Windows.Forms.Button buttonOperationBlock;
        private System.Windows.Forms.PictureBox Canvas;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button buttonErase;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Label labelText;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}

