using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class _manager : MonoBehaviour
{
    public GameObject tempsUI;
    public GameObject scoreUI;
    public int temps;
    public float timer;
    public int score1 = 0;
    public int score2 = 0;
    // Start is called before the first frame update
    void Start()
    {
        temps = 300;
        timer = 0f;
        tempsUI.GetComponent<Text>().text = temps.ToString();
        scoreUI.GetComponent<Text>().text = score1.ToString() + " - " + score2.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer>1.0f) {
            temps -= 1;
            timer = 0f;
            tempsUI.GetComponent<Text>().text = temps.ToString();
        }
        if (temps == 0)
        {
            SceneManager.LoadScene("scenefin");
        }
    }

    public void displayScore(int number, int team)
    {
        if(team==1)
        {
            score1 += number;
        }
        else
        {
            score2 += number;
        }
        
        scoreUI.GetComponent<Text>().text = score1.ToString() + " - " + score2.ToString();
    }
}
