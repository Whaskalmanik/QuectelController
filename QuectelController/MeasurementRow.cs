using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuectelController
{
    public record MeasurementRow([Index(0)]double RSRPx, [Index(1)]double RSRPy, [Index(2)]double RSRQx, [Index(3)]double RSRQy, [Index(4)]double SINRx, [Index(5)]double SINRy);
}
