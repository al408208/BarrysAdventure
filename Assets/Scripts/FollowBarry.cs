using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FollowBarry : MonoBehaviour
{
    bool empezar = false;
    Queue<Vector2> posQueue = new Queue<Vector2>();
    Vector2 lastPos = Vector2.zero;

    PlayerController barry;
    Rigidbody2D rBody;
    int retraso = 20;
    // Start is called before the first frame update
    void Start()
    {
        rBody= GetComponent<Rigidbody2D>();
        barry = FindObjectOfType<PlayerController>();
        empezar = true;

        GetComponent<Dialogue>().SetInteracuable(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(empezar) 
        {
            Vector2 movement;
            movement = barry.GetPosition();
            if(movement != lastPos) 
            {
                posQueue.Enqueue(movement);
            }
            lastPos = movement;
            
            if (posQueue.Count > retraso)
            {
                rBody.position = posQueue.Dequeue();
            }
        }
    }
}
