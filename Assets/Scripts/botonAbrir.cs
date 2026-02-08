using UnityEngine;

public class botonAbrir : MonoBehaviour
{
    public bool colgar = false;
    [SerializeField] GameObject botonColor;

    void OnEnable()
    {
        colgar = false;
        botonColor.GetComponent<SpriteRenderer>().color = Color.green;
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0)) { 
            colgar = true;
            botonColor.GetComponent<SpriteRenderer>().color = Color.red;
            Debug.Log("Botón presionado");
        }
    }
}
