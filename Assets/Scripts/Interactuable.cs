using UnityEngine;

public class Interactuable : MonoBehaviour
{
    public bool activated = false;

    private SpriteRenderer spriteRenderer;
    private Color colorOriginal;
    [SerializeField] private Color colorActivado = Color.pink;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            colorOriginal = spriteRenderer.color;
        }
    }

    public void Accion()
    {
        activated = !activated;
        Debug.Log("Objeto " + gameObject.name + " ahora está: " + activated);
    }

    void Update()
    {
        if (spriteRenderer == null) return;

        if (activated)
        {
            spriteRenderer.color = colorActivado;
        }
        else
        {
            spriteRenderer.color = colorOriginal;
        }
    }
}