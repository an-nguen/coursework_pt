using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.CompilerServices;

namespace TP_coursework
{
    public partial class MaskedField : UserControl, INotifyPropertyChanged, IColorable
    {
        /** Поля для работы с TextBox **/
        private string textFieldName;
        private Color backColorFieldName;
        private Color foreColorFieldName;
        private Color rootBackColor;

        [Browsable(true), 
            Category("Данные"),
            DefaultValue(typeof(Color), "Gray"),
            Description("Set default background color of TextBox")]
        public Color BackColorFieldName
        {
            get { return backColorFieldName; }
            set
            {
                backColorFieldName = value;
                OnPropertyChanged();
            }
        }

        [Browsable(true),
            Category("Данные"),
            DefaultValue(typeof(Color), "White"),
            Description("Set default text color of TextBox")]
        public Color ForeColorFieldName
        {
            get { return foreColorFieldName; }
            set
            {
                foreColorFieldName = value;
                OnPropertyChanged();
            }
        }

        [Browsable(true),
    Category("Данные"),
    DefaultValue(typeof(Color), "White"),
    Description("Set default text color of TextBox")]
        public Color RootBackColor
        {
            get { return rootBackColor; }
            set
            {
                rootBackColor = value;
                OnPropertyChanged();
            }
        }

        [Browsable(true),
            Category("Данные"),
            DefaultValue("default text"),
            Description("Set default value of TextBox")]
        public string TextFieldName {
            get { return textFieldName; }
            set { textFieldName = value;
                  OnPropertyChanged();
                }
        }

        /** Поля для работы с MaskedTextBox **/
        [Browsable(true),
            Category("Данные"),
            Description("Set mask of maskedTextBox")]
        public string InputMaskFormat
        {
            get { return maskedTextBox.Mask; }
            set { maskedTextBox.Mask = value; }
        }

        [Browsable(false)]
        public override string Text
        {
            get { return maskedTextBox.Text; }
            set { maskedTextBox.Text = value; }
        }

        [Browsable(true),            
            Category("Данные"),
            Description("Set AsciiOnly for maskedTextBox")]
        public bool AsciiOnly
        {
            get { return maskedTextBox.AsciiOnly; }
            set { maskedTextBox.AsciiOnly = value; }
        }
        public bool MaskCompleted { get { return maskedTextBox.MaskCompleted; } }

        public event EventHandler MaskedTextBoxLeave;

        /** Конструкторы **/
        public MaskedField()
        {
            InitializeComponent();
            // Используем его как наименования поля ввода
            fieldName.ReadOnly = true;
            // Устанавливаем стандартный цвет эл. textBox.backColor
            fieldName.ForeColor = this.foreColorFieldName;
            fieldName.BackColor = this.backColorFieldName;
            this.BackColor = this.rootBackColor;
            // Устанавливаем стандартный текст textBox
            fieldName.Text = this.textFieldName;
        }

        public MaskedField(string fieldNameValue) : this()
        {
            this.textFieldName = fieldNameValue;
        }

        public MaskedField(Color foreColor, Color backColor) : this()
        {
            backColorFieldName = backColor;
            foreColorFieldName = foreColor;
        }

        /** Операции с элементом textBox **/
        /* Задание цвета поля элемента textBox */
        public void setFieldNameBackColor(Color backColor)
        {
            fieldName.BackColor = backColor;
        }
        public void setFieldNameForeColor(Color foreColor)
        {
            fieldName.ForeColor = foreColor;
        }

        /* Задаём название поля элемента textBox */
        public void setFieldNameText(string name)
        {
            fieldName.Text = name;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            switch (propertyName)
            {
                case "TextFieldName":
                    setFieldNameText(TextFieldName);
                    break;
                case "ForeColorFieldName":
                    setFieldNameForeColor(ForeColorFieldName);
                    break;
                case "BackColorFieldName":
                    setFieldNameBackColor(BackColorFieldName);
                    break;
                case "RootBackColor":
                    setBackColor(RootBackColor);
                    break;
            }
        }


        /** Методы связанные с maskedTextBox **/
        private void maskedTextBox_Leave(object sender, EventArgs e)
        {
            if (this.MaskedTextBoxLeave != null)
                this.MaskedTextBoxLeave(this, e);
        }

        public void setBackColor(Color BackColor)
        {
            this.BackColor = BackColor;
        }

        public Color getBackColor()
        {
            return this.BackColor;
        }

        public void setForeColor(Color ForeColor)
        {
            throw new NotImplementedException();
        }

        public Color getForeColor()
        {
            throw new NotImplementedException();
        }

        public void setFont(Font font)
        {
            throw new NotImplementedException();
        }

        public Font getFont()
        {
            throw new NotImplementedException();
        }
    }
}
