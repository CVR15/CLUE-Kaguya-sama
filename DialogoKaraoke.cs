using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DialogoKaraoke : MonoBehaviour
{
	private int ncaso;
	[SerializeField] TMP_Text dialogos;
	string[] espacioDialogos;
	private string[] casoUnoDialogos = new string[] {	"Ahi está el presidente parece que va a otro lugar, le preguntaré si sabe algo de los objetos perdidos...",
														"Ah Fujiwara...¿Porqué traes ese gorro?...",
														"Eso no es lo importante, ¿sabés algo sobre los objetos perdidos del consejo?...",
														"No del todo, yo solo tomé la grabadora, me la llevaré al Karaoke...",
														"tendré una reunión con los miembros de otros consejos estudiantiles allá...",
														"Nos vemos más tarde..." };
	private string[] casoDosDialogos = new string[] { "Señorita Fujiwara, que gusto me da de verla...",
														"A mi también me da gusto verte Miko, que haces en el Karaoke, no pensé que fuera un lugar que te gustará...",
														"No no es eso, mis compañeros decidieron hacer una reunión para preparar los carteles del festival", 
														"incluso trajeron pintura para ello, y yo los acompañe porque alguien debe de cuidar el orden", 
														"sin mi esto sería un desastre...\nOye tú, bájate de ahí...",
														"(Creo que mejor dejo a Miko hacer lo suyo)..." };
	private string[] casoTresDialogos = new string[] { 	"Hola Hayasaka, de casualidad, ¿sabes algo sobre los objetos extraviados del consejo?...",
														"No, el presidente iba a prestarme la pintura esta mañana para uns preparativos del festival...",
														"¿Y no lograste encontrarla después?...",
														"No, pero vine a alcanzar unas amigas aquí a preguntarles y decidí quedarme, ¿Quieres unirtenos?...",
														"Gracias, pero aún tengo un misterio que resolver...",
														};
	private string[] casoCuatroDialogos = new string[] {"¡Kaguya! que sorpresa verte por aquí, no sabía que cantaras...",
														"Claro que si ,como una Shinomiya llevé clases artísticas desde que tengo uso de razón, tu deberias de saberlo...",
														"Tienes razón, ¿vienes a cantar con alguien más?",
														"No, vine porque llamaron al consejo diciendo que habia una reservación, pero parece ser que fue un malentendido...",
														"Parece ser que si fue alguien de la escuela pero no sé porqué asumieron que fue alguien del consejo...",
														"En fin, al regresar a la escuela llevaré este gran globo meteorológico a su lugar, lo habia tomado el otro día...",
														"Pero habia olvidado regresarlo a su lugar...",
														"Entonces regresemos juntas, aún hay cosas por investigar..."};
	private string[] casoCincoDialogos = new string[] { "Ishigami, ¿te gusta cantar?...",
														"No te ilusiones Fujiwara, solo vengo a traerle un poco de pintura a los chicos de tercero...",
														"Creo que es para el festival o algo así...",
														"Que aguafiestas, ¿no sabes sobre los demás objetos perdidos del consejo?",
														"Solo se que estan perdidos...",
														"Solo pierdo mi tiempo contigo..."
														};

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
		if(ncaso == 1 || ncaso == 3 || ncaso == 4) { iconChika.SetActive(true); }
		if(ncaso == 2) { iconMiko.SetActive(true); }
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
		if (ncaso==1)
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
				default: break;
			}
        }
		if (ncaso==2)
        {
			switch(contLineaDeDialogo)
            {
				case 1:
					iconChika.SetActive(true);
					iconMiko.SetActive(false);
					break;
				case 2:
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
		if (ncaso==3)
        {
			switch(contLineaDeDialogo)
            {
				case 1:
					iconChika.SetActive(false);
					iconHayasaka.SetActive(true);
					break;
				case 2:
					iconChika.SetActive(true);
					iconHayasaka.SetActive(false);
					break;
				case 3:
					iconChika.SetActive(false);
					iconHayasaka.SetActive(true);
					break;
				case 4:
					iconChika.SetActive(true);
					iconHayasaka.SetActive(false);
					break;
			}
        }
		if (ncaso==4)
        {
			switch(contLineaDeDialogo)
            {
				case 1:
					iconChika.SetActive(false);
					iconKaguya.SetActive(true);
					break;
				case 2:
					iconChika.SetActive(true);
					iconKaguya.SetActive(false);
					break;
				case 3:
					iconChika.SetActive(false);
					iconKaguya.SetActive(true);
					break;
				case 7:
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
