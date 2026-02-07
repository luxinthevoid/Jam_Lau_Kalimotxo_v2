using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector2 target;
    private Camera cam;
    private Collider2D objetoActual;
    bool eventoActivo = true;
    bool puedesMoverte = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;
        target = transform.position;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("¡Colisión física detectada con: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Muros"))
        {
            target = transform.position;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Interactuable"))
        {
            objetoActual = other;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other == objetoActual) 
            objetoActual = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (!puedesMoverte && objetoActual != null)
        {
            if (Keyboard.current.wKey.wasPressedThisFrame)
            {
                Interactuable script = objetoActual.GetComponent<Interactuable>();
                if (script != null)
                {
                    script.activated = false;
                    puedesMoverte = true;
                    Debug.Log("Terminamos minijuego - Movimiento restaurado");
                }
            }
            return; // Salimos del Update para que no se mueva mientras pulsa W
        }
        if (Mouse.current.rightButton.wasPressedThisFrame && puedesMoverte)
        {
            Console.WriteLine("EventoRaton");
            Vector2 pos = Mouse.current.position.ReadValue();
            target = cam.ScreenToWorldPoint(pos);
            Console.WriteLine("Posicion objetivo:" + target);
        }
        if (Mouse.current.leftButton.wasPressedThisFrame && objetoActual != null && eventoActivo)
        {
            ManageInteractuable();
        }


        if (puedesMoverte)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
    }
    void ManageInteractuable()
    {
        Interactuable scriptObjeto = objetoActual.GetComponent<Interactuable>();

        if (scriptObjeto != null && scriptObjeto.activated)
        {
            puedesMoverte = false; // Bloqueamos el movimiento
            target = transform.position; // Frenamos en seco
            Debug.Log("Entramos minijuego - Pulsa W para salir");
        }
    }
}
