using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


[System.Serializable]

public class DefaultRoom
{
    public string Name;
    public int sceneIndex;
    public int maxPlayer;

}
public class NetworkManeger01 : MonoBehaviourPunCallbacks
{
    [Tooltip("The Ui Panel to let the user enter name, connect and play")]
    [SerializeField]
    private GameObject controlPanel;
    [Tooltip("The UI Label to inform the user that the connection is in progress")]
    [SerializeField]
    private GameObject progressLabel;

    public List<DefaultRoom> defaultRooms;
    public GameObject roomUI;
    public GameObject connectUI;

    private void Start()
    {
        /*roomUI.SetActive(false);
        connectUI.SetActive(true);*/
    }

    public void ConnectToServer()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("서버에 연결하는 중...");
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        Debug.Log("로비에 입장하였습니다.");
/*        roomUI.SetActive(true);
        connectUI.SetActive(false);*/
    }

    public void InitializeRoom(int defaultRoomIndex) 
    {
        DefaultRoom roomSettings = defaultRooms[defaultRoomIndex];

        PhotonNetwork.LoadLevel(roomSettings.sceneIndex);

        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = (byte)roomSettings.maxPlayer;
        roomOptions.IsVisible = true;
        roomOptions.IsOpen = true;

        PhotonNetwork.JoinOrCreateRoom("Room 1", roomOptions, TypedLobby.Default);
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("서버와 연결되었습니다.");
        base.OnConnectedToMaster();
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("방에 입장하셨습니다,");
        base.OnJoinedRoom();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log(newPlayer.NickName + " 플레이어가 방에 입장하셨습니다.");
        base.OnPlayerEnteredRoom(newPlayer);
    }

    public override void OnPlayerLeftRoom(Player newPlayer)
    {
        Debug.Log(newPlayer.NickName + " 플레이어가 방에서 퇴장하셨습니다.");
        base.OnPlayerLeftRoom(newPlayer);
    }

}
