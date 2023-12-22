using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventary : MonoBehaviour
{
    public List<GameObject> Invetory = new List<GameObject>();

    private void OnCollisionStay2D(Collision2D collision)
    {
        float interaction = Input.GetAxis("Interaction");

        if (interaction != 0)
        {
            if (collision.gameObject.CompareTag("item"))
            {
                Invetory.Add(collision.gameObject);
                collision.gameObject.SetActive(false);
            }
            if (collision.gameObject.CompareTag("piedra"))
            {
                for (int i = 0; i < Invetory.Count; i++)
                    if (Invetory[i].name == "pala")
                    {
                        collision.gameObject.SetActive(false);
                    }
            }
        }
    }

}
