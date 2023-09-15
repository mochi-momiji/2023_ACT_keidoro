using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;
using UnityEngine.SceneManagement;

public class GMController : MonoBehaviour
{
    private const float PLAYTIME = 120.0f;
    [SerializeField] GameObject timerText = null;
    [SerializeField] GameObject scoreText = null;
    [SerializeField] GameObject itemText = null;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = PLAYTIME;
    }

    // Update is called once per frame
    void Update()
    {
        playTimer();

    }
    private void playTimer()
    {
        timer -= Time.deltaTime;
        timerText.GetComponent<TextMeshProUGUI>().text = "Time:" + timer.ToString("F2");
        if(timer < 0.0f)
        {
            SceneManager.LoadScene("EndScene");
        }
    }
}
