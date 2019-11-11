using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;


namespace GameCompany.BFE
{
    public class GameManager : MonoBehaviourPunCallbacks
    {
        [SerializeField]
        private GameObject playerPrefab;

        public void Start()
        {
            PhotonNetwork.Instantiate(playerPrefab.name, new Vector2(0f, 0f), Quaternion.identity, 0);
        }
        public void LeaveRoom()
        {
            PhotonNetwork.LeaveRoom();
        }

        public override void OnLeftRoom()
        {
            SceneManager.LoadScene(0);
        }
    }
}
