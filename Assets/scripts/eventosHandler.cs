using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class eventosHandler : MonoBehaviour
{
    [SerializeField] barraPepinillo barraPep;
    [SerializeField] Player player;
    [SerializeField] float tiempoEntreEventos = 10f;
    [SerializeField] float elapsedTime = 0f;
    [SerializeField] float finDeEventoTiempo = 16f;
    [SerializeField] float tiempoEnEvento = 0f;
    [SerializeField] bool completado = false;
    [SerializeField] bool enEvento = false;
    [SerializeField] public List<Interactuable> listaDeEventos = new List<Interactuable>();
    [SerializeField] float recompensa;
    public bool finEvento = false;
    public bool enMinijuego = false;


    void Update()
    {
        if (!enEvento)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= tiempoEntreEventos)
            {
                completado = false;
                barraPep.esClickable = false;
                enEvento = true;
                player.eventoActivo= enEvento;
                int randomEvent = Random.Range(0, listaDeEventos.Count);
                StartCoroutine(startEvent(randomEvent));
            }
        }
    }

    IEnumerator startEvent(int randomEvent)
    {
        listaDeEventos[randomEvent].GetComponent<Interactuable>().activated = true;
        //variamos randomEvent para que se vea bien el log
        randomEvent++;
        Debug.Log("evento "+randomEvent+ " activado");
        randomEvent--;

        while (!completado)
        {
            if(enMinijuego)
            tiempoEnEvento += Time.deltaTime;

            if (finEvento)
            {
                finEvento = false;
                completado = true;
                //recompensa = 20f;
            }

            yield return null;
        }
        if(tiempoEnEvento > finDeEventoTiempo)
        {
            //castigo por tardon
            Debug.Log("Castigo por tardon");

            recompensa = -10f;
        }

        barraPep.Progreso(recompensa);
        tiempoEnEvento = 0f;
        elapsedTime = 0f;
        barraPep.esClickable = true;
        enEvento = false;
        player.eventoActivo = enEvento;
    }

}