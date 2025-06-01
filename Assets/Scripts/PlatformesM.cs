using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformesM : MonoBehaviour{

    // Methodes pour garder le joueur sur la platforme
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Joueur"))
        {
            collision.gameObject.transform.parent = transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Joueur"))
        {
            collision.gameObject.transform.parent = null;
        }
    }
}