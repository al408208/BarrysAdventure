using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//PROGRAMADO POR DAVID VENTAS SANCHEZ 29/01/2023
public class muerte : MonoBehaviour
{

    [SerializeField] private ControladorJuego controladorjuego; 
    public Item i;
    public int tiempo=8;
    // Start is called before the first frame update
    void Start()
    {
        i=FindObjectOfType<Item>();
        controladorjuego=FindObjectOfType<ControladorJuego>();
        Invoke("Desaparecer", tiempo);

    }

    // Update is called once per frame
    void Update()
    {
        if(controladorjuego.tiempoActivo==false){
            Destroy(gameObject);
        }
    }

    void OnMouseDown()
    {
        i.puntos+=10;
        i.SetCountText();
        Destroy(gameObject);
    } 

    void Desaparecer(){
        i.puntos-=2;
        if(i.puntos<0){
            i.puntos=0;
        }
        i.SetCountText();
        Destroy(gameObject);
    }
}
