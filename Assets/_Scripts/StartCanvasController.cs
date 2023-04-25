using UnityEngine;
using UnityEngine.UI;

public class StartCanvasController : MonoBehaviour
{
    public GameObject canvas;
    public GameObject[] panels;
    public Button hideButton;
    public Button panelButton;
    public Button closeButton;

    private bool canvasActive = true;
    private int currentPanel = 0;

    private void Awake()
    {
        Time.timeScale = 0; // Stop time when canvas is active
        canvas.SetActive(canvasActive); // Show canvas on awake
        hideButton.onClick.AddListener(HideCanvas);
        panelButton.onClick.AddListener(NextPanel);
        closeButton.onClick.AddListener(CloseGame);
    }

    private void HideCanvas()
    {
        canvasActive = !canvasActive;
        canvas.SetActive(canvasActive);
        Time.timeScale = canvasActive ? 0 : 1; // Stop/start time based on canvas visibility
    }

    private void NextPanel()
    {
        currentPanel++;
        if (currentPanel >= panels.Length)
        {
            currentPanel = 0;
        }
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].SetActive(i == currentPanel);
        }
    }

    private void CloseGame()
    {
        Application.Quit();
    }
}
