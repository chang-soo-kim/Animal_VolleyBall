using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _1PScore = null;
    [SerializeField] private TextMeshProUGUI _2PScore = null;
    [SerializeField] private GameObject GameEnd = null;
    [SerializeField] private GameObject PausePanel = null;
    [SerializeField] private TextMeshProUGUI winText = null;
    int score_1P = 0;
    int score_2P = 0;


    public void WinScore(int who)
    {
        if(who == 1)
        {
            score_1P += 1;
            _1PScore.text = "1P : " + score_1P.ToString();
        }
        else if(who == 2)
        {
            score_2P += 1;
            _2PScore.text = "2P : " + score_2P.ToString();
        }

        if (score_1P >= 5)
        {
            winText.text = "1P WIN!!";
            GameEnd.SetActive(true);
        }
        else if(score_2P >= 5)
        {
            winText.text = "2P WIN!!";
            GameEnd.SetActive(true);
        }
    }

    public void PausePanelVisible()
    {
        Time.timeScale = 0f;
        Time.fixedDeltaTime = 0.2f * Time.timeScale;
        PausePanel.SetActive(true);
    }

    public void OnHomeBtn()
    {
        SceneManager.LoadScene("HomeScene");
    }

    public void OnReStartBtn()
    {
        SceneManager.LoadScene("InGameScene");
    }

    public void OnResumeBtn()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.2f * Time.timeScale;

        PausePanel.SetActive(false);
    }

    public void OnExitBtn()
    {
        Application.Quit();
    }

}
