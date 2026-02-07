using UnityEngine;
using System.Collections;

public class eventosHandler : MonoBehaviour
{
    [SerializeField] barraPepinillo barraPep;
    [SerializeField] float tiempoEntreEventos = 10f;
    [SerializeField] float elapsedTime = 0f;
    [SerializeField] float finDeEvento = 16f;
    [SerializeField] float tiempoEnEvento = 0f;
    [SerializeField] bool completado = false;
    [SerializeField] bool enEvento = false;

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
                int randomEvent = Random.Range(1, 7);
                if (randomEvent == 1) StartCoroutine(evento1());
                else if (randomEvent == 2) StartCoroutine(evento2());
                else if (randomEvent == 3) StartCoroutine(evento3());
                else if (randomEvent == 4) StartCoroutine(evento4());
                else if (randomEvent == 5) StartCoroutine(evento5());
                else StartCoroutine(evento6());
            }
        }
    }

    IEnumerator evento1()
    {
        Debug.Log("evento 1");
        while (!completado && tiempoEnEvento < finDeEvento)
        {
            tiempoEnEvento += Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.W))
            {
                completado = true;
                recompensa = 20f;
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

    IEnumerator evento2()
    {
        Debug.Log("evento 2");
        while (!completado && tiempoEnEvento < finDeEvento)
        {
            tiempoEnEvento += Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.W))
            {
                completado = true;
                recompensa = 20f;
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

    IEnumerator evento3()
    {
        Debug.Log("evento 3");
        while (!completado && tiempoEnEvento < finDeEvento)
        {
            tiempoEnEvento += Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.W))
            {
                completado = true;
                recompensa = 20f;
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

    IEnumerator evento4()
    {
        Debug.Log("evento 4");
        while (!completado && tiempoEnEvento < finDeEvento)
        {
            tiempoEnEvento += Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.W))
            {
                completado = true;
                recompensa = 20f;
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

    IEnumerator evento5()
    {
        Debug.Log("evento 5");
        while (!completado && tiempoEnEvento < finDeEvento)
        {
            tiempoEnEvento += Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.W))
            {
                completado = true;
                recompensa = 20f;
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

    IEnumerator evento6()
    {
        Debug.Log("evento 6");
        while (!completado && tiempoEnEvento < finDeEvento)
        {
            tiempoEnEvento += Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.W))
            {
                completado = true;
                recompensa = 20f;
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