using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FadeFinalFase : MonoBehaviour {

    public GameObject indio, fadeIn;

	void Update () {
        Fadezinho();
	}

    void Fadezinho()
    {
		if(indio.transform.position.x >= 110 && indio.transform.position.x >= 111)
        {
            Invoke("ChamarFade", 1f);
        }
    }

    void ChamarFade()
    {
        fadeIn.SetActive(true);
        Invoke("Pontinhos", 1.5f);
    }

    void Pontinhos()
    {
        SceneManager.LoadScene("Vitoria");
    }

}
