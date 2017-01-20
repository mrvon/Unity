﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryCard : MonoBehaviour {
    [SerializeField]
    private SceneController controller = null;
    [SerializeField]
    private GameObject cardBack = null;

    private int _id;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

    public int id {
        get { return _id;  }
    }

    public void SetCard(int id, Sprite image) {
        _id = id;
        GetComponent<SpriteRenderer>().sprite = image;
    }

    private void OnMouseDown() {
        if (cardBack.activeSelf && controller.canReveal) {
            cardBack.SetActive(false);
            controller.CardRevealed(this);
        }
    }

    public void Unreveal() {
        cardBack.SetActive(true);
    }

}
