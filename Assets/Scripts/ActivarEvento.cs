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
    private bool ejecutandoFregona = false;
    private bool ejecutandoRiel = false;
    private bool ejecutandoTelefonillo = false;
    private bool eventoCompletado = false;
    [SerializeField] private GameObject fregonaPlacehorlder;
    [SerializeField] private GameObject rielPlacehorlder;
    [SerializeField] private eventoFregona fregonaEvento;
    [SerializeField] private eventoRiel eventoRiel;
    [SerializeField] private telefonillop telefonillop;
    [SerializeField] private fregona freg;
    //[SerializeField] private GameObject fregonaEventoobjeto;
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
        if (ejecutandoFregona && fregonaEvento.completado)
        {

            ejecutandoFregona = false;
            eventoCompletado = true;
            fregonaPlacehorlder.SetActive(true);
            fregonaEvento.gameObject.SetActive(false);
            freg.gameObject.SetActive(false);

        }
        if (ejecutandoTelefonillo && telefonillop.completado)
        {
            ejecutandoTelefonillo = false;
            eventoCompletado = true;
            telefonillop.gameObject.SetActive(false);
            listaMarcos[eventNum].SetActive(false);
        }
        if (ejecutandoRiel && eventoRiel.completado)
        {
            ejecutandoRiel= false;
            eventoCompletado = true;
            eventoRiel.gameObject.SetActive(false);
            rielPlacehorlder.SetActive(true);
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
            case 1:
                //fregona
                Debug.Log("Ejecutando evento 1: fregona");
                ejecutandoFregona = true;
                fregonaPlacehorlder.SetActive(false);
                fregonaEvento.gameObject.SetActive(true);
                freg.gameObject.SetActive(true);
                break;
            case 2:
                Debug.Log("Ejecutando evento 2: telefonillo");
                ejecutandoTelefonillo = true;
                telefonillop.gameObject.SetActive(true);
                listaMarcos[eventNum].SetActive(true);
                break;
            case 3:
                Debug.Log("Ejecutando evento 3: Riel");
                ejecutandoRiel = true;
                eventoRiel.gameObject.SetActive(true);
                rielPlacehorlder.SetActive(false);
                break;
                case 4:
                    Debug.Log("Ejecutando evento 4: Telefono");
                break;

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

        pendingEvent = false;
    }
}
