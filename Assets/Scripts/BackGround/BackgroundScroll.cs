using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float scrollSpeed = 2f;
    public Transform[] backgrounds;

    private float backgroundWidth;

    void Start()
    {
        if (backgrounds.Length < 2)
        {
            Debug.LogError("Asigna al menos 2 fondos al array backgrounds");
            enabled = false;
            return;
        }

        // Calculamos el ancho del fondo usando el SpriteRenderer
        backgroundWidth = backgrounds[0].GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        foreach (Transform bg in backgrounds)
        {
            // Mueve el fondo hacia la izquierda
            bg.position += Vector3.left * scrollSpeed * Time.deltaTime;

            // Si el fondo ha salido completamente por la izquierda
            if (bg.position.x <= -backgroundWidth)
            {
                // Encuentra el fondo más a la derecha
                Transform rightmost = backgrounds[0];
                foreach (var other in backgrounds)
                {
                    if (other.position.x > rightmost.position.x)
                        rightmost = other;
                }

                // Recoloca este fondo justo detrás del más a la derecha sin dejar espacio
                bg.position = new Vector3(rightmost.position.x + backgroundWidth, bg.position.y, bg.position.z);
            }
        }
    }
}
