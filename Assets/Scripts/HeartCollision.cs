//Leen Al Harash
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCollision : MonoBehaviour {

    public AudioClip audioColletingItems = null; // Pour collecter les coeurs
    public AudioSource perso_AudioSource;

    private void Awake(){
        perso_AudioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Collection") && other.gameObject.activeSelf){
            print("Vous etes entre en collision avec un coeur!");

            //ajoute un coeur si le health est moins de 3
            if (HealthManager.health < 3) {
                HealthManager.health++;
            }

            //sons
            if (audioColletingItems != null && perso_AudioSource != null){
                AudioSource.PlayClipAtPoint(audioColletingItems, transform.position);
            }

            //enlever le coeur
            Destroy(other.gameObject);
        }
    }
}