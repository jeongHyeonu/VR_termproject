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
        // 스폰된 오브젝트 담는 List<bool> 초기화
        for(int i=0;i<itemList.Count;i++) isSpawned.Add(false);

        Invoke("GameStart", 5f); // 5초 뒤 게임시작
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
                timeText.text = "남은 시간 - " + min + ":0" + (int)sec;
            }
            else
            {
                timeText.text = "남은 시간 - " + min + ":" + (int)sec;
            }
            
        }
        if (limitTime <= 0)
        {
            timeText.text = "<b><color=red>시간종료</color></b>";
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
        scoreText.text = "점수 : " + totalScore;
        scoreText.transform.parent.GetComponent<Image>().DOColor(new Color(0, 0, 0, .7f), .5f).From(Color.cyan);
    }

    public void AlertMessage(string wrongTxt)
    {
        // 먼저 ux 실행되고있으면 강제종료 후 실행
        alertText.transform.parent.DOKill();

        // UX 및 텍스트 변경
        alertText.text = wrongTxt;
        alertText.transform.parent.DOScale(1f, .2f).From(0f).OnComplete(() =>
        {
            alertText.transform.parent.DOScale(0f, .2f).From(1f).SetDelay(3f);
        });
    }

    IEnumerator ItemSpawner(float _time)
    {
        // _time 시간 후에 실행
        yield return new WaitForSeconds(_time);



        while (true) // 중복 제거하고 랜덤 오브젝트 불러오기
        {
            // 중복제거
            int randomObjIdx = Random.Range(0, itemList.Count);
            if (isSpawned[randomObjIdx]) // 중복인 경우 체크
            {
                // 무한반복문에 크래시 뜨는 경우도 있어서.. 일부 랜덤 오브젝트는 중복 풀어두기
                isSpawned[Random.Range(0, itemList.Count)] = false;
                continue;
            }

            // 아이템 Instantiate
            isSpawned[randomObjIdx] = true;
            GameObject randomObj = Instantiate(itemList[randomObjIdx], itemSpawnPoint.transform);
            
            break;
        }

        // 게임 종료됬다면 스폰 멈춘다
        if (gameStoped) yield return null;

        // 아니라면 아이템 스폰 계속 진행
        StartCoroutine(ItemSpawner(Random.Range(5f,10f)));
    }
}
