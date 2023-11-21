using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecycleItem : MonoBehaviour
{
    [SerializeField] GameObject conveyorBeltObj;
    private float moveSpeed;
    private bool istemOnConveyor = false;

    private void OnCollisionStay(Collision collision)
    {
        //moveSpeed = conveyorBeltObj
        //istemOnConveyor = true;
    }
}
