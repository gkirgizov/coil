namespace hw4 {
    partial class Editor {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Editor));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolsPanel = new System.Windows.Forms.Panel();
            this.undoButton = new System.Windows.Forms.ToolStripButton();
            this.redoButton = new System.Windows.Forms.ToolStripButton();
            this.tools = new System.Windows.Forms.ToolStrip();
            this.canvas = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolsPanel.SuspendLayout();
            this.tools.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.canvas, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.toolsPanel, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.324759F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.67524F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(584, 361);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // toolsPanel
            // 
            this.toolsPanel.Controls.Add(this.tools);
            this.toolsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolsPanel.Location = new System.Drawing.Point(3, 3);
            this.toolsPanel.Name = "toolsPanel";
            this.toolsPanel.Size = new System.Drawing.Size(578, 27);
            this.toolsPanel.TabIndex = 1;
            // 
            // undoButton
            // 
            this.undoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.undoButton.Image = ((System.Drawing.Image)(resources.GetObject("undoButton.Image")));
            this.undoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(40, 22);
            this.undoButton.Text = "Undo";
            this.undoButton.Click += new System.EventHandler(this.undoButton_Click);
            // 
            // redoButton
            // 
            this.redoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.redoButton.Image = ((System.Drawing.Image)(resources.GetObject("redoButton.Image")));
            this.redoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.redoButton.Name = "redoButton";
            this.redoButton.Size = new System.Drawing.Size(38, 22);
            this.redoButton.Text = "Redo";
            this.redoButton.Click += new System.EventHandler(this.redoButton_Click);
            // 
            // tools
            // 
            this.tools.Dock = System.Windows.Forms.DockStyle.None;
            this.tools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoButton,
            this.redoButton});
            this.tools.Location = new System.Drawing.Point(0, 0);
            this.tools.Name = "tools";
            this.tools.Size = new System.Drawing.Size(90, 25);
            this.tools.Stretch = true;
            this.tools.TabIndex = 0;
            this.tools.Text = "tools";
            // 
            // canvas
            // 
            this.canvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvas.Location = new System.Drawing.Point(3, 36);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(578, 322);
            this.canvas.TabIndex = 0;
            this.canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseDown);
            this.canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseUp);
            this.canvas.Resize += new System.EventHandler(this.canvas_Resize);
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximumSize = new System.Drawing.Size(600, 400);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "Editor";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.toolsPanel.ResumeLayout(false);
            this.toolsPanel.PerformLayout();
            this.tools.ResumeLayout(false);
            this.tools.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel toolsPanel;
        private System.Windows.Forms.Panel canvas;
        private System.Windows.Forms.ToolStrip tools;
        private System.Windows.Forms.ToolStripButton undoButton;
        private System.Windows.Forms.ToolStripButton redoButton;
    }
}

