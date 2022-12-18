using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneManagers : MonoBehaviour
{
    GameObject student1;
    GameObject student2;
    GameObject student3;
    GameObject student4;
    GameObject student5;
    GameObject student6;
    GameObject student7;
    GameObject student8;
    GameObject student9;
    GameObject student10;
    GameObject student11;
    GameObject student12;
    GameObject student13;
    GameObject student14;
    GameObject student15;

    private void Start()
    {
        student1 = GameObject.Find("Student/Student1");
        student1.SetActive(false);
        student2 = GameObject.Find("Student/Student2");
        student2.SetActive(false);
        student3 = GameObject.Find("Student/Student3");
        student3.SetActive(false);
        student4 = GameObject.Find("Student/Student4");
        student4.SetActive(false);
        student5 = GameObject.Find("Student/Student5");
        student5.SetActive(false);
        student6 = GameObject.Find("Student/Student6");
        student6.SetActive(false);
        student7 = GameObject.Find("Student/Student7");
        student7.SetActive(false);
        student8 = GameObject.Find("Student/Student8");
        student8.SetActive(false); 
        student9 = GameObject.Find("Student/Student9");
        student9.SetActive(false);
        student10 = GameObject.Find("Student/Student10");
        student10.SetActive(false);
        student11 = GameObject.Find("Student/Student11");
        student11.SetActive(false);
        student12 = GameObject.Find("Student/Student12");
        student12.SetActive(false);
        student13 = GameObject.Find("Student/Student13");
        student13.SetActive(false);
        student14 = GameObject.Find("Student/Student14");
        student14.SetActive(false);
        student15 = GameObject.Find("Student/Student15");
        student15.SetActive(false);
    }
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void gameStart()
    {
        student1.SetActive(true);
        student2.SetActive(true);
        student3.SetActive(true);
        student4.SetActive(true);
        student5.SetActive(true);
        student6.SetActive(true);
        student7.SetActive(true);
        student8.SetActive(true);
        student9.SetActive(true);
        student10.SetActive(true);
        student11.SetActive(true);
        student12.SetActive(true);
        student13.SetActive(true);
        student14.SetActive(true);
        student15.SetActive(true);
        GameObject.Find("Canvas/StartPage").SetActive(false);
    }
}
