using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner2 : MonoBehaviour
{
  public GameObject theEnemy;
    private GameObject player;
    private PlayerController playerScript;
    private int xPos;
    private int zPos;
    private int xTry1;
    private int xTry2;
    private int xTry3;
    private int xTry4;
    private int xTry5;
    private int xTry6;
    private int zTry1;
    private int zTry2;
    private int zTry3;
    private int zTry4;
    private int zTry5;
    private int zTry6;
    private int sp;
    
    public int enemyCount;
    public float timeBetSpawn;
    public int ScoreMaxEnemies;
    public int radiusNotToSpawn;

    public static EnemySpawner2 Instance;

    void Start()
    {
        enemyCount = 0;
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");
        if (playerScript == null)
            playerScript=player.GetComponent<PlayerController>();
        EnemyDrop();
    }
    void Update()
    {
        Instance = GetComponent<EnemySpawner2>();
        EnemyDrop();
    }

    void EnemyDrop()
    {

        
        while(playerScript.points < ScoreMaxEnemies && enemyCount <5)
        {


            do
            {
                xTry1= Random.Range(-14, -11);
                zTry1 = Random.Range(-16, -14);

                xTry2= Random.Range(-22, -20);
                zTry2= Random.Range(13, 10);

                xTry3 = Random.Range(7, 10);
                zTry3 = Random.Range(-22, -21);

                xTry4 = Random.Range(-23, -19);
                zTry4 = Random.Range(-12, -10);

                xTry5 = Random.Range(19, 21);
                zTry5 = Random.Range(0, -2);

                xTry6 = Random.Range(18, 21);
                zTry6 = Random.Range(20, 22);

                sp = Random.Range(1,7);
                if(sp == 1)
                {
                    xPos = xTry1;
                    zPos = zTry1;
                }
                else if(sp == 2)
                {
                    xPos = xTry2;
                    zPos = zTry2;
                }
                else if(sp == 3)
                {
                    xPos = xTry3;
                    zPos = zTry3;
                }
                else if(sp == 4)
                {
                    xPos = xTry4;
                    zPos = zTry4;
                }
                else if(sp == 5)
                {
                    xPos = xTry5;
                    zPos = zTry5;
                }
                else
                {
                    xPos = xTry6;
                    zPos = zTry6;
                }

            } while ((xPos < player.transform.position.x + radiusNotToSpawn) && (xPos > player.transform.position.x - radiusNotToSpawn) && (zPos < player.transform.position.z + radiusNotToSpawn) && (zPos > player.transform.position.z - radiusNotToSpawn) && player!=null);
            
            Instantiate(theEnemy, new Vector3(xPos, 0, zPos), Quaternion.identity);
            
            enemyCount += 1;
        }
    }
}
