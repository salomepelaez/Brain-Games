using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void SinglePlayer()
    {
        SceneManager.LoadScene("OnePlayer");

        if(Manager.lockMouse)
        {
            Manager.lockMouse = !Manager.lockMouse;
        }
    }

    public void Multiplayer()
    {
        SceneManager.LoadScene("Multiplayer");

        if (ManagerMP.lockMouse)
        {
            ManagerMP.lockMouse = !ManagerMP.lockMouse;
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }        
}
