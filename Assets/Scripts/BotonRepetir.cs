using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//PROGRAMADO POR DAVID VENTAS SANCHEZ 29/01/2023
public class BotonRepetir : MonoBehaviour
{

    [SerializeField] private ControladorJuego controladorjuego; 
    public Item i;
    public Item i2;

    public GameObject objetActivable1;
    public GameObject objetActivable2;
    public GameObject objetActivable3;
    public GameObject objetActivable4;
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
        i.inicio=0;
        i2.inicio=0;
        i.puntos=0;
        i2.puntos=0;
        i.SetCountText();
        objetActivable1.SetActive(false);
        objetActivable2.SetActive(false);
        objetActivable3.SetActive(false);
        objetActivable4.SetActive(false);

    } 
}
