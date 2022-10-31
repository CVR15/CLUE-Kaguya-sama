using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicioCasos : MonoBehaviour
{
    private int caso;
    private string prefabsNumeroDeCaso = "Numero de Caso";
    void Start()
    {
        caso = Random.Range(1, 5);
        if (caso < 1 || caso > 5)
        {
            caso = 1;
        }
        PlayerPrefs.SetInt(prefabsNumeroDeCaso, caso);
        Debug.Log("Subió caso = " + caso);
    }

    public int RetornoCaso()
    {
        return caso;
    }


}
