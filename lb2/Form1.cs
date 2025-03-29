using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Drawing;

namespace lb2
{
    public partial class Form1 : Form
    {
        private string filePath = "";
        private byte[] fileBytes;
        private string keystream = "";
        private byte[] processedData;

        private const int LFSR_SIZE = 27;
        private const int DISPLAY_BITS = LFSR_SIZE * 2;

        public Form1()
        {
            InitializeComponent();
            FirstKey.TextChanged += FirstKey_TextChanged;

            EncOrDec.DropDownStyle = ComboBoxStyle.DropDownList;
            if (EncOrDec.Items.Count > 0)
            {
                EncOrDec.SelectedIndex = 0;
            }

            FirstKey.MaxLength = LFSR_SIZE;
            FirstKey.KeyPress += ValidateBinaryInput;
            FirstKey.TextChanged += ValidateKeyLength;
        }

        private void ValidateBinaryInput(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '0' && e.KeyChar != '1' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void ValidateKeyLength(object sender, EventArgs e)
        {
            FirstKey.BackColor = FirstKey.Text.Length != LFSR_SIZE ? Color.LightPink : SystemColors.Window;
        }

        private async void LookUpFiles_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Выберите файл";
                openFileDialog.Filter = "Все файлы (*.*)|*.*";
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    SelectedFile.Text = Path.GetFileName(filePath);

                    await Task.Run(() =>
                    {
                        fileBytes = File.ReadAllBytes(filePath);
                    });

                    string fileBits = GetLimitedBitsDisplay(fileBytes);
                    await UpdateTextBoxAsync(FirstFile, fileBits);
                }
            }
        }

        private async Task UpdateTextBoxAsync(TextBox textBox, string content)
        {
            if (textBox.InvokeRequired)
            {
                textBox.Invoke(new Action(() => textBox.Text = content));
            }
            else
            {
                textBox.Text = content;
            }
            await Task.Delay(10); 
        }

        private string GetLimitedBitsDisplay(byte[] data)
        {
            if (data == null || data.Length == 0)
                return "Файл пуст";

            var bits = new StringBuilder();
            int totalBits = data.Length * 8;
            int displayBits = Math.Min(DISPLAY_BITS * 2, totalBits); 

            bits.Append(GetBitsRange(data, 0, displayBits));

            if (totalBits > displayBits * 2)
            {
                bits.Append("\n...\n");
                bits.Append(GetBitsRange(data, totalBits - displayBits, displayBits));
            }
            return bits.ToString();
        }

        private string GetBitsRange(byte[] data, int startBit, int count)
        {
            var result = new StringBuilder();
            int endBit = Math.Min(startBit + count, data.Length * 8);

            for (int i = startBit; i < endBit; i++)
            {
                int bytePos = i / 8;
                int bitPos = i % 8;
                int bit = (data[bytePos] >> (7 - bitPos)) & 1;
                result.Append(bit);
            }

            return result.ToString();
        }

        private async void ExecuteButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("Сначала выберите файл.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (FirstKey.Text.Length != LFSR_SIZE)
            {
                MessageBox.Show($"Сеансовый ключ должен быть {LFSR_SIZE} бит.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            await Task.Run(() =>
            {
                fileBytes = File.ReadAllBytes(filePath);
                int fileBitsLength = fileBytes.Length * 8;
                keystream = GenerateLFSRKeystream(FirstKey.Text, fileBitsLength);
                processedData = XorData(fileBytes, keystream);
            });

            string limitedKeystream = GetLimitedKeyDisplay(keystream, fileBytes.Length * 8);
            await UpdateTextBoxAsync(SecondKey, limitedKeystream);

            string resultBits = GetLimitedBitsDisplay(processedData);
            await UpdateTextBoxAsync(SecondFile, resultBits);

            MessageBox.Show(
                $"Файл {(EncOrDec.SelectedIndex == 0 ? "зашифрован" : "расшифрован")}.\n" +
                "Теперь вы можете сохранить результат.",
                "Готово",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private string GetLimitedKeyDisplay(string fullKey, int usedBits)
        {
            if (string.IsNullOrEmpty(fullKey))
                return "Ключ не сгенерирован";

            var display = new StringBuilder();
            int displayBits = Math.Min(DISPLAY_BITS * 2, usedBits);

            display.Append(GetBitsRange(fullKey, 0, displayBits));

            if (usedBits > displayBits * 2)
            {
                display.Append("\n...\n");
                display.Append(GetBitsRange(fullKey, usedBits - displayBits, displayBits));
            }

            return display.ToString();
        }

        private string GetBitsRange(string bitString, int startBit, int count)
        {
            if (string.IsNullOrEmpty(bitString) || startBit >= bitString.Length)
                return string.Empty;

            int endBit = Math.Min(startBit + count, bitString.Length);
            return bitString.Substring(startBit, endBit - startBit);
        }

        private string GenerateLFSRKeystream(string initialState, int length)
        {
            var lfsr = new StringBuilder(initialState);
            var key = new StringBuilder();

            int[] taps = { 0, 19, 20, 26 };

            for (int i = 0; i < length; i++)
            {
                key.Append(lfsr[0]);

                char newBit = '0';
                foreach (int tap in taps)
                {
                    if (lfsr[tap] == '1')
                        newBit = (newBit == '0') ? '1' : '0';
                }

                lfsr.Remove(0, 1);
                lfsr.Append(newBit);
            }

            return key.ToString();
        }

        private byte[] XorData(byte[] data, string keystream)
        {
            byte[] result = new byte[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    int keyBitPos = i * 8 + j;
                    if (keyBitPos >= keystream.Length) break;

                    int dataBit = (data[i] >> (7 - j)) & 1;
                    int keyBit = keystream[keyBitPos] - '0';
                    int encryptedBit = dataBit ^ keyBit;

                    result[i] |= (byte)(encryptedBit << (7 - j));
                }
            }
            return result;
        }

        private void SaveResult_Click(object sender, EventArgs e)
        {
            if (processedData == null)
            {
                MessageBox.Show("Сначала выполните операцию.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Title = "Выберете место";
                saveDialog.Filter = "Все файлы (*.*)|*.*";
                saveDialog.FileName = GetResultFileName();

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllBytes(saveDialog.FileName, processedData);
                    MessageBox.Show("Файл сохранён.", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private string GetResultFileName()
        {
            string originalName = Path.GetFileNameWithoutExtension(filePath);
            string extension = Path.GetExtension(filePath);
            string operation = EncOrDec.SelectedIndex == 0 ? "_enc" : "_dec";
            return $"{originalName}{operation}{extension}";
        }

        private void CleanAll_Click(object sender, EventArgs e)
        {
            FirstFile.Text = string.Empty;
            SecondFile.Text = string.Empty;
            FirstKey.Text = string.Empty;
            SecondKey.Text = string.Empty;
            SelectedFile.Text = string.Empty;

            EncOrDec.SelectedIndex = 0;

            filePath = string.Empty;
            fileBytes = null;
            keystream = string.Empty;
            processedData = null;

            FirstKey.BackColor = SystemColors.Window;

            FirstKey.Focus();
        }

        private void Count_Click(object sender, EventArgs e)
        {
            int totalSymbols = FirstKey.Text.Length;
            Count.Text = $"Введено символов: {totalSymbols}";
        }

        private void FirstKey_TextChanged(object sender, EventArgs e)
        {
            Count.Text = FirstKey.Text.Length.ToString();
        }
    }
}