using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZoneMort : MonoBehaviour{
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Joueur")) {
            SceneManager.LoadSceneAsync(3);
        }
    }
}