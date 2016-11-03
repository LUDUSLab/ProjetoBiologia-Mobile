using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SaveScene : MonoBehaviour {

	void Start () {
        PlayerPrefs.SetString("faseAtual", SceneManager.GetActiveScene().name);
	}
}
