using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStuck : MonoBehaviour
{
    private float checkTime = 0.1f;
    private Vector2 oldPos;
    public Map_PlayerIconMove BarryIcon;

    void Update()
    {
        if (checkTime <= 0) {
            oldPos = transform.position;
            checkTime = 0.1f;
        }
        else {
            checkTime -= Time.deltaTime;
        }
        if (Vector2.Distance(transform.position, oldPos) < 0.1f)
        {
            BarryIcon.speed = 0.0f;
        }
        else
        {
            BarryIcon.speed = 1.05f;
        }
    }
}
