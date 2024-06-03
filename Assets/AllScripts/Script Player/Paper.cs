using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Paper : MonoBehaviour
{
    public float paperCount;
    public float maxPaper = 20;
    public Text paperText;

    private void FixedUpdate()
    {
        paperText.text = paperCount.ToString();
    }


    public void LostPaper()
    {
        paperCount -= 1;
        paperText.text = paperCount.ToString();

    }

    public void SetPaper()
    {
        paperCount += 1;

        if (paperCount >= maxPaper)
            paperCount = maxPaper;
        paperText.text = paperCount.ToString();
    }
}
