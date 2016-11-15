namespace CRM
{
    partial class ChangeLog
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Zmieniono ChangeLog");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Sprawadza czy połącznie z bazą jest aktywne");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Dodano formularz wyszukiwania klienta");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("15/11/2016", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Lista Klientów");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Porprawiono Dodwania Klienta");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("9/11/2016", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6});
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Klasa oAutorach");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Klasa DodajKlienta");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Osobne okienko dla dodawania klienta");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("6/11/2016", new System.Windows.Forms.TreeNode[] {
            treeNode8,
            treeNode9,
            treeNode10});
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Podłącznie do bazy");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Klasa SqlConnectionClass");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("3/11/2016", new System.Windows.Forms.TreeNode[] {
            treeNode12,
            treeNode13});
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Stworzenie projektu");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("30/10/2016", new System.Windows.Forms.TreeNode[] {
            treeNode15});
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Node1";
            treeNode1.Text = "Zmieniono ChangeLog";
            treeNode1.ToolTipText = "Zamiast formularza, lista";
            treeNode2.Name = "Node21";
            treeNode2.Text = "Sprawadza czy połącznie z bazą jest aktywne";
            treeNode3.Name = "Node24";
            treeNode3.Text = "Dodano formularz wyszukiwania klienta";
            treeNode4.Name = "Node0";
            treeNode4.Text = "15/11/2016";
            treeNode5.Name = "Node18";
            treeNode5.Text = "Lista Klientów";
            treeNode6.Name = "Node19";
            treeNode6.Text = "Porprawiono Dodwania Klienta";
            treeNode7.Name = "Node17";
            treeNode7.Text = "9/11/2016";
            treeNode8.Name = "Node14";
            treeNode8.Text = "Klasa oAutorach";
            treeNode9.Name = "Node15";
            treeNode9.Text = "Klasa DodajKlienta";
            treeNode10.Name = "Node16";
            treeNode10.Text = "Osobne okienko dla dodawania klienta";
            treeNode11.Name = "Node13";
            treeNode11.Text = "6/11/2016";
            treeNode12.Name = "Node11";
            treeNode12.Text = "Podłącznie do bazy";
            treeNode13.Name = "Node12";
            treeNode13.Text = "Klasa SqlConnectionClass";
            treeNode14.Name = "Node9";
            treeNode14.Text = "3/11/2016";
            treeNode15.Name = "Node8";
            treeNode15.Text = "Stworzenie projektu";
            treeNode16.Name = "Node7";
            treeNode16.Text = "30/10/2016";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode7,
            treeNode11,
            treeNode14,
            treeNode16});
            this.treeView1.Size = new System.Drawing.Size(284, 261);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // ChangeLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.treeView1);
            this.Name = "ChangeLog";
            this.Text = "ChangeLog";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
    }
}