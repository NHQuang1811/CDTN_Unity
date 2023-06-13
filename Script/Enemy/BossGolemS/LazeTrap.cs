using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazeTrap : MonoBehaviour
{
    public GameObject laze;

    // Update is called once per frame
    void Update()
    {
        Destroy(laze, 2f);
    }
}
