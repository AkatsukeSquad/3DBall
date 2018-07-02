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
    public bool Play = false;
    public bool NextLevel = false;
    public bool PrevLevel = false;
    public int CurrentSceneIndex;
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
        //Choose Level
        if (Play)
        {
            SceneManager.LoadScene(CurrentSceneIndex);
        }
             

        if (NextLevel)
        {
            if (chooseLevelCamera.transform.position.x < 35)
            {
                CurrentSceneIndex++;
                chooseLevelCamera.transform.position = new Vector3(chooseLevelCamera.transform.position.x + 25f, 22.3f, 0.3f);
            }
        }
            
        if (PrevLevel)
        {
            if(chooseLevelCamera.transform.position.x > 10)
            {
                CurrentSceneIndex--;
                chooseLevelCamera.transform.position = new Vector3(chooseLevelCamera.transform.position.x - 25f, 22.3f, 0.3f);
            }            
        }
            
        //Settings
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
