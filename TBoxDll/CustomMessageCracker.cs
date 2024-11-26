using QuickFix;
using TBoxDll.TBoxModel;

namespace TBoxDll
{
    public class CustomMessageCracker : MessageCracker
    {
        public virtual void OnMessage(RequestForPositionsAck message, SessionID sessionID)
        {
            // 处理自定义消息的逻辑
            Console.WriteLine($"Received RequestForPositionsAck");
        }

        public virtual void OnMessage(PositionReport message, SessionID sessionID)
        {
            // 处理自定义消息的逻辑
            Console.WriteLine($"Received PositionReport");
        }
    }
}
