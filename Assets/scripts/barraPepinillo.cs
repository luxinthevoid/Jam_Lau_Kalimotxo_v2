using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class barraPepinillo : MonoBehaviour
{
    [SerializeField]public Slider barra;
    [SerializeField] float valorClick = 1f;
    [SerializeField] float valorPerdida = -1f;
    [SerializeField] float valorActual;
    public bool completado = false;

    public bool esClickable = false;

    void awake()
    {
        barra = gameObject.GetComponent<Slider>();
        barra.value = 0;
    }
    void OnEnable()
    {
        barra.value = 0;
    }
    void Update()
    {
        valorActual = barra.value;
        if (!completado)
        {
            if (esClickable && Input.GetMouseButtonDown(0))
            {
                Progreso(valorClick);
            }
            Progreso(valorPerdida * Time.deltaTime);
            if(valorActual >=99)
            {
                completado = true;
                Debug.Log("Barra completada");
            }
        }
        else
        {
            barra.value = 100;
            esClickable = false;
        }
    }

    public void Progreso(float valor)
    {
        barra.value += valor;
    }

}
