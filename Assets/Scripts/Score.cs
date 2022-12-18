using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public int isCovid = 1;
    public int isVaccinated = 0;
    int people = 15;
    public bool initScore = false;
    bool flag = true;

    TextMeshProUGUI resourceText1;
    TextMeshProUGUI resourceText2;
    TextMeshProUGUI resourceText3;
    TextMeshProUGUI resourceText4;
    GameObject gameOver;
    GameObject gameSuccess;


    void Start()
    {
        gameOver = GameObject.Find("Canvas/GameOver");
        gameSuccess = GameObject.Find("Canvas/GameSuccess");
        gameOver.SetActive(false);
        gameSuccess.SetActive(false);

        resourceText1 = GameObject.Find("Canvas/ScoreBoard/ScoreBoard1/Text").GetComponent<TextMeshProUGUI>();
        resourceText1.text = isVaccinated.ToString() + " / " + people.ToString();
        resourceText2 = GameObject.Find("Canvas/ScoreBoard/ScoreBoard2/Text").GetComponent<TextMeshProUGUI>();
        resourceText2.text = isVaccinated.ToString() + " / " + people.ToString();
        resourceText3 = GameObject.Find("Canvas/ScoreBoard/ScoreBoard3/Text").GetComponent<TextMeshProUGUI>();
        resourceText3.text = isVaccinated.ToString() + " / " + people.ToString();
        resourceText4 = GameObject.Find("Canvas/ScoreBoard/ScoreBoard4/Text").GetComponent<TextMeshProUGUI>();
        resourceText4.text = isVaccinated.ToString() + " / " + people.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        if(initScore)
        {
            resourceText1.text = isVaccinated.ToString() + " / " + people.ToString();
            resourceText2.text = isVaccinated.ToString() + " / " + people.ToString();
            resourceText3.text = isVaccinated.ToString() + " / " + people.ToString();
            resourceText4.text = isVaccinated.ToString() + " / " + people.ToString();
            initScore = false;
        }

        if (isVaccinated + isCovid == 15)
        {
            if (isVaccinated <= 9 && flag)
            {
                // 게임 오버
                gameOver.SetActive(true);
                GameObject.Find("Student").SetActive(false);
                flag = false;
            }

            if (isVaccinated >= 10 && flag)
            {
                // 게임 완료
                gameSuccess.SetActive(true);
                GameObject.Find("Student").SetActive(false);
                flag = false;

            }
        }
    }
}
