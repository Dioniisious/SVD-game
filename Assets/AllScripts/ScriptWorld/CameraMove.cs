using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform Player;
    public float XDistance, YDistance;

    private void Update()
    {
        transform.position = new Vector3(Player.position.x + XDistance, Player.position.y + YDistance, -10); ;
    }
}
