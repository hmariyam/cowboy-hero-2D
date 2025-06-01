using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

// Auteur : Mariyam Hanfaoui
public class CollisionBalle : MonoBehaviour {
    // Declaration des variables
    int balleCompteurAffichage;
    public static int balleCompteur;
    public TMP_Text balleCompteurText;
    public AudioClip audioColletingItems = null; // Pour collecter les balles
    public AudioSource perso_AudioSource;

    public void Start() {
        balleCompteurText.text = ": " + balleCompteur;
    }

    // Methode pour incrementer le compteur des balles
    private void OnTriggerEnter2D(Collider2D trigger) {
        #region 
        print("Vous etre rentre en collision");
        // Verifie si la balle est egale au tag Balle ainsi que si elle est active afin d'eviter de la collecter
        if (trigger.CompareTag("Balle") && trigger.gameObject.activeSelf) {
            print("Vous etre rentre en collision");
            Destroy(trigger.gameObject);
            balleCompteur +=  1;
            balleCompteurAffichage = balleCompteur;
            // Affichage du compteur
            balleCompteurText.text = ": " + balleCompteurAffichage;
            // Attribuer le compteur a une cle
            PlayerPrefs.SetInt("CompteurBalle", CollisionBalle.balleCompteur);
            // Sauvegarder le compteur
            PlayerPrefs.Save();

            //sons
            if (audioColletingItems != null && perso_AudioSource != null){
                AudioSource.PlayClipAtPoint(audioColletingItems, transform.position);
            }
        }
        #endregion

    }
}