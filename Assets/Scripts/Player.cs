using System;
using UnityEngine;
using UnityEngine.InputSystem;

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
    [SerializeField] Transform origen;
    // Nuevo: referencia al Rigidbody2D
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        origen = this.transform;
        Physics2D.IgnoreLayerCollision(3, 18, true);
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        target = rb.position;

    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{

    //    if (collision.gameObject.CompareTag("Muros"))
    //    {
    //        //Debug.Log("¡Colisión física detectada con: " + collision.gameObject.name);
    //        target = transform.position;
    //    }
    //}
    void reStart()
    {
        Debug.Log("Reiniciando el juego... metodoreStart");
        rb.position = origen.position;
        barraPep.barra.value= 0;
        barraPep.completado = false;
        eventosHand.gameObject.SetActive(true);
        puedesMoverte = true;
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
            //Debug.Log("Se puede abrir");

        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other == objetoActual)
            objetoActual = null;
        //esClickeable viene del script barraPepinillo del objeto barraPepinillo
        barraPep.esClickable = false;
        //Debug.Log("No se puede abrir");
    }

    // Update is called once per frame
    void Update()
    {
        if (!barraPep.completado)
        {
            if (!puedesMoverte && objetoActual != null)
            {

                Interactuable script = objetoActual.GetComponent<Interactuable>();
                if (script != null)
                {
                    //Debug.Log("Terminamos minijuego - Movimiento restaurado");
                    //eventosHand.finEvento = true;
                    //eventosHand.enMinijuego = false;
                    if (eventosHand.finEvento == true &&
                    eventosHand.enMinijuego == false)
                    {
                        puedesMoverte = true;
                    }
                }

                return; // Salimos del Update para que no se mueva mientras pulsa W
            }
            if (Mouse.current.rightButton.wasPressedThisFrame && puedesMoverte)
            {
                Console.WriteLine("EventoRaton");
                Vector2 pos = Mouse.current.position.ReadValue();
                Vector3 worldPos = cam.ScreenToWorldPoint(pos);
                target = worldPos;
                Console.WriteLine("Posicion objetivo:" + target);
            }
            if (Mouse.current.leftButton.wasPressedThisFrame && objetoActual != null && eventoActivo)
            {
                ManageInteractuable();
            }
        }
        else
        {
            Debug.Log("¡Has ganado! Reiniciando el juego...");
            eventosHand.gameObject.SetActive(false);
            puedesMoverte = false;
            barraPep.esClickable = false;
            //EventoMoneda
            //if(eventoMoneda.win){
            //loadScene("WinScene");
            //}
            //else{
            reStart();
        }

    }

    void FixedUpdate()
    {
        // Movimiento físico usando Rigidbody2D para evitar jittering
        if (puedesMoverte && rb != null)
        {
            Vector2 nuevaPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
            rb.MovePosition(nuevaPos);
        }
    }

    void ManageInteractuable()
    {
        Interactuable scriptObjeto = objetoActual.GetComponent<Interactuable>();

        if (scriptObjeto != null && scriptObjeto.activated)
        {
            puedesMoverte = false; // Bloqueamos el movimiento
            eventosHand.enMinijuego = true;
            // Frenamos en seco usando la posición del rigidbody
            target = rb.position;
            //Debug.Log("Entramos minijuego - Pulsa W para salir");
        }
    }

}
