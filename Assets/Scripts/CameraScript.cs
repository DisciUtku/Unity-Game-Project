using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using static UnityEngine.GraphicsBuffer;

public class CameraScript : MonoBehaviour
{

Vector3 MyPos = new Vector3(0, 22,-10);
public Transform myPlay;

void Start()
    {
        
    }

    void Update()
    {
        transform.position = myPlay.position + MyPos;
    }
}
