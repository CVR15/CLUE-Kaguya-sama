using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DialogoGimnasio : MonoBehaviour
{
	private int ncaso;
	[SerializeField] TMP_Text dialogos;
	string[] espacioDialogos;
	private string[] casoUnoDialogos = new string[] {	"No puedo encontrar a Kaguya por ningún lado pero parece que ya encontré la pintura...", 
														"los chicos de primero la están usando para hacer carteles en el gimnasio para apoyar a los equipos durante el festival..." };
	private string[] casoDosDialogos = new string[] {	"Según me dijeron el presidente Shirogane debería de estar en clase de gimnasia, pero no lo veo", 
														"aunque por lo menos ya encontré un objeto perdido  ",
														"el profesor de gimnasia ideó un juego nuevo usando el gran globo meteorológico..." };
	private string[] casoTresDialogos = new string[] { "¿Iino puedes venir acá un momento?...",
														"Claro que sí superiora Fujiwara,¿Sucedea algo?...",
														"Si pero no es grave, ¿sabes algo sobre los objetos perdidos del consejo'...",
														"Solo se que el profesor de Gimnasia usará el gran globo meteorológico para un nuevo juego hoy...",
														"Y que la cancha esta cerrada con llave lo cual es muy extraño, por eso estamos practicando afuera...",
														"Con eso ya me ayudas a resolver el misterio, gracias Iino..."};
	private string[] casoCuatroDialogos = new string[] {	"Parece ser que el salón de Ishigami esta en clase de gimnasia, le preguntaré rápido si sabe algo...",
															"Hey Ishigami, ¿has sabido algo sobre los objetos perdidos?...",
															"No, pero me gustaría, hoy en la clase de Gimnasia usariamos la grabadora para una actividad pero desapareció...",
															"Pocas veces me entusiasma una nueva actividad y no pudimos llevarla a cabo...",
															"Me voy a casa...",
															"Cielos, no pensé que se fuera a poner así..."
															};
	private string[] casoCincoDialogos = new string[] { "¿Hayasaka puedo hablar contigo un momento?...",
														"Claro que sí señorita Fujiwara,¿Sucedea algo?...",
														"Si pero no es grave, ¿sabes algo sobre los objetos perdidos del consejo'...",
														"Solo se que el profesor de Gimnasia usará el gran globo meteorológico para un nuevo juego hoy...",
														"Luce bastante prometedora la nueva actividad, parece que ya va a comenzar...",
														"Ya puedes regresar, gracias por tu ayuda" };

	private int contLineaDeDialogo;
	private float velocidadTexto;
	private string prefabsVelocidadTexto = "Velocidad de Texto";
	private string prefabsNumeroDeCaso = "Numero de Caso";

	[SerializeField] GameObject iconChika;
	[SerializeField] GameObject iconKaguya;
	[SerializeField] GameObject iconShirogane;
	[SerializeField] GameObject iconIshigami;
	[SerializeField] GameObject iconMiko;
	[SerializeField] GameObject iconHayasaka;
	void Start()
	{
		ncaso = PlayerPrefs.GetInt(prefabsNumeroDeCaso, 1);
		velocidadTexto = PlayerPrefs.GetFloat(prefabsVelocidadTexto, 0.05f);
		switch (ncaso)
		{
			case 1:
				espacioDialogos = casoUnoDialogos;
				break;
			case 2:
				espacioDialogos = casoDosDialogos;
				break;
			case 3:
				espacioDialogos = casoTresDialogos;
				break;
			case 4:
				espacioDialogos = casoCuatroDialogos;
				break;
			case 5:
				espacioDialogos = casoCincoDialogos;
				break;
			default:
				espacioDialogos = casoUnoDialogos;
				break;
		}
		IniciaDialogo();
	}
	void Update()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			if (dialogos.text == espacioDialogos[contLineaDeDialogo])
			{
				SiguienteDialogo();
			}
			else
			{
				StopAllCoroutines();
				dialogos.text = espacioDialogos[contLineaDeDialogo];
			}
		}

	}

	private void IniciaDialogo()
	{
		contLineaDeDialogo = 0;
		StartCoroutine(ShowLine());
		if (ncaso >= 1 && ncaso<=5) { iconChika.SetActive(true); }
	}

	private void SiguienteDialogo()
	{
		contLineaDeDialogo++;
		if (contLineaDeDialogo < espacioDialogos.Length)
		{
			StartCoroutine(ShowLine());
		}
		else
		{
			Debug.Log("Fin de los comentarios   " + espacioDialogos.Length);
			SceneManager.LoadScene(3);
		}
		if (ncaso == 1)
		{
			switch (contLineaDeDialogo)
			{
				default: break;
			}
		}
		if (ncaso == 2)
        {
			switch(contLineaDeDialogo)
            {
				default: break;
            }
        }
		if (ncaso == 3)
        {
			switch (contLineaDeDialogo)
            {
				case 1:
					iconChika.SetActive(false);
					iconMiko.SetActive(true);
					break;
				case 2:
					iconChika.SetActive(true);
					iconMiko.SetActive(false);
					break;
				case 3:
					iconChika.SetActive(false);
					iconMiko.SetActive(true);
					break;
				case 5:
					iconChika.SetActive(true);
					iconMiko.SetActive(false);
					break;
				default: break;
			}
        }
		if (ncaso == 4)
        {
			switch(contLineaDeDialogo)
            {
				case 2:
					iconChika.SetActive(false);
					iconIshigami.SetActive(true);
					break;
				case 5:
					iconChika.SetActive(true);
					iconIshigami.SetActive(false);
					break;
				default: break;
			}
        }			
	}

	private IEnumerator ShowLine()
	{
		dialogos.text = string.Empty;
		foreach (char ch in espacioDialogos[contLineaDeDialogo])
		{
			dialogos.text += ch;
			yield return new WaitForSeconds(velocidadTexto);
		}
	}
}
