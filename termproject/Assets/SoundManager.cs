using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance = null;
    private AudioSource audioSource;

    [SerializeField] private AudioClip wrongSound;
    [SerializeField] private AudioClip answerSound;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            // DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        this.audioSource = GetComponent<AudioSource>();
    }

    public void RecycleWrongSound()
    {
        audioSource.PlayOneShot(wrongSound);
    }

    public void RecycleAnswerSound()
    {
        audioSource.PlayOneShot(answerSound);
    }

    public void playByClip(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
