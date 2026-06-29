using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using NAudio.Wave;

namespace GainAudioPlayer
{
    public partial class Form1 : Form
    {

        Bitmap canvas;
        Graphics g;

        int width_osc = 1290;
        int height_osc = 623;
        int centerY = 0;
        int lastY;

        Pen utilityPen = Pens.Gray;
        Pen samplePen = Pens.Green;

        public Form1()
        {
            canvas = new Bitmap(width_osc, height_osc);
            g = Graphics.FromImage(canvas);

            InitializeComponent();
            this.DoubleBuffered = true;

            g.Clear(Color.Black);
            Invalidate();
        }


        List<string> codaAudio = new List<string>();
        List<float> campioniCanzone = new List<float>();
        string audio = "";

        private void caricaFileAudio(object sender, EventArgs e)
        {
            campioniCanzone.Clear();
            audio = aggiungiAudioInCoda();
            if (!String.IsNullOrEmpty(audio))
            {
                var mp3Reader = new Mp3FileReader(audio);
                toolStripStatusLabel_nomeCanzone.Text = audio;

                //ISampleProvider fornisce campioni già come float normalizzati
                ISampleProvider sampleProvider = mp3Reader.ToSampleProvider();
                float[] samples = new float[4096];
                int samplesRead;
                int iterazione = 0;
                float max = 0;
                while ((samplesRead = sampleProvider.Read(samples, 0, samples.Length)) > 0)
                {
                    for (int i = 0; i < samplesRead; i++)
                    {
                        // samples[i] conteine un valore tra -1.0f e +1.0f
                       campioniCanzone.Add(samples[i]);
                        if (samples[i] > max)
                        {
                            max = samples[i];
                        }
                    }
                    iterazione++;
                }
                disegnaOnda();
                Invalidate();
            }
        }

        private void disegnaOnda()
        {
            g.Clear(Color.Black);
            centerY = height_osc / 2;
            g.DrawLine(utilityPen, 0, centerY, width_osc - 1, centerY);

            int totaleCampioni = campioniCanzone.Count;

            for (int x = 0; x < width_osc - 1; x++)
            {
                //idxStart : totaleCampioni = x : width_osc
                int idxStart = (int)(((float)x / width_osc) * totaleCampioni);
                int idxEnd = (int)(((float)(x + 1) / width_osc) * totaleCampioni);
                idxEnd = Math.Min(idxEnd, totaleCampioni - 1);  //Serve per sicurezza per non andare fuori dalla lista

                // Trova il valore massimo e minimo del blocco
                float max = 0f, min = 0f;
                for (int i = idxStart; i <= idxEnd; i++)
                {
                    if (campioniCanzone[i] > max)
                    {
                        max = campioniCanzone[i] * 1f;
                    }
                    if (campioniCanzone[i] < min)
                    {
                        min = campioniCanzone[i] * 1f;
                    }
                }

                // Converti in coordinate Y
                //Con (max + 1f) / 2f) normalizzo per ricondurmi all'intervallo [0, 1] dato che i float vanno da -1f a + 1f
                //All'inizio metto 1f - ... in modo da invertire la forma d'onda dato che nel grafico y=0 sta in alto e non in basso
                int yMax = (int)(((1f - (max + 1f) / 2f)) * height_osc);
                int yMin = (int)(((1f - (min + 1f) / 2f)) * height_osc);

                //Clamp di sicurezza per evitare che la forma d'onda esca dal grafico
                yMax = Math.Max(0, Math.Min(yMax, height_osc - 1));
                yMin = Math.Max(0, Math.Min(yMin, height_osc - 1));

                // Disegna una linea verticale dal minimo al massimo
                g.DrawLine(samplePen, x, yMin, x, yMax);
            }
        }

        private string aggiungiAudioInCoda()
        {
            string filePath = "";
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Audio File (*.mp3)|*.mp3";
                dialog.Title = "Seleziona un file MP3";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = dialog.FileName;
                }
            }

            return filePath;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.FillRectangle(Brushes.Black, 10, 30, width_osc, height_osc);
            e.Graphics.DrawRectangle(Pens.Red, 9, 29, width_osc + 1, height_osc + 1);
            e.Graphics.DrawImage(canvas, 10, 30);

            // Disegna la linea di posizione sopra il canvas
            if (waveOut != null && waveOut.PlaybackState == PlaybackState.Playing)
            {
                e.Graphics.DrawLine(Pens.Red,
                    10 + pixelCorrente, 30,
                    10 + pixelCorrente, 30 + height_osc);
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            width_osc = this.Width - 40;
            height_osc = this.Height - 100;

            // Ricrea il bitmap con le nuove dimensioni
            g?.Dispose();
            canvas?.Dispose();
            canvas = new Bitmap(width_osc, height_osc);
            g = Graphics.FromImage(canvas);

            //disegna sul bitmap aggiornato
            g.Clear(Color.Black);
            centerY = height_osc / 2;
            g.DrawLine(utilityPen, 0, centerY, width_osc - 1, centerY);
            if (campioniCanzone != null && campioniCanzone.Count > 0)
            {
                disegnaOnda();
            }
            Invalidate();
        }

        WaveOutEvent waveOut;
        AudioFileReader audioReader;

        private void RiproduciAudio()
        {
            audioReader = new AudioFileReader(audio);
            waveOut = new WaveOutEvent();
            waveOut.Init(audioReader);
            waveOut.Play();

            // Timer per aggiornare la posizione
            Timer timer = new Timer();
            timer.Interval = 16; // ~60fps
            timer.Tick += AggiornaPosizione;
            timer.Start();
        }
        int pixelCorrente = 0;

        private void AggiornaPosizione(object sender, EventArgs e)
        {
            if (audioReader == null) return;

            // Posizione corrente in campioni
            long campioneTotali = audioReader.Length / 4; // 4 byte per campione float
            long campioneCorrente = audioReader.Position / 4;

            // Mappa in pixel X
            pixelCorrente = (int)((float)campioneCorrente / campioneTotali * width_osc);

            Invalidate(); // ridisegna
        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {
            RiproduciAudio();
        }
    }
}
