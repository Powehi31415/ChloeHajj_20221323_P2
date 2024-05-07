using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingColorObstacle : MonoBehaviour
{
    float timer;

    void Start()
    {
        timer = 0;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 1)
        {
            GameManager.instance.SetRandomColor(gameObject);
            timer = 0;
        }
    }
}
