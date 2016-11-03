using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BarraDeTempoController : MonoBehaviour {

	public float TempoDaBarra;	//tempo pra durar a barra
	public string CenaToGo;
	private bool stop;
	private float tempoInicial;


	void OnEnable()
	{
		///*
		stop = false;
		Debug.Log ("o gigante ficou habilitado");
		GetComponent<Animator> ().speed = 1 / TempoDaBarra;	//muda a velocidade da animacao de acordo com o tempo escolhido
		//Invoke("GameOver", TempoDaBarra);
		tempoInicial = Time.realtimeSinceStartup;
		Debug.Log ("iniciou em " + tempoInicial);
		//*/
	}
	void Start()
	{
		//Debug.Log ("o gigante iniciou");
	}
		
	void Awake ()
	{
		//Debug.Log ("o gigante acordou");
	}

	void Update()
	{
		
		if(Time.realtimeSinceStartup - tempoInicial >= TempoDaBarra)
		{
			//Debug.Log ("game over");
			GameOver ();
		}
	}
	public void Parar()
	{
		stop = true;
		gameObject.SetActive (false);
	}

	private void GameOver()
	{
		/*
		if(this.isActiveAndEnabled)
		{
			SceneManager.LoadScene (CenaToGo);
		}
		*/
		if(gameObject.activeSelf)
		//if(!stop)
		{
			Debug.Log ("outra cena -->");
			SceneManager.LoadScene (CenaToGo);
		}
	}
}
