using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class goMenu : MonoBehaviour {
    
    public void voltarMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
