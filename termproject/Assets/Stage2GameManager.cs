using DG.Tweening;
using DG.Tweening.Core.Easing;
using Meta.WitAi.Lib;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Stage2GameManager : MonoBehaviour
{

    public static Stage2GameManager instance = null;

    [SerializeField] public TextMeshProUGUI timeText;
    [SerializeField] public TextMeshProUGUI scoreText;
    [SerializeField] public TextMeshProUGUI alertText;
    [SerializeField] public GameObject itemSpawnPoint;
    [SerializeField] public List<GameObject> itemList;
    
    private List<bool> isSpawned = new List<bool>();

    private int totalScore;
    private bool gameStoped = true;
    public float limitTime = 90f;
    int min;
    float sec;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            // DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        // ������ ������Ʈ ��� List<bool> �ʱ�ȭ
        for(int i=0;i<itemList.Count;i++) isSpawned.Add(false);

        Invoke("GameStart", 5f); // 5�� �� ���ӽ���
    }

    void Update()
    {
        if (gameStoped) return;

        limitTime -= Time.deltaTime;

        if (limitTime > 0f)
        {
            min = (int)limitTime / 60;
            sec = limitTime % 60;
            if (sec < 10)
            {
                timeText.text = "���� �ð� - " + min + ":0" + (int)sec;
            }
            else
            {
                timeText.text = "���� �ð� - " + min + ":" + (int)sec;
            }
            
        }
        if (limitTime <= 0)
        {
            timeText.text = "<b><color=red>�ð�����</color></b>";
            GameStop();
        }
    }

    public void GameStart()
    {
        gameStoped = false;
        totalScore = 0;
        StartCoroutine(ItemSpawner(0f));
    }

    public void GameStop()
    {
        gameStoped = true;
    }

    public void GetScore(int score)
    {
        totalScore += score;
        scoreText.text = "���� : " + totalScore;
        scoreText.transform.parent.GetComponent<Image>().DOColor(new Color(0, 0, 0, .7f), .5f).From(Color.cyan);
    }

    public void AlertMessage(string wrongTxt)
    {
        // ���� ux ����ǰ������� �������� �� ����
        alertText.transform.parent.DOKill();

        // UX �� �ؽ�Ʈ ����
        alertText.text = wrongTxt;
        alertText.transform.parent.DOScale(1f, .2f).From(0f).OnComplete(() =>
        {
            alertText.transform.parent.DOScale(0f, .2f).From(1f).SetDelay(3f);
        });
    }

    IEnumerator ItemSpawner(float _time)
    {
        // _time �ð� �Ŀ� ����
        yield return new WaitForSeconds(_time);



        while (true) // �ߺ� �����ϰ� ���� ������Ʈ �ҷ�����
        {
            // �ߺ�����
            int randomObjIdx = Random.Range(0, itemList.Count);
            if (isSpawned[randomObjIdx]) // �ߺ��� ��� üũ
            {
                // ���ѹݺ����� ũ���� �ߴ� ��쵵 �־.. �Ϻ� ���� ������Ʈ�� �ߺ� Ǯ��α�
                isSpawned[Random.Range(0, itemList.Count)] = false;
                continue;
            }

            // ������ Instantiate
            isSpawned[randomObjIdx] = true;
            GameObject randomObj = Instantiate(itemList[randomObjIdx], itemSpawnPoint.transform);
            
            break;
        }

        // ���� �����ٸ� ���� �����
        if (gameStoped) yield return null;

        // �ƴ϶�� ������ ���� ��� ����
        StartCoroutine(ItemSpawner(Random.Range(5f,10f)));
    }
}