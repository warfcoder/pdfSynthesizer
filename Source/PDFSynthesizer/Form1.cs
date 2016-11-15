using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.IO;
using System.Speech.Synthesis;
using System.Windows.Forms;
using System.Linq;

namespace PDFSynthesizer
{
    public partial class Form1 : Form
    {
        public SynthesizablePDF synthesizablePDF { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Show();
            btnChoosePDF_Click(sender, e);
            this.OriginalWidth = this.Width;
        }

        private void TogglePlaying(object sender, EventArgs e)
        {
            synthesizablePDF.TogglePlaying();
            UpdatePlayButton();
        }

        private void UpdatePlayButton()
        {
            switch (synthesizablePDF.SpeechSynthesizer.State)
            {
                case SynthesizerState.Paused:
                    btnTogglePlay.Text = "Play";
                    break;
                default:
                    btnTogglePlay.Text = "Pause";
                    break;
            }
        }
        protected void UpdateSynthesisProgress(object sender, SpeakProgressEventArgs e)
        {
            if (pbSpeaking == null) { return; }
            pbSpeaking.Value = e.CharacterPosition;

#if debug
            Console.WriteLine("Speak progress: {0} AudioPosition: {1} Text: {2}", e.CharacterPosition, e.AudioPosition, e.Text);
#endif
            if (string.IsNullOrWhiteSpace(rtbPage.Text)) { return; }

            rtbPage.Find(e.Text, synthesizablePDF.ReadingStartPosition + e.CharacterPosition, RichTextBoxFinds.WholeWord);
            rtbPage.Focus();
        }

        private void lbxPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            synthesizablePDF.CurrentPageNumber = lbxPages.SelectedIndex + 1;
            synthesizablePDF.ReadCurrentPageAloud();
            ReinitializeDisplay();
        }

        private void ReinitializeDisplay()
        {
            InitProgressBar();
            rtbPage.Text = synthesizablePDF.GetCurrentPage();
            lblCurrentPage.Text = "Current Page: " + synthesizablePDF.CurrentPageNumber;
        }

        private void InitProgressBar()
        {
            pbSpeaking.Maximum = synthesizablePDF.GetCurrentPage().Count();
            pbSpeaking.Value = 0;
            pbSpeaking.Step = 1;
        }

        private void btnChangeSpeed_Click(object sender, EventArgs e)
        {
            switch (((Button)sender).Text)
            {
                case "<":
                    synthesizablePDF.ReduceSpeed();
                    break;
                case ">":
                    synthesizablePDF.IncreaseSpeed();
                    break;
                default:
                    synthesizablePDF.ResetSpeed();
                    break;
            }
            ReadFromCursor();
            btnResetSpeed.Text = synthesizablePDF.SpeakRate.ToString();
        }

        private void btnChoosePDF_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(openFileDialog1.FileName))
            {
                openFileDialog1.FileName = @"D:\My Documents\Military Stuff\SNCOA Course 14 - Distance\Self Awareness\SA04 Critical Thinking.pdf";
            }
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.

            if (result != DialogResult.OK && synthesizablePDF == null)
            {
                this.Close();
            }

            this.Focus();

            if (result != DialogResult.OK) { return; }

            txtPDFFilePath.Text = openFileDialog1.FileName;

            if (synthesizablePDF != null) { synthesizablePDF.Dispose(); }
            synthesizablePDF = new SynthesizablePDF(txtPDFFilePath.Text); //, PromptBreak.ExtraSmall);
            //
            lblTotalPages.Text = "# Pages Total: " + synthesizablePDF.NumberOfPages;
            lbxPages.DataSource = synthesizablePDF.Pages;
            synthesizablePDF.SpeechSynthesizer.SpeakProgress += new EventHandler<SpeakProgressEventArgs>(UpdateSynthesisProgress);
            synthesizablePDF.SpeechSynthesizer.SpeakCompleted += SpeechSynthesizer_SpeakCompleted;
        }

        void SpeechSynthesizer_SpeakCompleted(object sender, SpeakCompletedEventArgs e)
        {
            if (e.Cancelled) { return; }
            btnNextPage_Click(sender, e);
        }

        private void chkShowPages_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked) // if (this.Width == this.OriginalWidth)
            {
                this.Width = this.OriginalWidth;
            }
            else { this.Width = 638; }
        }

        private void ReadFromCursor()
        {
            var current = synthesizablePDF.SpeechSynthesizer.GetCurrentlySpokenPrompt();
            if (current != null)
            {
                synthesizablePDF.SpeechSynthesizer.SpeakAsyncCancel(current);
            }
            synthesizablePDF.ReadingStartPosition = rtbPage.SelectionStart;
            synthesizablePDF.SpeechSynthesizer.SpeakAsync(GetPageStartingAtCursor());
            synthesizablePDF.SpeechSynthesizer.Resume();
            this.UpdatePlayButton();
        }

        private string GetPageStartingAtCursor()
        {
            return rtbPage.Text.Substring(rtbPage.SelectionStart);
        }
        public int OriginalWidth { get; set; }

        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            synthesizablePDF.CurrentPageNumber--;
            synthesizablePDF.ReadCurrentPageAloud();
            ReinitializeDisplay();
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            try
            {
                synthesizablePDF.CurrentPageNumber++;
                synthesizablePDF.ReadCurrentPageAloud();
                ReinitializeDisplay();
            }
            catch (ArgumentException)
            {
            }
        }

        private void btnReadFromCursor_Click(object sender, EventArgs e)
        {
            ReadFromCursor();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //synthesizablePDF.ExportToWave(txtPDFFilePath.Text + "Page");
            synthesizablePDF.SpeakToFile(txtPDFFilePath.Text + "Page");
        }
    }
}
