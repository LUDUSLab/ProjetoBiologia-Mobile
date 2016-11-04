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
        if(indio.transform.position.x >= 91 && indio.transform.position.x >= 92)
        {
            Invoke("ChamarFade", 1f);
        }
    }

    void ChamarFade()
    {
        fadeIn.SetActive(true);
        Invoke("Vitoria", 1.5f);
    }

    void Vitoria()
    {
        SceneManager.LoadScene("Vitoria");
    }

}
