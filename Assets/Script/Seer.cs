using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Seer : MonoBehaviour {
    private int min;
    private int max;
    private int guess;
    private LevelManager levelManager = GameObject.FindObjectOfType<LevelManager>();

    public int attemps;
    public Text guessLabel;


	// Use this for initialization
	void Start () {
        StartGame();
	}

    private void StartGame() {
        min = 1;
        max = 1001;
        NextGuess();
        ShowGuess();
    }

    private void NextGuess() {
        guess = UnityEngine.Random.Range(min, max);
        attemps--;
    }

    private void ShowGuess() {
        if (attemps >= 0) {
            guessLabel.text = "Is your number " + guess + "?";
        } else {
            SceneManager.LoadScene("Win");
        }
    }

    public void GuessHigher() {
        if (guess == max - 1) {
            SceneManager.LoadScene("Cheat");
        } else { 
        min = guess + 1;
        NextGuess();
        ShowGuess();
        }
    }

    public void GuessLower() {
        if (guess == min) {
            SceneManager.LoadScene("Cheat");
        } else { 
        max = guess;
        NextGuess();
        ShowGuess();
        }
    }

    public void CorrectGuess() {
        SceneManager.LoadScene("Loss");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
