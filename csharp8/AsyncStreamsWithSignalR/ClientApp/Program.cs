using Microsoft.AspNetCore.SignalR.Client;
using StreamSample.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ClientApp
{
    class Program
    {
        private static HubConnection? s_hubConnection;
        static async Task Main()
        {
            Console.WriteLine("client - wait for service...");
            Console.ReadLine();

            s_hubConnection = new HubConnectionBuilder()
                .WithUrl("https://localhost:44340/hubs/stream")
                .Build();

            s_hubConnection.Closed += async (ex) =>
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("restart");
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await s_hubConnection.StartAsync();
            };

            var cts = new CancellationTokenSource();
            await s_hubConnection.StartAsync(cts.Token);
            //var channel = await s_hubConnection.StreamAsChannelAsync<int>("GetSomeData", 100, 1000, cts.Token);
            //while (await channel.WaitToReadAsync())
            //{
            //    while (channel.TryRead(out int data))
            //    {
            //        Console.WriteLine($"received {data}");
            //    }
            //}
            var stream = s_hubConnection.StreamAsync<int>("GetSomeData2", 20, 100, cts.Token);
            await foreach (var d in stream)
            {
                Console.WriteLine($"received {d}");
            }
            Console.WriteLine("complete");
        }
    }
}
