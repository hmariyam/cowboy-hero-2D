//Leen Al Harash
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPoint : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision){
        //passer de niveau 1 a niveau 2
        if (collision.CompareTag("Player")){
            // Transfère du compteur des balles
            CollisionBalle.balleCompteur = PlayerPrefs.GetInt("CompteurBalle");
            SceneManager.LoadSceneAsync(2);
        }
        //passer de niveau 2 au menu win
        else if (collision.CompareTag("Joueur")){
            SceneManager.LoadSceneAsync(4); //win
        }
    }
}