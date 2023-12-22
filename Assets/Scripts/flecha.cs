using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//PROGRAMADO POR DAVID VENTAS SANCHEZ 29/01/2023

public class flecha : MonoBehaviour
{
    public GameObject objetActivable1;

    void start(){
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 traslacion= new Vector2(-14.02f,6.7f);
            objetActivable1.transform.position=traslacion;
            
        }
    }
}
