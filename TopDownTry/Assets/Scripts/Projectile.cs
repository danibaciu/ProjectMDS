using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector3 firingPoint;

    [SerializeField]
    float projectileSpeed;

    [SerializeField]
    private float maxProjectileDistance;

    [SerializeField]
    private float damage;

    private GameObject triggeringEnemy;
    
    void Start()
    {
        firingPoint = transform.position;
    }

    void Update()
    {
        MoveProjectile();
    }

    void MoveProjectile() {
        if (Vector3.Distance(firingPoint, transform.position) > maxProjectileDistance){
            Destroy(this.gameObject);
        } else {
            transform.Translate(Vector3.forward * projectileSpeed * Time.deltaTime);
        }
        transform.Translate(Vector3.forward * projectileSpeed * Time.deltaTime);
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Enemy")
        {
            triggeringEnemy = other.gameObject;
            triggeringEnemy.GetComponent<Enemy>().health -= damage;
        }
    }

}
