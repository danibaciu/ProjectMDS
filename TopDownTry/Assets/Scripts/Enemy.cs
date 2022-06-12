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
    private GameObject gun;

    [SerializeField]
    private Transform firingPoint;

    [SerializeField]
    private GameObject projectile;

    [SerializeField]
    private float firingSpeed;

    [SerializeField]
    private float pointsToGive;

    [SerializeField]
    private GameObject MuzzleFlash;
    

    private float currentTime;
    private GameObject player;
    private bool shot;
    private Animator anim;
    private float curent_x=0;
    private float curent_z=0;
    public float minDistance;
    //public Transform target;

    private float lastTimeShot = 0;

    NavMeshAgent nav;
   
    //Methods

    public void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = corp.GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
        
    }
    public void Shoot()
    {
        if (lastTimeShot + firingSpeed < Time.time)
        {
            lastTimeShot = Time.time;
            Instantiate(projectile, firingPoint.position, firingPoint.rotation);
            MuzzleFlash.SetActive(true);
            StartCoroutine(wait());
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.04f);
        MuzzleFlash.SetActive(false);
    }



    public void Update()
    {
        float x = this.transform.position.x;
        float z = this.transform.position.z;

        anim.SetFloat("Speed", Mathf.Abs(x-curent_x)+Mathf.Abs(z-curent_z)); 

        curent_x = x;
        curent_z = z;

        //nav.SetDestination(player.transform.position);
        float distance = Vector3.Distance(player.transform.position, this.transform.position);
        this.transform.LookAt(player.transform);

        if (distance < minDistance && player.transform.hasChanged)
        {

            
            this.nav.SetDestination(player.transform.position);

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
                Shoot();
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

        float playerPoints = player.GetComponent<PlayerController>().points;

        if (PlayerPrefs.HasKey("highScore"))
        {
            if (playerPoints > PlayerPrefs.GetFloat("highScore"))
            {
                PlayerPrefs.SetFloat("highScore", playerPoints);
                PlayerPrefs.Save();
            }
        }
        else
        {   
            PlayerPrefs.SetFloat("highScore", playerPoints);
            PlayerPrefs.Save();
        }
        EnemySpawn.Instance.enemyCount-=1;
        Destroy(this.gameObject);
        
    }
    
    
}
