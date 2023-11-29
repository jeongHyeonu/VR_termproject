using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class cshThrowTrash : MonoBehaviour
{
    public string trashTag;
    private static int score = 0;
    public TMP_Text scoreText;
    public TMP_Text answerText;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == trashTag)
        {
            score += 10;
            Debug.Log(score);
            Destroy(coll.gameObject);
            answerText.text = "O";
            answerText.color = new Color(.2f, 1f, 0f, .7f);
            SoundManager.instance.RecycleAnswerSound();
            scoreText.text = "Score: " + score.ToString();
            
            StartCoroutine(TextOff());
        }
        else if (coll.gameObject.tag != trashTag)
        {
            score += 0;
            Debug.Log("Wrong! " + coll.gameObject.name + " Is not " + trashTag + " !!!");
            Destroy(coll.gameObject);
            answerText.text = "X";
            answerText.color = new Color(1f, 0f, 0f, .7f);
            SoundManager.instance.RecycleWrongSound();
            StartCoroutine(TextOff());
        }
    }

    IEnumerator TextOff()
    {
        yield return new WaitForSeconds(1.5f);
        answerText.text = "";
    }

}
