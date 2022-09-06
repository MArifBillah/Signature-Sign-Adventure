using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPmove : MonoBehaviour
{
    [Header("References")]
    public Transform orientation;
    public Transform Player;
    public Transform playerObject;
    public Rigidbody rb;

    public GameObject freeMode;
    public GameObject combatMode;

    public float rotationSpeed;
    public Transform combatCamera;
    public CameraStyle now;

    public enum CameraStyle
    {
        free,
        combat
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        //mengubah mode kamera
        if (Input.GetKeyDown(KeyCode.Alpha1)) SwitchCamera(CameraStyle.free);
        if (Input.GetKeyDown(KeyCode.Alpha2)) SwitchCamera(CameraStyle.combat);

        // orientasi rotasi
        Vector3 viewDir = Player.position - new Vector3(transform.position.x, Player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;
        if(now == CameraStyle.free)
        {
            //rotate player
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxisRaw("Vertical");
            Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;

            if(inputDir != Vector3.zero)
                playerObject.forward = Vector3.Slerp(playerObject.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
            
    
        }

        else if(now == CameraStyle.combat)
        {
            Vector3 combatDir = combatCamera.position - new Vector3(transform.position.x, combatCamera.position.y, transform.position.z);
            orientation.forward = combatDir.normalized;

            playerObject.forward = combatDir.normalized;
        }

    }

    private void SwitchCamera(CameraStyle newStyle)
    {
        freeMode.SetActive(false);
        combatMode.SetActive(false);

        if (newStyle == CameraStyle.free) freeMode.SetActive(true);
        if (newStyle == CameraStyle.combat) combatMode.SetActive(true);

        now = newStyle;
    }

    
}