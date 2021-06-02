using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyController : MonoBehaviour
{
    float vertical;
    float horizontal;

    float yRotate;
    Transform tr;
    Rigidbody rg;
    void Start()
    {
        tr = GetComponent<Transform>();
        rg = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        rg.AddForce(tr.forward * vertical * 20f);
        rg.AddForce(tr.right * horizontal * 20f);
        transform.rotation = Quaternion.Euler(0, yRotate, 0);

    }

    public void SomeMethod(float val)
    {
        yRotate = val;
    }
}
