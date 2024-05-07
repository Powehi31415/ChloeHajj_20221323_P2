using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Highscore : MonoBehaviour
{
    TMP_Text highscore;

    void Start()
    {
        highscore = GetComponent<TMP_Text>();
    }

    void Update()
    {
        highscore.text = GameManager.instance.GetHighscore().ToString();
    }
}
