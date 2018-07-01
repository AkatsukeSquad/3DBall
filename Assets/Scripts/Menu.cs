using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    //Main Menu
    public bool NewGame = false;
    public bool Settings = false;
    public bool Exit = false;
    //Settings
    public bool Low = false;
    public bool Middle = false;
    public bool High = false;
    public bool Back = false;
    //Choose Level
    public bool Level_1 = false;
    public bool Level_2 = false;
    //Cameras
    public Camera mainCamera;
    public Camera settingsCamera;    
    public Camera chooseLevelCamera;

    void Start()
    {
        mainCamera.enabled = true;
        settingsCamera.enabled = false;
        chooseLevelCamera.enabled = false;
    }

    void OnMouseUp()
    {
        if (NewGame)
        {
            mainCamera.enabled = false;
            chooseLevelCamera.enabled = true;
        }
        if (Level_1)
            SceneManager.LoadScene(1);
                    
        if (Level_2)
            SceneManager.LoadScene(2);
            
        if (Settings)
        {
            mainCamera.enabled = false;
            settingsCamera.enabled = true;
        }
        if (Back)
        {
            mainCamera.enabled = true;
            settingsCamera.enabled = false;
            chooseLevelCamera.enabled = false;
        }
        if (Low)
            QualitySettings.currentLevel = QualityLevel.Fast;
        if (Middle)
            QualitySettings.currentLevel = QualityLevel.Good;
        if (High)
            QualitySettings.currentLevel = QualityLevel.Fantastic;
        if (Exit)
            Application.Quit();
    }
}
