using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//PROGRAMADO POR DAVID VENTAS SANCHEZ 29/01/2023
public class Rotate : MonoBehaviour
{
    [SerializeField] float rotspeed=1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,360*rotspeed*Time.deltaTime);

        if(transform.position.y<-4){
            gameObject.SetActive(false);
        }
    }
}
