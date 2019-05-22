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
    /*
        TextField - используем в качестве наименования поля ввода
        MaskedTextBox - используем в качестве поле ввода
         */
    public partial class MaskedField : UserControl, INotifyPropertyChanged, IColorable
    {
        /** Свойства для работы с TextBox **/
        private string textFieldName;
        private Color backColorFieldName;
        private Color foreColor;
        private Color rootBackColor;

        // Цвет элемента управления - поле наименования
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

        // Цвет текста в поле наименования
        [Browsable(true),
            Category("Данные"),
            DefaultValue(typeof(Color), "White"),
            Description("Set default text color of TextBox")]
        public Color TextColor
        {
            get { return foreColor; }
            set
            {
                foreColor = value;
                OnPropertyChanged();
            }
        }

        // Цвет родительского элемента на которой находится поля
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

        // Текст в поле наименования
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
        // Маска поле ввода
        [Browsable(true),
            Category("Данные"),
            Description("Set mask of maskedTextBox")]
        public string InputMaskFormat
        {
            get { return maskedTextBox.Mask; }
            set { maskedTextBox.Mask = value; }
        }

        // Введённый текст в поле ввода
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
        public event EventHandler MaskedTextBoxValidating;

        /** Конструкторы **/
        // Конструктор по-умолчанию
        public MaskedField()
        {
            InitializeComponent();
            // Используем его как наименования поля ввода
            fieldName.ReadOnly = true;
            // Устанавливаем стандартный цвет эл. textBox.backColor
            fieldName.ForeColor = this.foreColor;
            fieldName.BackColor = this.backColorFieldName;
            this.BackColor = this.rootBackColor;
            // Устанавливаем стандартный текст textBox
            fieldName.Text = this.textFieldName;
        }

        // this() - вызывает конструктор без параметров
        public MaskedField(string fieldNameValue) : this()
        {
            this.textFieldName = fieldNameValue;
        }

        public MaskedField(Color foreColor, Color backColor) : this()
        {
            backColorFieldName = backColor;
            this.foreColor = foreColor;
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

        /* Задание названия поля элемента textBox */
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
                    setFieldNameForeColor(TextColor);
                    break;
                case "BackColorFieldName":
                    setFieldNameBackColor(BackColorFieldName);
                    break;
                case "RootBackColor":
                    setBackColor(RootBackColor);
                    break;
            }
        }


        /** Методы связанные с maskedTextBox. Геттеры и сеттеры **/
        // Метод связанный с событием Leave
        private void maskedTextBox_Leave(object sender, EventArgs e)
        {
            if (this.MaskedTextBoxLeave != null)
                this.MaskedTextBoxLeave(this, e);
        }

        private void maskedTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (this.MaskedTextBoxValidating != null)
                this.MaskedTextBoxValidating(this, e);
        }

        public void setBackColorAll(Color BackColor, 
                                    Color BackColorTextField, 
                                    Color BackColorMaskedTextField
            )
        {
            this.BackColor = BackColor;
            this.fieldName.BackColor = BackColorTextField;
            this.maskedTextBox.BackColor = BackColorMaskedTextField;
        }

        public void setErrorColor(Color BackColorMaskedFieldIfError,
                                  Color ForeColorMaskedFieldIfError,
                                  Color BackColorMaskedFieldDefault,
                                  Color ForeColorMaskedFieldDefault,
                                  Func<bool> exp)
        {
            if (exp())
            {
                this.maskedTextBox.BackColor = BackColorMaskedFieldIfError;
                this.maskedTextBox.ForeColor = ForeColorMaskedFieldIfError;
            }
            else
            {
                this.maskedTextBox.BackColor = BackColorMaskedFieldDefault;
                this.maskedTextBox.ForeColor = ForeColorMaskedFieldDefault;
            }
        }

        // Устанавливает цвет фона для родительского элемента
        public void setBackColor(Color BackColor)
        {
            this.BackColor = BackColor;
        }

        // Получает цвет фона для родительского элемента
        public Color getBackColor()
        {
            return this.BackColor;
        }

        // Устанавливает цвет текста для поле ввода
        public void setForeColor(Color ForeColor)
        {
            this.maskedTextBox.ForeColor = ForeColor;
        }

        // Получает цвет текста для поле ввода
        public Color getForeColor()
        {
            return this.maskedTextBox.ForeColor;
        }

        // Устанавливает шрифт текста для поле ввода
        public void setFont(Font font)
        {
            this.maskedTextBox.Font = font;
        }

        // Получает шрифт текста для поле ввода
        public Font getFont()
        {
            return this.maskedTextBox.Font;
        }
    }
}
