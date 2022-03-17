using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public float speed = 5f;
    public float turnTime = 0.2f;
    float turnVelocity;


    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(x, 0f,z).normalized;

        if(dir.magnitude >= 0.1f)
        {
            float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float tangle = Mathf.SmoothDampAngle(transform.eulerAngles.y,angle, ref turnVelocity, turnTime);
            transform.rotation = Quaternion.Euler(0f, tangle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, angle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
    }

}
