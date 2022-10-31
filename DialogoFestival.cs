using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DialogoFestival : MonoBehaviour
{
	private int ncaso;
	[SerializeField] TMP_Text dialogos;
	string[] espacioDialogos;
	private string[] casoUnoDialogos = new string[] { "Hayasaka, se que fuiste al consejo en la mañana, ¿sabes algo sobré los objetos que se perdieron?...",
														"No sabía que se hubiera extraviado algo secretaria Fujiwara, Kaguya me prestó un silbato para el festival...",
														"Voy a ser la encargada de algunas de las competencias de atletismo...",
														"No hay problema, seguiré buscando..." };
	private string[] casoDosDialogos = new string[] { "¡Kaguya! Que bueno que te veo por aquí, perdón que te lo pregunte", 
														"pero, ¿no has visto los objetos perdidos del consejo?...",
														"No Fujiwara solo se de uno que le presté a Hayasaka, por otra parte", 
														"estuve buscando en la mañana un paquete de globos para hacer decoraciones en el festival",
														"Como vicepresidenta del consejo es importante que se vea nuestra participación en el festival...",
														"Es cierto, tienes muy buenas ideas Kaguya.\nVoy a seguir con mi búsqueda...." };
	private string[] casoTresDialogos = new string[] { "Pensé que Ishigami estaría con los porristas previo al festival para entrenar un poco pero no lo veo...",
														"Aunque lo bueno es que ya encontré los globos para hacer animales, los usaron los porristas para su acto..."};
	private string[] casoCuatroDialogos = new string[] {	"Presidente que bueno que lo veo involucrado con los preparativos del festival...",
															"Claro, es mi deber como presidente del comité cuidar de las actividades de la escuela...",
															"¿Qué es lo que lleva en aquella caja?...",
															"Pintura, es la que teniamos en la sala del consejo, quise ayudar con las decoraciones en persona...",
															"¿No te unes Fujiwara?",
															"Le agradezco la invitación, pero hay un misterio que resolver"};
	private string[] casoCincoDialogos = new string[] { "Presidente que bueno que lo veo involucrado con los preparativos del festival...",
														"Claro, es mi deber como presidente del comité cuidar de las actividades de la escuela...",
														"Traje un paquete de globos para hacer figuras, habia pensado en adornar con animalitos.....",
														"Momento, ¿escuchas eso Fujiwara?, parece ser que hay mucho ruido mas allá, ¿qué será lo que sucede?",
														"No estoy segura presidente, pero parece que es una persona la que se encuentra haciendo este desorden"};

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
		if (ncaso >=1 && ncaso <= 5) { iconChika.SetActive(true); }
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
				case 1:
					iconChika.SetActive(false);
					iconHayasaka.SetActive(true);
					break;
				case 3:
					iconChika.SetActive(true);
					iconHayasaka.SetActive(false);
					break;
			}
		}
		if (ncaso == 2)
		{
			switch (contLineaDeDialogo)
			{
				case 2:
					iconChika.SetActive(false);
					iconKaguya.SetActive(true);
					break;
				case 5:
					iconChika.SetActive(true);
					iconKaguya.SetActive(false);
					break;
			}
		}
		if (ncaso == 3)
		{
			switch (contLineaDeDialogo)
			{ default: break; }
		}
		if (ncaso == 4)
		{
			switch (contLineaDeDialogo)
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
				case 5:
					iconChika.SetActive(true);
					iconShirogane.SetActive(false);
					break;
				default: break;

			}
        }
		if (ncaso == 5)
        {
			switch(contLineaDeDialogo)
            {
				case 1:
					iconChika.SetActive(false);
					iconShirogane.SetActive(true);
					break;
				case 4:
					iconChika.SetActive(true);
					iconShirogane.SetActive(false);
					break;
				default:
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
