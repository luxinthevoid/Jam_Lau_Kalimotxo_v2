using UnityEngine;

public class eventoRiel : MonoBehaviour
{
    [SerializeField] GameObject pRotacion;
    [SerializeField] float rotacionActual;
    [SerializeField] BoxCollider2D cajaRiel;

    public bool completado = false;
    
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
        completado = false;
    }

    void Update()
    {
        if (rotacionActual >= 0f)
        {
            pRotacion.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            Debug.Log("Evento completado");
            completado = true;
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
