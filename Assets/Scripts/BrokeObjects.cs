using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokeObjects : MonoBehaviour
{
    public string itemNameNeeded;
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        float interaction = Input.GetAxis("Interaction");
        if (interaction != 0)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                foreach (string tool in GlobalVariable.ActivesItems)
                {
                    if(tool == itemNameNeeded) this.gameObject.SetActive(false);
                }
                
            }
        }
    }
}