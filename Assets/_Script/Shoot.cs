using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private Animator _Animator;

    private const string FIRE = "Fire"  ;
    [Tooltip("Flecha a lanzar")]
    public GameObject arrow;
    [Tooltip("fuerza al lanzar")]
    public float shotForce;
    [Tooltip("Posición desde la que se va a lanzar")]
    public Transform SpawnPoint;

    private float shotRate = 1f;

    private float shotTime = 0;
        // Start is called before the first frame update
    void Start()
    {
        _Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            if(Time.time > shotTime)
            {
                shotTime = Time.time + shotRate;
                _Animator.SetTrigger(FIRE);
                GameObject newArrow = Instantiate(arrow, SpawnPoint.position, SpawnPoint.rotation);
                newArrow.GetComponent<Rigidbody>().AddForce(SpawnPoint.forward*shotForce);
                Destroy(newArrow,2);
            }

            
        }
    }
}
