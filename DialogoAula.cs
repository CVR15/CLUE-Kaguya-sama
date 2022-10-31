using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DialogoAula : MonoBehaviour
{
	private int ncaso;
	[SerializeField] TMP_Text dialogos;
	string[] espacioDialogos;
	private string[] casoUnoDialogos = new string[] { "(Ishigami viene saliendo del salón de clases, le preguntaré para acabar esto pronto)...",
														"¿Qué haces aquí Fujiwara?...",
														"Estoy investigando los objetos perdidos del consejo, ¿no sabrás tú algo?...",
														"No, pero si los encuentras me dices si ves el gran globo meteorológico...", 
														"mi salón quería usarlo para el festival pero no logré encontrarlo por ningún lado...",
														"Solo porque es para el festival...",
														"(Parece ser que en el salón no hay nada extraño, seguiré buscando)..." };
	private string[] casoDosDialogos = new string[] { "Que bueno que la veo señorita Fujiwara, ¿no sabrá usted porque está cerrado el salón de clases ? ...",
														"¿Esta cerrado ? Que extraño...",
														"Si, mis amigas y yo íbamos a ensayar una coreografía, la señorita Kaguya nos hizo el favor...", 
														"de prestarnos una grabadora para la música pero no sabemos porque esté cerrado el salón...",
														"Voy a investigarlo Hayasaka, gracias por avisarme..." };
	private string[] casoTresDialogos = new string[] { 	"Presidente que bien que lo veo, ¿sabe algo de los objetos perdidos del consejo?...",
														"Solo se del silbato de Iino, lo encontré hace poco...",
														"Bueno, por lo menos es un objeto menos a buscar, gracias por su ayuda...",
														"No hay de que Fujiwara, por cierto si vez a Iino no le digas que yo tengo su silbato, quiero sorprenderla...",
														"De acuerdo...", };
	private string[] casoCuatroDialogos = new string[] {	"¡Oye tú, no te subas así a la banca!\n¡Tú no estes lanzando esas cosas, tendré que reportarlos...",
															"****Suena un silbato***",
															"Siento que haya tenido que ver esto superiora Fujiwara, es culpa mia por no ejercer bien mi labor de vigilante..",
															"No hay problema Iino, lo bueno es que se controló la situación...",
															"Veo que encontraste el silbato perdido...",
															"Si y justo a tiempo me hacia gran falta en estos casos..."	};
	private string[] casoCincoDialogos = new string[] {     "Kaguya, siento molestarte en el salón de clases pero, ¿sabes algo sobre los objetos perdidos?...",
															"No, pensaba usar el silbato para una dinamica en clase, la que propusimos en el consejo aquella vez...",
															"Pero nadie sabe su ubicación, si lo llegas a encontrar me avisas por favor Chika...",
															"Claro que si Kaguya..."};

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
		if (ncaso == 1 || ncaso == 3 || ncaso == 5) { iconChika.SetActive(true); }
		if (ncaso == 2) { iconHayasaka.SetActive(true); }
		if (ncaso == 4) { iconMiko.SetActive(true); }
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
		if(ncaso ==1)
        {
			switch(contLineaDeDialogo)
            {
				case 1:
					iconChika.SetActive(false);
					iconIshigami.SetActive(true);
					break;
				case 2:
					iconChika.SetActive(true);
					iconIshigami.SetActive(false);
					break;
				case 3:
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
		if(ncaso ==2)
        {
			switch (contLineaDeDialogo)
			{
				case 1:
					iconChika.SetActive(true);
					iconHayasaka.SetActive(false);
					break;
				case 2:
					iconChika.SetActive(false);
					iconHayasaka.SetActive(true);
					break;
				case 4:
					iconChika.SetActive(true);
					iconHayasaka.SetActive(false);
					break;
				default: break;
			}
        }
		if(ncaso ==3)
        {
			switch(contLineaDeDialogo)
            {
				case 1:
					iconChika.SetActive(false);
					iconShirogane.SetActive(true);
					break;
				case 2:
					iconChika.SetActive(true);
					iconShirogane.SetActive(false);
					break;
				case 3:
					iconChika.SetActive(false);
					iconShirogane.SetActive(true);
					break;
				case 4:
					iconChika.SetActive(true);
					iconShirogane.SetActive(false);
					break;
				default: break;
			}
        }
		if(ncaso ==4)
        {
			switch (contLineaDeDialogo)
			{
				case 3:
					iconChika.SetActive(true);
					iconMiko.SetActive(false);
					break;
				case 5:
					iconChika.SetActive(false);
					iconMiko.SetActive(true);
					break;
			}
        }
		if(ncaso ==5)
		{
			switch (contLineaDeDialogo)
			{
				case 1:
					iconChika.SetActive(false);
					iconKaguya.SetActive(true);
					break;
				case 3:
					iconChika.SetActive(true);
					iconKaguya.SetActive(false);
					break;
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
