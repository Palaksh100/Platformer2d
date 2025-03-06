using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SwipeController : MonoBehaviour, IEndDragHandler
{
    public static int UnlockedLevel=1;
    public int MaxPage;
    int CurrentPage=1;
    public Vector3 TargetPosition;
    public Vector3 PageStep;
    public RectTransform LevelPagesRect;
    public LeanTweenType TweenType;
    public float TweenTime;
    float dragThreshold;
    public Image[] BarImage;
    public Color barClosed,barOpen;
    public Button PreviousButton,NextButton;
    public Button[] LevelButtons;
    void Awake()
    {
        CurrentPage=1;
        TargetPosition=LevelPagesRect.localPosition;
        dragThreshold=Screen.width/15;
        UpdateBar();
        UpdateArrowButton();
        for(int i=0;i<LevelButtons.Length;i++){
            if(i<UnlockedLevel) LevelButtons[i].interactable=true;
            else LevelButtons[i].interactable=false;
        }
    }

    public void Next(){
        if(CurrentPage<MaxPage){
            CurrentPage++;
            TargetPosition+=PageStep;
            MovePage();
        }
    }

    public void Previous(){
        if(CurrentPage>1){
            CurrentPage--;
            TargetPosition-=PageStep;
            MovePage();
        }
    }
    public void MovePage(){
        LevelPagesRect.LeanMoveLocal(TargetPosition,TweenTime).setEase(TweenType);
        UpdateBar();
        UpdateArrowButton();
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if(Mathf.Abs(eventData.position.x-eventData.pressPosition.x)>dragThreshold){
            if(eventData.position.x>eventData.pressPosition.x)  Previous();
            else    Next();
        }
        else{
            MovePage();
        }
    }
    void UpdateBar(){
        foreach(var item in BarImage){
            item.color=barClosed;
        }
        BarImage[CurrentPage-1].color=barOpen;
    }
    void UpdateArrowButton(){
        if(CurrentPage==1)  PreviousButton.interactable=false;
        else{
            PreviousButton.interactable=true;
        }
        if(CurrentPage==MaxPage)  NextButton.interactable=false;
        else{
            NextButton.interactable=true;
        }
    }
}
