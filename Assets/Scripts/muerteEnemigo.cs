using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//PROGRAMADO POR DAVID VENTAS SANCHEZ 29/01/2023
public class muerteEnemigo : MonoBehaviour
{
    [SerializeField] private ControladorJuego controladorjuego; 
    public Item i;
    public int tiempo=5;
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
            Desaparecer();
        }
    }

    void OnMouseDown()
    {
        i.puntos-=5;
        if(i.puntos<0){
            i.puntos=0;
        }
        i.SetCountText();
        Desaparecer();
    } 

    void Desaparecer(){
        Destroy(gameObject);
    }
}

