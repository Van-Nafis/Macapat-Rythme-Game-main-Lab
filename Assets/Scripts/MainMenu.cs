using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void Start()
    {

    }

    public void PlayGame1()
    {
        SceneManager.LoadScene("Maskumambang");
    }

    public void PlayGame2()
    {
        SceneManager.LoadScene("Mijil");
    }

    public void PlayGame3()
    {
        SceneManager.LoadScene("Sinom");
    }

    public void PlayGame4()
    {
        SceneManager.LoadScene("Kinanti");
    }

    public void PlayGame5()
    {
        SceneManager.LoadScene("Asmaradana");
    }

    public void PlayGame6()
    {
        SceneManager.LoadScene("Gambuh");
    }

    public void PlayGame7()
    {
        SceneManager.LoadScene("Dandanggula");
    }

    public void PlayGame8()
    {
        SceneManager.LoadScene("Durma");
    }

    public void PlayGame9()
    {
        SceneManager.LoadScene("Pangkur");
    }

    public void PlayGame10()
    {
        SceneManager.LoadScene("Megatruh");
    }

    public void PlayGame11()
    {
        SceneManager.LoadScene("Pucung");
    }

    public void PlayDebug()
    {
        SceneManager.LoadScene("Debug");
    }

    public void GoToSettingMenu()
    {
        SceneManager.LoadScene("Setting Menu");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void GoToLevelMenu()
    {
        SceneManager.LoadScene("Level Selection");
    }

    public void GoToLearning()
    {
        SceneManager.LoadScene("Belajar 1 Alt");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
