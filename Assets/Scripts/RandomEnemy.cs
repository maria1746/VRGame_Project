using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEnemy : MonoBehaviour
{ 
    public void startGame()
    {
        int ran = Random.Range(1, 16);
        GameObject.Find("Student" + ran).tag = "Enemy";
        Debug.Log("Student" + ran + " is fist covid");
    }
}
