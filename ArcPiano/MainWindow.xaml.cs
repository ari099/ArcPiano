using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
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
using ArcPiano.custom_objects;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace ArcPiano {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        public MainWindow() {
            InitializeComponent();
        }

        /// <summary>
        /// Piano key event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void NoteEventHandler(object sender, EventArgs e) {
            // Getting the piano key
            Button key = sender as Button;
            string name = "";

            // Get name of the note
            if (key.Name.ToLower().Length == 5)
                name = key.Name.ToLower()[0].ToString();
            else {
                name = key.Name.ToLower()[0].ToString() + "#-";
                name += name = key.Name.ToLower()[1].ToString() + "b";
            }

            // Play piano note
            Piano.PlayNote(name);
        }
    }
}