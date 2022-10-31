using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SeleccionFinal : MonoBehaviour
{
    private string prefabsSPersona = "Sospechoso Persona";
    private string prefabsSObjeto = "Sospechoso Objeto";
    private string prefabsSLugar = "Sospechoso Lugar";
    private int sPersona=1;
    private int sObjeto=3;
    private int sLugar=3;
    private string prefabsExito= "Acierto";
    private int exito;
    private string prefabsNumeroDeCaso = "Numero de Caso";
    private int caso;
    [SerializeField] GameObject flechaKaguya;
    [SerializeField] GameObject flechaShirogane;
    [SerializeField] GameObject flechaIshigami;
    [SerializeField] GameObject flechaHayasaka;
    [SerializeField] GameObject flechaMiko;
    //---------------------------------------//
    [SerializeField] GameObject flechaGloboMet;
    [SerializeField] GameObject flechaGloboAn;
    [SerializeField] GameObject flechaPintura;
    [SerializeField] GameObject flechaGrabadora;
    [SerializeField] GameObject flechaSilbato;
    //--------------------------------------//
    [SerializeField] GameObject flechaConsejo;
    [SerializeField] GameObject flechaAula;
    [SerializeField] GameObject flechaGimnasia;
    [SerializeField] GameObject flechaKaraoke;
    [SerializeField] GameObject flechaFestival;
    
    private void Start()
    {
        ActualizaSospechosos();
        PlayerPrefs.DeleteKey(prefabsExito);
        caso = PlayerPrefs.GetInt(prefabsNumeroDeCaso, 1);
    }
    private void ActualizaSospechosos()
    {
        PlayerPrefs.SetInt(prefabsSPersona, sPersona);
        PlayerPrefs.SetInt(prefabsSObjeto, sObjeto);
        PlayerPrefs.SetInt(prefabsSLugar, sLugar);
    }

    public void SelKaguya()
    {
        flechaKaguya.SetActive(true);
        flechaShirogane.SetActive(false); 
        flechaIshigami.SetActive(false); 
        flechaHayasaka.SetActive(false); 
        flechaMiko.SetActive(false);
        sPersona = 1;
        ActualizaSospechosos();
    }
    public void SelShirogane()
    {
        flechaKaguya.SetActive(false);
        flechaShirogane.SetActive(true);
        flechaIshigami.SetActive(false);
        flechaHayasaka.SetActive(false);
        flechaMiko.SetActive(false);
        sPersona = 2;
        ActualizaSospechosos();
    }
    public void SelIshigami()
    {
        flechaKaguya.SetActive(false);
        flechaShirogane.SetActive(false);
        flechaIshigami.SetActive(true);
        flechaHayasaka.SetActive(false);
        flechaMiko.SetActive(false);
        sPersona = 3;
        ActualizaSospechosos();
    }
    public void SelHayasaka()
    {
        flechaKaguya.SetActive(false);
        flechaShirogane.SetActive(false);
        flechaIshigami.SetActive(false);
        flechaHayasaka.SetActive(true);
        flechaMiko.SetActive(false);
        sPersona = 4;
        ActualizaSospechosos();
    }
    public void SelMiko()
    {
        flechaKaguya.SetActive(false);
        flechaShirogane.SetActive(false);
        flechaIshigami.SetActive(false);
        flechaHayasaka.SetActive(false);
        flechaMiko.SetActive(true);
        sPersona = 5;
        ActualizaSospechosos();
    }
    public void SelGloboMet()
    {
        flechaGloboMet.SetActive(true);
        flechaGloboAn.SetActive(false);
        flechaPintura.SetActive(false);
        flechaGrabadora.SetActive(false);
        flechaSilbato.SetActive(false);
        sObjeto = 1;
        ActualizaSospechosos();
    }
    public void SelGloboAn()
    {
        flechaGloboMet.SetActive(false);
        flechaGloboAn.SetActive(true);
        flechaPintura.SetActive(false);
        flechaGrabadora.SetActive(false);
        flechaSilbato.SetActive(false);
        sObjeto = 2;
        ActualizaSospechosos();
    }
    public void SelPintura()
    {
        flechaGloboMet.SetActive(false);
        flechaGloboAn.SetActive(false);
        flechaPintura.SetActive(true);
        flechaGrabadora.SetActive(false);
        flechaSilbato.SetActive(false);
        sObjeto = 3;
        ActualizaSospechosos();
    }
    public void SelGrabadora()
    {
        flechaGloboMet.SetActive(false);
        flechaGloboAn.SetActive(false);
        flechaPintura.SetActive(false);
        flechaGrabadora.SetActive(true);
        flechaSilbato.SetActive(false);
        sObjeto = 4;
        ActualizaSospechosos();
    }
    public void SelSilbato()
    {
        flechaGloboMet.SetActive(false);
        flechaGloboAn.SetActive(false);
        flechaPintura.SetActive(false);
        flechaGrabadora.SetActive(false);
        flechaSilbato.SetActive(true);
        sObjeto = 1;
        ActualizaSospechosos();
    }
    public void SelConsejo()
    {
        flechaConsejo.SetActive(true);
        flechaAula.SetActive(false);
        flechaGimnasia.SetActive(false);
        flechaKaraoke.SetActive(false);
        flechaFestival.SetActive(false);
        sLugar = 1;
        ActualizaSospechosos();
    }
    public void SelAula()
    {
        flechaConsejo.SetActive(false);
        flechaAula.SetActive(true);
        flechaGimnasia.SetActive(false);
        flechaKaraoke.SetActive(false);
        flechaFestival.SetActive(false);
        sLugar = 2;
        ActualizaSospechosos();
    }
    public void SelGimnasia()
    {
        flechaConsejo.SetActive(false);
        flechaAula.SetActive(false);
        flechaGimnasia.SetActive(true);
        flechaKaraoke.SetActive(false);
        flechaFestival.SetActive(false);
        sLugar = 3;
        ActualizaSospechosos();
    }
    public void SelKaraoke()
    {
        flechaConsejo.SetActive(false);
        flechaAula.SetActive(false);
        flechaGimnasia.SetActive(false);
        flechaKaraoke.SetActive(true);
        flechaFestival.SetActive(false);
        sLugar = 4;
        ActualizaSospechosos();
    }
    public void SelFestival()
    {
        flechaConsejo.SetActive(false);
        flechaAula.SetActive(false);
        flechaGimnasia.SetActive(false);
        flechaKaraoke.SetActive(false);
        flechaFestival.SetActive(true);
        sLugar = 5;
        ActualizaSospechosos();
    }

    public void ConfirmarSelecciones()
    {
        sPersona = PlayerPrefs.GetInt(prefabsSPersona);
        sLugar = PlayerPrefs.GetInt(prefabsSLugar);
        sObjeto = PlayerPrefs.GetInt(prefabsSObjeto);
        caso = PlayerPrefs.GetInt(prefabsNumeroDeCaso);
        if (sPersona == caso && sLugar == caso && sObjeto == caso)
        {
            exito = 1;
            PlayerPrefs.SetInt(prefabsExito, exito);
            Debug.Log("C"+caso + ""+ sPersona + "" + sLugar + "" + sObjeto );
        }
        else
        {
            exito = 0;
            PlayerPrefs.SetInt(prefabsExito, exito);
            Debug.Log("C" + caso + "" + sPersona + "" + sLugar + "" + sObjeto);
        }
        SceneManager.LoadScene(10);
    }
}
