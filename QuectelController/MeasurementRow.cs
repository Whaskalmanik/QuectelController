using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuectelController
{
    public record MeasurementRow5G([Index(0)]double Time, [Index(1)]double RSRP_5G, [Index(2)]double RSRQ_5G, [Index(3)] double SINR_5G);
    public record MeasurementRowLTE([Index(0)]double Time, [Index(1)]double RSRP_LTE, [Index(2)] double RSRQ_LTE, [Index(3)] double SINR_LTE);
    public record MeasurementRowENDC([Index(0)]double Time, [Index(1)] double RSRP_5G, [Index(2)] double RSRQ_5G, [Index(3)] double SINR_5G, [Index(4)] double RSRP_LTE, [Index(5)] double RSRQ_LTE, [Index(6)] double SINR_LTE);
}
