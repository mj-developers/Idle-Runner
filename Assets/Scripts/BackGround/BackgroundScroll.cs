using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float scrollSpeed = 2f;
    public Transform[] backgrounds;
    public float moveLimit = 0.5f;
    public float offset = 0.1f;

    private float backgroundWidth;

    void Start()
    {
        // Asumimos que todos tienen el mismo ancho
        backgroundWidth = backgrounds[0].GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        foreach (Transform bg in backgrounds)
        {
            bg.position += Vector3.left * scrollSpeed * Time.deltaTime;

            // Si ha salido completamente por la izquierda
            if (bg.position.x <= -(backgroundWidth + moveLimit))
            {
                // Buscar el fondo más a la derecha
                float maxX = backgrounds[0].position.x;
                foreach (Transform other in backgrounds)
                {
                    if (other != bg && other.position.x > maxX)
                        maxX = other.position.x;
                }

                // Reposicionarlo justo después
                bg.position = new Vector3(maxX + (backgroundWidth - offset), bg.position.y, bg.position.z);
            }
        }
    }

}
