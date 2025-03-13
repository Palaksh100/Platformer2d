using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using Unity.VisualScripting;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    public Animator FadeAnimator;
    public Animator SlidingAnimator;
    public float TransitionTime;
    GameObject PauseMenu;
    
    void Awake()
    {
        instance=this;
    }
    public void LoadScene(string name){
        StartCoroutine(SceneTransition(name,FadeAnimator));
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
    IEnumerator SceneTransition(string name,Animator Transition){
        Time.timeScale=1f;
        Transition.SetTrigger("Start");
        yield return new WaitForSeconds(TransitionTime);
        SceneManager.LoadSceneAsync(name);   
    }
}
