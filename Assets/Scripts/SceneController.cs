using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    public Animator TransitionAnimator;
    public float TransitionTime;
    GameObject PauseMenu;
    void Awake()
    {
        if(instance==null){
            instance=this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }
    public void LoadScene(string name){
        Time.timeScale=1f;
        SceneManager.LoadSceneAsync(name);
    }
    public void Quit(){
        Application.Quit();
    }
    public void Play(){
        LoadScene("Level Menu");
    }
    public void StartLevel(int Level)
    {
        LoadScene("Level"+Level.ToString());
    }
    public void MainMenu(){
        LoadScene("Main Menu");
    }
    public void Complete(){
        LoadScene("Game Complete");
    }
    public void Restart(){
        LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Pause(GameObject menu){
        PauseMenu=menu;
        PauseMenu.SetActive(true);
        Time.timeScale=0f;
    }
    public void Resume(){
        PauseMenu.SetActive(false);
        Time.timeScale=1f;
    }
}
