using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void SinglePlayer()
    {
        SceneManager.LoadScene("OnePlayer");
    }

    public void Multiplayer()
    {
        SceneManager.LoadScene("Multiplayer");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
