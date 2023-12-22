using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Collections;
using System;
using Unity.VisualScripting;
//PROGRAMADO POR DAVID VENTAS SANCHEZ 29/01/2023

    
public class ActivarPalanca : MonoBehaviour
{
    
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] GameObject dialoguePanel;

    public InteractPalanca palanca;
    public GameObject objetActivable1;
    public GameObject objetActivable2;//palanca estado1
    public GameObject objetActivable3;//palanca estado2
    public GameObject puente2;//puente
    // Start is called before the first frame update
    void Start()
    {
        palanca=FindObjectOfType<InteractPalanca>();
        objetActivable2.SetActive(false);
        objetActivable3.SetActive(false);
        puente2.SetActive(false);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        float interaction = Input.GetAxis("Interaction");
        if (interaction != 0 && palanca.agarrado==true)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                objetActivable1.SetActive(false);
                Invoke("Espera", 1);
            }
        }
    }

    void Espera(){
        objetActivable2.SetActive(true);
        StartDialogue();
    }

    private void StartDialogue()
    {
        dialoguePanel.SetActive(true);
        dialogueText.text = "Genial ya puedo activar la palanca";
        Invoke("fin", 1);
    }

    void fin(){
        dialoguePanel.SetActive(false);
        Destroy(gameObject);
    }
}
