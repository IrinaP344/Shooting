using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class headControllerPart1 : MonoBehaviour
{
    float xRotate;
    float yRotate;
    float sens = 3f;
    public GameObject scope;
    Image scope_image;
    public GameObject textic;
    public Transform hand;
    bool isHand = false;
    public ParticleSystem shooting;

    void Start()
    {
        scope_image = scope.GetComponent<Image>();

    }

    void shoot(GameObject arg)
    {
        if(Input.GetMouseButtonDown(0))
        {
            shooting.Play();
            Destroy(arg);
        }
    }

    // Update is called once per frame
    void Update()
    {
     
        xRotate = xRotate - Input.GetAxis("Mouse Y") * sens;
        yRotate = yRotate + Input.GetAxis("Mouse X") * sens;
        xRotate = Mathf.Clamp(xRotate, -90, 90);
        transform.rotation = Quaternion.Euler(xRotate, yRotate, 0);
        FindObjectOfType<BodyController>().SomeMethod(yRotate);
        
        Debug.DrawRay(transform.position, transform.forward * 4f, Color.red);
        scope_image.color = Color.green;
        textic.SetActive(false);

        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, 6f))
        {
            scope_image.color = Color.red;
            if(hit.collider.gameObject.tag == "Bottle")
            {
               
               textic.SetActive(true);
               shoot(hit.transform.gameObject);

               if(Input.GetKeyDown("e"))
               {
                print("Поднял бутылку");
                hit.transform.position = hand.position;
                hit.transform.SetParent(hand);
                isHand = true;
               }
            }
        }
        if(isHand == true)
        {
            if(Input.GetKeyDown("g"))
            {
                print("Выброси бутылку");
                hand.DetachChildren();
            }
        }

        if(hit.collider.gameObject.tag == "bottle")
        {
            shoot(hit.transform.gameObject);
        }


    }

}
