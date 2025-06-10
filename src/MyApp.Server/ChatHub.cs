using MagicOnion.Server.Hubs;
using MyApp.Shared;
using MessagePack.Unity;
using UnityEngine;

namespace MyApp.Server
{
    public class ChatHub : StreamingHubBase<IChatHub, IChatHubReceiver>, IChatHub
    {
        IGroup<IChatHubReceiver>? room;
        string userName = "unknown";

        public async ValueTask JoinAsync(string roomName, string userName)
        {
            Console.WriteLine($"JoinAsync called: {userName} joined {roomName}");
            this.room = await Group.AddAsync(roomName);
            this.userName = userName;
            room.All.OnJoin(userName);
        }

        public async ValueTask LeaveAsync()
        {
            room.All.OnLeave(userName);
            await room.RemoveAsync(Context);
        }

        public async ValueTask SendMessageAsync(string message)
        {
            room.All.OnSendMessage(userName, message);
        }
    }
}
