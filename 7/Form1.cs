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

namespace _7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<string> level = new List<string>() { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        string[] shapes = new string[]
        {
            Encoding.UTF8.GetString(new byte[]{ 226, 153, 160 }),
            Encoding.UTF8.GetString(new byte[]{ 226, 153, 165 }),
            Encoding.UTF8.GetString(new byte[]{ 226, 153, 166 }),
            Encoding.UTF8.GetString(new byte[]{ 226, 153, 163 })
        };
        private void Form1_Load(object sender, EventArgs e)
        {
            string[] lines = File.ReadAllLines("C:/SMS/1060307.SM");
            double[] values = lines.Skip(1).Select(double.Parse).ToArray();
            List<string> exists = new List<string>();

            int index = 0;
            for(int i = 0; i < int.Parse(lines[0]); i++)
            {
                string[] cards = new string[2];
                for(int j = 0; j < 2; j++)
                {
                    string card = $"{shapes[(int)(values[index] * 52 / 13)]}" +
                        $"{((int)(values[index] * 52 % 13 + 1) == 1 ? "A" : level[(int)(values[index] * 52 % 13 - 1)])}";
                    index++;
                    if (exists.Contains(card))
                    {
                        j--;
                        continue;
                    }
                    exists.Add(card);
                    cards[j] = card;
                }
                dataGridView1.Rows.Add(0, cards[0], cards[1],
                    level.IndexOf(string.Join("", cards[0].Skip(1))) > level.IndexOf(string.Join("", cards[1].Skip(1))) ? "玩家贏" :
                    level.IndexOf(string.Join("", cards[0].Skip(1))) < level.IndexOf(string.Join("", cards[1].Skip(1))) ? "莊家贏" : "平手"
                );
            }
            for (int i = 0; i < dataGridView1.Rows.Count; i++) dataGridView1.Rows[i].Cells[0].Value = $"{i + 1}";
        }
    }
}
