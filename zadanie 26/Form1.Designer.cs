namespace wieleOkien
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.otwórzToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.okno1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.okno2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.okno3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.zamknijToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.metodaIIOtwórzInstancjeOknaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oknoInstancja1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oknoInstancja2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oknoInstancja3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.otwórzToolStripMenuItem,
            this.metodaIIOtwórzInstancjeOknaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(481, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // otwórzToolStripMenuItem
            // 
            this.otwórzToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.okno1ToolStripMenuItem,
            this.okno2ToolStripMenuItem,
            this.okno3ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.zamknijToolStripMenuItem});
            this.otwórzToolStripMenuItem.Name = "otwórzToolStripMenuItem";
            this.otwórzToolStripMenuItem.Size = new System.Drawing.Size(184, 20);
            this.otwórzToolStripMenuItem.Text = "Metoda I: Otwórz bezpośrednio";
            // 
            // okno1ToolStripMenuItem
            // 
            this.okno1ToolStripMenuItem.Name = "okno1ToolStripMenuItem";
            this.okno1ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.okno1ToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.okno1ToolStripMenuItem.Text = "Okno 1";
            this.okno1ToolStripMenuItem.Click += new System.EventHandler(this.Okno1ToolStripMenuItem_Click);
            // 
            // okno2ToolStripMenuItem
            // 
            this.okno2ToolStripMenuItem.Name = "okno2ToolStripMenuItem";
            this.okno2ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.okno2ToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.okno2ToolStripMenuItem.Text = "Okno 2";
            this.okno2ToolStripMenuItem.Click += new System.EventHandler(this.Okno2ToolStripMenuItem_Click);
            // 
            // okno3ToolStripMenuItem
            // 
            this.okno3ToolStripMenuItem.Name = "okno3ToolStripMenuItem";
            this.okno3ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.okno3ToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.okno3ToolStripMenuItem.Text = "Okno 3";
            this.okno3ToolStripMenuItem.Click += new System.EventHandler(this.Okno3ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(160, 6);
            // 
            // zamknijToolStripMenuItem
            // 
            this.zamknijToolStripMenuItem.Name = "zamknijToolStripMenuItem";
            this.zamknijToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.zamknijToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.zamknijToolStripMenuItem.Text = "Zamknij";
            this.zamknijToolStripMenuItem.Click += new System.EventHandler(this.ZamknijToolStripMenuItem_Click);
            // 
            // metodaIIOtwórzInstancjeOknaToolStripMenuItem
            // 
            this.metodaIIOtwórzInstancjeOknaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oknoInstancja1ToolStripMenuItem,
            this.oknoInstancja2ToolStripMenuItem,
            this.oknoInstancja3ToolStripMenuItem});
            this.metodaIIOtwórzInstancjeOknaToolStripMenuItem.Name = "metodaIIOtwórzInstancjeOknaToolStripMenuItem";
            this.metodaIIOtwórzInstancjeOknaToolStripMenuItem.Size = new System.Drawing.Size(165, 20);
            this.metodaIIOtwórzInstancjeOknaToolStripMenuItem.Text = "Metoda II:Otwórz z instancji";
            // 
            // oknoInstancja1ToolStripMenuItem
            // 
            this.oknoInstancja1ToolStripMenuItem.Name = "oknoInstancja1ToolStripMenuItem";
            this.oknoInstancja1ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.oknoInstancja1ToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.oknoInstancja1ToolStripMenuItem.Text = "Okno Instancja 1";
            this.oknoInstancja1ToolStripMenuItem.Click += new System.EventHandler(this.OknoInstancja1ToolStripMenuItem_Click);
            // 
            // oknoInstancja2ToolStripMenuItem
            // 
            this.oknoInstancja2ToolStripMenuItem.Name = "oknoInstancja2ToolStripMenuItem";
            this.oknoInstancja2ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.oknoInstancja2ToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.oknoInstancja2ToolStripMenuItem.Text = "Okno Instancja 2";
            this.oknoInstancja2ToolStripMenuItem.Click += new System.EventHandler(this.OknoInstancja2ToolStripMenuItem_Click);
            // 
            // oknoInstancja3ToolStripMenuItem
            // 
            this.oknoInstancja3ToolStripMenuItem.Name = "oknoInstancja3ToolStripMenuItem";
            this.oknoInstancja3ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.oknoInstancja3ToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.oknoInstancja3ToolStripMenuItem.Text = "Okno Instancja 3";
            this.oknoInstancja3ToolStripMenuItem.Click += new System.EventHandler(this.OknoInstancja3ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 408);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Okno główne. Aplikacaj wielookienkowa:. AL";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem otwórzToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem okno1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem okno2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem okno3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem zamknijToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem metodaIIOtwórzInstancjeOknaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oknoInstancja1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oknoInstancja2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oknoInstancja3ToolStripMenuItem;
    }
}

