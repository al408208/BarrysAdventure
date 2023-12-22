using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleMap : MonoBehaviour
{
    Transform playerPos;
    Transform offscreenPos;
    public float showSpeed;

    void Start()
    {
        PlayerController p = FindObjectOfType<PlayerController>();
        playerPos = p.GetComponent<Transform>();
        offscreenPos = p.GetComponentsInChildren<Transform>()[1];
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.M))
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, showSpeed * Time.deltaTime);
        }
        else {
            transform.position = Vector2.MoveTowards(transform.position, offscreenPos.position, showSpeed * Time.deltaTime);
        }
    }
}
