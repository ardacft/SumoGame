using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountDownTimer : MonoBehaviour
{
    public static int countDownTime = 3;
    public Text countDownDisplay;
    private Scene _scene;
    
    private void Awake()
    {
        _scene = SceneManager.GetActiveScene();
        Debug.Log(_scene.name);
    }

    void Start()
    {
        StartCoroutine(CountDownStart());
    }

    void Update()
    {
        if (Controller.gameOver)
        {
            countDownTime = 3;
            SpawnManager.enemyNumber = 0;
            Controller.gameOver = false;
            SceneManager.LoadScene(_scene.name);
        }
    }
    
    IEnumerator CountDownStart()
    {
        while(countDownTime > 0)
        {
            countDownDisplay.text = countDownTime.ToString();

            yield return new WaitForSeconds(1f);

            countDownTime--;

            Debug.Log(countDownTime);
        }

        countDownDisplay.text = "GO!";

        yield return new WaitForSeconds(1f);

        countDownTime = -1;
        countDownDisplay.text = " ";

        Debug.Log(countDownTime);
    }

    
}
