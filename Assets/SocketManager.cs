using System.Collections;
using System.Collections.Generic;
using Assets.MoveEvents;
using Newtonsoft.Json;
using Quobject.SocketIoClientDotNet.Client;
using UnityEngine;
using Socket = Quobject.SocketIoClientDotNet.Client.Socket;

public class MoveCommand
{
    public string type;
    public float value;

    public override string ToString()
    {
        return "type: " + type + " value: " + value;
    }
}

public class SocketManager : MonoBehaviour
{
    private Socket socket = null;
    public string server = "http://localhost:3000";
    public float reconnect_delay = 0.5f;
    private float last_alive = 0;
    public bool reconnect = false;
    public bool connected = false;

	// Use this for initialization
	void Start () {
		Connect();
	}
	
	// Update is called once per frame
	void Update () {
	    if (reconnect)
	    {
	        Connect();
	        reconnect = false;
	    }
	    connected = socket != null;
	}

    void Destroy()
    {
        Disconnect();
    }

    void OnApplicationQuit()
    {
        Disconnect();
    }

    void Connect()
    {
        if (socket == null)
        {
            socket = IO.Socket(server);
            socket.On(Socket.EVENT_CONNECT, () =>
            {
                Debug.Log("[Socket] Connected");
            });
            socket.On("move", (data) =>
            {
                MoveCommand moveCommand = JsonConvert.DeserializeObject<MoveCommand>(data.ToString());
                HandleCommand(moveCommand);
            });
        }
    }

    void Disconnect()
    {
        if (socket != null)
        {
            socket.Disconnect();
            socket = null;
        }
    }

    void HandleCommand(MoveCommand moveCommand)
    {
        MoveEvent moveEvent = MoveEventsManager.GetMoveEvent(moveCommand.type);
        if (moveEvent == null)
            return;
        moveEvent.Exec(moveCommand.value);
    }
}
