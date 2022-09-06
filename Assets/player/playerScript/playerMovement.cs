using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float groundDrag;

    public float jumpForce;
    public float jumpCoolDown;
    public float airMultiplier;
    bool readyToJump = true;
    
    [Header("keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;
    float horizontalInput;
    float verticallInput;

    Vector3 moveDirection;
    Rigidbody rb;

    [Header("animations")]
    public Animator anim;


    private void Awake()
    {
        anim = GameObject.Find("astroguy_running").GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        anim.SetBool("isRunning",false);

    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight*0.5f+0.2f, whatIsGround);


        MyInput();
        speedControl();

        if(grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;


    }


    private void FixedUpdate()
    {
        movePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticallInput = Input.GetAxisRaw("Vertical");       
        if(horizontalInput != 0 || verticallInput != 0){
            anim.SetBool("isRunning",true);
        }else{
            anim.SetBool("isRunning",false);
        }
        if(Input.GetKey(jumpKey) && grounded && readyToJump){
            readyToJump = false;
            jump();

            Invoke(nameof(resetJump), jumpCoolDown);
        }
    }

    private void movePlayer()
    {
        moveDirection = orientation.forward * verticallInput + orientation.right * horizontalInput;
        if(grounded){
            rb.AddForce(moveDirection.normalized*moveSpeed*10f, ForceMode.Force);
        }
        else if(!grounded)
        {
            rb.AddForce(moveDirection.normalized*moveSpeed*10f*airMultiplier, ForceMode.Force);
        }
            
    }

    private void speedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        if(flatVel.magnitude>moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void resetJump()
    {
        readyToJump = true;
    }




}
