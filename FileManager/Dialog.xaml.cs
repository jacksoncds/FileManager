using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FileManager
{
    /// <summary>
    /// Interaction logic for Dialog.xaml
    /// </summary>
    public partial class Dialog : Window
    {
        public event EventHandler OnResult;

        private DialogButtonType result;

        public object Message
        {
            get { return (object)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Message.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(object), typeof(Dialog), new PropertyMetadata(0));

        public Dialog()
        {
            InitializeComponent();
        }

        public Dialog(Window owner)
        {
            InitializeComponent();

            this.Owner = owner;
        }

        public DialogButtonType RenderDialog()
        {
            this.ShowDialog();

            return this.result;
        }

        private void OnNoClick(object sender, RoutedEventArgs e)
        {
            this.result = DialogButtonType.No;
            this.Close();
        }

        private void OnYesClick(object sender, RoutedEventArgs e)
        {
            this.result = DialogButtonType.Yes;
            this.Close();
        }
    }
}
