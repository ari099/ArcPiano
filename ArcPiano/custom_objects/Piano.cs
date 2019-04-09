using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace ArcPiano.custom_objects {
    public static class Piano {
        /// <summary>
        /// Play a musical note from the WPF piano
        /// </summary>
        /// <param name="note"></param>
        public static async void PlayNote(string note) {
            // Play the note
            using (var ms = File.OpenRead("C:\\Users\\alore\\Documents\\Toychest\\C#\\ArcPiano\\ArcPiano\\notes\\" + note + ".mp3"))
            using (var rdr = new Mp3FileReader(ms))
            using (var wavStream = WaveFormatConversionStream.CreatePcmStream(rdr))
            using (var baStream = new BlockAlignReductionStream(wavStream))
            using (var waveOut = new WaveOut(WaveCallbackInfo.FunctionCallback())) {
                waveOut.Init(baStream);
                waveOut.Play();
                while (waveOut.PlaybackState == PlaybackState.Playing)
                    await Task.Delay(100);
            }
        }
    }
}
