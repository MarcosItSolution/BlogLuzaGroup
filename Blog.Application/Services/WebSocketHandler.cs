using System;
using System.Net.WebSockets;
using System.Text;

namespace Blog.Internal.Applications.Core.Services
{
	public class WebSocketHandler
	{
        private readonly List<WebSocket> _sockets;

        public WebSocketHandler()
		{
            _sockets = new();
        }

        public async Task AddSocket(WebSocket socket)
        {
            _sockets.Add(socket);

            while (socket.State == WebSocketState.Open)
            {
                await Task.Delay(1000); // Mantém conexão
            }

            _sockets.Remove(socket);
        }

        public async Task NotifyAllAsync(
            string message, CancellationToken cancellationToken = default)
        {
            var buffer = Encoding.UTF8.GetBytes(message);

            foreach (var socket in _sockets)
            {
                if (socket.State == WebSocketState.Open)
                {
                    await socket.SendAsync(
                        buffer,
                        WebSocketMessageType.Text,
                        true,
                        cancellationToken);
                }
            }
        }
    }
}

