using UnityEngine;

public class Interfono : MonoBehaviour
{
    [SerializeField] BoxCollider2D cajaBoton;
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            cajaBoton.enabled = true;
            Debug.Log("Responder");
        }
    }
}
