namespace Sawanna
{
    partial class Sawanna
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi1Settings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiAboutAutor = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAntelopes = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLions = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTokos = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHyenas = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSnakes = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.DarkKhaki;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.menuStrip1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSettings,
            this.tsmiAntelopes,
            this.tsmiLions,
            this.tsmiTokos,
            this.tsmiHyenas,
            this.tsmiSnakes});
            this.menuStrip1.Location = new System.Drawing.Point(0, 738);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(1334, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiSettings
            // 
            this.tsmiSettings.BackColor = System.Drawing.Color.Olive;
            this.tsmiSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi1Settings,
            this.toolStripSeparator2,
            this.tsmiAboutAutor});
            this.tsmiSettings.Name = "tsmiSettings";
            this.tsmiSettings.Size = new System.Drawing.Size(89, 20);
            this.tsmiSettings.Text = "Ustawienia";
            // 
            // tsmi1Settings
            // 
            this.tsmi1Settings.Name = "tsmi1Settings";
            this.tsmi1Settings.Size = new System.Drawing.Size(152, 22);
            this.tsmi1Settings.Text = "Ustawienia";
            this.tsmi1Settings.Click += new System.EventHandler(this.SettingsToolStripMenuItem1_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // tsmiAboutAutor
            // 
            this.tsmiAboutAutor.Name = "tsmiAboutAutor";
            this.tsmiAboutAutor.Size = new System.Drawing.Size(152, 22);
            this.tsmiAboutAutor.Text = "O autorze";
            this.tsmiAboutAutor.Click += new System.EventHandler(this.tsmiInfoAboutAuthor_Click);
            // 
            // tsmiAntelopes
            // 
            this.tsmiAntelopes.Name = "tsmiAntelopes";
            this.tsmiAntelopes.Size = new System.Drawing.Size(82, 20);
            this.tsmiAntelopes.Text = "Antylopy ";
            // 
            // tsmiLions
            // 
            this.tsmiLions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsmiLions.Name = "tsmiLions";
            this.tsmiLions.Size = new System.Drawing.Size(40, 20);
            this.tsmiLions.Text = "Lwy";
            // 
            // tsmiTokos
            // 
            this.tsmiTokos.Name = "tsmiTokos";
            this.tsmiTokos.Size = new System.Drawing.Size(47, 20);
            this.tsmiTokos.Text = "Toko";
            // 
            // tsmiHyenas
            // 
            this.tsmiHyenas.Name = "tsmiHyenas";
            this.tsmiHyenas.Size = new System.Drawing.Size(54, 20);
            this.tsmiHyenas.Text = "Hieny";
            // 
            // tsmiSnakes
            // 
            this.tsmiSnakes.Name = "tsmiSnakes";
            this.tsmiSnakes.Size = new System.Drawing.Size(47, 20);
            this.tsmiSnakes.Text = "Węże";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // Sawanna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.DarkKhaki;
            this.ClientSize = new System.Drawing.Size(1334, 762);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(1350, 800);
            this.MinimumSize = new System.Drawing.Size(1350, 766);
            this.Name = "Sawanna";
            this.Text = "Sawanna";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Sawanna_Paint);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiSettings;
        private System.Windows.Forms.ToolStripMenuItem tsmi1Settings;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiAntelopes;
        private System.Windows.Forms.ToolStripMenuItem tsmiLions;
        private System.Windows.Forms.ToolStripMenuItem tsmiTokos;
        private System.Windows.Forms.ToolStripMenuItem tsmiHyenas;
        private System.Windows.Forms.ToolStripMenuItem tsmiSnakes;
        private System.Windows.Forms.ToolStripMenuItem tsmiAboutAutor;
    }
}

