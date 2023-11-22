using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorMoveManager : MonoBehaviour
{
    [SerializeField] private float speed; 

    private void OnCollisionStay(Collision collision)
    {
        collision.transform.parent.gameObject.GetComponent<Transform>().Translate(-Vector3.forward * speed);
    }

    private void OnCollisionExit(Collision collision)
    {
        //collision.gameObject.GetComponent<Rigidbody>().useGravity = true;
    }
}
