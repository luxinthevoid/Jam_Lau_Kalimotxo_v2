using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class eventosHandler : MonoBehaviour
{
    [SerializeField] barraPepinillo barraPep;
    [SerializeField] ActivarEvento actEv;
    [SerializeField] Player player;
    [SerializeField] float tiempoEntreEventos = 10f;
    [SerializeField] float elapsedTime = 0f;
    [SerializeField] float finDeEventoTiempo = 16f;
    [SerializeField] float tiempoEnEvento = 0f;
    [SerializeField] bool completado = false;
    [SerializeField] bool enEvento = false;
    [SerializeField] public List<Interactuable> listaDeInteractuables = new List<Interactuable>();
    [SerializeField] float recompensa;
    public bool finEvento = false;
    public bool enMinijuego = false;

    private void OnEnable()
    {
        elapsedTime = 0f;
        tiempoEnEvento = 0f;
        completado = false;
        enEvento = false;
        finEvento = false;
        enMinijuego = false;
    }

    void Update()
    {
        if (!enEvento)
        {
            //Debug.Log("Tiempo: " + elapsedTime);
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= tiempoEntreEventos)
            {
                completado = false;
                barraPep.esClickable = false;
                enEvento = true;
                player.eventoActivo = enEvento;

                int randomEvent = Random.Range(0, listaDeInteractuables.Count);
                listaDeInteractuables[randomEvent].GetComponent<Interactuable>().gameObject.SetActive(true);
                StartCoroutine(startEvent(randomEvent));//cambiar por randomEvent cuando termine el testing

            }
        }
    }

    IEnumerator startEvent(int randomEvent)
    {
        //Debug.LogWarning($"Evento iniciado en eventoHandler: {randomEvent}");
        actEv.activarEvento(randomEvent);//llamar al script del evento para que se active el evento seleccionado
        //aviso visual
        listaDeInteractuables[randomEvent].GetComponent<Interactuable>().activated = true;//cambia el sprite del box colider


        //mientras que no este completado el evento, se va a quedar en este bucle, y se va a ir sumando el tiempo que el jugador tarda en completar el evento una vez el jugador llegue al minijuego
        while (!completado)
        {
            if (enMinijuego)
                tiempoEnEvento += Time.deltaTime;

            if (finEvento)
            {
                finEvento = false;
                completado = true;
                //recompensa = 20f;
            }
            if (completado)
            {
                barraPep.Progreso(recompensa);
                tiempoEnEvento = 0f;
                elapsedTime = 0f;
                enEvento = false;
                player.eventoActivo = enEvento;
                listaDeInteractuables[randomEvent].GetComponent<Interactuable>().activated = false;//devuelve el sprite del box colider
            }
            yield return null;
        }
        Debug.LogWarning($"Evento finalizado en eventoHandler: {randomEvent}");

        if (tiempoEnEvento > finDeEventoTiempo)
        {
            //castigo por tardon
            //Debug.Log("Castigo por tardon");

            recompensa = -10f;
        }
        else
        {
            recompensa = 0f;
        }
        
        


    }

}