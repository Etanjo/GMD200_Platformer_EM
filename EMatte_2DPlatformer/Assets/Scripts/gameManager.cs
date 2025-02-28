using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gameManager : MonoBehaviour
{
    public int score = 0;
    [SerializeField] TMP_Text scoreText;

    // Update is called once per frame
    void Update()
    {
        scoreText.SetText("Score: " + score);
    }
}
