using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Speech.Synthesis;
using System.Windows.Forms;
using System.Linq;
using System.Text.RegularExpressions;
using System.Speech.AudioFormat;
using System.Threading.Tasks;

namespace PDFSynthesizer
{
    public class SynthesizablePDF : IDisposable
    {
        #region private

        private int currentPageNumber;
        private string pdfFilePath;

        #endregion private

        public List<string> Pages { get; set; }
        public int NumberOfPages { get; private set; }
        public SpeechSynthesizer SpeechSynthesizer { get; private set; }
        public int SpeakRate { get { return SpeechSynthesizer.Rate; } }
        public int ReadingStartPosition { get; set; }
        public int CurrentPageNumber
        {
            get { return this.currentPageNumber; }
            set
            {
                if (value <= 0 || value > this.NumberOfPages)
                {
                    throw new ArgumentException("Invalid Page Range");
                }
                this.currentPageNumber = value;
            }
        }

        private SynthesizablePDF()
        {
            this.Pages = new List<string>();
        }

        public SynthesizablePDF(string pdfFilePath)
            : this()
        {
            this.pdfFilePath = pdfFilePath;
            if (!File.Exists(pdfFilePath)) { throw new FileLoadException("File '%0' not found", pdfFilePath); }

            var pdfReader = new PdfReader(pdfFilePath);

            this.SpeechSynthesizer = new SpeechSynthesizer();
            SpeechSynthesizer.BookmarkReached += (s2, e2) =>
            {
                this.CurrentPageNumber++;
                this.ReadCurrentPageAloud();
            };


            this.NumberOfPages = pdfReader.NumberOfPages;
            for (int page = 1; page <= pdfReader.NumberOfPages; page++)
            {
                ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                var currentText = PdfTextExtractor.GetTextFromPage(pdfReader, page, strategy)
                    .Replace("(s)", "s")
                    .Replace("-\n", string.Empty);
                var filteredTest = new Regex("_+").Replace(currentText, " [fill-in-the-blank] ");
                //var utf8Text= Encoding.UTF8.GetString(ASCIIEncoding.Convert(
                //    Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(currentText)));
                //if (utf8Text.Equals(currentText))
                //{
                //    System.Windows.Forms.MessageBox.Show("did't need do encode");
                //}
                this.Pages.Add(filteredTest);
            }
            this.Pages.ForEach(x => System.Diagnostics.Debug.WriteLine(x));
            pdfReader.Close();
        }

        private void OutPutFile(string outputTextFilePath = "")
        {
            if (string.IsNullOrWhiteSpace(outputTextFilePath))
            {
                outputTextFilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\output.txt";
            }
            File.WriteAllText(outputTextFilePath, this.GetCurrentPage());
        }
        internal string GetCurrentPage()
        {
            return this.Pages[CurrentPageNumber - 1];
        }

        internal void ReadCurrentPageAloud()
        {
            this.CancelSpeaking();
            this.ReadingStartPosition = 0;

            this.SpeechSynthesizer.SpeakAsync(this.GetCurrentPage());
            //OutPutFile();
        }

        private void CancelSpeaking()
        {
            var current = this.SpeechSynthesizer.GetCurrentlySpokenPrompt();
            if (current != null)
            {
                this.SpeechSynthesizer.SpeakAsyncCancel(current);
            }
        }

        internal void TogglePlaying()
        {
            if (this.SpeechSynthesizer.State == SynthesizerState.Speaking)
            {
                this.SpeechSynthesizer.Pause();
            }
            else { this.SpeechSynthesizer.Resume(); }
        }

        internal void ReduceSpeed()
        {
            try { this.SpeechSynthesizer.Rate--; }
            catch (Exception) { }
        }

        internal void IncreaseSpeed()
        {
            try { this.SpeechSynthesizer.Rate++; }
            catch (Exception) { }
        }

        internal void ResetSpeed()
        {
            this.SpeechSynthesizer.Rate = 0;
        }

        public void Dispose()
        {
            SpeechSynthesizer.Dispose();
        }


        public void ExportToWave(string filePath)
        {
            // Initialize a new instance of the SpeechSynthesizer.
            using (SpeechSynthesizer synth = new SpeechSynthesizer())
            {

                // Configure the audio output. 

                //,                  new SpeechAudioFormatInfo(32000, AudioBitsPerSample.Sixteen, AudioChannel.Mono));

                //// Create a SoundPlayer instance to play output audio file.
                //System.Media.SoundPlayer m_SoundPlayer = new System.Media.SoundPlayer(@"C:\temp\test.wav");

                // Build a prompt.
                PromptBuilder builder = new PromptBuilder();
                foreach (var page in this.Pages)
                {
                    synth.SetOutputToWaveFile(filePath + this.Pages.IndexOf(page) + ".wav");
                    synth.Speak(page);
                }
                MessageBox.Show("Finished Creating Files");

                // Speak the prompt.
                //m_SoundPlayer.Play();
            }

        }

        public void SpeakToFile(string filePath)
        {
            foreach (var page in this.Pages)
            {
                Task.Factory.StartNew(() =>
                {
                    using (var synthesizer = new SpeechSynthesizer())
                    {
                        var ms = new MemoryStream();
                        synthesizer.SetOutputToWaveStream(ms);
                        synthesizer.Speak(page);
                        FileStream fs = File.OpenWrite(filePath + (this.Pages.IndexOf(page)+1) + ".wav");
                        byte[] data = ms.ToArray();
                        fs.Write(data, 0, data.Length);
                        fs.Close();

                    }
                });
            }
        }
    }
}
