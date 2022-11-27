using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntController : MonoBehaviour
{

    public float speed = 5f;
    public float rotateSpeed = 100f;
    Vector3 forward;
    Vector3 right;

    void Start()
    {
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
    }

    void Update()
    {
        if (Input.anyKey)
        {
            Move();
        }
    }

    void Move()
    {
        Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 rightMovement = right * speed * Time.deltaTime * Input.GetAxisRaw("Horizontal");
        Vector3 upMovement = forward * speed * Time.deltaTime * Input.GetAxisRaw("Vertical");
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), Time.time * rotateSpeed);


        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);
        transform.forward = heading;
        transform.position += rightMovement;
        transform.position += upMovement;
    }
}