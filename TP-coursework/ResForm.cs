using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP_coursework.utils;

namespace TP_coursework
{
    public partial class ResForm : Form
    {
        public ResForm()
        {
            InitializeComponent();
        }

        private void ResForm_Load(object sender, EventArgs e)
        {
            float res = 0;
            string data = DataLayer.studentInfoToSave.Split(';')[5];
            this.ResLabel.Text = "Ваш ВУЗ: " + data;

            var list = DataLayer.loadFromFileQuiz(data);
            foreach(var i in list)
            {
                res += int.Parse(i);
            }
            res /= list.Count;
            this.r1.Text = res.ToString();
        }

        private void ButtonEnd_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
