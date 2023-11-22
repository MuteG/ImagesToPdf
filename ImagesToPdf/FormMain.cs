using System.Diagnostics;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace ImagesToPdf
{
    public partial class FormMain : Form
    {
        private readonly HashSet<string> _imageExtensions;
        private readonly List<string> _images;

        public FormMain()
        {
            InitializeComponent();
            _imageExtensions = new HashSet<string>
            {
                ".jpg",
                ".jpeg",
                ".png",
                ".tif",
                ".tiff",
                ".bmp"
            };
            _images = new List<string>();
        }

        private void LblSelect_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                SelectImages(openFileDialog1.FileNames);
            }
        }

        private void LvwImages_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Link;
        }

        private void LvwImages_DragDrop(object sender, DragEventArgs e)
        {
            var files = (string[])e.Data?.GetData(DataFormats.FileDrop) ?? Array.Empty<string>();
            SelectImages(files);
        }

        private void LvwImages_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    foreach (ListViewItem item in lvwImages.SelectedItems)
                    {
                        var image = (string)item.Tag;
                        lvwImages.Items.RemoveByKey(image);
                        _images.Remove(image);
                    }

                    lblSelect.Visible = _images.Count == 0;
                    btnStart.Enabled = _images.Count > 0;
                    break;
            }
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (_images.Count == 0) return;
            saveFileDialog1.InitialDirectory = Path.GetDirectoryName(_images[0]);
            if (saveFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                GeneratePdf(saveFileDialog1.FileName);
            }
        }

        private void SelectImages(IEnumerable<string> files)
        {
            var images = files
                .Where(f => !_images.Contains(f) &&
                            _imageExtensions.Contains(Path.GetExtension(f).ToLower()))
                .ToList();
            if (images.Count > 0)
            {
                _images.AddRange(images);
                _images.Sort();
                lblSelect.Visible = false;
                btnStart.Enabled = true;
                RefreshListView();
            }
        }

        private void RefreshListView()
        {
            lvwImages.SuspendLayout();
            lvwImages.Items.Clear();
            foreach (var image in _images)
            {
                var item = lvwImages.Items.Add(image, Path.GetFileName(image), 0);
                item.Tag = image;
            }

            lvwImages.ResumeLayout(true);
        }

        private void GeneratePdf(string filename)
        {
            using PdfDocument document = new PdfDocument();
            foreach (var imageFile in _images)
            {
                PdfPage page = document.AddPage();
                using XGraphics gfx = XGraphics.FromPdfPage(page);
                using XImage image = XImage.FromFile(imageFile);
                gfx.DrawImage(image, 0, 0, page.Width.Point, page.Height.Point);
                lvwImages.Items[imageFile].ImageIndex = 1;
            }

            document.Save(filename);
            MessageBox.Show(@"PDFÉú³ÉÍê±Ï¡£");
        }
    }
}