using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Docnet.Core;
using Docnet.Core.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace PDFCutter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cmbImageFormat.SelectedIndex = 0; // 預設 PNG
            cmbDpi.SelectedIndex = 2; // 預設 150 DPI
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtInputFile.Text = openFileDialog.FileName;
                    LoadPDFInfo(openFileDialog.FileName);

                    // 如果勾選了同資料夾，自動更新輸出路徑
                    if (chkSameFolder.Checked)
                    {
                        UpdateOutputPathToSameFolder();
                    }
                }
            }
        }

        private void UpdateOutputPathToSameFolder()
        {
            if (!string.IsNullOrEmpty(txtInputFile.Text))
            {
                string inputPath = txtInputFile.Text;
                string inputDirectory = Path.GetDirectoryName(inputPath);
                string inputFileName = Path.GetFileNameWithoutExtension(inputPath);
                txtOutputFile.Text = Path.Combine(inputDirectory, $"{inputFileName}_extracted.pdf");
            }
        }

        private void chkSameFolder_CheckedChanged(object sender, EventArgs e)
        {
            btnSelectOutput.Enabled = !chkSameFolder.Checked;
            if (chkSameFolder.Checked)
            {
                UpdateOutputPathToSameFolder();
            }
            else
            {
                txtOutputFile.Clear();
            }
        }

        private void btnSelectOutput_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;

                if (!string.IsNullOrEmpty(txtInputFile.Text))
                {
                    string inputFileName = Path.GetFileNameWithoutExtension(txtInputFile.Text);
                    saveFileDialog.FileName = $"{inputFileName}_extracted.pdf";
                }

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtOutputFile.Text = saveFileDialog.FileName;
                }
            }
        }

        private void LoadPDFInfo(string filePath)
        {
            try
            {
                using (PdfReader reader = new PdfReader(filePath))
                {
                    int pageCount = reader.NumberOfPages;
                    lblPageCount.Text = $"總頁數: {pageCount}";
                    txtPageRange.Text = $"1-{pageCount}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"讀取 PDF 檔案時發生錯誤: {ex.Message}", "錯誤", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExtract_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInputFile.Text))
            {
                MessageBox.Show("請選擇輸入檔案", "警告", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtOutputFile.Text))
            {
                MessageBox.Show("請選擇輸出位置", "警告", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtPageRange.Text))
            {
                MessageBox.Show("請輸入頁面範圍", "警告", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                ExtractPages(txtInputFile.Text, txtOutputFile.Text, txtPageRange.Text);
                MessageBox.Show("PDF 頁面擷取完成！", "成功", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"擷取頁面時發生錯誤: {ex.Message}", "錯誤", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExtractPages(string inputPath, string outputPath, string pageRange)
        {
            using (PdfReader reader = new PdfReader(inputPath))
            {
                int totalPages = reader.NumberOfPages;
                var pagesToExtract = ParsePageRange(pageRange, totalPages);

                if (pagesToExtract.Count == 0)
                {
                    throw new ArgumentException("無效的頁面範圍");
                }

                using (Document document = new Document())
                {
                    using (PdfCopy copy = new PdfCopy(document, new FileStream(outputPath, FileMode.Create)))
                    {
                        document.Open();

                        foreach (int pageNum in pagesToExtract)
                        {
                            if (pageNum >= 1 && pageNum <= totalPages)
                            {
                                copy.AddPage(copy.GetImportedPage(reader, pageNum));
                            }
                        }
                    }
                }
            }
        }

        private List<int> ParsePageRange(string pageRange, int totalPages)
        {
            var pages = new List<int>();
            var ranges = pageRange.Split(',', StringSplitOptions.RemoveEmptyEntries);

            foreach (var range in ranges)
            {
                var trimmedRange = range.Trim();
                
                if (trimmedRange.Contains('-'))
                {
                    // 處理範圍 (例如: 1-5)
                    var parts = trimmedRange.Split('-');
                    if (parts.Length == 2 && 
                        int.TryParse(parts[0].Trim(), out int start) && 
                        int.TryParse(parts[1].Trim(), out int end))
                    {
                        for (int i = start; i <= end && i <= totalPages; i++)
                        {
                            if (i >= 1 && !pages.Contains(i))
                            {
                                pages.Add(i);
                            }
                        }
                    }
                }
                else
                {
                    // 處理單一頁面
                    if (int.TryParse(trimmedRange, out int pageNum))
                    {
                        if (pageNum >= 1 && pageNum <= totalPages && !pages.Contains(pageNum))
                        {
                            pages.Add(pageNum);
                        }
                    }
                }
            }

            return pages.OrderBy(x => x).ToList();
        }

        private void btnConvertToImage_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInputFile.Text))
            {
                MessageBox.Show("請選擇輸入檔案", "警告",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtPageRange.Text))
            {
                MessageBox.Show("請輸入頁面範圍", "警告",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 選擇輸出資料夾
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "選擇圖片輸出資料夾";
                
                // 預設使用輸入檔案的目錄
                if (!string.IsNullOrEmpty(txtInputFile.Text))
                {
                    folderDialog.SelectedPath = Path.GetDirectoryName(txtInputFile.Text);
                }

                if (folderDialog.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    // 建立以原檔名命名的子資料夾
                    string baseFileName = Path.GetFileNameWithoutExtension(txtInputFile.Text);
                    string outputFolder = Path.Combine(folderDialog.SelectedPath, baseFileName);
                    Directory.CreateDirectory(outputFolder);

                    ConvertPdfToImages(txtInputFile.Text, outputFolder, txtPageRange.Text);
                    MessageBox.Show($"PDF 轉圖檔完成！\n輸出至: {outputFolder}", "成功",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"轉換圖檔時發生錯誤: {ex.Message}", "錯誤",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ConvertPdfToImages(string inputPath, string outputFolder, string pageRange)
        {
            int dpi = int.TryParse(cmbDpi.SelectedItem?.ToString(), out int d) ? d : 150;
            string format = cmbImageFormat.SelectedItem?.ToString() ?? "PNG";
            
            ImageFormat imageFormat = format.ToUpper() switch
            {
                "PNG" => ImageFormat.Png,
                "JPG" => ImageFormat.Jpeg,
                "BMP" => ImageFormat.Bmp,
                "TIFF" => ImageFormat.Tiff,
                _ => ImageFormat.Png
            };

            string extension = format.ToLower();
            string baseFileName = Path.GetFileNameWithoutExtension(inputPath);

            // DPI 對應的縮放倍數 (72 DPI 為基準)
            double scale = dpi / 72.0;

            using (var library = DocLib.Instance)
            using (var docReader = library.GetDocReader(inputPath, new PageDimensions(scale)))
            {
                int totalPages = docReader.GetPageCount();
                var pagesToConvert = ParsePageRange(pageRange, totalPages);

                foreach (int pageNum in pagesToConvert)
                {
                    int pageIndex = pageNum - 1;
                    
                    if (pageIndex >= 0 && pageIndex < totalPages)
                    {
                        using (var pageReader = docReader.GetPageReader(pageIndex))
                        {
                            int width = pageReader.GetPageWidth();
                            int height = pageReader.GetPageHeight();
                            var rawBytes = pageReader.GetImage();

                            // Docnet 回傳 BGRA 格式
                            using (var bmp = new Bitmap(width, height, PixelFormat.Format32bppArgb))
                            {
                                var bmpData = bmp.LockBits(
                                    new System.Drawing.Rectangle(0, 0, width, height),
                                    ImageLockMode.WriteOnly, 
                                    PixelFormat.Format32bppArgb);
                                
                                Marshal.Copy(rawBytes, 0, bmpData.Scan0, rawBytes.Length);
                                bmp.UnlockBits(bmpData);

                                // 建立白色底圖，將 PDF 渲染結果疊上
                                using (var whiteBg = new Bitmap(width, height, PixelFormat.Format24bppRgb))
                                {
                                    using (var g = Graphics.FromImage(whiteBg))
                                    {
                                        g.Clear(Color.White);
                                        g.DrawImage(bmp, 0, 0, width, height);
                                    }

                                    string outputPath = Path.Combine(outputFolder, 
                                        $"{baseFileName}_page{pageNum:D3}.{extension}");
                                    whiteBg.Save(outputPath, imageFormat);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtInputFile.Clear();
            txtOutputFile.Clear();
            txtPageRange.Clear();
            lblPageCount.Text = "總頁數: 0";
            chkSameFolder.Checked = false;
        }
    }
} 