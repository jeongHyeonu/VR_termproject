using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecycleItem : MonoBehaviour
{
    public enum ItemType
    {
        pet,
        plastic_pp,
        plastic_pe,
        plastic_ps,
        plastic_other,
        vinyl_pp,
        vinyl_pe,
        vinyl_ps,
        vinyl_other,
        brown_glass,
        green_glass,
        white_glass,
        can,
        paper,
        compounds,
        not_recycleAble
    }

    [SerializeField] public string objectName;
    [SerializeField] public ItemType itemType;
    [SerializeField] public bool isSubObject;
    [SerializeField] public List<RecycleItem> subObjList;

    [SerializeField] public string wrongTxt; // 틀리면 나올 텍스트메세지
    [SerializeField] public AudioClip wrongSound; // 틀리면 나올 음성메세지

    //[SerializeField] public ItemType type;
    public void ChangeSubObject() { isSubObject = false; }

    public void RemoveSubObject(RecycleItem i) 
    {
        subObjList.Remove(i);
    }
}
