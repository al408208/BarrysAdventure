using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//PROGRAMADO POR DAVID VENTAS SANCHEZ 29/01/2023
public class Interact_Remove : MonoBehaviour
{

    Animator anim;

    void Start()
    {
        anim=gameObject.GetComponent<Animator>();

    }
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        float interaction = Input.GetAxis("Interaction");
        if (interaction != 0)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                anim.SetTrigger("Cortar");
                Invoke("Desaparecer", (float)1.2);
            }
        }
    }


    void Desaparecer(){
        Destroy(gameObject);
    }
}
