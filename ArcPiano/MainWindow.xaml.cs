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
        /// Play a musical note from the WPF piano
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void PlayNote(object sender, EventArgs e) {
            // Locate piano key button
            Button key = sender as Button;
            string name = "";

            // Get name of the note
            if (key.Name.ToLower().Length == 5)
                name = key.Name.ToLower()[0].ToString();
            else {
                name = key.Name.ToLower()[0].ToString() + "#-";
                name += name = key.Name.ToLower()[1].ToString() + "b";
            }

            // Play the note
            using (var ms = File.OpenRead("C:\\Users\\alore\\Documents\\Toychest\\C#\\ArcPiano\\ArcPiano\\notes\\" + name + ".mp3"))
            using (var rdr = new Mp3FileReader(ms))
            using (var wavStream = WaveFormatConversionStream.CreatePcmStream(rdr))
            using (var baStream = new BlockAlignReductionStream(wavStream))
            using (var waveOut = new WaveOut(WaveCallbackInfo.FunctionCallback())) {
                waveOut.Init(baStream);
                waveOut.Play();
                while (waveOut.PlaybackState == PlaybackState.Playing) {
                    await Task.Delay(100);
                }
            }
        }
    }
}