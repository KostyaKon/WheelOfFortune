using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasButton : MonoBehaviour
{
    public void LoadScene(int numberScen)
    {
        SceneManager.LoadScene(numberScen);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
