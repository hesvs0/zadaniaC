namespace _21b_menuMyszki
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.element1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.element2ToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.element3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.element1ToolStripMenuItem,
            this.element2ToolStripMenuItem,
            this.element3ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(195, 54);
            // 
            // element1ToolStripMenuItem
            // 
            this.element1ToolStripMenuItem.Name = "element1ToolStripMenuItem";
            this.element1ToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.element1ToolStripMenuItem.Text = "Zmień kolor na losowy";
            this.element1ToolStripMenuItem.Click += new System.EventHandler(this.element1ToolStripMenuItem_Click);
            // 
            // element2ToolStripMenuItem
            // 
            this.element2ToolStripMenuItem.Name = "element2ToolStripMenuItem";
            this.element2ToolStripMenuItem.Size = new System.Drawing.Size(191, 6);
            // 
            // element3ToolStripMenuItem
            // 
            this.element3ToolStripMenuItem.Name = "element3ToolStripMenuItem";
            this.element3ToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.element3ToolStripMenuItem.Text = "Zamknij";
            this.element3ToolStripMenuItem.Click += new System.EventHandler(this.element3ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 294);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu kontekstowe:. AL";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem element1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem element3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator element2ToolStripMenuItem;
    }
}

