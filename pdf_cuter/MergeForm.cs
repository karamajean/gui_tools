using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace PDFCutter
{
    public partial class MergeForm : Form
    {
        private readonly List<string> _files = new List<string>();

        public MergeForm()
        {
            InitializeComponent();
        }

        private void btnAddFiles_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.Multiselect = true;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string file in openFileDialog.FileNames)
                    {
                        _files.Add(file);
                        lstFiles.Items.Add(Path.GetFileName(file));
                    }

                    if (chkSameFolder.Checked)
                    {
                        UpdateOutputPathToSameFolder();
                    }
                }
            }
        }

        private void UpdateOutputPathToSameFolder()
        {
            if (_files.Count == 0)
            {
                txtMergeOutput.Clear();
                return;
            }

            string firstFile = _files[0];
            string inputDirectory = Path.GetDirectoryName(firstFile);
            string inputFileName = Path.GetFileNameWithoutExtension(firstFile);
            txtMergeOutput.Text = Path.Combine(inputDirectory, $"{inputFileName}_merged.pdf");
        }

        private void chkSameFolder_CheckedChanged(object sender, EventArgs e)
        {
            btnSelectMergeOutput.Enabled = !chkSameFolder.Checked;
            if (chkSameFolder.Checked)
            {
                UpdateOutputPathToSameFolder();
            }
            else
            {
                txtMergeOutput.Clear();
            }
        }

        private void btnRemoveFile_Click(object sender, EventArgs e)
        {
            int index = lstFiles.SelectedIndex;
            if (index < 0)
            {
                MessageBox.Show("請先選擇要移除的檔案", "警告",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _files.RemoveAt(index);
            lstFiles.Items.RemoveAt(index);

            if (chkSameFolder.Checked)
            {
                UpdateOutputPathToSameFolder();
            }
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            int index = lstFiles.SelectedIndex;
            if (index <= 0)
            {
                return;
            }

            SwapFiles(index, index - 1);
            lstFiles.SelectedIndex = index - 1;

            if (chkSameFolder.Checked)
            {
                UpdateOutputPathToSameFolder();
            }
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            int index = lstFiles.SelectedIndex;
            if (index < 0 || index >= _files.Count - 1)
            {
                return;
            }

            SwapFiles(index, index + 1);
            lstFiles.SelectedIndex = index + 1;

            if (chkSameFolder.Checked)
            {
                UpdateOutputPathToSameFolder();
            }
        }

        private void SwapFiles(int indexA, int indexB)
        {
            (_files[indexA], _files[indexB]) = (_files[indexB], _files[indexA]);

            object itemA = lstFiles.Items[indexA];
            lstFiles.Items[indexA] = lstFiles.Items[indexB];
            lstFiles.Items[indexB] = itemA;
        }

        private void btnClearList_Click(object sender, EventArgs e)
        {
            _files.Clear();
            lstFiles.Items.Clear();

            if (chkSameFolder.Checked)
            {
                UpdateOutputPathToSameFolder();
            }
        }

        private void btnSelectMergeOutput_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.FileName = "merged.pdf";
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtMergeOutput.Text = saveFileDialog.FileName;
                }
            }
        }

        private void btnMerge_Click(object sender, EventArgs e)
        {
            if (_files.Count < 2)
            {
                MessageBox.Show("請至少加入兩個 PDF 檔案", "警告",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtMergeOutput.Text))
            {
                MessageBox.Show("請選擇輸出位置", "警告",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                MergePdfFiles(_files, txtMergeOutput.Text);
                MessageBox.Show("PDF 合併完成！", "成功",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"合併 PDF 時發生錯誤: {ex.Message}", "錯誤",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MergePdfFiles(List<string> inputPaths, string outputPath)
        {
            using (Document document = new Document())
            using (PdfCopy copy = new PdfCopy(document, new FileStream(outputPath, FileMode.Create)))
            {
                document.Open();

                foreach (string inputPath in inputPaths)
                {
                    using (PdfReader reader = new PdfReader(inputPath))
                    {
                        int pageCount = reader.NumberOfPages;
                        for (int i = 1; i <= pageCount; i++)
                        {
                            copy.AddPage(copy.GetImportedPage(reader, i));
                        }
                    }
                }
            }
        }

        private void btnCloseMerge_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
