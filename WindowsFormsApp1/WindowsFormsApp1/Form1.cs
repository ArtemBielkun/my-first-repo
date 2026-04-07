using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Перевірка, чи коректно введені дані (чи є вони числами)
            if (double.TryParse(textBox1.Text, out double radius) &&
                double.TryParse(textBox2.Text, out double angle))
            {
                // Перевірка на від'ємні значення
                if (radius < 0 || angle < 0)
                {
                    MessageBox.Show("Радіус та кут не можуть бути від'ємними числами.",
                                    "Помилка вводу",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                // Перевірка на логічність кута (не більше 360 градусів)
                if (angle > 360)
                {
                    MessageBox.Show("Центральний кут не може перевищувати 360 градусів.",
                                    "Увага",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    return;
                }

                // Обчислення за формулою L = (PI * R * alpha) / 180
                double length = (Math.PI * radius * angle) / 180.0;

                // Виведення результату з округленням до 4 знаків після коми
                label4.Text = $"Результат: довжина дуги = {Math.Round(length, 4)}";
            }
            else
            {
                // Повідомлення, якщо користувач ввів літери або залишив поля порожніми
                MessageBox.Show("Будь ласка, введіть коректні числові значення.",
                                "Помилка формату",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    }
}