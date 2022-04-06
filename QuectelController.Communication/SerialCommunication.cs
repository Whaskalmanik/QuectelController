using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using RJCP.IO.Ports;

namespace QuectelController.Communication
{
    public class SerialCommunication : IDisposable
    {
        private readonly SerialPortStream stream;
        private bool disposedValue;

        public SerialCommunication(string @interface, int baudrate, int dataBits, Parity parity, StopBits stopBits)
        {
            Interface = @interface;
            Baudrate = baudrate;
            DataBits = dataBits;
            Parity = parity;
            StopBits = stopBits;

            if (Interface == null)
            {
                return;
            }

            stream = new SerialPortStream(Interface, Baudrate, DataBits, Parity, StopBits);
        }

        public string Interface { get; set; }

        public int Baudrate { get; set; }

        public int DataBits { get; set; }

        public Parity Parity { get; set; }

        public StopBits StopBits { get; set; }

        public IObservable<string> ReceivedCharactersObservable { get; private set; }

        public static List<string> GetSerialPorts()
        {
            return SerialPortStream.GetPortNames().ToList();
        }

        public bool IsOpen()
        {
            if (stream == null)
            {
                return false;
            }

            if (!stream.IsOpen)
            {
                return false;
            }

            return true;
        }

        public void Open()
        {
            if (stream == null)
            {
                return;
            }

            if (stream.IsOpen)
            {
                return;
            }

            stream.Open();
            stream.WriteTimeout = 5000;
            stream.ReadTimeout = 5000;

            ReceivedCharactersObservable = Observable.FromEvent<EventHandler<SerialDataReceivedEventArgs>, SerialDataReceivedEventArgs>(
                x => (obj, args) => x(args),
                x => stream.DataReceived += x,
                x => stream.DataReceived -= x)
                .Where(x => x.EventType == SerialData.Chars)
                .Select(x => stream.ReadExisting());
        }
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public void Write(string message)
        {
            using var writer = new StreamWriter(stream, Encoding.ASCII, 1024, true);
            writer.Write(message);
            writer.Write('\r');
        }

        public string Read()
        {
            using var reader = new StreamReader(stream, Encoding.ASCII, false, 1024, true);
            return reader.ReadLine();
        }

        private void Close()
        {
            if (stream == null)
            {
                return;
            }

            if (!stream.IsOpen)
            {
                return;
            }

            ReceivedCharactersObservable = Observable.Empty<string>();
            stream.Close();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Close();
                }

                disposedValue = true;
            }
        }
    }
}
