using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Unity.VisualScripting;
//PROGRAMADO POR DAVID VENTAS SANCHEZ 29/01/2023
public class spanwkk : MonoBehaviour
{
    [SerializeField] TMP_Text dialogueText;
    [SerializeField] GameObject dialoguePanel;
    // Start is called before the first frame update
    void Start()
    {  
        dialoguePanel.SetActive(true);
        dialogueText.text = "Mendoza te ha engañado, te ha utilizado para repartir sus folletos. Deberias irte...";
        Invoke("fin", 5);
        
        
    }

    void fin(){
        dialoguePanel.SetActive(false);
    }
}
