using Oculus.Interaction;
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
        not_recycleAble,
        leftOver
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

    public void SubObjectSelect(RecycleItem _item)
    {
        // 서브오브젝트 속성 재설정
        _item.GetComponent<Rigidbody>().isKinematic = false;
        _item.GetComponent<Collider>().isTrigger = false;
        _item.GetComponent<RecycleItem>().isSubObject = false;
        if(_item.transform.parent != null) _item.transform.parent.parent.GetComponent<RecycleItem>().RemoveSubObject(_item); // 하드코딩 ㅈㅅ.. 구현은 이게 빨라서
        _item.transform.transform.parent = null; // 하드코딩 ㅈㅅ.. ㅋㅋㅋ
        Destroy(_item.GetComponent<InteractableUnityEventWrapper>());
    }
}
