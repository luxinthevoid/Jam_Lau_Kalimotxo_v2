using UnityEngine;

public class eventoRiel : MonoBehaviour
{
    [SerializeField] float rotacionActual;

    public bool completado = false;
    
    void Awake()
    {
        this.transform.rotation = Quaternion.Euler(0f, 0f, -15f);
        rotacionActual = -15f;
    }

    void OnEnable()
    {
        this.transform.rotation = Quaternion.Euler(0f, 0f, -15f);
        rotacionActual = -15f;
        completado = false;
    }

    void Update()
    {
        if (rotacionActual >= 0f)
        {
            this.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            Debug.Log("Evento completado");
            completado = true;
        }
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rotacionActual += 5f;
            this.transform.rotation = Quaternion.Euler(0f, 0f, -15f);
        }
    }
}
