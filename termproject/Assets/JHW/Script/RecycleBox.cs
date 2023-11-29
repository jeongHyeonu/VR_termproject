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
        if (collision.gameObject.GetComponent<RecycleItem>() != null)
        {
            RecycleItem item = collision.gameObject.GetComponent<RecycleItem>();
            if (itemTypeReceiver == item.itemType)
            {
                if (item.subObjList.Count > 0) // 페트병의 라벨, 병뚜껑 등 subobject 분리 못한경우
                {
                    ox_text.text = "△";
                    ox_text.color = new Color(1f, .7f, 0f, .7f);
                    Stage2GameManager.instance.GetScore(5);
                    Stage2GameManager.instance.AlertMessage(item.wrongTxt);
                    SoundManager.instance.playByClip(item.wrongSound);
                }
                else // 그외
                {
                    Debug.Log("정답! 점수 +1");
                    ox_text.text = "O";
                    ox_text.color = new Color(.2f, 1f, 0f, .7f);
                    Stage2GameManager.instance.GetScore(10);
                    SoundManager.instance.RecycleAnswerSound();
                }
            }
            else
            {
                Debug.Log("오답! "+item.wrongTxt);
                ox_text.text = "X";
                ox_text.color = new Color(1f, 0f, 0f, .7f);
                SoundManager.instance.RecycleWrongSound();
            }
            StartCoroutine(OXTextOff());
            Destroy(item.gameObject);
        }
    }

    IEnumerator OXTextOff()
    {
        yield return new WaitForSeconds(1.5f);
        ox_text.text = "";
    }
}
