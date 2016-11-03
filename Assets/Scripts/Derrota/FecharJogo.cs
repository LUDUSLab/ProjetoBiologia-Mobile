using UnityEngine;
using System.Collections;

public class FecharJogo : MonoBehaviour {

    public GameObject sair;

    public void Sim()
    {
        Application.Quit();
    }

    public void Nao()
    {
        sair.SetActive(false);
    }

}
