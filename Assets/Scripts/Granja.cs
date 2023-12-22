using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Collections;
using System;
using Unity.VisualScripting;
//PROGRAMADO POR DAVID VENTAS SANCHEZ 29/01/2023
public class Granja : MonoBehaviour
{
    [SerializeField] TMP_Text dialogueText;
    [SerializeField] GameObject dialoguePanel;
    public GameObject objetActivable1;
    public GameObject objetActivable2;
    public GameObject objetActivable3;
    public GameObject objetActivable4;
    // Start is called before the first frame update
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
                dialoguePanel.SetActive(true);
                dialogueText.text = "Si quieres que te lleve en coche a la ciudad recoge mis frutas, que estoy mayor";
                Invoke("fin", 2);
                
                objetActivable1.SetActive(false);
                objetActivable2.SetActive(false);
                objetActivable3.SetActive(false);
                objetActivable4.SetActive(false);
                

            }
        }
    }
    void fin(){
        dialoguePanel.SetActive(false);
    }
    
}
