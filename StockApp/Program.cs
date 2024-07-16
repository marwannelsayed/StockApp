using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

var hubConnection = new HubConnectionBuilder()
    .WithUrl("http://localhost:5191/StockHub")
    .Build();

hubConnection.On<Stock>("ReceiveStockUpdate", (stock) =>
{
    Console.WriteLine($"Received stock update: {stock.StockSymbol} - {stock.Price}");
});

await hubConnection.StartAsync();

Console.WriteLine("Connected to SignalR server. Press any key to exit...");
Console.ReadKey();

await hubConnection.DisposeAsync();

public class Stock
{
    public string StockSymbol { get; set; }
    public decimal Price { get; set; }
}
