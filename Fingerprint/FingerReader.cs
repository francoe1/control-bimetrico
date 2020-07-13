using DPFP;
using DPFP.Capture;
using DPFP.Error;
using DPFP.Processing;
using DPFP.Verification;
using System;
using System.Collections.Generic;

namespace Fingerprint
{
    public class FingerReader : DPFP.Capture.EventHandler
    {
        public static event Action<CaptureFeedback> ReaderStatusCaptureEvent;
        public delegate void CaptureDelegate(Sample sample);

        private static FeatureExtraction m_extractor;

        private static Verification m_verificator;

        private static Capture m_capture;

        private bool m_success { get; set; }

        public bool IsRuning
        {
            get;
            private set;
        }

        public event CaptureDelegate OnCaptureEvent;

        public FingerReader()
        {
            try
            {
                m_extractor = new FeatureExtraction();
                m_verificator = new Verification();
                m_capture = new Capture(Priority.High)
                {
                    EventHandler = this
                };
            }
            catch (SDKException ex)
            {
                Console.WriteLine(string.Format("Error {0}", ex.ErrorCode.ToString()));
                throw ex;
            }
        }

        public bool StartCapture()
        {
            if (IsRuning)
            {
                return false;
            }
            try
            {
                m_capture.StartCapture();
                IsRuning = true;
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se puede iniciar la captura del lector\n" + ex.Message, "Error grave");
                return false;
            }
        }

        public bool StopCapture()
        {
            if (!IsRuning)
            {
                return false;
            }
            try
            {
                m_capture.StopCapture();
                IsRuning = false;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool GetFeature(Sample sample, out FeatureSet feature)
        {
            CaptureFeedback CaptureFeedback = CaptureFeedback.None;
            feature = new FeatureSet();
            m_extractor.CreateFeatureSet(sample, DataPurpose.Verification, ref CaptureFeedback, ref feature);
            ReaderStatusCaptureEvent?.Invoke(CaptureFeedback);
            if (CaptureFeedback == CaptureFeedback.Good)
            {
                return true;
            }
            return false;
        }

        public bool Verify(Sample sample, List<byte[]> fingers)
        {
            if (GetFeature(sample, out FeatureSet feature))
            {
                for (int i = 0; i < fingers.Count; i++)
                {
                    Verification.Result Result = new Verification.Result();
                    Template template = new Template();
                    foreach (byte[] finger in fingers)
                    {
                        template.DeSerialize(finger);
                        m_verificator.Verify(feature, template, ref Result);
                        if (Result.Verified)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        void DPFP.Capture.EventHandler.OnComplete(object Capture, string ReaderSerialNumber, Sample Sample)
        {
            m_success = true;
            OnCaptureEvent?.Invoke(Sample);
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
           // m_description = new ReaderDescription(ReaderSerialNumber);
        }

        void DPFP.Capture.EventHandler.OnReaderDisconnect(object Capture, string ReaderSerialNumber)
        {
        }

        void DPFP.Capture.EventHandler.OnSampleQuality(object Capture, string ReaderSerialNumber, CaptureFeedback CaptureFeedback)
        {
        }
    }
}