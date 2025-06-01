using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// Auteur : Hanfaoui Mariyam
// Video utilise : https://youtu.be/G1AQxNAQV8g

public class ControleJeu : MonoBehaviour {

    // Declaration des variables
    public GameObject pauseMenu;

    // Start is called before the first frame update
    void Start() {
        pauseMenu.SetActive(false);
    }

    public void Pause() {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Continuer() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Menu() {
        SceneManager.LoadSceneAsync(0);
    }
}