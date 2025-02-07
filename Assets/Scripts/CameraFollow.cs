using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    [SerializeField]private float Speed;

    void LateUpdate()
    {
        transform.position=Vector3.Lerp(transform.position,player.position-Vector3.forward*10,Speed);
    }
}
