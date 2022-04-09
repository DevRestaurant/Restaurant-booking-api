using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace restaurant_booking_Application.Common
{
    public class NotificationHub : Hub
    {
        private readonly IConfiguration _config;
        public NotificationHub(IConfiguration config)
        {
            _config = config;
        }

        HubConnection _connection = null;

        private async Task ConnectToServer()
        {
            _connection = new HubConnectionBuilder()
                .WithUrl(_config["HostUrl:Url"]).Build();
            await _connection.StartAsync();
        }
    }
}
