using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector2 target;
    private Camera cam;
    private Collider2D objetoActual;
    public bool eventoActivo = false;
    bool puedesMoverte = true;
    [SerializeField] barraPepinillo barraPep;
    [SerializeField] eventosHandler eventosHand;
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
        if (other.CompareTag("BotePepi") && !eventoActivo)
        {
            //esClickeable viene del script barraPepinillo del objeto barraPepinillo
            barraPep.esClickable = true;
            Debug.Log("Se puede abrir");

        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other == objetoActual)
            objetoActual = null;
        //esClickeable viene del script barraPepinillo del objeto barraPepinillo
        barraPep.esClickable = false;
        Debug.Log("No se puede abrir");
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
                    eventosHand.finEvento = true;
                    eventosHand.enMinijuego = false;
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
            barraPep.esClickable = false;
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
            eventosHand.enMinijuego = true;
            target = transform.position; // Frenamos en seco
            Debug.Log("Entramos minijuego - Pulsa W para salir");
        }
    }

}
