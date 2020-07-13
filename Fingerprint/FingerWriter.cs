using DPFP;
using DPFP.Capture;
using DPFP.Processing;
using System;
using System.Drawing;
using System.IO;

namespace Fingerprint
{
    public class FingerWriter : DPFP.Capture.EventHandler
    {
        public static event Action<CaptureFeedback> ReaderStatusCaptureEvent;
        private delegate void _delegateDefault();

        public delegate void SuccessDelegate(byte[] data);

        public delegate void StepDelegate(int step);

        private static SampleConversion m_converter { get; set; } = new SampleConversion();

        private static FeatureExtraction m_extractor { get; set; } = new FeatureExtraction();

        private Bitmap m_captureImage;
        private bool m_success { get; set; }

        private static Capture _capture
        {
            get;
            set;
        }

        private static Enrollment _enrollment
        {
            get;
            set;
        }

        public Bitmap CaptureImage
        {
            get
            {
                return m_captureImage;
            }
        }

        public bool IsRuning
        {
            get;
            private set;
        }

        public event SuccessDelegate OnSuccessEvent;

        public event StepDelegate OnStepEvent;

        public FingerWriter()
        {
            _enrollment = new Enrollment();
            m_captureImage = new Bitmap(512, 512);
        }

        public bool StartCapture()
        {
            if (IsRuning)
            {
                return false;
            }
            try
            {
                _capture = new Capture
                {
                    EventHandler = this
                };
                _capture.StartCapture();
                IsRuning = true;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool StopCapture()
        {
            _enrollment.Clear();
            if (!IsRuning)
            {
                return false;
            }
            try
            {
                _capture.StopCapture();
                _capture.Dispose();
                IsRuning = false;
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                _capture = null;
            }
        }

        public bool ReseteCapture()
        {
            try
            {
                StopCapture();
                StartCapture();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void InvokeSafe(Action method)
        {
            _delegateDefault method2 = method.Invoke;
            Invoke(method2);
        }

        private void Invoke(Delegate method)
        {
            method.DynamicInvoke();
        }

        void DPFP.Capture.EventHandler.OnComplete(object Capture, string ReaderSerialNumber, Sample Sample)
        {
            m_success = true;
            Audio.PlayClip(2);
            if (IsRuning)
            {
                m_converter.ConvertToPicture(Sample, ref m_captureImage);
                if (GetFeature(Sample, out FeatureSet feature))
                {
                    _enrollment.AddFeatures(feature);
                }
                if (_enrollment.TemplateStatus == Enrollment.Status.Ready)
                {
                    InvokeSafe(delegate
                    {
                        using (MemoryStream memoryStream = new MemoryStream(_enrollment.Template.Bytes))
                        {
                            this.OnSuccessEvent(memoryStream.ToArray());
                        }
                    });
                }
                else if (_enrollment.TemplateStatus == Enrollment.Status.Failed)
                {
                    _enrollment.Clear();
                    ReseteCapture();
                }
                else
                {
                    InvokeSafe(delegate
                    {
                        this.OnStepEvent((int)_enrollment.FeaturesNeeded);
                    });
                }
            }
        }

        void DPFP.Capture.EventHandler.OnFingerGone(object Capture, string ReaderSerialNumber)
        {
            if (!m_success) Audio.PlayClip(1);
            m_success = false;
        }

        void DPFP.Capture.EventHandler.OnFingerTouch(object Capture, string ReaderSerialNumber)
        {
            Audio.PlayClip(0);
        }

        void DPFP.Capture.EventHandler.OnReaderConnect(object Capture, string ReaderSerialNumber)
        {
        }

        void DPFP.Capture.EventHandler.OnReaderDisconnect(object Capture, string ReaderSerialNumber)
        {
        }

        void DPFP.Capture.EventHandler.OnSampleQuality(object Capture, string ReaderSerialNumber, CaptureFeedback CaptureFeedback)
        {
        }

        public static bool GetFeature(Sample sample, out FeatureSet feature)
        {
            CaptureFeedback CaptureFeedback = CaptureFeedback.None;
            feature = new FeatureSet();
            m_extractor.CreateFeatureSet(sample, DataPurpose.Enrollment, ref CaptureFeedback, ref feature);
            ReaderStatusCaptureEvent?.Invoke(CaptureFeedback);
            if (CaptureFeedback == CaptureFeedback.Good)
            {
                return true;
            }
            return false;
        }
    }
}