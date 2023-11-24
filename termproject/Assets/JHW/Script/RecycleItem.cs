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
        compounds
    }

    [SerializeField] public string objectName;
    [SerializeField] public ItemType itemType;

    //[SerializeField] public ItemType type;
}
