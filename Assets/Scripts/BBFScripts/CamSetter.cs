using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamSetter : MonoBehaviour
{

    public GameObject garrettInstance;
    void Update() 
    {
        garrettInstance = GameObject.Find("Garrett(Clone)");
        GetComponent<CinemachineVirtualCamera>().Follow = garrettInstance.transform;
    
    }

}
