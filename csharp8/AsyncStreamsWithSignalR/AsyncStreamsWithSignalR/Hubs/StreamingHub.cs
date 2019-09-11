using Microsoft.AspNetCore.SignalR;
using StreamSample.Models;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace AsyncStreamsWithSignalR.Hubs
{
    public class StreamingHub : Hub
    {
        public async IAsyncEnumerable<int> GetSomeData2(int count, int delay, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            for (int i = 0; i < count; i++)
            {
                await Task.Delay(delay);
                yield return i;
            }
        }

        public ChannelReader<int> GetSomeData(
            int count, 
            int delay, 
            CancellationToken cancellationToken)
        {
            var channel = Channel.CreateUnbounded<int>();
             _ = WriteItemsAsync(channel.Writer, count, delay, cancellationToken);

            return channel.Reader;
        }

        private async Task WriteItemsAsync(
            ChannelWriter<int> writer,
            int count,
            int delay,
            CancellationToken cancellationToken)
        {
            try
            {
                for (var i = 0; i < count; i++)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    await writer.WriteAsync(i);

                    await Task.Delay(delay, cancellationToken);
                }
            }
            catch (Exception ex)
            {
                writer.TryComplete(ex);
            }

            writer.TryComplete();
        }
    }
}
