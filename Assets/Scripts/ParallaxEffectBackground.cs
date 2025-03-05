using UnityEngine;
public class ParallaxEffectBackground : MonoBehaviour
{
    public float Scale;
    public float Speed;
    public Transform player;
    public PlayerMovement movement;
    [SerializeField] private float BackgroundWidth;
    void Start()
    {
        SpriteRenderer sr=GetComponent<SpriteRenderer>();
        BackgroundWidth=sr.bounds.size.x/2;
    }

    void LateUpdate()
    {
        float X=(player.position.x*(Scale-1f))%BackgroundWidth+BackgroundWidth/2+player.position.x;
        transform.position=Vector3.Lerp(transform.position,new Vector3(X,0,0),Speed);
        if(movement.InBossRoom){
            this.enabled=false;
        }
    }
}
