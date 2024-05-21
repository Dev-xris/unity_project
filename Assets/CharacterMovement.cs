using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float X, Y, Z;
    public bool Grounded = false;

    public Rigidbody Rb;
    public CharacterController Controller;

    void Start()
    {
        Rb = GetComponent<Rigidbody>();

        Controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        X = Input.GetAxis("Horizontal");
        Y = Input.GetAxis("Vertical");

        Z = (Grounded && Input.GetKeyDown(KeyCode.Space)) ? 500 : 0;

        Controller.Move((new Vector3(X, 0, Y)).normalized * Time.deltaTime);
        Rb.AddForce((new Vector3(0, Z, 0)));
    }
    private void OnTriggerExit(Collider other)
    {
        Grounded = false;
    }
    private void OnTriggerStay(Collider other)
    {
        Grounded = true;
    }
}
