using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject theEnemy;
    private GameObject player;
    private PlayerController playerScript;
    private int xPos;
    private int zPos;
    private int xTry1;
    private int xTry2;
    private int xTry3;
    private int zTry1;
    private int zTry2;
    private int zTry3;
    private int sp;
    
    public int enemyCount;
    public float timeBetSpawn;
    public int ScoreMaxEnemies;
    public int radiusNotToSpawn;

    public static EnemySpawn Instance;

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
        Instance = GetComponent<EnemySpawn>();
        EnemyDrop();
    }

    void EnemyDrop()
    {

        
        while(playerScript.points < ScoreMaxEnemies && enemyCount <3)
        {


            do
            {
                xTry1= Random.Range(-20, -18);
                zTry1 = Random.Range(4, 6);

                xTry2= Random.Range(-10, -7);
                zTry2= Random.Range(4, 5);

                xTry3 = Random.Range(-2, 1);
                zTry3 = Random.Range(14, 16);

                sp = Random.Range(1,4);
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
                else
                {
                    xPos = xTry3;
                    zPos = zTry3;
                }

            } while ((xPos < player.transform.position.x + radiusNotToSpawn) && (xPos > player.transform.position.x - radiusNotToSpawn) && (zPos < player.transform.position.z + radiusNotToSpawn) && (zPos > player.transform.position.z - radiusNotToSpawn) && player!=null);
            
            Instantiate(theEnemy, new Vector3(xPos, 0, zPos), Quaternion.identity);
            
            enemyCount += 1;
        }
    }
}
