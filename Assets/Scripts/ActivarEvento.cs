using System.Collections.Generic;
using UnityEngine;

public class ActivarEvento : MonoBehaviour
{
    [SerializeField] public List<GameObject> listaMarcos = new List<GameObject>();
    [SerializeField] eventosHandler eventosHand;
    [SerializeField] Player player;
    private int eventNum = -1;
    private bool pendingEvent = false;
    private bool ejecutandoFogones = false;
    private bool eventoCompletado = false;
    [SerializeField] List<fogones> listaFogones = new List<fogones>();
    //[SerializeField] List<GameObject> objetosFogones = new List<GameObject>();

    void Start()
    {
    }

    public void activarEvento(int randomEvent)
    {
        //Debug.LogWarning($"LLegaEvento: {randomEvent}");

        if (randomEvent < 0 || randomEvent >= listaMarcos.Count)
        {
            Debug.LogWarning($"activarEvento: índice fuera de rango: {randomEvent}");
            return;
        }

        eventNum = randomEvent;
        pendingEvent = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (pendingEvent && eventosHand.enMinijuego)
        {
            EjecutarEvento();
        }
        //Todos los fogones completados
        if (ejecutandoFogones && listaFogones[0].completado && listaFogones[1].completado && listaFogones[2].completado)
        {
            Debug.LogWarning($"Se completan fogones");

            ejecutandoFogones = false;
            eventoCompletado = true;
            for (int i = 0; i < listaFogones.Count; i++)
            {
                listaFogones[i].gameObject.SetActive(false);
            }
            listaMarcos[eventNum].SetActive(false);
        }

        //cualquier evento completado
        if (eventoCompletado)
        {
            Debug.LogWarning($"Se restaura timer minijuego y mov jugador");

            eventoCompletado = false;
            eventosHand.finEvento = true;
            eventosHand.enMinijuego = false;
        }
    }

    private void EjecutarEvento()
    {
        Debug.LogWarning($"EjecutaEvento: {eventNum}");
        switch (eventNum)
        {
            case 0:
                //fogones
                Debug.Log("Ejecutando evento 0: Fogones");
                for (int i = 0; i < listaFogones.Count; i++)
                {
                    listaFogones[i].gameObject.SetActive(true);
                }
                listaMarcos[eventNum].SetActive(true);
                ejecutandoFogones = true;
                break;
            //case 1:
            //    Debug.Log("Ejecutando evento 1");
            //    break;
            //case 2:
            //    Debug.Log("Ejecutando evento 2");
            //    break;
            default:
                Debug.Log("Ejecutando evento default: Fogones");

                for (int i = 0; i < listaFogones.Count; i++)
                {
                    listaFogones[i].gameObject.SetActive(true);
                }
                listaMarcos[eventNum].SetActive(true);
                ejecutandoFogones = true;
                break;
        }

        if (eventNum >= 0 && eventNum < listaMarcos.Count)
        {
            listaMarcos[eventNum].SetActive(true);
        }
        pendingEvent = false;
    }
}
