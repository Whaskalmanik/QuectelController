using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuectelController
{
    public class PeriodicTask
    {
        public static async Task Run(Action action, TimeSpan period, CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await Task.Delay(period, cancellationToken);
                if (!cancellationToken.IsCancellationRequested)
                    action();
            }
        }
        public static Task Run(Action actiom, TimeSpan period)
        {
            return Run(actiom, period, CancellationToken.None);
        }

        public static Task Stop(Action actiom, TimeSpan period)
        {
            CancellationToken cancellationToken = new CancellationToken();
            cancellationToken.ThrowIfCancellationRequested();
            return Run(actiom, TimeSpan.Zero, cancellationToken);
        }
    }
}
