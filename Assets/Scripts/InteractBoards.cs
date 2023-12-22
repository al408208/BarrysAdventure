using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//PROGRAMADO POR DAVID VENTAS SANCHEZ 29/01/2023
public class InteractBoards : MonoBehaviour
{

    public GameObject objetActivable1;
    public GameObject objetActivable2;
    public GameObject objetActivable3;
    public bool agarrado=false;

    void Start()
    {
        objetActivable1.SetActive(false);
        objetActivable2.SetActive(false);
        objetActivable3.SetActive(false);
    }
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        float interaction = Input.GetAxis("Interaction");
        if (interaction != 0)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                agarrado=true;
                objetActivable1.SetActive(true);
                Destroy(gameObject);

            }
        }
    }
}
