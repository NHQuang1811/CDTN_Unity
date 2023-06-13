using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpin : MonoBehaviour
{
    private Transform Player;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        Spin();
    }
    private void Spin()
    {
        if (Player.position.x < transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
