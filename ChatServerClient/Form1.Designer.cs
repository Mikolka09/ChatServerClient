
namespace ChatServerClient
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
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxReciveMessage = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonSend = new System.Windows.Forms.Button();
            this.textBoxSendMessage = new System.Windows.Forms.TextBox();
            this.checkBoxAuto = new System.Windows.Forms.CheckBox();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonTurnOnServer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(122, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "ОКНО СООБЩЕНИЙ КЛИЕНТА";
            // 
            // listBoxReciveMessage
            // 
            this.listBoxReciveMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBoxReciveMessage.FormattingEnabled = true;
            this.listBoxReciveMessage.HorizontalScrollbar = true;
            this.listBoxReciveMessage.ItemHeight = 18;
            this.listBoxReciveMessage.Location = new System.Drawing.Point(15, 160);
            this.listBoxReciveMessage.Name = "listBoxReciveMessage";
            this.listBoxReciveMessage.Size = new System.Drawing.Size(440, 184);
            this.listBoxReciveMessage.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(84, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(297, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "ОКНО ДЛЯ НАПИСАНИЯ СООБЩЕНИЙ";
            // 
            // buttonSend
            // 
            this.buttonSend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSend.Location = new System.Drawing.Point(282, 92);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(112, 35);
            this.buttonSend.TabIndex = 5;
            this.buttonSend.Text = "Отправить";
            this.buttonSend.UseVisualStyleBackColor = false;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // textBoxSendMessage
            // 
            this.textBoxSendMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxSendMessage.Location = new System.Drawing.Point(87, 29);
            this.textBoxSendMessage.Multiline = true;
            this.textBoxSendMessage.Name = "textBoxSendMessage";
            this.textBoxSendMessage.Size = new System.Drawing.Size(307, 57);
            this.textBoxSendMessage.TabIndex = 6;
            this.textBoxSendMessage.TextChanged += new System.EventHandler(this.textBoxSendMessage_TextChanged);
            // 
            // checkBoxAuto
            // 
            this.checkBoxAuto.AutoSize = true;
            this.checkBoxAuto.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxAuto.Location = new System.Drawing.Point(87, 92);
            this.checkBoxAuto.Name = "checkBoxAuto";
            this.checkBoxAuto.Size = new System.Drawing.Size(133, 21);
            this.checkBoxAuto.TabIndex = 7;
            this.checkBoxAuto.Text = "Автоответчик";
            this.checkBoxAuto.UseVisualStyleBackColor = true;
            this.checkBoxAuto.CheckedChanged += new System.EventHandler(this.checkBoxAuto_CheckedChanged);
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonExit.Location = new System.Drawing.Point(343, 350);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(112, 35);
            this.buttonExit.TabIndex = 8;
            this.buttonExit.Text = "Выход";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonTurnOnServer
            // 
            this.buttonTurnOnServer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonTurnOnServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonTurnOnServer.Location = new System.Drawing.Point(15, 350);
            this.buttonTurnOnServer.Name = "buttonTurnOnServer";
            this.buttonTurnOnServer.Size = new System.Drawing.Size(159, 35);
            this.buttonTurnOnServer.TabIndex = 9;
            this.buttonTurnOnServer.Text = "Включить сервер";
            this.buttonTurnOnServer.UseVisualStyleBackColor = false;
            this.buttonTurnOnServer.Click += new System.EventHandler(this.buttonTurnOnServer_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 400);
            this.Controls.Add(this.buttonTurnOnServer);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.checkBoxAuto);
            this.Controls.Add(this.textBoxSendMessage);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.listBoxReciveMessage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "SERVER";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxReciveMessage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.TextBox textBoxSendMessage;
        private System.Windows.Forms.CheckBox checkBoxAuto;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonTurnOnServer;
    }
}

