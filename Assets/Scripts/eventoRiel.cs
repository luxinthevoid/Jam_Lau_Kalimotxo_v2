using UnityEngine;

public class eventoRiel : MonoBehaviour
{
    [SerializeField] GameObject pRotacion;
    [SerializeField] float rotacionActual;
    [SerializeField] BoxCollider2D cajaRiel;
    
    void Awake()
    {
        pRotacion.transform.rotation = Quaternion.Euler(0f, 0f, -30f);
        cajaRiel.transform.rotation = Quaternion.Euler(0f, 0f, -30f);
        rotacionActual = -30f;
    }

    void OnEnable()
    {
        pRotacion.transform.rotation = Quaternion.Euler(0f, 0f, -30f);
        cajaRiel.transform.rotation = Quaternion.Euler(0f, 0f, -30f);
        rotacionActual = -30f;
    }

    void Update()
    {
        if (rotacionActual >= 0f)
        {
            pRotacion.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            Debug.Log("Evento completado");
            cajaRiel.enabled = false;
        }
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rotacionActual += 10f;
            pRotacion.transform.rotation = Quaternion.Euler(0f, 0f, rotacionActual);
            cajaRiel.transform.rotation = Quaternion.Euler(0f, 0f, rotacionActual);
        }
    }
}
