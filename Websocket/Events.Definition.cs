namespace Mbk.Discord.Websocket;

public partial class Events
{
    //-------------------------------OP 0----------------------------------

    /// <summary>
    /// Ready
    /// Discord send the app a Ready event (OPCODE 0)
    /// https://discord.com/developers/docs/topics/gateway-events#ready
    /// </summary>

    public const string OnLogin = "onlogin";
    public class OnLoginAttribute : Attribute
    {
    }

    //-------------------------------OP 9----------------------------------

    /// <summary>
    /// Invalid Session
    /// Used to notify client they have an invalid session id
    /// https://discord.com/developers/docs/topics/gateway-events#ready
    /// </summary>

    public const string OnInvalidSession = "oninvalidsession";
    public class OnInvalidSessionAttribute : Attribute
    {
    }

    //-------------------------------OP 10----------------------------------

    /// <summary>
    /// Hello
    /// Sent on connection to the websocket
    /// https://discord.com/developers/docs/topics/gateway-events#ready
    /// </summary>

    public const string OnConnect = "onconnect";
    public class OnConnectAttribute : Attribute
    {
    }

    //-------------------------------OP 11----------------------------------

    /// <summary>
    /// Heartbeat ACK
    /// Heartbeat confirmation (OPCODE 11) after a heartbeat was sent.
    /// https://discord.com/developers/docs/topics/gateway#sending-heartbeats
    /// </summary>

    public const string OnHeartbeatACK = "onhearbeatack";
    public class OnHeartbeatACKAttribute : Attribute
    {
    }

    //----------------------------------------------------------------------

    /// <summary>
    /// Disconnect
    /// When the websocket disconnect, a reason is provided
    /// <param name="reason">The reason of the disconnect</param>
    /// </summary>

    //[MethodArguments(new Type[] { typeof(string) })]
    public class OnDisconnectAttribute : Attribute
    {
    }
}
