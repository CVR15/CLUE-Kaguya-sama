using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; 

public class DialogoConsejo : MonoBehaviour
{
    private int ncaso;
	[SerializeField] TMP_Text dialogos;
	string[] espacioDialogos;
	private string[] casoUnoDialogos = new string[] { "Ah, superiora Fujiwara, ¿Buscaba alguien en especial?...",
														"No Iino, estaba buscando los objetos perdidos...",
														"Por cierto, acabo de encontrar uno, había tomado este paquete de globos para figuras...", 
														"pensé que eran globos normales, lo siento mucho...",
														"No hay problema Iino ya es un objeto menos que buscar, por cierto El salón del consejo se ve algo extraño...", 
														"¿no crees?...",
														"Ahora que lo menciona si, no se que es pero se ve distinto..." };
	private string[] casoDosDialogos = new string[] { "(Parece ser que solo está Ishigami en el salón del consejo, lo interrogaré para ver si el sabe algo del asunto)...",
														"¿Ishigami tu sabes algo de los objetos perdidos?...",
														"Solo se de uno, el silbato de Iino lo tengo yo...", 
														"no dejaba de atormentarme con él así que se lo escondí, pero no le vayas a decir...",
														"Vine al salón del consejo para poder jugar videojuegos en paz...", 
														"si ves a Iino no le digas que estoy acá, ni mucho menos que tengo  su silbato...",
														"Solo por está ocasión..." };
	private string[] casoTresDialogos = new string[] { "¡Kaguya! Que gusto me da verte aquí, ¿Qué haces en el salón del consejo a esta hora?",
														"Pongo algo de orden por aquí, resulta ser que la grabadora no estaba perdida como habiamos pensado",
														"Yo habia pensado que sí, incluso la busque hace un par de horas",
														"Ya ves que no, esta se encontraba debajo del escritorio del presidente, no se como llego ahí",
														"Lo importante es que ya la encontramos...\n(Creo que fuí yo la que la uso la última vez ups)",
														};
	private string[] casoCuatroDialogos = new string[] {	"Qué extraño Hayasaka me había dicho que estaría aquí, pero viendolo positivamente apareció algo...",
															"Dejaron los globos para figura frente a la puerta con una nota de que ya no los necesitarían...",
															"Parece ser que fueron los porristas y que harán algo distinto para el festival..."};
    private string[] casoCincoDialogos = new string[] {     "Pensé que Iino estaría aquí por la hora, pero no hay nadie que extraño",
                                                            "Pero parece ser que alguién vino a regresar la grabadora perdida, tiene una nota pegada...",
                                                            "Resulta ser que hubo un mal entendido y la tenian los chicos de tercero, pero que bueno que se aclaró...",
															"Debo seguir investigando"};

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
		if (ncaso == 1) { iconMiko.SetActive(true); }
		if (ncaso == 2 || ncaso == 3 || ncaso == 4 || ncaso == 5) { iconChika.SetActive(true); }
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
		if(ncaso == 1)
        {
			switch (contLineaDeDialogo)
            {
				case 1:
					iconChika.SetActive(true);
					iconMiko.SetActive(false);
					break;
				case 2:
					iconChika.SetActive(false);
					iconMiko.SetActive(true);
					break;
				case 4:
					iconChika.SetActive(true);
					iconMiko.SetActive(false);
					break;
				case 6:
					iconChika.SetActive(false);
					iconMiko.SetActive(true);
					break;
				default:
					break;
			}

		}
		if(ncaso == 2)
        {
			switch(contLineaDeDialogo)
            {
				case 2:
					iconChika.SetActive(false);
					iconIshigami.SetActive(true);
					break;
				case 6:
					iconChika.SetActive(true);
					iconIshigami.SetActive(false);
					break;
				default: break;
			}
        }
		if(ncaso == 3)
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
				case 4:
					iconChika.SetActive(true);
					iconKaguya.SetActive(false);
					break;
				default: break;
			}
        }
		if(ncaso == 4)
        {
			switch(contLineaDeDialogo)
            {
				default: break;
			}
        }
		if(ncaso == 5)
		{ switch(contLineaDeDialogo)
            {
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
