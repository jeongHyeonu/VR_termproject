using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class cshPlayManager : MonoBehaviour
{
    public TMP_Text timeText;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        time = 60f;
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 0) {
            time -= Time.deltaTime;
            timeText.text = Mathf.Ceil(time).ToString();
        }
        
    }
}
