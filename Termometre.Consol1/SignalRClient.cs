
using System.Text;

namespace Termometre.Consol1
{
    using System;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.SignalR.Client;

    class Program
    {
        static async Task Main(string[] args)
        {
            var hubConnection = new HubConnectionBuilder()
                .WithUrl("https://localhost:5000/myhub")
                .Build();

            await hubConnection.StartAsync();

            if (hubConnection.State == HubConnectionState.Connected)
            {
                Console.WriteLine("Hub'a bağlanıldı.");
            }

            
            Console.WriteLine("Gönderilecek mesajı yazınız:");
            string messageToSend = Console.ReadLine();

            // HTTP isteği gönderme
            using var httpClient = new HttpClient();
            var content = new StringContent(JsonSerializer.Serialize(messageToSend), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("https://localhost:5000/api/home", content);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Mesaj başarıyla gönderildi.");
            }
            else
            {
                Console.WriteLine($"İsteğe ulaşılırken bir hata oluştu: {response.StatusCode} - {response.ReasonPhrase}");
            }

            Console.WriteLine("Çıkmak için bir tuşa basın...");
            Console.ReadKey();

            await hubConnection.StopAsync();
        }
    }
}