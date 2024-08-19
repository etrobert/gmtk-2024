using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    static public void PlayGame()
    {
        Debug.Log("Play Game");

        SceneManager.LoadScene(1);
    }
    static public void QuitGame()
    {
        Debug.Log("Quit Game");

        SceneManager.LoadScene(0);
    }

}
