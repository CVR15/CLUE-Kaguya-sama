using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    private float velocidadTexto;
    private string prefabsVelocidadTexto = "Velocidad de Texto";
    private string prefabsExito = "Acierto";
    private string prefabsSPersona = "Sospechoso Persona";
    private string prefabsSObjeto = "Sospechoso Objeto";
    private string prefabsSLugar = "Sospechoso Lugar";
    private string prefabsIntentos = "Intentos";
    public void IniciaJuego()
    {
        SceneManager.LoadScene(1);
        PlayerPrefs.DeleteKey(prefabsExito);
        PlayerPrefs.DeleteKey(prefabsSPersona);
        PlayerPrefs.DeleteKey(prefabsSObjeto);
        PlayerPrefs.DeleteKey(prefabsSLugar);
        PlayerPrefs.DeleteKey(prefabsIntentos);
    }

    public void Salir()
    {
        Application.Quit();
        Debug.Log("Saliendo...");
    }

    public void VelocidadAlta()
    {
        velocidadTexto = 0.01f;
        PlayerPrefs.SetFloat(prefabsVelocidadTexto, velocidadTexto);
    }
    public void VelocidadBaja()
    {
        velocidadTexto = 0.05f;
        PlayerPrefs.SetFloat(prefabsVelocidadTexto, velocidadTexto);
    }
}
