using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
//PROGRAMADO POR DAVID VENTAS SANCHEZ 29/01/2023
public class ControladorPuzzle : MonoBehaviour
{

    public TextMeshProUGUI info;

    public float tiempoActual; 
    public bool tiempoActivo=false;
    public int puntos;
    public int mins=0;
    public int seconds=0;
    int aux=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(tiempoActivo){
            CambiarContador();
            if((int)tiempoActual!=0){
               SetTimeText();
            }
            
        }
    }

    private void CambiarContador(){
        tiempoActual+=Time.deltaTime;
        
    }

    private void CambiarTemporizador(bool estado){
        tiempoActivo=estado;
    }

    public void ActivarTemporizador(){
        CambiarTemporizador(true);
    }

    public void DesactivarTemporizador(){
        CambiarTemporizador(false);
    }

    public void SetTimeText()
	{    
        seconds = (int)tiempoActual % 60; 
        if((int)tiempoActual % 60==0 && aux==0){
            mins+=1;
            aux=1;
        }
        if( seconds>=2){
            aux=0;
        }
        
        info.text =mins.ToString()+ ":"+seconds.ToString();

	}
}
