using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.InputSystem;
using TMPro;

public class Interact_RemoveFolletos : MonoBehaviour
{
    void Start()
    {
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        float interaction = Input.GetAxis("Interaction");
        if (interaction != 0)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Invoke("Vanish", (float)0.0);
            }
        }
    }
    void Vanish(){
        Destroy(gameObject);
    }
}
