using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogoPSospechosos : MonoBehaviour
{
	[SerializeField] TMP_Text dialogos;
	private string[] espacioDialogos = new string[] {       "Comencemos por el principio, esta nota solo pudo haber sido puesta por algun miembro del consejo...",
															"Lo cual nos deja con 4 sospechosos...o talvez cinco si contamos a la última persona en venir...",
															"\n¡Ai Hayasaka!...",
							 								"Solo se que vino a ver a Kaguya mas temprano, aunque no sabía que se conocieran...",
															"Analicemos cada uno de nuestros sospechosos...",
															"\nLa primer sospechosa es...",
															"Mi gran amiga Kaguya Shinomiya, es la única heredera de una gran familia, la segunda mejor del instituto",
															"Y vicepresidenta del consejo estudiantil, la quiero tanto...",
															"Lo cual nos lleva al siguiente sospechoso...",
															"Miyuki Shirogane, el presidente del consejo estudiantil y mejor alumno del instituto, por poco mejor que Kaguya...",
															"Siguiendo con el consejo...",
															"Tenemos a Yu Ishigami, el tesorero del consejo y alumno de 1er año. Sinceramente no nos llevamos muy bien...",
															"Frecuentemente hace comentarios un tanto extraños, pero es bueno en lo que hace...",
															"Después tenemos a la última en añadirse al consejo estudiantil...",
															"La ejemplar Miko Iino, es una alumna de primer año igual que Ishigami pero ella si es responsable...",
															"Es la mejor de su generación como el presidente lo es de la nuestra, me cae muy bien y siempre habla bien de mi...",
															"Y por último tenemos a la enigmatica Ai Hayasaka, no se mucho de ella...solo conozco que va en nuestra generación...",
															"Y que tiene un trabajo de medio tiempo, aunque nunca dice cuál es, es buena alumna pero no destaca en nada más...",
															"Aquí tenemos a nuestros cinco sospechosos...",
															"Ahora pasemos a los posibles lugares donde ocurrirá la broma...",
															"El primer lugar es aquí mismo en el consejo...",
															"El siguiente es en nuestra aula de clases...",
															"El tercero es en la clase de gimnasia...",
															"El cuarto es en el karaoke...",
															"El último lugar es durante el festival deportivo...",
															"También noté que faltan cinco objetos del salón del consejo, estos son...",
															"1.Un gran globo meteorológico...\n2.Una bolsa de globos para hacer animales...",
															"3.Dos latas de pintura...\n4.Una grabadora\n5.Un silbato...",
															"¿Cuál de ellos podrá ser usado en la broma?...",
															"Será mejor darme prisa, calculo que solo tendré 5 intentos para investigar las cosas...",
															"Pero nada es imposible para...\n¡La gran detective Chika Fujiwara!"
															};
	[SerializeField] GameObject iconDetective;
	[SerializeField] GameObject iconKaguya;
	[SerializeField] GameObject iconShirogane;
	[SerializeField] GameObject iconIshigami;
	[SerializeField] GameObject iconMiko;
	[SerializeField] GameObject iconHayasaka;
	[SerializeField] GameObject iconHayasaka_2;
	[SerializeField] GameObject fondoConsejo;
	[SerializeField] GameObject fondoAula;
	[SerializeField] GameObject fondoGimnasia;
	[SerializeField] GameObject fondoKaraoke;
	[SerializeField] GameObject fondoFestival;

	private int contLineaDeDialogo;
	private float velocidadTexto;
	private string prefabsVelocidadTexto = "Velocidad de Texto";
	private string prefabsIntentos = "Intentos";

	void Start()
    {
		IniciaDialogo();
		velocidadTexto = PlayerPrefs.GetFloat(prefabsVelocidadTexto, 0.05f);
		PlayerPrefs.DeleteKey(prefabsIntentos);
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
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
		switch (contLineaDeDialogo)
		{
			case 2:
				iconHayasaka.SetActive(true);
				break;
			case 4:
				iconHayasaka.SetActive(false);
				break;
			case 6:
				iconKaguya.SetActive(true);
				break;
			case 8:
				iconKaguya.SetActive(false);
				break;
			case 9:
				iconShirogane.SetActive(true);
				break;
			case 10:
				iconShirogane.SetActive(false);
				break;
			case 11:
				iconIshigami.SetActive(true);
				break;
			case 13:
				iconIshigami.SetActive(false);
				break;
			case 14:
				iconMiko.SetActive(true);
				break;
			case 16:
				iconMiko.SetActive(false);
				iconHayasaka_2.SetActive(true);
				break;
			case 18:
				iconKaguya.SetActive(true);
				iconShirogane.SetActive(true);
				iconMiko.SetActive(true);
				iconIshigami.SetActive(true);
				iconHayasaka_2.SetActive(true);
				break;
			case 19:
				iconKaguya.SetActive(false);
				iconShirogane.SetActive(false);
				iconMiko.SetActive(false);
				iconIshigami.SetActive(false);
				iconHayasaka_2.SetActive(false);
				break;
			case 21:
				fondoConsejo.SetActive(false);
				fondoAula.SetActive(true);
				break;
			case 22:
				fondoAula.SetActive(false);
				fondoGimnasia.SetActive(true);
				break;
			case 23:
				fondoGimnasia.SetActive(false);
				fondoKaraoke.SetActive(true);
				break;
			case 24:
				fondoKaraoke.SetActive(false);
				fondoFestival.SetActive(true);
				break;
			case 25:
				fondoFestival.SetActive(false);
				fondoConsejo.SetActive(true);
				break;
			default:
				break;
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
