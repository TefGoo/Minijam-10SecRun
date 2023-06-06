using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingCanvas : MonoBehaviour
{
    public void CloseGame()
    {
        Application.Quit();
        Debug.Log("Closing Game..");
    }

    public void LoadSampleScene()
    {
        // Load the "SampleScene"
        SceneManager.LoadScene("SampleScene");
    }
}
