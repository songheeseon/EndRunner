using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region instance 
    public static GameManager instance;
    private void Awake()
    {
        if(instance!=null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    #endregion

    public delegate void OnPlay(bool isPlay);
    public OnPlay onPlay;

    public float gameSpeed = 1;
    public bool isplay = false;
    public GameObject playBtn;
    public Text scoreTxt;
    public Text BestScoreTxt;


    public int score = 0;

    IEnumerator AddScore()
    {
        while (isplay)
        {
            score++;
            scoreTxt.text = score.ToString();
            gameSpeed = gameSpeed + 0.01f;

            yield return new WaitForSeconds(0.1f);
        }
    }

    private void Start()
    {
        BestScoreTxt.text = PlayerPrefs.GetInt("BestScore", 0).ToString();        
    }
    public void PlayBtnClick()
    {
        playBtn.SetActive(false);
        isplay = true;
        onPlay.Invoke(isplay);
        score = 0;
        scoreTxt.text = score.ToString();
        StartCoroutine(AddScore());
    }

    public void GameOver()
    {
        playBtn.SetActive(true);
        isplay = false;
        onPlay.Invoke(isplay);
        StopCoroutine(AddScore());
        if(PlayerPrefs.GetInt("BestScore", 0) < score)
        {
            PlayerPrefs.SetInt("BestScore", score);
            BestScoreTxt.text = score.ToString();
        }
        
    }
}
