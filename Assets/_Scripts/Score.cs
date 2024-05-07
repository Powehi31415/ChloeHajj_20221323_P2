using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    TMP_Text score;

    void Start()
    {
        score = GetComponent<TMP_Text>();
    }

    void Update()
    {
        score.text = GameManager.instance.GetScore().ToString();
    }
}
