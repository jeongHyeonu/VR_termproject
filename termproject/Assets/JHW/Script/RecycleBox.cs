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
                Debug.Log("정답! 점수 +1");
                ox_text.text = "O";
                ox_text.color = new Color(.2f, 1f, 0f, .7f);
                //GameManager.instance.getScore(1);
            }
            else
            {
                Debug.Log("오답!");
                ox_text.text = "X";
                ox_text.color = new Color(1f, 0f, 0f, .7f);
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
