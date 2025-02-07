using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class PortalHandler : MonoBehaviour
{
    Dictionary <GameObject,GameObject> conjugate=new Dictionary<GameObject,GameObject>();
    void Start(){
        GameObject[] P=new GameObject[2];int i=0;
        foreach(Transform child in transform){
            P[i]=child.gameObject;
            i++;
        }
        conjugate[P[0]]=P[1];
        conjugate[P[1]]=P[0];
    }
}
