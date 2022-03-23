using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float health;
    public float waitTime;

    private float currentTime;
    private GameObject player;
    private bool shot;

    //public Transform target;

    NavMeshAgent nav;
   
    //Methods

    public void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        
    }
    public void Update()
    {
        if(health <= 0)
        {
            Die();
        }
        this.transform.LookAt(player.transform);
        if(currentTime==0)
        {
            Shoot();
        }
        if (shot && currentTime < waitTime)
            currentTime += 1 * Time.deltaTime;
        if (currentTime >= waitTime)
            currentTime = 0;
        nav.SetDestination(player.transform.position);
    }

    //trebuie scriptul de shoot si bullet de la Dani
    public void Die()
    {
        
        Destroy(this.gameObject);
    }
    public void Shoot()
    {
        shot = true;
        //print("Shot");
    }
}
