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

    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= tiempoEntreEventos - 0.5f)
        {
            completado = false;
            int randomEvent = Random.Range(1, 7);
            if (randomEvent == 1) evento1();
            else if (randomEvent == 2) evento2();
            else if (randomEvent == 3) evento3();
            else if (randomEvent == 4) evento4();
            else if (randomEvent == 5) evento5();
            else evento6();
        }
        if (elapsedTime >= tiempoEntreEventos)
        {
            barraPep.esClickable = false;
        }
    }

    void evento1()
    {
        if (Input.GetKeyDown("w"))
        {
            completado = true;
        }
        tiempoEnEvento += Time.deltaTime;
        if (completado)
        {
            barraPep.Progreso(20f);
            tiempoEnEvento = 0f;
            elapsedTime = 0f;
            barraPep.esClickable = true;
        }
        if (!completado && tiempoEnEvento >= finDeEvento)
        {
            barraPep.Progreso(-10f);
            tiempoEnEvento = 0f;
            elapsedTime = 0f;
            barraPep.esClickable = true;
        }
    }

    void evento2()
    {
        tiempoEnEvento += Time.deltaTime;
        if (completado)
        {
            barraPep.Progreso(20f);
            tiempoEnEvento = 0f;
            elapsedTime = 0f;
            barraPep.esClickable = true;
        }
        if (!completado && tiempoEnEvento >= finDeEvento)
        {
            barraPep.Progreso(-10f);
            tiempoEnEvento = 0f;
            elapsedTime = 0f;
            barraPep.esClickable = true;
        }
    }

    void evento3()
    {
        tiempoEnEvento += Time.deltaTime;
        if (completado)
        {
            barraPep.Progreso(20f);
            tiempoEnEvento = 0f;
            elapsedTime = 0f;
            barraPep.esClickable = true;
        }
        if (!completado && tiempoEnEvento >= finDeEvento)
        {
            barraPep.Progreso(-10f);
            tiempoEnEvento = 0f;
            elapsedTime = 0f;
            barraPep.esClickable = true;
        }
    }

    void evento4()
    {
        tiempoEnEvento += Time.deltaTime;
        if (completado)
        {
            barraPep.Progreso(20f);
            tiempoEnEvento = 0f;
            elapsedTime = 0f;
            barraPep.esClickable = true;
        }
        if (!completado && tiempoEnEvento >= finDeEvento)
        {
            barraPep.Progreso(-10f);
            tiempoEnEvento = 0f;
            elapsedTime = 0f;
            barraPep.esClickable = true;
        }
    }

    void evento5()
    {
        tiempoEnEvento += Time.deltaTime;
        if (completado)
        {
            barraPep.Progreso(20f);
            tiempoEnEvento = 0f;
            elapsedTime = 0f;
            barraPep.esClickable = true;
        }
        if (!completado && tiempoEnEvento >= finDeEvento)
        {
            barraPep.Progreso(-10f);
            tiempoEnEvento = 0f;
            elapsedTime = 0f;
            barraPep.esClickable = true;
        }
    }

    void evento6()
    {
        tiempoEnEvento += Time.deltaTime;
        if (completado)
        {
            barraPep.Progreso(20f);
            tiempoEnEvento = 0f;
            elapsedTime = 0f;
            barraPep.esClickable = true;
        }
        if (!completado && tiempoEnEvento >= finDeEvento)
        {
            barraPep.Progreso(-10f);
            tiempoEnEvento = 0f;
            elapsedTime = 0f;
            barraPep.esClickable = true;
        }
    }
}