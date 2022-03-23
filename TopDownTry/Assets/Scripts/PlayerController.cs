using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float  speed;

    // Update is called once per frame
    void Update()
    {
        MovementInput();
        RotationInput();
        HandleShootInput();
    }
    void MovementInput()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(x, 0f,z).normalized;

        transform.Translate(dir *speed* Time.deltaTime, Space.World );


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
}
