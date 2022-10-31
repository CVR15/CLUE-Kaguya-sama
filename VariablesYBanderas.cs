using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class VariablesYBanderas : MonoBehaviour
{
    public int intentos=0;
    private string prefabsIntentos = "Intentos";
    private int caso = 0;
    private int[] casosKaguya = new int[] {3,5,1,4,2};
    private int[] casosShirogane = new int[] { 4, 3, 2, 5, 5 };
    private int[] casosIshigami = new int[] { 2, 1, 5, 3, 4 };
    private int[] casosHayasaka = new int[] { 5, 2, 4, 1, 3 };
    private int[] casosMiko = new int[] { 1, 4, 3, 2, 1 };
    private int[] casosGloboMet = new int[] { 2, 3, 3, 4, 3 };
    private int[] casosGloboAn = new int[] { 1, 5, 5, 1, 5 };
    private int[] casosPintura = new int[] { 3, 4, 4, 5, 4 };
    private int[] casosGrabadora = new int[] { 4, 2, 1, 3, 1 };
    private int[] casosSilbato = new int[] { 5, 1, 2, 2, 2 };

    private string prefabsNumeroDeCaso = "Numero de Caso";
    public void Start()
    {
        intentos = PlayerPrefs.GetInt(prefabsIntentos, 0);
        caso = PlayerPrefs.GetInt(prefabsNumeroDeCaso, 1); 
        Debug.Log("caso Bandera =" + caso);
        if(intentos >= 5)
        {
            SceneManager.LoadScene(9);
        }
    }

    public void AumentaIntentos()
    {
        intentos++;
        Debug.Log("Llevamos " + intentos + "intentos");
    }
    public int RetornoCaso()
    {
        return caso;
    }
    private void GuardarIntentos(int intentosActuales)
    {
        PlayerPrefs.SetInt(prefabsIntentos, intentosActuales);
    }
    public void Kaguya()
    {
        AumentaIntentos();
        GuardarIntentos(intentos);
        SceneManager.LoadScene(casosKaguya[caso - 1] + 3);
    }
    public void Shirogane()
    {
        AumentaIntentos();
        GuardarIntentos(intentos);
        SceneManager.LoadScene(casosShirogane[caso - 1] + 3);
    }
    public void Ishigami()
    {
        AumentaIntentos();
        GuardarIntentos(intentos);
        SceneManager.LoadScene(casosIshigami[caso - 1] + 3);
    }
    public void Hayasaka()
    {
        AumentaIntentos();
        GuardarIntentos(intentos);
        SceneManager.LoadScene(casosHayasaka[caso - 1] + 3);
    }
    public void Miko()
    {
        AumentaIntentos();
        GuardarIntentos(intentos);
        SceneManager.LoadScene(casosMiko[caso - 1] + 3);
    }
    public void GloboMet()
    {
        AumentaIntentos();
        GuardarIntentos(intentos);
        SceneManager.LoadScene(casosGloboMet[caso - 1] + 3);
    }
    public void GloboAn()
    {
        AumentaIntentos();
        GuardarIntentos(intentos);
        SceneManager.LoadScene(casosGloboAn[caso - 1] + 3);
    }
    public void Pintura()
    {
        AumentaIntentos();
        GuardarIntentos(intentos);
        SceneManager.LoadScene(casosPintura[caso - 1] + 3);
    }
    public void Grabadora()
    {
        AumentaIntentos();
        GuardarIntentos(intentos);
        SceneManager.LoadScene(casosGrabadora[caso - 1] + 3);
    }
    public void Silbato()
    {
        AumentaIntentos();
        GuardarIntentos(intentos);
        SceneManager.LoadScene(casosSilbato[caso - 1] + 3);
    }
    public void Consejo()
    {
        AumentaIntentos();
        GuardarIntentos(intentos);
        SceneManager.LoadScene(4);
    }
    public void Aula()
    {
        AumentaIntentos();
        GuardarIntentos(intentos);
        SceneManager.LoadScene(5);
    }
    public void Gimnasia()
    {
        AumentaIntentos();
        GuardarIntentos(intentos);
        SceneManager.LoadScene(6);
    }
    public void Karaoke()
    {
        AumentaIntentos();
        GuardarIntentos(intentos);
        SceneManager.LoadScene(7);
    }
    public void Festival()
    {
        AumentaIntentos();
        GuardarIntentos(intentos);
        SceneManager.LoadScene(8);
    }
}
