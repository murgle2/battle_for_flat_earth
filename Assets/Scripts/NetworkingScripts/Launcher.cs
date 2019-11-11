using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

namespace GameCompany.BFE
{
    public class Launcher : MonoBehaviourPunCallbacks
    {

        [SerializeField]
        private byte maxPlayersPerRoom;


        bool isConnecting;
        string gameVersion = "1";



        private void Awake()
        {
            PhotonNetwork.AutomaticallySyncScene = true;
        }


        public void Connect()
        {
            if (PhotonNetwork.IsConnected)
            {
                PhotonNetwork.JoinRandomRoom();
            }
            else
            {
                //connect to photon network first!
                //PhotonNetwork.GameVersion = gameVersion;
                PhotonNetwork.ConnectUsingSettings();
                isConnecting = true;
            }
            
        }

        public override void OnConnectedToMaster()
        {
            //this exists so we that we only join a room AFTER we are connected
            if (isConnecting)
            {
                PhotonNetwork.JoinRandomRoom();
            }
        }

        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            //called if no rooms exist
            Debug.Log("Creating room...");
            PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = maxPlayersPerRoom });
            
        }

        public override void OnJoinedRoom()
        {
            //loads the game world
            PhotonNetwork.LoadLevel("World");
            Debug.Log("Success!");
        }


    }
}
