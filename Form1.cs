using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MyDFA
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// The following 2 properties needed for async calls only
        /// </summary>
        private string resetWord { get; set; }
        private DateTime beginTime { get; set; }

        public int inputFormat { get; set; } = 1;

        public Form1()
        {
            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
        }

        private void btnOpenInputDialog_Click(object sender, EventArgs e)
        {
            string filePath = string.Empty;
            DialogResult dlgResult = openFileDialog1.ShowDialog();
            if (dlgResult == DialogResult.OK)
            {
                filePath = openFileDialog1.FileName;
                txtPathInput.Text = filePath;
               
            }
        }

        private void btnGetResetWord_Click(object sender, EventArgs e)
        {
            string filePath = txtPathInput.Text;
           FileManager fm = new FileManager(filePath);
            List<string> lstLines = new List<string>();
            string line = null;
            while (true)
            {
                line = fm.readLine();
                if (line != null)
                    lstLines.Add(line);
                else
                    break;
            }
            DFA dfa = new DFA();
            if (inputFormat == 1)
                dfa.initializeByFormat1(lstLines);
            if (inputFormat == 2)
                dfa.initializeByFormat2(lstLines);
            dfa.buildPairs();
            string w = dfa.getResetWord();
            txtResetWord.Text = w;
        }

        private void btnCherny_Click(object sender, EventArgs e)
        {
            lblWorkTimeResult.Text = string.Empty;
            txtFinishTime.Text = string.Empty;
            int n = int.Parse(txtN.Text);
            DFA dfa= Algorithms.buildChernyAtomaton(n);
            dfa.buildPairs();
            DateTime dt1 = DateTime.Now;
            txtStartTime.Text = DateTime.Now.ToString();
            string w = dfa.getResetWord();
            w = Algorithms.compressStringByPowers(w);
            txtResetWord.Text = w;
            DateTime dt2 = DateTime.Now;
            txtFinishTime.Text= DateTime.Now.ToString();
            double workTime = (dt2 - dt1).TotalSeconds;
            lblWorkTimeResult.Text = workTime.ToString();
        }

        private void btnForChernyAsync_Click(object sender, EventArgs e)
        {
            lblWorkTimeResult.Text = string.Empty;
            txtFinishTime.Text = string.Empty;
            beginTime = DateTime.Now;
            txtStartTime.Text = DateTime.Now.ToString();
            if (backgroundWorker1.IsBusy != true)
            {
                // Start the asynchronous operation.
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int n = int.Parse(txtN.Text);
            DFA dfa = Algorithms.buildChernyAtomaton(n);            
            dfa.buildPairs();
            string w = dfa.getResetWord();
            resetWord = Algorithms.compressStringByPowers(w);
            backgroundWorker1.CancelAsync();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            txtResetWord.Text = resetWord;
            DateTime dt2 = DateTime.Now;
            txtFinishTime.Text = DateTime.Now.ToString();
            double workTime = (dt2 - beginTime).TotalSeconds;
            lblWorkTimeResult.Text = workTime.ToString();
        }

        private void cmbInputFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = cmbInputFormat.Items[cmbInputFormat.SelectedIndex].ToString();
            inputFormat = int.Parse(value);
        }
    }
}
