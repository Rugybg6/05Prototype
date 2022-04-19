using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowGrenade : MonoBehaviour
{
    public float throwForce = 500f;

    public GameObject grenadePrefab;

    public Transform spawnPoint;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Throw();
        }
    }

    void Throw()
    {
        GameObject newGrenade = Instantiate(grenadePrefab, spawnPoint.position, spawnPoint.rotation);
        newGrenade.GetComponent<Rigidbody>().AddForce(spawnPoint.forward*throwForce,ForceMode.Impulse);
    }
}
