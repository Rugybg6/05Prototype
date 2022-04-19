using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [Range(1,10)]
    public float countdown = 3f;
    [Range(5,20)]
    public float radius = 5f;
    [Range(500,1500)]
    public float explosionForce = 700;

    private bool hasExploded=false;
    public GameObject grenadePE;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0 && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
    }

    void Explode()
    {
        
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (var rangeObject in colliders)
        {
            Rigidbody rangeObjectRigidbody = rangeObject.GetComponent<Rigidbody>();
            if (rangeObjectRigidbody != null)
            {
                rangeObjectRigidbody.AddExplosionForce(explosionForce,transform.position,radius);
            }
        }

        GameObject casa = Instantiate(grenadePE, transform.position, transform.rotation);
        casa.GetComponent<ParticleSystem>().Play();
        Destroy(this.gameObject);
    }
}
