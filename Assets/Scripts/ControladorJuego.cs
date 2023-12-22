using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
//PROGRAMADO POR DAVID VENTAS SANCHEZ 29/01/2023
public class ControladorJuego : MonoBehaviour
{

    public GameObject objetActivable1;
    public GameObject objetActivable2;
    public GameObject objetActivable3;
    public GameObject objetActivable4;

    public TextMeshProUGUI info;
    public Item i;

    [SerializeField] private float tiempoMaximo; 
    [SerializeField] private Slider slider; 
    private float tiempoActual; 
    public bool tiempoActivo=false;
    // Start is called before the first frame update
    void Start()
    {
        i=FindObjectOfType<Item>();
    }

    // Update is called once per frame
    void Update()
    {
        if(tiempoActivo){
            CambiarContador();
        }
    }

    private void CambiarContador(){
        tiempoActual-=Time.deltaTime;
        if(tiempoActual>=0){
            slider.value=tiempoActual;
        }
        if(tiempoActual<=0){
            objetActivable1.SetActive(true);
            objetActivable2.SetActive(true);
            objetActivable2.transform.position=new Vector2(-2.5f,-1.9f);
            objetActivable3.SetActive(true);
            objetActivable4.SetActive(true);
            CambiarTemporizador(false);
            if(i.puntos<100){
                SetInfoText("Vaya no has alzanzado la puntuación necesaria para avanzar, intentalo de nuevo");
                objetActivable2.SetActive(false);
                objetActivable3.transform.position=new Vector2(-0.28f,-1.9f);
            }else if(i.puntos>=100 && i.puntos<150){
                SetInfoText("Enhorabuena has conseguido la puntuación de bronce para avanzar a la siguiente zona");
            }else if(i.puntos>=150 && i.puntos<200){
                SetInfoText("Enhorabuena has conseguido la puntuación de plata para avanzar a la siguiente zona");
            }else if(i.puntos>=200){
                SetInfoText("Enhorabuena has conseguido la puntuación de oro para avanzar a la siguiente zona");
            }
        }
    }

    private void CambiarTemporizador(bool estado){
        tiempoActivo=estado;
    }

    public void ActivarTemporizador(){
        tiempoActual=tiempoMaximo;
        slider.maxValue=tiempoMaximo;
        CambiarTemporizador(true);
    }

    public void DesactivarTemporizador(){
        CambiarTemporizador(false);
    }

    public void SetInfoText(string newInfo)
	{        
		info.text =newInfo.ToString();
        
	}
}
