using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    [SerializeField]
    private Text scoreLabel = null;
    [SerializeField]
    private SettingsPopup settingsPopup = null;
    private int _score;

    void Start() {
        _score = 0;
        scoreLabel.text = _score.ToString();

        settingsPopup.Close();
    }

    private void Awake() {
        Messenger.AddListener(GameEvent.ENEMY_HIT, OnEnemyHit);
    }

    private void OnDestroy() {
        Messenger.RemoveListener(GameEvent.ENEMY_HIT, OnEnemyHit);
    }

    private void OnEnemyHit() {
        _score += 1;
        scoreLabel.text = _score.ToString();
    }

    public void OnOpenSettings() {
        settingsPopup.Open();
    }
}
