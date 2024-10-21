using System;
using System.Linq;
using System.Windows;

namespace HammingDistanceApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // обработчик нажатия кнопки "Calculate"
        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            string bin1 = BinaryInput1.Text.Trim();
            string bin2 = BinaryInput2.Text.Trim();

            // проверка, что введены только двоичные символы
            if (!IsValidBinary(bin1) || !IsValidBinary(bin2))
            {
                MessageBox.Show("Please enter valid binary strings (only 0 and 1).", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // проверка, что длины строк одинаковы
            if (bin1.Length != bin2.Length)
            {
                MessageBox.Show("Binary strings must be of equal length.", "Length Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // вычисляется кодовое расстояние
            int distance = CalculateHammingDistance(bin1, bin2);
            ResultLabel.Content = $"Hamming Distance: {distance}";
        }

        // функция для проверки, что строка содержит только 0 и 1
        private bool IsValidBinary(string input)
        {
            return input.All(c => c == '0' || c == '1');
        }

        // функция для вычисления расстояния Хэмминга
        private int CalculateHammingDistance(string bin1, string bin2)
        {
            return bin1.Zip(bin2, (c1, c2) => c1 == c2 ? 0 : 1).Sum();
        }
    }
}
