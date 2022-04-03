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
        static CancellationTokenSource token;
        private static async Task Run(Action action, TimeSpan period, CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await Task.Delay(period);
                if (!cancellationToken.IsCancellationRequested)
                    action();
            }
        }
        public static Task Run(Action action, TimeSpan period)
        {
            token = new CancellationTokenSource();
            CancellationToken ct = token.Token;
            return Run(action, period, ct);
        }
        
        public static void Stop()
        {
            token?.Cancel();
            token?.Dispose();
            token = null;
        }
    }
}
