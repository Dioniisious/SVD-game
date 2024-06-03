using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveCard : MonoBehaviour
{
    public Animator anim;
    public GameObject Player;
    public RectTransform PositionRect;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        PositionRect = gameObject.GetComponent<RectTransform>();
    }
    private void FixedUpdate()
    {
        if (Player.GetComponent<MovePlayer>().isChoseTool == true)
        {
            if (PositionRect.position.x != -800)
                PositionRect.Translate(-50f, 0,0);
            else
                PositionRect.Translate(0, 0, 0);
        }
        else
        {
            if (PositionRect.position.x != -442)
                PositionRect.Translate(50f, 0, 0);
            else
                PositionRect.Translate(0, 0, 0);

        }
    }
}
