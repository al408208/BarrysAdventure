using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    CinemachineVirtualCamera camara;
    // Start is called before the first frame update
    void Start()
    {
        camara = GetComponent<CinemachineVirtualCamera>();
        var pl = FindObjectOfType<PlayerController>();
        camara.Follow = pl.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
