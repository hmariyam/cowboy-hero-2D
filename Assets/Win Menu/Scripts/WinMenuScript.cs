//Leen Al Harash
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenuScript : MonoBehaviour {

    public void ReStartGame(){
        //initialisation de compteur
        CollisionBalle.balleCompteur = 0;
        SceneManager.LoadSceneAsync(1);
    }
    
    public void QuitGame(){
        Application.Quit();
    }
}