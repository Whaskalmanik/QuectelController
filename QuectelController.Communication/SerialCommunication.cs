using RJCP.IO.Ports;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using System.Text;

namespace QuectelController.Communication
{
    public class SerialCommunication : IDisposable
    {
        SerialPortStream Stream;
        private bool disposedValue;

        public string Interface { get; set; }
        public int Baudrate { get; set; }
        public int DataBits { get; set; }
        public Parity Parity { get; set; }
        public StopBits StopBits { get; set; }
        public IObservable<string> ReceivedCharactersObservable { get; private set; }

        public SerialCommunication(string _interface, int _baudrate,int _dataBits, Parity _parity, StopBits _stopBits)
        {
            Interface = _interface;
            Baudrate = _baudrate;
            DataBits = _dataBits;
            Parity = _parity;
            StopBits = _stopBits;
                   
            Stream = new SerialPortStream(Interface, Baudrate, DataBits, Parity, StopBits);                  
        }

        public static List<string> GetSerialPorts()
        {
            return SerialPortStream.GetPortNames().ToList();
        }

        public void Open()
        {
            if(Stream.IsOpen)
            {
                return;
            }
            Stream.Open();
            ReceivedCharactersObservable = Observable.FromEvent<EventHandler<SerialDataReceivedEventArgs>, SerialDataReceivedEventArgs>(
                x => (obj, args) => x(args),
                x => Stream.DataReceived += x,
                x => Stream.DataReceived -= x)
                .Where(x => x.EventType == SerialData.Chars)
                .Select(x => Stream.ReadExisting());
        }

        private void Close()
        {
            if(!Stream.IsOpen)
            {
                return;
            }
            ReceivedCharactersObservable = Observable.Empty<string>();
            Stream.Close();
        }

        public void Write(string message)
        {
            using var writer = new StreamWriter(Stream,Encoding.ASCII,1024,true);
            writer.Write(message);
            writer.Write('\r');
        }

        public string Read()
        {
            using var reader = new StreamReader(Stream, Encoding.ASCII, false, 1024, true);
            return reader.ReadLine();
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

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
