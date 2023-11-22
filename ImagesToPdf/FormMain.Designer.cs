namespace ImagesToPdf
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            lvwImages = new ListView();
            imageList1 = new ImageList(components);
            lblSelect = new LinkLabel();
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            btnStart = new Button();
            SuspendLayout();
            // 
            // lvwImages
            // 
            lvwImages.AllowDrop = true;
            lvwImages.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lvwImages.Location = new Point(12, 59);
            lvwImages.Name = "lvwImages";
            lvwImages.Size = new Size(776, 379);
            lvwImages.SmallImageList = imageList1;
            lvwImages.TabIndex = 0;
            lvwImages.UseCompatibleStateImageBehavior = false;
            lvwImages.View = View.List;
            lvwImages.DragDrop += LvwImages_DragDrop;
            lvwImages.DragEnter += LvwImages_DragEnter;
            lvwImages.KeyDown += LvwImages_KeyDown;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth24Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "StatusHidden_16x.png");
            imageList1.Images.SetKeyName(1, "StatusOK_16x.png");
            // 
            // lblSelect
            // 
            lblSelect.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblSelect.BackColor = Color.White;
            lblSelect.Font = new Font("Microsoft YaHei UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            lblSelect.Location = new Point(250, 221);
            lblSelect.Name = "lblSelect";
            lblSelect.Size = new Size(301, 54);
            lblSelect.TabIndex = 1;
            lblSelect.TabStop = true;
            lblSelect.Text = "直接拖入或点击此处选择图片";
            lblSelect.TextAlign = ContentAlignment.MiddleCenter;
            lblSelect.VisitedLinkColor = Color.Blue;
            lblSelect.LinkClicked += LblSelect_LinkClicked;
            // 
            // openFileDialog1
            // 
            openFileDialog1.Multiselect = true;
            // 
            // saveFileDialog1
            // 
            saveFileDialog1.DefaultExt = "pdf";
            saveFileDialog1.Filter = "PDF|*.pdf";
            // 
            // btnStart
            // 
            btnStart.Font = new Font("Microsoft YaHei UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            btnStart.Location = new Point(660, 12);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(128, 41);
            btnStart.TabIndex = 2;
            btnStart.Text = "开始";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += BtnStart_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(800, 450);
            Controls.Add(btnStart);
            Controls.Add(lblSelect);
            Controls.Add(lvwImages);
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Images to PDF";
            ResumeLayout(false);
        }

        #endregion

        private ListView lvwImages;
        private ImageList imageList1;
        private LinkLabel lblSelect;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private Button btnStart;
    }
}