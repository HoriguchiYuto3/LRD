using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartController : MonoBehaviour {
	private Button startButton;

    void Start () {

        //PlayerPrefs.DeleteAll();

        startButton = GameObject.Find("StartButton").GetComponent<Button>();
		startButton.onClick.AddListener(StartButtonDown);
		startButton.Select();

    }

	public void StartButtonDown() {
        SceneManager.LoadScene("Stop");
        Debug.Log(RankController.besttime[0]);
    }
}
