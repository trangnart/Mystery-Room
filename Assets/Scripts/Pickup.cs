using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public float pickUpRange=5;
    public float moveForce = 250;
    public Transform holdParent;
    public GameObject heldObj;
    public GameManager gameManager;

    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E)) {
            // if the object has not been picked up yet: 
            if (heldObj == null) {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange)) {
                    PickupObject(hit.transform.gameObject);
                }

            } else {
                DropObject();

            }
        }

        if (heldObj != null) {
            MoveObject();
        }
    }

    void MoveObject () {
        if (Vector3.Distance(heldObj.transform.position, holdParent.position) > 0.1f) {
            Vector3 moveDirection = (holdParent.position - heldObj.transform.position);
            heldObj.GetComponent<Rigidbody>().AddForce(moveDirection * moveForce);
        }
    }

    // when picking up the object
    void PickupObject(GameObject pickObj) {
        if(pickObj.GetComponent<Rigidbody>()) {
            if (pickObj.layer == LayerMask.NameToLayer("DeleteObj"))
            {
                Destroy(pickObj);
                gameManager.cluesFound += 1;
                return;
            }
            Rigidbody objRig = pickObj.GetComponent<Rigidbody>();
            objRig.useGravity = false;
            objRig.drag = 10;

            objRig.transform.parent = holdParent;
            heldObj = pickObj;
        }
    }

    void DropObject() {
        Rigidbody heldRig = heldObj.GetComponent<Rigidbody>();
        heldRig.useGravity = true;
        heldRig.drag = 1;

        heldObj.transform.parent = null;
        heldObj = null;

    }
}