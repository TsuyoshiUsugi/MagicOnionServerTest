using System.Threading.Tasks;
using MagicOnion;

namespace MyApp.Shared
{
    public interface IChatHub : IStreamingHub<IChatHub, IChatHubReceiver>
    {
        ValueTask JoinAsync(string roomName, string userName);
        ValueTask LeaveAsync();
        ValueTask SendMessageAsync(string message);
    }
    
    public interface IChatHubReceiver
    {
        void OnJoin(string userName);
        void OnLeave(string userName);
        void OnSendMessage(string userName, string message);
    }
}