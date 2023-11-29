using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Stage1ButtonOnClick()
    {
        SceneManager.LoadScene("Stage1");
    }

    public void Stage2ButtonOnClick()
    {
        SceneManager.LoadScene("Stage2");
    }
}
