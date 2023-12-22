using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//PROGRAMADO POR DAVID VENTAS SANCHEZ 29/01/2023
public class inicioMinijuego2 : MonoBehaviour
{

    [SerializeField] private ControladorJuego controladorjuego; 
    public GameObject objetActivable1;
    public GameObject objetActivable2;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        controladorjuego.ActivarTemporizador();
        objetActivable1.SetActive(false);
        objetActivable2.SetActive(false);

    } 
}
