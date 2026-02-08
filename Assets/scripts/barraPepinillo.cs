using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class barraPepinillo : MonoBehaviour
{
    [SerializeField] Slider barra;
    [SerializeField] float valorClick = 1f;
    [SerializeField] float valorPerdida = -1f;
    [SerializeField] float valorActual;

    public bool esClickable = false;

    void awake()
    {
        barra = gameObject.GetComponent<Slider>();
        barra.value = 0;
    }
    void Update()
    {
        valorActual = barra.value;
        if (barra.value < 99)
        {
            if (esClickable && Input.GetMouseButtonDown(0))
            {
                Progreso(valorClick);
            }
            Progreso(valorPerdida * Time.deltaTime);
        }
        else
        {
            barra.value = 100;
            esClickable = false;
            int cincuenta=Random.Range(0, 2);
            if (cincuenta == 0)
            {
                //cargar escena de fin de juego (animación abriendo el bote?)
                Debug.Log("Fin de juego bueno");
            }
            else
            {
                //cargar escena fin de juego alternativo (animación se te resbala el bote?)
                Debug.Log("Fin de juego bueno");
            }
        }
    }

    public void Progreso(float valor)
    {
        barra.value += valor;
    }

}
