using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PossibilityZone : MonoBehaviour
{
    public GameObject Player;

    private void FixedUpdate()
    {
        transform.position = Player.transform.position;
    }
}
