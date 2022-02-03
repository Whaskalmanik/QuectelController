using RJCP.IO.Ports;
using System;
using System.IO;
using System.Text;

namespace QuectelController.Communication
{
    public class SerialCommunitacion : IDisposable
    {
        SerialPortStream Stream;
        private bool disposedValue;

        public string Interface { get; set; }
        public int Baudrate { get; set; }

        public SerialCommunitacion(string _interface, int _baudrate)
        {
            Interface = _interface;
            Baudrate = _baudrate; 
            Stream = new SerialPortStream(Interface, Baudrate);                  
        }
        private void OnPortChange()
        {
            Stream = new SerialPortStream(Interface, Baudrate);
        }
        public void Open()
        {
            if(Stream.IsOpen)
            {
                return;
            }
            Stream.Open();
        }

        private void Close()
        {
            if(!Stream.IsOpen)
            {
                return;
            }
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
            // Neměňte tento kód. Kód pro vyčištění vložte do metody Dispose(bool disposing).
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
