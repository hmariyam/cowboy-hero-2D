using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformesL : MonoBehaviour {

    // Methode pour garder le joueur sur la platforme - entrer
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            collision.gameObject.transform.parent = transform;
        }
    }
    // Methode pour garder le joueur sur la platforme - sortir
    private void OnCollisionExit2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Player")) {
            collision.gameObject.transform.parent = null;
        }
    }
}