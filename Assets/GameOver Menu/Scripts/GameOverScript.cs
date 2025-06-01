//Leen Al Harash
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour {

    // Déclaration d'une variable pour initialiser le compteur des balles
    public int balleCompteur = 0;

    public void RePlayGame(){
        CollisionBalle.balleCompteur = PlayerPrefs.GetInt("CompteurBalle");
        CollisionBalle.balleCompteur = balleCompteur;
        SceneManager.LoadSceneAsync(1);
    }

    public void ReturnToMenu(){
        SceneManager.LoadSceneAsync(0);
    }
}