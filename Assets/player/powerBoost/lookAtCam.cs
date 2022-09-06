using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAtCam : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform cam;
    public Transform orientation;

    public void cheese()
    {
        ///nanti diperbaiki
        Debug.Log("Liat Kamera dong");
        orientation.LookAt(cam.position);
    }
}
