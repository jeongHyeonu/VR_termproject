using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorMove : MonoBehaviour
{
    [SerializeField] float duration = 1f;
    [SerializeField] GameObject nextObject;
    [SerializeField] float degree_X = 0f;

    private void Start()
    {
        MoveConveyorCube();
    }

    public void MoveConveyorCube()
    {
        this.transform.DOMove(nextObject.transform.position, duration).From(this.transform.position).SetLoops(-1).SetEase(Ease.Linear);
        if (degree_X==0f) return;
        else this.transform.DOLocalRotate(new Vector3(degree_X,0,-90),duration).From(new Vector3(-90,0,-90)).SetLoops(-1).SetEase(Ease.Linear);
    }
}
