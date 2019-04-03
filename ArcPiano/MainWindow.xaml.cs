using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ArcPiano {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        /// <summary>
        /// Play a musical note from the WPF piano
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void PlayNote(object sender, EventArgs e) {
            // ...
            Button key = sender as Button;
            string name = key.Name;

        }
    }
}
