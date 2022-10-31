using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogoPPrincipal : MonoBehaviour
{
	[SerializeField] TMP_Text dialogos;
	private string[] espacioDialogos = new string[] {   "Esta es la academia Suchiin, se trata de un instituto de gran fama y prestigio...",
														"Para educar a los jovenes de alta sociedad, incluso sin poseer titulos nobiliarios...",
														"Pero no todo es glamour o elegancia, tambien existen jovenes promesas...",
														"Un día apareció una nota en la puerta del consejo estudiantil.....",
														"En esta se menciona que se realizara una 'broma' a los miembros del consejo...",
														"\nEste es un trabajo para............",
														"\n¡La detective del amor Chika Fujiwara!....." };
	[SerializeField] GameObject imagenDetective;
	[SerializeField] GameObject fondoNegro;
	[SerializeField] GameObject iconDetective;

    private int  contLineaDeDialogo;
    private float velocidadTexto;
	private string prefabsVelocidadTexto = "Velocidad de Texto";

	void Start()
	{
		IniciaDialogo();
		velocidadTexto = PlayerPrefs.GetFloat(prefabsVelocidadTexto,0.05f);
	}
	void Update()
    {
		if(Input.GetButtonDown("Fire1"))
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
		if(contLineaDeDialogo < espacioDialogos.Length)
		{
			StartCoroutine(ShowLine());
		}
		else
		{
			Debug.Log("Fin de los comentarios   "+ espacioDialogos.Length);
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
    }

    private IEnumerator ShowLine()
    {
		dialogos.text = string.Empty;
		if(contLineaDeDialogo == 6)
		{	
			imagenDetective.SetActive(true);
 			fondoNegro.SetActive(true);
		}
		if (contLineaDeDialogo == 5)
		{
			iconDetective.SetActive(true);
		}
		foreach (char ch in espacioDialogos[contLineaDeDialogo])
		{
			dialogos.text += ch;
			yield return new WaitForSeconds(velocidadTexto);
		}
    }    


}
