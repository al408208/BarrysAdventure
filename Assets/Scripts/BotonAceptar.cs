using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//PROGRAMADO POR DAVID VENTAS SANCHEZ 29/01/2023
public class BotonAceptar : MonoBehaviour
{

    [SerializeField] private ControladorJuego controladorjuego; 
    public Item i;

    public GameObject objetActivable1;
    public GameObject objetActivable2;
    public GameObject objetActivable3;
    public GameObject objetActivable4;


    // Start is called before the first frame update
    void Start()
    {        
        i=FindObjectOfType<Item>();
        objetActivable3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        if(controladorjuego.tiempoActivo==false && i.inicio==1){
            Debug.Log("se pasa a la siguiente escena");
            SceneManager.LoadScene("Towcala");
        }else{
            controladorjuego.ActivarTemporizador();
            objetActivable1.SetActive(false);
            objetActivable2.SetActive(false);
            objetActivable3.SetActive(false);
            objetActivable4.SetActive(false);

            objetActivable4.transform.position=new Vector2(540f,90f);

        }
        
    } 
}