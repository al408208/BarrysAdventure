using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
//PROGRAMADO POR DAVID VENTAS SANCHEZ 29/01/2023
public class Puzzle : MonoBehaviour
{
    public NumberBox boxPrefab;
    public NumberBox [,] boxes =new NumberBox[3,3];
    public Sprite [] sprites;  

    [SerializeField] private ControladorPuzzle controladorPuzzle; 
    public GameObject objetActivable1;
    public GameObject objetActivable2;
    public GameObject objetActivable3;
    public GameObject objetActivable4;
    public int ganador=0;

    public TextMeshProUGUI info;
    
    public int inicio=0;

    void Start()
    {
        
        controladorPuzzle=FindObjectOfType<ControladorPuzzle>();
    }

    void Update()
    {
        if(controladorPuzzle.tiempoActivo && inicio==0){
            Init();
            inicio=1;
            objetActivable4.SetActive(true);
            for (int i = 0; i<100; i++){
                Mezclar();
            }
        }
        
        
    }

    public void Init(){
        int n=0;
        for (int y = 2; y>=0; y--)
        {
            for (int x = 0; x<3; x++){
                NumberBox box= Instantiate(boxPrefab, new Vector2(x,y),Quaternion.identity);
                box.Init(x,y,n+1,sprites[n],ClickToSwap); 
                boxes[x,y]=box;
                n++;
            }
        } 

         
    }
    void ClickToSwap(int x,int y){
        int dx=getDx(x,y);
        int dy=getDy(x,y);
        Swap(x,y,dx,dy);
        if(IsWin()==true){
            Invoke("Victoria", 1);
            
        }
    }

    void Swap(int x,int y,int dx, int dy){
        
        
        var from =boxes[x,y];
        var target=boxes[x+dx,y+dy];

        //cambio piezas

        boxes[x,y]=target;
        boxes[x+dx,y+dy]=from;

        //update

        from.UpdatePos(x+dx,y+dy);
        target.UpdatePos(x,y);
    }

    int getDx(int x,int y){
        //libre derecha
        if(x<2 && boxes[x+1,y].IsEmpty()){
            return 1;
        }

        //libre izquierda

        if(x>0 && boxes[x-1,y].IsEmpty()){
            return -1;
        }
        return 0;
    }

    int getDy(int x,int y){

        //libre arriba
        if(y<2 && boxes[x,y+1].IsEmpty()){
            return 1;
        }

        //libre abajo

        if(y >0 && boxes[x,y-1].IsEmpty()){
            return -1;
        }
        return 0;
    }

    void Mezclar(){

        for (int i = 0; i<3; i++)
        {
            for (int j = 0; j<3; j++){

                if(boxes[i,j].IsEmpty()){
                    Vector2 pos=getValidMove(i,j);
                    Swap(i,j,(int)pos.x,(int)pos.y);
                }
            }
        }
    }

    
    public bool IsWin(){
        bool ganador=true;
        int cont=7;
        for (int i = 0; i<3; i++)
        {
            for (int j = 0; j<3; j++){

                if(boxes[j,i].index!=cont){
                    return ganador=false;
                }
                cont++;
            }
            cont-=6;
        }
        return ganador;
    }

    private Vector2 lastMove;

    Vector2 getValidMove(int x , int y){
        Vector2 pos=new Vector2();
        do{        
            int n=Random.Range(0,4);
            if(n==0){
                pos=Vector2.left;
            }else if(n==1){
                pos=Vector2.right;
            }else if(n==2){
                pos=Vector2.up;
            }else{
                pos=Vector2.down;
            }
        }while(!(isValid(x+(int)pos.x) && isValid(y+(int)pos.y)) || isRepeatMove(pos));
        lastMove=pos;
        return pos;
    }
    
    bool isValid(int n){
        return n>=0 && n<=2;
    } 

    bool isRepeatMove(Vector2 pos){
        return pos*-1==lastMove; 
    }
    public void SetInfoText(string newInfo)
	{        
		info.text =newInfo.ToString();
        
	}

    public void Victoria(){
        for (int i = 0; i<3; i++)
        {
            for (int j = 0; j<3; j++){
                
                boxes[j,i].SeñalWin();
                
            }
        }
        int k =(int)controladorPuzzle.tiempoActual;
        objetActivable1.SetActive(true);
        objetActivable2.SetActive(true);
        objetActivable3.SetActive(true);
        objetActivable4.SetActive(false);
        controladorPuzzle.DesactivarTemporizador();
        if(k<65){
            SetInfoText("Enhorabuena consigues la medalla de ORO porque has tardado "+k+  
            " segundos en completar el puzzle" );
        }else if(k>=65 && k<120){
            SetInfoText("Enhorabuena consigues la medalla de PLATA porque has tardado "+k+  
            " segundos en completar el puzzle" );
        }else if(k>=120){
            SetInfoText("Enhorabuena consigues la medalla de BRONCE porque has tardado "+k+  
            " segundos en completar el puzzle" );
        }
    }
}
