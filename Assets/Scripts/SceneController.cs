using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    public Animator TransitionAnimator;
    public float TransitionTime;
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
}
