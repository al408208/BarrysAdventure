using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;
//PROGRAMADO POR DAVID VENTAS SANCHEZ 29/01/2023
public class PlayerMinijuego : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Transform limitD;
    [SerializeField] Transform limitI;
    Animator animator;
    private bool cambiar=false;

    bool isInfected,isWin;
    [SerializeField] Color infectedColor;
    [SerializeField] Color saveColor;
    SpriteRenderer srpiteRende;
    public TextMeshProUGUI contador;
    int puntos;
    
    public TextMeshProUGUI info;
    public GameObject objetActivable1;
    public GameObject objetActivable2;

    private void Awake(){
        srpiteRende=GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        animator=gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if(isInfected||isWin){
            
            if(isWin){
                SetInfoText("!Lo has logrado!" +"\n"+"Pulsa la E para continuar." );
                if(Input.GetKeyDown(KeyCode.E)){
                    //SceneManager.LoadScene("JuegoFinal");
                    Debug.Log("se pasa a la siguiente escena");
                    SceneManager.LoadScene("Fin");
                }
            }else{
                if(Input.GetKeyDown(KeyCode.E)){
                    SceneManager.LoadScene("JuegoFinal");
                }
            }
            objetActivable1.SetActive(true);
            objetActivable2.SetActive(true);
            
        }else{
            if(Input.GetMouseButtonDown(0)){
            cambiar=!cambiar;
            ChangeDirect();
            }
            transform.position= new Vector2(transform.position.x+speed*Time.deltaTime,transform.position.y);
            if(transform.position.x>=limitD.position.x){
                cambiar=true;
                transform.position= new Vector2(limitD.position.x,transform.position.y);   
                ChangeDirect();
            }

            if(transform.position.x<limitI.position.x){
                cambiar=false;
                transform.position= new Vector2(limitI.position.x,transform.position.y);
                ChangeDirect();
            }
            
        }
        
    }

    void ChangeDirect(){
        animator.SetBool("cambio",cambiar);
        speed=-speed;
    }


    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("enemy")){
            isInfected=true;
            animator.SetBool("Infected",isInfected);
            srpiteRende.color=infectedColor;
            collision.gameObject.GetComponentInParent<Spawner>().stop=true;
            collision.gameObject.SetActive(false);
        }
        if(collision.CompareTag("point")){

            if(!isInfected){
                puntos++;
                SetCountText(); 
                collision.gameObject.SetActive(false);
            }

            if(puntos==6){
                isWin=true;
                animator.SetBool("Infected",isWin);
                srpiteRende.color=saveColor;
                collision.gameObject.GetComponentInParent<Spawner>().stop=true;
            }
            
        }
    }

    public void SetCountText()
	{        
		contador.text = puntos.ToString()+"/6";
        
	}
    public void SetInfoText(string newInfo)
	{        
		info.text =newInfo.ToString();
        
	}

}
