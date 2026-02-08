using UnityEngine;

public class Interfono : MonoBehaviour
{
    [SerializeField] BoxCollider2D cajaBoton;
    [SerializeField] GameObject altavoz;

    bool responder = false;
    bool oscilar = false;


    void Update()
    {
        if (!responder)
        {
            if (oscilar)
            {
                altavoz.transform.Rotate(0f, 0f, -5f);
                oscilar = false;
            }
            else
            {
                altavoz.transform.Rotate(0f, 0f, 5f);
                oscilar = true;
            }
        }
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            cajaBoton.enabled = true;
            responder = true;
            Debug.Log("Responder");
        }
    }
}
