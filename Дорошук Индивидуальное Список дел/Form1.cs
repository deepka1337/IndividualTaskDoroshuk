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

namespace Дорошук_Индивидуальное_Список_дел
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label6.Text = DateTime.Now.ToString("yyyy.MM.dd"); // Текущая дата 
        }



        private void button1_Click(object sender, EventArgs e) //Добавление нового пункта с проверкой на отстутсвие символов
        {
            if (textBox1.Text != "")
            {
                listBox1.Items.Add(textBox1.Text);
                textBox1.Clear();
            }
        }

        private void button3_Click(object sender, EventArgs e) // Программирование кнопки на перемещение одного элемента
        {

            MoveSelectedItems(listBox1, listBox2);
        }

        private void button2_Click(object sender, EventArgs e) // Программирование кнопки на очистку элементов
        {
            listBox3.Items.Clear();
        }

        private void button4_Click(object sender, EventArgs e) // Программирование кнопки на перемещение одного элемента
        {
            MoveSelectedItems(listBox2, listBox3);
        }

        private void MoveSelectedItems(ListBox lstFrom, ListBox lstTo) // процедура перемещения выбранного элемента из одной табличной части в другую
        {
            while (lstFrom.SelectedItems.Count > 0)
            {
                string item = (string)lstFrom.SelectedItems[0];
                lstTo.Items.Add(item);
                lstFrom.Items.Remove(item);
            }
        }

        private void MoveAllItems(ListBox lstFrom, ListBox lstTo) // процедура перемещения всех элементов из одной табличной части в другую
        {
            {
                lstTo.Items.AddRange(lstFrom.Items);
                lstFrom.Items.Clear();

            }
        }

        private void button5_Click(object sender, EventArgs e) // Программирование кнопки на перемещение всех элементов
        {
            MoveAllItems(listBox1, listBox2);
        }

        private void button6_Click(object sender, EventArgs e)// Программирование кнопки на перемещение всех элементов
        {
            MoveAllItems(listBox2, listBox3);
        }

        private void button7_Click(object sender, EventArgs e) // Программирование кнопки перемещение одного элемента
        {
            MoveSelectedItems(listBox3, listBox2);
        }

        private void button8_Click(object sender, EventArgs e) // Программирование кнопки на перемещение всех элементов
        {
            MoveAllItems(listBox3, listBox2);
        }

        private void button9_Click(object sender, EventArgs e) // Программирование кнопки на перемещение одного элемента
        {
            MoveSelectedItems(listBox2, listBox1);
        }

        private void button10_Click(object sender, EventArgs e) // Программирование кнопки на перемещение всех элементов
        {
            MoveAllItems(listBox2, listBox1);
        }

        //Cохранение данных в файл
        private void button11_Click(object sender, EventArgs e) // Процедура на выгрузку данных
        {

            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Text documents (.txt)|*.txt";

            if (save.ShowDialog() == DialogResult.OK)
            {
                StreamWriter w = new StreamWriter(save.FileName);

                foreach (var item in listBox1.Items)
                    w.WriteLine(item.ToString());
                foreach (var item in listBox2.Items)
                    w.WriteLine(item.ToString());
                foreach (var item in listBox3.Items)
                    w.WriteLine(item.ToString());

                w.Close();
            }

        }

        private void button12_Click(object sender, EventArgs e) // Процедура на загруку данных
        {
            using (OpenFileDialog List = new OpenFileDialog())
            {
                List.Filter = "Текстовые файлы|*.txt";
                if (List.ShowDialog() == DialogResult.OK)
                {
                    listBox1.Items.AddRange(File.ReadAllLines(List.FileName));
                }
            }
        }
    }
}








