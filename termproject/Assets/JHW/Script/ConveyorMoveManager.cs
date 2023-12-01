using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorMoveManager : MonoBehaviour
{
    [SerializeField] private float speed; 

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.GetComponent<RecycleItem>() != null)
        {
            // SubObject 물체 회전값 재설정
            collision.gameObject.transform.localRotation = Quaternion.Euler(Vector3.zero);
            collision.gameObject.GetComponent<Transform>().Translate(-Vector3.right * speed);
        }

        // 컨베이너 위에 올려진 물체들 이동
        else collision.transform.parent.gameObject.GetComponent<Transform>().Translate(-Vector3.right * speed);
    }

    private void OnCollisionExit(Collision collision)
    {
        //collision.gameObject.GetComponent<Rigidbody>().useGravity = true;
    }
}
