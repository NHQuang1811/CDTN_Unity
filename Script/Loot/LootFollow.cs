using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootFollow : MonoBehaviour
{
    private Transform Player;
    private float speed = 8;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        Invoke("FlyToward", 1f);
    }
    private void FlyToward()
    {
        transform.position = Vector2.MoveTowards(this.transform.position, Player.position, speed * Time.deltaTime);
    }
}
