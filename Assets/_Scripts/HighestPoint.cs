using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighestPoint : MonoBehaviour
{

    [SerializeField] GameObject Player;
    void Start()
    {
        
    }

    void Update()
    {
        if (Player.transform.position.y > transform.position.y)
        {
            transform.position = Player.transform.position;
        }
    }
}
