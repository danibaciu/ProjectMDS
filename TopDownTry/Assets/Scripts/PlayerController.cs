using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float  speed;

    [SerializeField]
    private GameObject corp;

    [SerializeField]
    public float phealth;

    [SerializeField]
    public float points;

    [SerializeField]
    private float highScore;

    private Animator anim;


    void Start()
    {
        anim = corp.GetComponent<Animator>();
        if (PlayerPrefs.HasKey("highScore")) {
            highScore = PlayerPrefs.GetFloat("highScore");
        } else {
            highScore = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        MovementInput();
        RotationInput();
        HandleShootInput();
        checkStatus();
    }
    void MovementInput()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(x, 0f,z).normalized;

        transform.Translate(dir *speed* Time.deltaTime, Space.World );
        anim.SetFloat("Speed", Mathf.Abs(x)+Mathf.Abs(z)); 


    }

    void RotationInput()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit))
        {
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        }
    }

    void HandleShootInput() {
            if (Input.GetButton("Fire1")) 
            {
                    PlayerGun.Instance.Shoot();
            }
    }

    void checkStatus()
    {
        if(phealth <= 0)
        {
            if (highScore > PlayerPrefs.GetFloat("highScore"))
            {
                PlayerPrefs.SetFloat("highScore", highScore);
                PlayerPrefs.Save();
            }
            Destroy(this.gameObject);
            Application.Quit();
        }
    }
}
