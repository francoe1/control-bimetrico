using DPFP;
using DPFP.Capture;

namespace Fingerprint
{
    public class FingerScanner : DPFP.Capture.EventHandler
    {
        public void OnComplete(object Capture, string ReaderSerialNumber, Sample Sample)
        {

        }

        public void OnFingerGone(object Capture, string ReaderSerialNumber)
        {
        }

        public void OnFingerTouch(object Capture, string ReaderSerialNumber)
        {
        }

        public void OnReaderConnect(object Capture, string ReaderSerialNumber)
        {
        }

        public void OnReaderDisconnect(object Capture, string ReaderSerialNumber)
        {
        }

        public void OnSampleQuality(object Capture, string ReaderSerialNumber, CaptureFeedback CaptureFeedback)
        {
        }
    }
}