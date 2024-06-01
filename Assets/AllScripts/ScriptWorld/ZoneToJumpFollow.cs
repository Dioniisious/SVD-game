using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneToJumpFollow : MonoBehaviour
{
    public Transform ObjectToJump;
    public float XDistance, YDistance;

    private void Update()
    {
        transform.position = new Vector2(ObjectToJump.position.x + XDistance, ObjectToJump.position.y + YDistance);
    }
}
