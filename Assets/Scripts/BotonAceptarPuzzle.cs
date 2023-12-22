using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//PROGRAMADO POR DAVID VENTAS SANCHEZ 29/01/2023
public class BotonAceptarPuzzle : MonoBehaviour
{
    [SerializeField] private ControladorPuzzle controladorPuzzle;
    [SerializeField] private Puzzle puzzle;
    public GameObject objetActivable1;
    public GameObject objetActivable2;
    public GameObject objetActivable3;
    public GameObject objetActivable4;
    // Start is called before the first frame update
    void Start()
    {
        puzzle=FindObjectOfType<Puzzle>();
        objetActivable4.SetActive(false);
    }

    void OnMouseDown()
    {
        if(controladorPuzzle.tiempoActivo==false && puzzle.inicio==1){
            Debug.Log("se pasa a la siguiente escena");
            SceneManager.LoadScene("Skyran");
        }else{
            controladorPuzzle.ActivarTemporizador();
            objetActivable1.SetActive(false);
            objetActivable2.SetActive(false);
            objetActivable3.SetActive(false);

            objetActivable3.transform.position=new Vector2(410f,220f);
        }
       
    } 
}
