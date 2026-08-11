namespace GainAudioPlayer
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.caricaAudioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_nomeCanzone = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripDropDownButton_play = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripStatusLabel_separator = new System.Windows.Forms.ToolStripStatusLabel();
            this.codaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aggiungiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visualizzaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.caricaAudioToolStripMenuItem,
            this.codaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1272, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // caricaAudioToolStripMenuItem
            // 
            this.caricaAudioToolStripMenuItem.Name = "caricaAudioToolStripMenuItem";
            this.caricaAudioToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.caricaAudioToolStripMenuItem.Text = "Carica";
            this.caricaAudioToolStripMenuItem.Click += new System.EventHandler(this.caricaFileAudio);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_nomeCanzone,
            this.toolStripStatusLabel_separator,
            this.toolStripDropDownButton_play});
            this.statusStrip1.Location = new System.Drawing.Point(0, 550);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1272, 26);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel_nomeCanzone
            // 
            this.toolStripStatusLabel_nomeCanzone.Name = "toolStripStatusLabel_nomeCanzone";
            this.toolStripStatusLabel_nomeCanzone.Size = new System.Drawing.Size(195, 20);
            this.toolStripStatusLabel_nomeCanzone.Text = "Nessun file mp3 selezionato";
            // 
            // toolStripDropDownButton_play
            // 
            this.toolStripDropDownButton_play.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton_play.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton_play.Image")));
            this.toolStripDropDownButton_play.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton_play.Name = "toolStripDropDownButton_play";
            this.toolStripDropDownButton_play.ShowDropDownArrow = false;
            this.toolStripDropDownButton_play.Size = new System.Drawing.Size(45, 24);
            this.toolStripDropDownButton_play.Text = "PLAY";
            this.toolStripDropDownButton_play.Click += new System.EventHandler(this.toolStripDropDownButton_play_Click);
            // 
            // toolStripStatusLabel_separator
            // 
            this.toolStripStatusLabel_separator.Name = "toolStripStatusLabel_separator";
            this.toolStripStatusLabel_separator.Size = new System.Drawing.Size(13, 20);
            this.toolStripStatusLabel_separator.Text = "|";
            // 
            // codaToolStripMenuItem
            // 
            this.codaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aggiungiToolStripMenuItem,
            this.visualizzaToolStripMenuItem,
            this.eliminaToolStripMenuItem});
            this.codaToolStripMenuItem.Name = "codaToolStripMenuItem";
            this.codaToolStripMenuItem.Size = new System.Drawing.Size(58, 24);
            this.codaToolStripMenuItem.Text = "Coda";
            // 
            // aggiungiToolStripMenuItem
            // 
            this.aggiungiToolStripMenuItem.Name = "aggiungiToolStripMenuItem";
            this.aggiungiToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.aggiungiToolStripMenuItem.Text = "Aggiungi";
            // 
            // visualizzaToolStripMenuItem
            // 
            this.visualizzaToolStripMenuItem.Name = "visualizzaToolStripMenuItem";
            this.visualizzaToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.visualizzaToolStripMenuItem.Text = "Visualizza";
            // 
            // eliminaToolStripMenuItem
            // 
            this.eliminaToolStripMenuItem.Name = "eliminaToolStripMenuItem";
            this.eliminaToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.eliminaToolStripMenuItem.Text = "Elimina";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1272, 576);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem caricaAudioToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_nomeCanzone;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton_play;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_separator;
        private System.Windows.Forms.ToolStripMenuItem codaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aggiungiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visualizzaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminaToolStripMenuItem;
    }
}

