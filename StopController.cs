
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
        this.time += Time.deltaTime;//���t���[���̎��Ԃ����Z.
        int minute = (int)time / 60;//��.time��60�Ŋ������l.
        int second = (int)time % 60;//�b.time��60�Ŋ������]��.
        string minText, secText, timeText;//�e�L�X�g�`���̕��E�b��p��.
        if (minute < 10)
            minText = "0" + minute.ToString();//ToString��int��string�ɕϊ�.
        else
            minText = minute.ToString();
        if (second < 10)
            secText = "0" + second.ToString();//��ɓ�����.
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
