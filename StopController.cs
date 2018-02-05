
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StopController : MonoBehaviour {
    private Button stopButton;

    GameObject text;

    float time;

    void Start () {
        this.time = 0;
        this.text = GameObject.Find("text");

        stopButton = GameObject.Find("StopButton").GetComponent<Button>();
        stopButton.onClick.AddListener(StopButtonDown);
        stopButton.Select();
	}

    void Update()
    {
        this.time += Time.deltaTime;//毎フレームの時間を加算.
        int minute = (int)time / 60;//分.timeを60で割った値.
        int second = (int)time % 60;//秒.timeを60で割った余り.
        string minText, secText, timeText;//テキスト形式の分・秒を用意.
        if (minute < 10)
            minText = "0" + minute.ToString();//ToStringでint→stringに変換.
        else
            minText = minute.ToString();
        if (second < 10)
            secText = "0" + second.ToString();//上に同じく.
        else
            secText = second.ToString();

        string cr = System.Environment.NewLine;
        timeText = minText + ":" + secText;
        this.text.GetComponent<Text>().text = timeText;
    }

    public void StopButtonDown() {
        PlayerPrefs.SetFloat("SETTIME", time);
        Debug.Log(time);
        SceneManager.LoadScene("Rank");
	}
}
