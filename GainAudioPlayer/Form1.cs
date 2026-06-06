using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;

namespace GainAudioPlayer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        List<string> codaAudio = new List<string>();

        private void caricaFileAudio(object sender, EventArgs e)
        {
            string audio = aggiungiAudioInCoda();
            if (audio != null)
            {
                var reader = new AudioFileReader(audio);
                float[] buffer = new float[4096];

                int samplesRead;

                while ((samplesRead = reader.Read(buffer, 0, buffer.Length)) > 0)
                {
                    for (int i = 0; i < samplesRead; i++)
                    {
                        float sample = buffer[i];

                        Console.WriteLine(sample);
                        Debug.WriteLine(sample);
                    }
                }
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
    }
}
