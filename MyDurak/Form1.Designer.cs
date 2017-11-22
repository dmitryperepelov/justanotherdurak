namespace MyDurak
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.trumpLbl = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.cardCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.enemyCard = new System.Windows.Forms.Label();
            this.myCards = new System.Windows.Forms.Label();
            this.defDeck = new System.Windows.Forms.Label();
            this.giveDeck = new System.Windows.Forms.Label();
            this.table = new System.Windows.Forms.Label();
            this.playerChoice = new System.Windows.Forms.NumericUpDown();
            this.throwButton = new System.Windows.Forms.Button();
            this.bitoButton = new System.Windows.Forms.Button();
            this.getButton = new System.Windows.Forms.Button();
            this.turnlbl = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerChoice)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(212, 28);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(211, 24);
            this.toolStripMenuItem1.Text = "toolStripMenuItem1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1202, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(60, 24);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.newGameToolStripMenuItem.Text = "New Game";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 131);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(120, 310);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(138, 31);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(806, 100);
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(950, 131);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(120, 310);
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Location = new System.Drawing.Point(138, 441);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(806, 100);
            this.pictureBox4.TabIndex = 5;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Location = new System.Drawing.Point(138, 137);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(806, 298);
            this.pictureBox5.TabIndex = 6;
            this.pictureBox5.TabStop = false;
            // 
            // trumpLbl
            // 
            this.trumpLbl.AutoSize = true;
            this.trumpLbl.Location = new System.Drawing.Point(117, 82);
            this.trumpLbl.Name = "trumpLbl";
            this.trumpLbl.Size = new System.Drawing.Size(53, 17);
            this.trumpLbl.TabIndex = 7;
            this.trumpLbl.Text = "Trump:";
            // 
            // pictureBox6
            // 
            this.pictureBox6.Location = new System.Drawing.Point(1076, 181);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(120, 100);
            this.pictureBox6.TabIndex = 8;
            this.pictureBox6.TabStop = false;
            // 
            // cardCount
            // 
            this.cardCount.AutoSize = true;
            this.cardCount.Location = new System.Drawing.Point(33, 65);
            this.cardCount.Name = "cardCount";
            this.cardCount.Size = new System.Drawing.Size(137, 17);
            this.cardCount.TabIndex = 9;
            this.cardCount.Text = "Cards in deck count:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1105, 350);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 17);
            this.label3.TabIndex = 10;
            // 
            // enemyCard
            // 
            this.enemyCard.AutoSize = true;
            this.enemyCard.Location = new System.Drawing.Point(186, 114);
            this.enemyCard.Name = "enemyCard";
            this.enemyCard.Size = new System.Drawing.Size(106, 17);
            this.enemyCard.TabIndex = 11;
            this.enemyCard.Text = "Enemy`s cards:";
            // 
            // myCards
            // 
            this.myCards.AutoSize = true;
            this.myCards.Location = new System.Drawing.Point(186, 463);
            this.myCards.Name = "myCards";
            this.myCards.Size = new System.Drawing.Size(69, 17);
            this.myCards.TabIndex = 12;
            this.myCards.Text = "My cards:";
            // 
            // defDeck
            // 
            this.defDeck.AutoSize = true;
            this.defDeck.Location = new System.Drawing.Point(79, 31);
            this.defDeck.Name = "defDeck";
            this.defDeck.Size = new System.Drawing.Size(91, 17);
            this.defDeck.TabIndex = 13;
            this.defDeck.Text = "Defualt deck:";
            // 
            // giveDeck
            // 
            this.giveDeck.AutoSize = true;
            this.giveDeck.Location = new System.Drawing.Point(77, 48);
            this.giveDeck.Name = "giveDeck";
            this.giveDeck.Size = new System.Drawing.Size(93, 17);
            this.giveDeck.TabIndex = 14;
            this.giveDeck.Text = "Current deck:";
            // 
            // table
            // 
            this.table.AutoSize = true;
            this.table.Location = new System.Drawing.Point(186, 282);
            this.table.Name = "table";
            this.table.Size = new System.Drawing.Size(48, 17);
            this.table.TabIndex = 16;
            this.table.Text = "Table:";
            // 
            // playerChoice
            // 
            this.playerChoice.Location = new System.Drawing.Point(202, 492);
            this.playerChoice.Name = "playerChoice";
            this.playerChoice.Size = new System.Drawing.Size(120, 22);
            this.playerChoice.TabIndex = 18;
            // 
            // throwButton
            // 
            this.throwButton.AutoSize = true;
            this.throwButton.Enabled = false;
            this.throwButton.Location = new System.Drawing.Point(12, 492);
            this.throwButton.Name = "throwButton";
            this.throwButton.Size = new System.Drawing.Size(179, 27);
            this.throwButton.TabIndex = 19;
            this.throwButton.Text = "Что ты скажешь на это?";
            this.throwButton.UseVisualStyleBackColor = true;
            this.throwButton.Click += new System.EventHandler(this.throwButton_Click);
            // 
            // bitoButton
            // 
            this.bitoButton.AutoSize = true;
            this.bitoButton.Enabled = false;
            this.bitoButton.Location = new System.Drawing.Point(344, 492);
            this.bitoButton.Name = "bitoButton";
            this.bitoButton.Size = new System.Drawing.Size(87, 27);
            this.bitoButton.TabIndex = 20;
            this.bitoButton.Text = "Пока живи";
            this.bitoButton.UseVisualStyleBackColor = true;
            this.bitoButton.Click += new System.EventHandler(this.bitoButton_Click);
            // 
            // getButton
            // 
            this.getButton.AutoSize = true;
            this.getButton.Enabled = false;
            this.getButton.Location = new System.Drawing.Point(437, 492);
            this.getButton.Name = "getButton";
            this.getButton.Size = new System.Drawing.Size(159, 27);
            this.getButton.TabIndex = 21;
            this.getButton.Text = "Тебе просто повезло";
            this.getButton.UseVisualStyleBackColor = true;
            this.getButton.Click += new System.EventHandler(this.getButton_Click);
            // 
            // turnlbl
            // 
            this.turnlbl.AutoSize = true;
            this.turnlbl.Location = new System.Drawing.Point(128, 99);
            this.turnlbl.Name = "turnlbl";
            this.turnlbl.Size = new System.Drawing.Size(42, 17);
            this.turnlbl.TabIndex = 22;
            this.turnlbl.Text = "Turn:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1202, 553);
            this.Controls.Add(this.turnlbl);
            this.Controls.Add(this.getButton);
            this.Controls.Add(this.bitoButton);
            this.Controls.Add(this.throwButton);
            this.Controls.Add(this.playerChoice);
            this.Controls.Add(this.table);
            this.Controls.Add(this.giveDeck);
            this.Controls.Add(this.defDeck);
            this.Controls.Add(this.myCards);
            this.Controls.Add(this.enemyCard);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cardCount);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.trumpLbl);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Durak";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerChoice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label trumpLbl;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label cardCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label enemyCard;
        private System.Windows.Forms.Label myCards;
        private System.Windows.Forms.Label defDeck;
        private System.Windows.Forms.Label giveDeck;
        private System.Windows.Forms.Label table;
        private System.Windows.Forms.NumericUpDown playerChoice;
        private System.Windows.Forms.Button throwButton;
        private System.Windows.Forms.Button bitoButton;
        private System.Windows.Forms.Button getButton;
        private System.Windows.Forms.Label turnlbl;
    }
}

