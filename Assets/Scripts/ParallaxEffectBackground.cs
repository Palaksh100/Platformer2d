using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UIElements;

public class ParallaxEffectBackground : MonoBehaviour
{
    public float Scale;
    private Transform CameraTransform;
    [SerializeField]private float BackgroundWidth;
    private Vector3 start;
    private float InitialCameraX;
    void Start()
    {
        CameraTransform=Camera.main.transform;
        InitialCameraX=CameraTransform.position.x;
        start=transform.position;
    }

    void Update()
    {
        transform.position=new Vector3(start.x+(CameraTransform.position.x-InitialCameraX)*Scale,start.y,start.z);
    
    }
}
