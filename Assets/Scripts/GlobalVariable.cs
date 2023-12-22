using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariable : MonoBehaviour
{
    // Start is called before the first frame update
    public static int zonaActual = 0;
    string[] secuencia = new string[6]
    {"top","left","bottom","top","right","right"};

    public static List<string> ActivesItems = new();
}
