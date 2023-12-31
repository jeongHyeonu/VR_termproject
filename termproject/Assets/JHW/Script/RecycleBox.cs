using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RecycleBox : MonoBehaviour
{
    [SerializeField] public RecycleItem.ItemType itemTypeReceiver;
    [SerializeField] public TextMeshProUGUI ox_text;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (itemTypeReceiver == RecycleItem.ItemType.leftOver) { Destroy(collision.gameObject); return; }
        if (Stage2GameManager.instance.gameStoped) return; // ���� ��������� ����X
       
        if (collision.gameObject.GetComponent<RecycleItem>() != null)
        {
            Destroy(collision.gameObject);
            RecycleItem item = collision.gameObject.GetComponent<RecycleItem>();
            
            if (itemTypeReceiver == item.itemType)
            {
                if (item.subObjList.Count > 0) // ��Ʈ���� ��, ���Ѳ� �� subobject �и� ���Ѱ��
                {
                    ox_text.text = "��";
                    ox_text.color = new Color(1f, .7f, 0f, .7f);
                    Stage2GameManager.instance.GetScore(5);
                    Stage2GameManager.instance.AlertMessage(item.wrongTxt);
                    if(item.wrongSound) SoundManager.instance.playByClip(item.wrongSound);
                }
                else // �׿�
                {
                    Debug.Log("����! ���� +1");
                    ox_text.text = "O";
                    ox_text.color = new Color(.2f, 1f, 0f, .7f);
                    Stage2GameManager.instance.GetScore(10);
                    SoundManager.instance.RecycleAnswerSound();
                }
            }
            else
            {
                Debug.Log("����! "+item.wrongTxt);
                ox_text.text = "X";
                ox_text.color = new Color(1f, 0f, 0f, .7f);
                SoundManager.instance.RecycleWrongSound();
                if (item.wrongSound) SoundManager.instance.playByClip(item.wrongSound);
                Stage2GameManager.instance.AlertMessage(item.wrongTxt);
            }
            StartCoroutine(OXTextOff());
        }
    }

    IEnumerator OXTextOff()
    {
        yield return new WaitForSeconds(1.5f);
        ox_text.text = "";
    }
}
