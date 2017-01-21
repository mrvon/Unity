using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    [SerializeField]
    private Text scoreLabel = null;
    [SerializeField]
    private SettingsPopup settingsPopup = null;

    void Start() {
        settingsPopup.Close();
    }

    void Update () {
        scoreLabel.text = Time.realtimeSinceStartup.ToString();
	}

    public void OnOpenSettings() {
        settingsPopup.Open();
    }
}
