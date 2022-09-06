using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAtPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform cam;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(cam);
    }
}
