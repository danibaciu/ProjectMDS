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

    [SerializeField]
    private GameObject corp;

    private float currentTime;
    private GameObject player;
    private bool shot;
    private Animator anim;
    private float curent_x=0;
    private float curent_z=0;
    public float minDistance;
    //public Transform target;

    NavMeshAgent nav;
   
    //Methods

    public void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = corp.GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
        
    }
    public void Update()
    {
        float x = transform.position.x;
        float z = transform.position.z;

        anim.SetFloat("Speed", Mathf.Abs(x-curent_x)+Mathf.Abs(z-curent_z)); 

        curent_x = x;
        curent_z = z;


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

        float distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance < minDistance && player.transform.hasChanged && nav.isActiveAndEnabled)
        {
            nav.isStopped = false;

            this.transform.LookAt(player.transform);
            nav.SetDestination(player.transform.position);


        }
        else if(nav.isActiveAndEnabled)
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
