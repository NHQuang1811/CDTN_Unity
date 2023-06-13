using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor;
using UnityEngine;

public class CameraManagerment : MonoBehaviour
{
    public float damping = 1f;
    private CinemachineVirtualCamera vcam;
    public GameObject player;
    private void Start()
    {
        player = GameObject.Find("Player");
        if (player != null)
        {
            vcam = FindObjectOfType<CinemachineVirtualCamera>();
            if (vcam != null)
            {
                CinemachineTransposer transposer = vcam.GetCinemachineComponent<CinemachineTransposer>();
                if (transposer != null)
                {
                    transposer.m_FollowOffset = new Vector3(0f, 0f, -10f);
                    transposer.m_BindingMode = CinemachineTransposer.BindingMode.LockToTarget;
                    transposer.m_XDamping = damping;
                    transposer.m_YDamping = damping;
                    transposer.m_ZDamping = damping;
                    transposer.m_FollowOffset = new Vector3(0f, 0f, -10f);
                    transposer.m_FollowOffset = new Vector3(0f, 0f, 0f);
                    transposer.m_BindingMode = CinemachineTransposer.BindingMode.LockToTarget;
                    transposer.m_FollowOffset = new Vector3(0f, 0f, -10f);
                }

            }
        }
    }
    private void Update()
    {
        transform.position = player.transform.position + new Vector3(0, 0, -10);
    }
}
