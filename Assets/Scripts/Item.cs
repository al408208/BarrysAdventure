using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
//PROGRAMADO POR DAVID VENTAS SANCHEZ 29/01/2023
public class Item : MonoBehaviour
{
    [SerializeField] private ControladorJuego controladorjuego; 

    public GameObject[] misobjs;
    public float tmin=0.5f;
    public float tmax=1f;
    public int inicio=0;//para demorar la salida

    public TextMeshProUGUI contador;
    public int puntos;
    // Start is called before the first frame update
    void Start()
    {
        controladorjuego=FindObjectOfType<ControladorJuego>();
        puntos=0;
        SetCountText();       

    }

    // Update is called once per frame
    void Update()
    {
        if(controladorjuego.tiempoActivo && inicio==0){
            Generar(); 
        }
    }

    void Generar(){
        if(inicio!=0){
            Vector2 randomSpawn=new Vector2(Random.Range(-7.4f,7.3f),Random.Range(-2.6f,3.5f));
            Instantiate(misobjs[Random.Range(0,misobjs.Length)], randomSpawn, Quaternion.identity);
        }
        inicio=1;
        if(controladorjuego.tiempoActivo==true){
            Invoke("Generar", Random.Range(tmin,tmax));
        }
       
    }

    public void SetCountText()
	{        
		contador.text = "Puntos: " + puntos.ToString();
        
	}

    
}


