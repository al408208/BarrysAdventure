using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//PROGRAMADO POR DAVID VENTAS SANCHEZ 29/01/2023
public class Spawner : MonoBehaviour
{

    [SerializeField] GameObject enemyPrefab;
    List<GameObject> enemilist;
    [SerializeField] GameObject pointPrefab;
    List<GameObject> pointlist;

    [SerializeField] float spwanTime=1;
    float timer;
    [SerializeField] Transform limitD;
    [SerializeField] Transform limitI;

    public bool stop;
    public GameObject objetActivable1;
    public GameObject objetActivable2;
    // Start is called before the first frame update
    void Start()
    {
        objetActivable1.SetActive(false);
        objetActivable2.SetActive(false);
        enemilist=new List<GameObject>();
        pointlist=new List<GameObject>();
        timer=spwanTime;
    }

    // Update is called once per frame
    void Update()
    {
        // Camera has fixed width and height on every screen solution
        if(!stop){
            timer-=Time.deltaTime;

            if(timer<0){
                Spawn();
            }
        }
        
        
    }

    void Spawn()
    {
        Vector2 spawnPos= new Vector2(Random.Range(limitI.position.x, limitD.position.x), transform.position.y);
        
        int rndType=Random.Range(0,3);
        if(rndType==0){
            GameObject newPoint=getFirstPointNoActive();
            newPoint.transform.position=spawnPos;
            newPoint.SetActive(true);
        }else{
            GameObject newEnemy=getFirstEnmyNoActive();
            newEnemy.transform.position=spawnPos;
            newEnemy.SetActive(true);
        }
        
        
        timer=spwanTime;
    }

    GameObject getFirstEnmyNoActive(){
        for(int i=0; i<enemilist.Count;i++){
            if(!enemilist[i].activeInHierarchy){
                return enemilist[i];
            }
        }
        return createEnemy();
    }

    GameObject createEnemy(){
        GameObject newEnemy= Instantiate(enemyPrefab);
        newEnemy.transform.parent=gameObject.transform;
        newEnemy.SetActive(false);
        enemilist.Add(newEnemy);
        return newEnemy;
    }


    GameObject getFirstPointNoActive(){
        for(int i=0; i<pointlist.Count;i++){
            if(!pointlist[i].activeInHierarchy){
                return pointlist[i];
            }
        }
        return createPoint();
    }
    GameObject createPoint(){
        GameObject newPoint= Instantiate(pointPrefab);
        newPoint.transform.parent=gameObject.transform;
        newPoint.SetActive(false);
        pointlist.Add(newPoint);
        return newPoint;
    }
}
