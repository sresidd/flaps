using UnityEngine;
using TMPro;


public class GameOver : MonoBehaviour
{
    SettingButtons settingButtons;
    UIManager uIManager;

    ScoreAndCoin score1;
    GameObject ScoreNCoin;
    private void Awake()
    {
        score1 = FindObjectOfType<ScoreAndCoin>();
    }

    private void Start()
    {
        settingButtons = FindObjectOfType<SettingButtons>();
        uIManager = FindObjectOfType<UIManager>();
        FindObjectOfType<lowerCollider>().OnPlayerDeath += OnGameOver;
        ScoreNCoin = uIManager.GetGameOverUI().transform.GetChild(1).transform.GetChild(0).gameObject;
        ScoreNCoin.transform.GetChild(0).GetComponent<TMP_Text>().text = "COIN: 0";
    }


    public void OnGameOver()
    {
        print("gameOver");
        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
        settingButtons.ShowGameOverUI();
        GameObject HighSC = uIManager.GetGameOverUI().transform.GetChild(1).gameObject;
        ScoreNCoin.transform.GetChild(0).GetComponent<TMP_Text>().text = "SCORE: " + score1.CurrentScore().ToString();
        ScoreNCoin.transform.GetChild(1).GetComponent<TMP_Text>().text = "COIN: " + score1.ReturnCoin().ToString();
        HighSC.transform.GetChild(2).GetComponent<TMP_Text>().text = "HIGHSCORE: " + score1.HighScore().ToString();
        HighSC.transform.GetChild(3).GetComponent<TMP_Text>().text = "TOTAL COIN: " + score1.TotalCoins().ToString();
    }
}
