//Leen Al Harash
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//EnObCollision - Enemie Obstacle Collision
public class EnObCollision : MonoBehaviour{
    [SerializeField] private AudioClip audioHitScorpion = null;
    private AudioSource audioSource;
    private Rigidbody2D rb;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
    }

    //si on touche un enemie/un obstacle on perd un coeur, si les coeurs = 0 , le cowboy meurt
    private void HandleScorpionCollision(Transform scorpionTransform) {
        PlayHitSound();
        HealthManager.health--;

        if (HealthManager.health <= 0) {
            SceneManager.LoadScene("GameOver Menu");
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.transform.CompareTag("Scorpions")) {
            HandleScorpionCollision(collision.transform);
        }
    }

    //sound s'il touche des obstacles/ennemies
    private void PlayHitSound() {
        if (audioHitScorpion != null && audioSource != null) {
            audioSource.PlayOneShot(audioHitScorpion);
        }
    }
}