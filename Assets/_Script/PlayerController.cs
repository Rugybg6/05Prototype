using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [Range(0,100), Tooltip("Velocidad de movimiento del jugador")]
    public float moveSpeed;
    [Range(0,180), Tooltip("Angulos que gira el jugador")]
    public float rotateSpeed;

    private Rigidbody _rigidbody;
    [Range(0,100), Tooltip("Fuerza aplicada al jugador")]
    public float force;
    
    [Tooltip("Mueve el objeto por fisicas S/N")]
    public bool usePhysicsEngine;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void MovePlayer()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        if (!usePhysicsEngine)
        {
            transform.Translate(Vector3.forward*moveSpeed*Time.deltaTime*verticalInput);
            transform.Rotate(Vector3.up*rotateSpeed*Time.deltaTime*horizontalInput);
        }
        else
        {
            _rigidbody.AddForce(Vector3.forward*force*Time.deltaTime*verticalInput);
            _rigidbody.AddTorque(Vector3.up*force*Time.deltaTime*horizontalInput);
        }
    }
    //TODO:Refactorizar los limites del juego
    void KeepPlayerInBounds()
    {
        if (Mathf.Abs(transform.position.x) >= 9.5f)
        {
            _rigidbody.velocity = Vector3.zero;
            if (transform.position.x > 9.5)
            {
                transform.position = new Vector3(9.5f, transform.position.y, transform.position.z);
            }
            if (transform.position.x < -9.5)
            {
                transform.position = new Vector3(-9.5f, transform.position.y, transform.position.z);
            }
        }
        if (Mathf.Abs(transform.position.z) >= 9.5f)
        {
            _rigidbody.velocity = Vector3.zero;
            if (transform.position.z > 9.5)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, 9.5f);
            }
            if (transform.position.z < -9.5)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -9.5f);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        KeepPlayerInBounds();
    }
}
