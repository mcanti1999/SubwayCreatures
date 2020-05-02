using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private GameObject player;
    

    //Makes the camera stick to the player but keeps having a fixed y coordinate
    void LateUpdate()
    {
        transform.position = new Vector3(player.transform.position.x,transform.position.y,transform.position.z);
    }
}
