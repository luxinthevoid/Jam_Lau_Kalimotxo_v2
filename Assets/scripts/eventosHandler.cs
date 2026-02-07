using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class eventosHandler : MonoBehaviour
{
    [SerializeField] barraPepinillo barraPep;
    [SerializeField] float tiempoEntreEventos = 10f;
    [SerializeField] float elapsedTime = 0f;
    [SerializeField] float finDeEvento = 16f;
    [SerializeField] float tiempoEnEvento = 0f;
    [SerializeField] bool completado = false;
    [SerializeField] bool enEvento = false;
    [SerializeField] public List<Interactuable> listaDeEventos = new List<Interactuable>();
    [SerializeField] float recompensa;

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

        while (!completado && tiempoEnEvento < finDeEvento)
        {
            tiempoEnEvento += Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.W))
            {
                completado = true;
                //recompensa = 20f;
            }

            yield return null;
        }
        if (!completado) recompensa = -10f;

        barraPep.Progreso(recompensa);
        tiempoEnEvento = 0f;
        elapsedTime = 0f;
        barraPep.esClickable = true;
        enEvento = false;
    }

}