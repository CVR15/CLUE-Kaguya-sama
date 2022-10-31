using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PFinal : MonoBehaviour
{
	string espacioDialogos;
	private string casoUnoDialogos = 	"Maldita Fujiwara, quería sorprender al presidente llenando el globo de pequeños corazones" ;
	private string casoDosDialogos = 	"Yo solo quería mostrarle a Kaguya mis nuevas habilidades con los globos haciendo figuras" ;
	private string casoTresDialogos = 	"Solo era una pequeña broma, y era para Iino...Me quiero ir a casa" ;
	private string casoCuatroDialogos = "Que aguafiestas, solo queria mostarle al presidente que tambien mejore mi rap" ;
	private string casoCincoDialogos = 	"Pero si no era una broma, el consejo de corregir su conducta, somos la cara de la escuela" ;

	[SerializeField] GameObject PanelVictoria;
	[SerializeField] GameObject PanelDerrota;
	[SerializeField] TMP_Text dialogos;
	[SerializeField] GameObject iconKaguya;
	[SerializeField] GameObject iconShirogane;
	[SerializeField] GameObject iconIshigami;
	[SerializeField] GameObject iconMiko;
	[SerializeField] GameObject iconHayasaka;

	private string prefabsExito = "Acierto";
    private int exito;
	private string prefabsNumeroDeCaso = "Numero de Caso";
	private int ncaso;

	private void Start()
    {
        exito = PlayerPrefs.GetInt(prefabsExito, 0);
		ncaso = PlayerPrefs.GetInt(prefabsNumeroDeCaso);
		Debug.Log(exito);
		CambioFinal();
		dialogos.text = espacioDialogos;
	}

	private void CambioFinal()
	{
		if (exito == 1)
		{
			PanelVictoria.SetActive(true);
			PanelDerrota.SetActive(false);
			switch (ncaso)
			{
				case 1:
					espacioDialogos = casoUnoDialogos;
					iconKaguya.SetActive(true);
					break;
				case 2:
					espacioDialogos = casoDosDialogos;
					iconShirogane.SetActive(true);
					break;
				case 3:
					espacioDialogos = casoTresDialogos;
					iconIshigami.SetActive(true);
					break;
				case 4:
					espacioDialogos = casoCuatroDialogos;
					iconHayasaka.SetActive(true);
					break;
				case 5:
					espacioDialogos = casoCincoDialogos;
					iconMiko.SetActive(true);
					break;
				default:
					espacioDialogos = casoUnoDialogos;
					iconKaguya.SetActive(true);
					break;
			}
		}
		else
		{
			PanelVictoria.SetActive(true);
			PanelDerrota.SetActive(false);
		}
	}

	public void Reinicio()
    {
		SceneManager.LoadScene(0);
    }
}
