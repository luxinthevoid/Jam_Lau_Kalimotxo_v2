using UnityEngine;

public class botonAbrir : MonoBehaviour
{
    public bool colgar = false;
    [SerializeField] GameObject botonColor;

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0)) { 
            colgar = true;
            botonColor.GetComponent<SpriteRenderer>().color = Color.red;
            Debug.Log("Botón presionado");
        }
    }
}
