namespace CRM
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
            this.buttonWyszukajPesel = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zakończToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.użytkownicyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wyszukajKlientaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listaKlientówToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dodajKlientaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pomocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oAutorachToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oBazieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonWyszukajPesel
            // 
            this.buttonWyszukajPesel.Location = new System.Drawing.Point(343, 115);
            this.buttonWyszukajPesel.Name = "buttonWyszukajPesel";
            this.buttonWyszukajPesel.Size = new System.Drawing.Size(175, 23);
            this.buttonWyszukajPesel.TabIndex = 15;
            this.buttonWyszukajPesel.Text = "dont delte this";
            this.buttonWyszukajPesel.UseVisualStyleBackColor = true;
            this.buttonWyszukajPesel.Click += new System.EventHandler(this.buttonWyszukajPesel_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.użytkownicyToolStripMenuItem,
            this.pomocToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(582, 24);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zakończToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // zakończToolStripMenuItem
            // 
            this.zakończToolStripMenuItem.Name = "zakończToolStripMenuItem";
            this.zakończToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.zakończToolStripMenuItem.Text = "Zakończ";
            this.zakończToolStripMenuItem.Click += new System.EventHandler(this.zakończToolStripMenuItem_Click);
            // 
            // użytkownicyToolStripMenuItem
            // 
            this.użytkownicyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wyszukajKlientaToolStripMenuItem,
            this.listaKlientówToolStripMenuItem,
            this.dodajKlientaToolStripMenuItem});
            this.użytkownicyToolStripMenuItem.Name = "użytkownicyToolStripMenuItem";
            this.użytkownicyToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.użytkownicyToolStripMenuItem.Text = "Klienci";
            // 
            // wyszukajKlientaToolStripMenuItem
            // 
            this.wyszukajKlientaToolStripMenuItem.Name = "wyszukajKlientaToolStripMenuItem";
            this.wyszukajKlientaToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.wyszukajKlientaToolStripMenuItem.Text = "Wyszukaj klienta";
            // 
            // listaKlientówToolStripMenuItem
            // 
            this.listaKlientówToolStripMenuItem.Name = "listaKlientówToolStripMenuItem";
            this.listaKlientówToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.listaKlientówToolStripMenuItem.Text = "Lista klientów";
            this.listaKlientówToolStripMenuItem.Click += new System.EventHandler(this.listaKlientówToolStripMenuItem_Click);
            // 
            // dodajKlientaToolStripMenuItem
            // 
            this.dodajKlientaToolStripMenuItem.Name = "dodajKlientaToolStripMenuItem";
            this.dodajKlientaToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.dodajKlientaToolStripMenuItem.Text = "Dodaj klienta";
            this.dodajKlientaToolStripMenuItem.Click += new System.EventHandler(this.dodajKlientaToolStripMenuItem_Click);
            // 
            // pomocToolStripMenuItem
            // 
            this.pomocToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeLogToolStripMenuItem,
            this.oAutorachToolStripMenuItem,
            this.oBazieToolStripMenuItem});
            this.pomocToolStripMenuItem.Name = "pomocToolStripMenuItem";
            this.pomocToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.pomocToolStripMenuItem.Text = "Pomoc";
            // 
            // changeLogToolStripMenuItem
            // 
            this.changeLogToolStripMenuItem.Name = "changeLogToolStripMenuItem";
            this.changeLogToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.changeLogToolStripMenuItem.Text = "Change Log";
            this.changeLogToolStripMenuItem.Click += new System.EventHandler(this.changeLogToolStripMenuItem_Click);
            // 
            // oAutorachToolStripMenuItem
            // 
            this.oAutorachToolStripMenuItem.Name = "oAutorachToolStripMenuItem";
            this.oAutorachToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.oAutorachToolStripMenuItem.Text = "O autorach";
            this.oAutorachToolStripMenuItem.Click += new System.EventHandler(this.oAutorachToolStripMenuItem_Click);
            // 
            // oBazieToolStripMenuItem
            // 
            this.oBazieToolStripMenuItem.Name = "oBazieToolStripMenuItem";
            this.oBazieToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.oBazieToolStripMenuItem.Text = "O bazie";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 261);
            this.Controls.Add(this.buttonWyszukajPesel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonWyszukajPesel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zakończToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem użytkownicyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wyszukajKlientaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pomocToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oAutorachToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listaKlientówToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dodajKlientaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oBazieToolStripMenuItem;
    }
}

