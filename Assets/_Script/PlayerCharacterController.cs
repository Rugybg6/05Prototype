using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class PlayerCharacterController : MonoBehaviour
{
    //gravedad al personaje
    private float gravity = -9.81f;
    private Vector3 velocityGravity;
    
    //que no caiga tan rapido por gravity
    [Header("CheckGround")]
    public Transform groundCheck;
    private float sphereRadius = 0.3f;
    public LayerMask groundMask;
    private bool isGrounded;
    
    private CharacterController _characterController;
[Range(0,30), Tooltip("Velocidad de movimiento del jugador")]
    public float speed=10f;
[Range(0,10), Tooltip("Altura de salto")]
    public float jumpHeight = 3;
    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        Vector3 right = transform.right * horizontal * Time.deltaTime * speed;
        Vector3 forward = transform.forward * vertical * Time.deltaTime * speed;
        Vector3 movement = right + forward;
        
        _characterController.Move(movement);
        
        //gravedad
        velocityGravity.y += gravity * Time.deltaTime;
        _characterController.Move(velocityGravity*Time.deltaTime);
        
        //check floor
        
        isGrounded = Physics.CheckSphere(groundCheck.position, sphereRadius, groundMask);
        
        if (isGrounded)
        {
            velocityGravity.y = -2;
        }
        //jump
        if (isGrounded && Input.GetAxis("Jump")>0)
        {
            velocityGravity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
    }
}
