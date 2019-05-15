using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP_coursework.utils;

namespace TP_coursework
{
    public partial class MainForm : Form
    {
        // Поля показывают правильность заполнения полей ФИО
        private bool reqFieldsIsValid = false;
        private bool nreqFieldsIsValid = false;

        public MainForm()
        {
            InitializeComponent();
            // Привязываем события полей ввода ФИО к одному методу
            maskedFieldLastName.MaskedTextBoxLeave += MaskedField_MaskedTextBoxLeave;
            maskedFieldName.MaskedTextBoxLeave += MaskedField_MaskedTextBoxLeave;
            maskedFieldMidName.MaskedTextBoxLeave += MaskedField_MaskedTextBoxLeave_nreq;
        }

        // Метод проверяет поля ввода данных на пустоту строк
        private bool fieldsIsEmpty()
        {
            if (string.IsNullOrEmpty(maskedFieldLastName.Text) |
                string.IsNullOrEmpty(maskedFieldName.Text) |
                string.IsNullOrEmpty(maskedFieldUniversity.Text) |
                !maskedFieldPhone.MaskCompleted)
                return true;
            else
                return false;
        }

        // Метод проверяет строку, принятый в аргумент метода, на то что в 
        // строке должны только встречаться латинские и русские символы
        private bool isValidField(String text)
        {
            return
                (!System.Text.RegularExpressions.Regex.IsMatch(text, @"^[A-Za-zА-Яа-я]+$")) 
                ? false : true;
        }

        // Метод к которому привязаны события обязательных полей ввода данных
        private void MaskedField_MaskedTextBoxLeave(object sender, EventArgs e)
        {
            if (!(sender is MaskedField)) return;

            MaskedField field = sender as MaskedField;
            reqFieldsIsValid = isValidField(field.Text);
        }

        // Метод к которому привязаны события необязательных полей ввода данных
        private void MaskedField_MaskedTextBoxLeave_nreq(object sender, EventArgs e)
        {
            if (!(sender is MaskedField)) return;

            MaskedField field = sender as MaskedField;
            if (!string.IsNullOrEmpty(field.Text))
                nreqFieldsIsValid = isValidField(field.Text);
            else
                nreqFieldsIsValid = true;
        }

        // Данные студента которые потом сохраним в файл
        public void setStudentInfo()
        {
            DataLayer.studentInfoToSave = maskedFieldLastName.Text + ';' + maskedFieldName.Text + ';' +
                maskedFieldMidName.Text + ';' + maskedFieldPhone.Text + ';' + maskedFieldUniversity.Text + ';';
        }

        /** События **/
        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonNext_Click(object sender, EventArgs e)
        {
            if (!fieldsIsEmpty() & reqFieldsIsValid)
            {
                setStudentInfo();
                this.Hide();
                Program.form1.FormClosed += (s, args) => this.Close();
                Program.form1.Show();
            } else
            {
                MessageBox.Show("Заполните все поля. Также в полях ФИО не может быть чисел.");
            }
        }
    }
}
