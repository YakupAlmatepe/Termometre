//using Microsoft.AspNetCore.SignalR.Client;
//using System;
//using System.Net.Http;
//using System.Threading.Tasks;

//namespace ConsoleApp2
//{
//    class Program
//    {
//        static HubConnection connection;
//        async static Task Main(string[] args)
//        {
//            connection = new HubConnectionBuilder().WithUrl("https://localhost:5001/myhub").Build();
//            await connection.StartAsync();
//            Console.WriteLine(connection.State);
//            connection.On<string>("receiveMessage", message =>
//            {
//                Console.WriteLine($"--->{message}");
//            });
//            connection.On<string>("userJoined", message =>
//            {
//                Console.WriteLine($"{message} katıldı.");
//            });
//            connection.On<string>("userLeaved", message =>
//            {
//                Console.WriteLine($"{message} ayrıldı.");
//                Console.WriteLine("*****************************");
//            });


//            while (true)
//            {
//                Console.WriteLine("Gönderilecek mesajı yazınız.");
//                await connection.InvokeAsync("SendMessageAsync", Console.ReadLine());
//            }
//        }
//    }
//}
