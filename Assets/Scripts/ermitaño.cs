using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Collections;
using System;
using Unity.VisualScripting;
//PROGRAMADO POR DAVID VENTAS SANCHEZ 29/01/2023
public class ermitaño : MonoBehaviour
{

    [SerializeField] TMP_Text dialogueText;
    [SerializeField] GameObject dialoguePanel;
    public InteractBoards tablon;
    public InteractPalanca palanca;
    public GameObject objetActivable1;
    public GameObject llave;
    public bool llave_agarrado=false;
    
    // Start is called before the first frame update
    void Start()
    {
        tablon=FindObjectOfType<InteractBoards>();
        palanca=FindObjectOfType<InteractPalanca>();
    }



    private void OnCollisionStay2D(Collision2D collision)
    {
        float interaction = Input.GetAxis("Interaction");
        if (interaction != 0 && tablon.agarrado==false)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                StartDialogue(1);
                Invoke("fin", 2);
            }
        }
        if (interaction != 0 && tablon.agarrado==true)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                StartDialogue(2);
                objetActivable1.SetActive(false);
                llave.SetActive(true);
                Invoke("fin", 2);
                
            }
        }

        if (interaction != 0 && palanca.agarrado==true)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                StartDialogue(3);
                llave.SetActive(false);
                Invoke("fin", 2);
                
            }
        }
        
        
    }

    private void StartDialogue(int i)
    {
        dialoguePanel.SetActive(true);
        if(i==1){
            dialogueText.text = "Si encuentras madera te dire como levantar el puente";
        }
        if(i==2){
            dialogueText.text = "Con esta llave podras abrir el laberinto y buscar la palanca";
            llave_agarrado=true;
        }
        if(i==3){
            dialogueText.text = "Yo subi el puente para no extender la infeccion, lo siento...";
        }
    }

    void fin(){
        dialoguePanel.SetActive(false);
    }
}
