using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string original = File.ReadAllText("C:/SMS/1060301.SM"), reverse = "";
            for (int i = original.Length - 1; i >= 0; i--) reverse += original[i];
            textBox1.Text = $"第一題答案：{original} is {(original == reverse ? "" : "not ")}a palindrome.";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int num = int.Parse(File.ReadAllText("C:/SMS/1060302.SM"));
            textBox2.Text = "第二題答案：\r\n";
            for(int i = 1; i <= num; i++)
            {
                for (int j = 1; j <= i; j++) textBox2.Text += $"{j}";
                textBox2.Text += "\r\n";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int num = int.Parse(File.ReadAllText("C:/SMS/1060303.SM"));
            bool isPrime = true;
            for (int i = 2; i < num / 2 && isPrime; i++) if (num % i == 0) isPrime = false;
            textBox3.Text = $"第三題答案：{num} is {(isPrime ? "" : "not ")}a prime number.";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string[] lines = File.ReadAllLines("C:/SMS/1060304.SM");
            int minBMI = 999999999;
            for(int i = 0; i < 3; i++)
            {
                double height = double.Parse(lines[i].Split(',')[0]) / 100.0;
                double weight = double.Parse(lines[i].Split(',')[1]);
                int bmi = (int)(weight / (height * height) + .5);
                if (bmi < minBMI) minBMI = bmi;
            }
            textBox4.Text = $"第四題答案：最小 BMI 值={minBMI}，{((minBMI <= 25 && minBMI >= 20) ? "" : "不")}正常";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string[] lines = File.ReadAllLines("C:/SMS/1060305.SM");
            for(int i = 0; i < 2; i++)
            {
                textBox5.Text += "[";
                for(int j = 0; j < 2; j++) textBox5.Text += 
                        $"{int.Parse(lines[i].Split(',')[j]) + int.Parse(lines[i + 2].Split(',')[j])}" +
                        (j == 0 ? "\t" : "");
                textBox5.Text += "]\r\n";
            }
        }
    }
}
