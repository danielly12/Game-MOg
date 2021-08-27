using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;


public class PlayerManager : MonoBehaviour
{
    PhotonView PV;
    GameObject controller;
     void Awake()
    {
       PV = GetComponent<PhotonView>();   

       
    }


    void Start()
    {
       if (PV.IsMine)
        {
            CreateController();
        } 
        
    }

    void CreateController()
    {
       
      
       PhotonNetwork.Instantiate(Path.Combine( "PhotonPrefabs","PlayerController"), Vector2.zero, Quaternion.identity, 0, new object[] { PV.ViewID });
    }

    public void Die()
    {
        PhotonNetwork.Destroy(controller);
        CreateController();
    }
}