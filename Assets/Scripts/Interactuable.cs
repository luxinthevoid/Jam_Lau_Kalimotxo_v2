using UnityEngine;

public class Interactuable : MonoBehaviour
{
    public bool activated = false;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    public void Accion()
    {
        activated = !activated;
        //Debug.Log("Objeto " + gameObject.name + " ahora está: " + activated);
    }


}