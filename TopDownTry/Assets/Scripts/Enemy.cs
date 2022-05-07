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

    [SerializeField]
    private float pointsToGive;
    

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

        //nav.SetDestination(player.transform.position);
        float distance = Vector3.Distance(player.transform.position, transform.position);
        this.transform.LookAt(player.transform);

        if (distance < minDistance && player.transform.hasChanged)
        {

            
            nav.SetDestination(player.transform.position);

        }


        if(health <= 0)
        {
            Die();
        }
        // if player in range -> Shoot;
        if(currentTime==0)
        {
            if(distance < minDistance && player.transform.hasChanged)
            {
                EnemyGun.Instance.Shoot();
            }
        }
        if (shot && currentTime < waitTime)
            currentTime += 1 * Time.deltaTime;
        if (currentTime >= waitTime)
            currentTime = 0;

        
        
        

    }


    public void Die()
    {
        player.GetComponent<PlayerController>().points += pointsToGive;
        Destroy(this.gameObject);
        
    }
    public void Shoot()
    {
        shot = true;
        //print("Shot");
    }
}
