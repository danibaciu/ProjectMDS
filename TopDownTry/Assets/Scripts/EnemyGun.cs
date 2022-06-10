using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    [SerializeField]
    private Transform firingPoint;

    [SerializeField]
    private GameObject projectile;

    [SerializeField]
    private GameObject Corp;

    [SerializeField]
    private float firingSpeed;

    

    public static EnemyGun Instance;

    private float lastTimeShot = 0;

    void Start()
    {
        
        // path to individual firePoint : Find("Bip001/Bip001 Pelvis/Bip001 Spine/Bip001 R Clavicle/Bip001 R UpperArm/Bip001 R Forearm/Bip001 R Hand/R_hand_container/w_flamethrower/FirePointE");
        //firingPoint = this.Corp.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.transform.GetChild(2).gameObject.transform.GetChild(2).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0);
        
    }
    void Update()
    {
        Instance = GetComponent<EnemyGun>();
        
    }

    public void Shoot()
    {
        if (lastTimeShot + firingSpeed < Time.time)
        {
            lastTimeShot = Time.time;
            Instantiate(projectile, firingPoint.position, firingPoint.rotation);
        }
    }
}
