using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;

    void Update() {
        MovementInput();
        MovementMouse();
        HandleShootInput();
    }

    void MovementInput() {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 position = new Vector3(x, 0f, z).normalized;

        transform.Translate(position * movementSpeed * Time.deltaTime, Space.World);

    }

    void MovementMouse() {
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
