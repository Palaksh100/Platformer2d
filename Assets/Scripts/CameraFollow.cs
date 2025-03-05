using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Transform BossRoomPortal1;
    public Transform BossRoomPortal2;
    public PlayerMovement movement;
    [SerializeField]private float Speed;

    void LateUpdate()
    {
        transform.position=Vector3.Lerp(transform.position,player.position-Vector3.forward*10,Speed);
        if(movement.InBossRoom) {
            transform.position=new Vector3(0,33,-10);
            BossRoomPortal2.position=BossRoomPortal1.position-new Vector3(BossRoomPortal1.position.x*2,0,0);
            this.enabled=false;                       
        }
    }
}
