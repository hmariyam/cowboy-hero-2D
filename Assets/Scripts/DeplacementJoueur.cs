using System;
using UnityEngine;
using static Cinemachine.CinemachineImpulseManager.ImpulseEvent;
// Videos utilise : https://youtu.be/fE3agO5xfFw?list=PLUWxWDlz8PYKnrd27LTqOxL2lr3KhEVRT
// https://youtu.be/oBu1fUkXsk0?list=PLUWxWDlz8PYKnrd27LTqOxL2lr3KhEVRT
// Auteur : Hanfaoui Mariyam, 2240026
// Script qui contrele le joueur (deplacement avant et arriere avec les fleches gauche et droite du clavier)
// Methode de saut
public class DeplacementJoueur : MonoBehaviour {

    // Declaration des variables
    public float vitesse; // Vitesse du deplacement
    public float jumpForce; // force du saut
    public Rigidbody2D rb; // Reference le rigidBody du personnage
    public Animator animator; // Reference au personnage
    private Vector3 velocity = Vector3.zero;
    private bool isJumping;
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() {
        // Methode pour verifier si le joueur fait un saut
        #region
        // si la touche espace est enfoncee
        if (Input.GetKeyDown(KeyCode.Space) == true && isJumping == false) {
            // on ajoute une force e l'objet
            rb.velocity = Vector2.up * jumpForce;
            isJumping = true;

        }
        
        // une fois que la velocite s'approche bcp de zero, on va mettre la vaiable testSaut e false 
        if (Mathf.Abs(rb.velocity.y) < 0.01) {
            isJumping = false;
        }
        #endregion
    }

    void FixedUpdate() {

        // Variable pour le mouvement horizontal du personnage
        float mouvementHorizontal = Input.GetAxis("Horizontal") * vitesse * Time.deltaTime;

        // Methode pour le deplacement droite et gauche du joueur
        Deplacement(mouvementHorizontal);

        // Vitesse du personnage sur l'axe horizontale qui sera toujours positive
        // En theorie, la vitesse d'une personne qui recule n'est jamais negative
        // Valeur absolue de la vitesse, donc elle ne sera jamais negative
        float characterVelocity = MathF.Abs(rb.velocity.x);
        // Envoyer la vitesse e l'animator
        animator.SetFloat("Vitesse", characterVelocity);

        // // Methode qui flip le personnage horizontalement selon son deplacement
        #region
        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * 10f, 0f, 0f);
        if (Input.GetAxis("Horizontal") < 0) {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (Input.GetAxis("Horizontal") > 0) {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        #endregion
    }

    // Methode de deplacement
    void Deplacement(float _mouvementHorizontal) {
        // La direction que le joueur va se deplacer va etre base sur l'axe horizontal
        Vector3 targetVelocity = new Vector2(_mouvementHorizontal, rb.velocity.y);
        // Deplacement lisse
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);
    }
}