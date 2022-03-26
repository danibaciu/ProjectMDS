using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    public float health;

    [SerializeField]
    public float waitTime;

    private float currentTime;
    private GameObject player;
    private bool shot;

    
    public float minDistance;

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
        
        if(currentTime==0)
        {
            Shoot();
        }
        if (shot && currentTime < waitTime)
            currentTime += 1 * Time.deltaTime;
        if (currentTime >= waitTime)
            currentTime = 0;
        

        float distance = Vector3.Distance(player.transform.position, transform.position);
        
        if (distance < minDistance && player.transform.hasChanged)
        {
            nav.isStopped = false;

            this.transform.LookAt(player.transform);
            nav.SetDestination(player.transform.position);

            
        }
        else
            nav.isStopped = true;
       
        
            
        
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
