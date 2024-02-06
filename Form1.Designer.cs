
namespace MyDFA
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtPathInput = new System.Windows.Forms.TextBox();
            this.btnOpenInputDialog = new System.Windows.Forms.Button();
            this.btnGetResetWord = new System.Windows.Forms.Button();
            this.txtResetWord = new System.Windows.Forms.TextBox();
            this.btnCherny = new System.Windows.Forms.Button();
            this.txtN = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnForChernyAsync = new System.Windows.Forms.Button();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.txtStartTime = new System.Windows.Forms.TextBox();
            this.txtFinishTime = new System.Windows.Forms.TextBox();
            this.lblFinishTime = new System.Windows.Forms.Label();
            this.lblWorkTime = new System.Windows.Forms.Label();
            this.lblWorkTimeResult = new System.Windows.Forms.Label();
            this.lblInputFormat = new System.Windows.Forms.Label();
            this.cmbInputFormat = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtPathInput
            // 
            this.txtPathInput.Location = new System.Drawing.Point(54, 26);
            this.txtPathInput.Name = "txtPathInput";
            this.txtPathInput.Size = new System.Drawing.Size(679, 26);
            this.txtPathInput.TabIndex = 0;
            // 
            // btnOpenInputDialog
            // 
            this.btnOpenInputDialog.Location = new System.Drawing.Point(787, 20);
            this.btnOpenInputDialog.Name = "btnOpenInputDialog";
            this.btnOpenInputDialog.Size = new System.Drawing.Size(122, 38);
            this.btnOpenInputDialog.TabIndex = 1;
            this.btnOpenInputDialog.Text = "Load input file";
            this.btnOpenInputDialog.UseVisualStyleBackColor = true;
            this.btnOpenInputDialog.Click += new System.EventHandler(this.btnOpenInputDialog_Click);
            // 
            // btnGetResetWord
            // 
            this.btnGetResetWord.Location = new System.Drawing.Point(54, 69);
            this.btnGetResetWord.Name = "btnGetResetWord";
            this.btnGetResetWord.Size = new System.Drawing.Size(380, 40);
            this.btnGetResetWord.TabIndex = 2;
            this.btnGetResetWord.Text = "Build automaton by input and get reset word";
            this.btnGetResetWord.UseVisualStyleBackColor = true;
            this.btnGetResetWord.Click += new System.EventHandler(this.btnGetResetWord_Click);
            // 
            // txtResetWord
            // 
            this.txtResetWord.Location = new System.Drawing.Point(54, 115);
            this.txtResetWord.Name = "txtResetWord";
            this.txtResetWord.Size = new System.Drawing.Size(615, 26);
            this.txtResetWord.TabIndex = 3;
            // 
            // btnCherny
            // 
            this.btnCherny.Location = new System.Drawing.Point(54, 170);
            this.btnCherny.Name = "btnCherny";
            this.btnCherny.Size = new System.Drawing.Size(332, 41);
            this.btnCherny.TabIndex = 4;
            this.btnCherny.Text = "Get reset word for Cerny automaton for n=";
            this.btnCherny.UseVisualStyleBackColor = true;
            this.btnCherny.Click += new System.EventHandler(this.btnCherny_Click);
            // 
            // txtN
            // 
            this.txtN.Location = new System.Drawing.Point(406, 177);
            this.txtN.Name = "txtN";
            this.txtN.Size = new System.Drawing.Size(61, 26);
            this.txtN.TabIndex = 5;
            this.txtN.Text = "4";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // btnForChernyAsync
            // 
            this.btnForChernyAsync.Location = new System.Drawing.Point(54, 231);
            this.btnForChernyAsync.Name = "btnForChernyAsync";
            this.btnForChernyAsync.Size = new System.Drawing.Size(365, 41);
            this.btnForChernyAsync.TabIndex = 6;
            this.btnForChernyAsync.Text = "Get reset word async for Cerny automaton for n=";
            this.btnForChernyAsync.UseVisualStyleBackColor = true;
            this.btnForChernyAsync.Visible = false;
            this.btnForChernyAsync.Click += new System.EventHandler(this.btnForChernyAsync_Click);
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Location = new System.Drawing.Point(546, 177);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(82, 20);
            this.lblStartTime.TabIndex = 7;
            this.lblStartTime.Text = "Start time:";
            // 
            // txtStartTime
            // 
            this.txtStartTime.Location = new System.Drawing.Point(673, 177);
            this.txtStartTime.Name = "txtStartTime";
            this.txtStartTime.Size = new System.Drawing.Size(209, 26);
            this.txtStartTime.TabIndex = 8;
            // 
            // txtFinishTime
            // 
            this.txtFinishTime.Location = new System.Drawing.Point(673, 231);
            this.txtFinishTime.Name = "txtFinishTime";
            this.txtFinishTime.Size = new System.Drawing.Size(209, 26);
            this.txtFinishTime.TabIndex = 10;
            // 
            // lblFinishTime
            // 
            this.lblFinishTime.AutoSize = true;
            this.lblFinishTime.Location = new System.Drawing.Point(546, 231);
            this.lblFinishTime.Name = "lblFinishTime";
            this.lblFinishTime.Size = new System.Drawing.Size(89, 20);
            this.lblFinishTime.TabIndex = 9;
            this.lblFinishTime.Text = "Finish time:";
            // 
            // lblWorkTime
            // 
            this.lblWorkTime.AutoSize = true;
            this.lblWorkTime.Location = new System.Drawing.Point(550, 285);
            this.lblWorkTime.Name = "lblWorkTime";
            this.lblWorkTime.Size = new System.Drawing.Size(84, 20);
            this.lblWorkTime.TabIndex = 11;
            this.lblWorkTime.Text = "Work time:";
            // 
            // lblWorkTimeResult
            // 
            this.lblWorkTimeResult.AutoSize = true;
            this.lblWorkTimeResult.Location = new System.Drawing.Point(673, 284);
            this.lblWorkTimeResult.Name = "lblWorkTimeResult";
            this.lblWorkTimeResult.Size = new System.Drawing.Size(18, 20);
            this.lblWorkTimeResult.TabIndex = 12;
            this.lblWorkTimeResult.Text = "0";
            // 
            // lblInputFormat
            // 
            this.lblInputFormat.AutoSize = true;
            this.lblInputFormat.Location = new System.Drawing.Point(673, 76);
            this.lblInputFormat.Name = "lblInputFormat";
            this.lblInputFormat.Size = new System.Drawing.Size(100, 20);
            this.lblInputFormat.TabIndex = 13;
            this.lblInputFormat.Text = "Input format:";
            // 
            // cmbInputFormat
            // 
            this.cmbInputFormat.FormattingEnabled = true;
            this.cmbInputFormat.Items.AddRange(new object[] {
            "1",
            "2"});
            this.cmbInputFormat.Location = new System.Drawing.Point(788, 76);
            this.cmbInputFormat.Name = "cmbInputFormat";
            this.cmbInputFormat.Size = new System.Drawing.Size(121, 28);
            this.cmbInputFormat.TabIndex = 14;
            this.cmbInputFormat.Text = "1";
            this.cmbInputFormat.SelectedIndexChanged += new System.EventHandler(this.cmbInputFormat_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 450);
            this.Controls.Add(this.cmbInputFormat);
            this.Controls.Add(this.lblInputFormat);
            this.Controls.Add(this.lblWorkTimeResult);
            this.Controls.Add(this.lblWorkTime);
            this.Controls.Add(this.txtFinishTime);
            this.Controls.Add(this.lblFinishTime);
            this.Controls.Add(this.txtStartTime);
            this.Controls.Add(this.lblStartTime);
            this.Controls.Add(this.btnForChernyAsync);
            this.Controls.Add(this.txtN);
            this.Controls.Add(this.btnCherny);
            this.Controls.Add(this.txtResetWord);
            this.Controls.Add(this.btnGetResetWord);
            this.Controls.Add(this.btnOpenInputDialog);
            this.Controls.Add(this.txtPathInput);
            this.Name = "Form1";
            this.Text = "DFA operations";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtPathInput;
        private System.Windows.Forms.Button btnOpenInputDialog;
        private System.Windows.Forms.Button btnGetResetWord;
        private System.Windows.Forms.TextBox txtResetWord;
        private System.Windows.Forms.Button btnCherny;
        private System.Windows.Forms.TextBox txtN;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnForChernyAsync;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.TextBox txtStartTime;
        private System.Windows.Forms.TextBox txtFinishTime;
        private System.Windows.Forms.Label lblFinishTime;
        private System.Windows.Forms.Label lblWorkTime;
        private System.Windows.Forms.Label lblWorkTimeResult;
        private System.Windows.Forms.Label lblInputFormat;
        private System.Windows.Forms.ComboBox cmbInputFormat;
    }
}

