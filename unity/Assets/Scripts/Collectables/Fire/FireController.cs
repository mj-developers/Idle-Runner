using System.Collections;
using UnityEngine;

public class FireController : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody2D rb2d;
    private Animator animator;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.linearVelocity = new Vector2(-speed, rb2d.linearVelocity.y);
    }

    private void OnBecameVisible()
    {
        animator.Play("FireStart", 0, 0f);
    }

    private void OnBecameInvisible()
    {
        Invoke(nameof(Destruir), 1f);
    }

    private void Destruir()
    { 
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameController gc = GameController.Instance;
            gc.AnadirColeccionable(1);
            Destroy(gameObject);
        }
    }
}
