using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshThrowTrash : MonoBehaviour
{
    public string trashTag;
    private static int score = 0;
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
        }
        else if (coll.gameObject.tag != trashTag)
        {
            score += 0;
            Debug.Log("Wrong! " + coll.gameObject.name + " Is not " + trashTag + " !!!");
            Destroy(coll.gameObject);
        }
    }

}
