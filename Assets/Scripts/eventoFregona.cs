using UnityEngine;

public class eventoFregona : MonoBehaviour
{
    [SerializeField] GameObject mancha;
    [SerializeField] fregona freg;

    public bool completado = false;
    float timer = 0;
    int cont = 3;

    void OnEnable()
    {
        cont = 3;
        completado = false;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (cont > 0)
        {
            if (timer > 1f)
            {
                Debug.Log("Contador de manchas: " + cont);

                CrearMancha();
                timer = 0f;
                cont--;
            }
        }

        if (freg.limpio)
        {
            Debug.Log("Evento completado");
            this.enabled = false;
            completado = true;
        }
    }

    void CrearMancha()
    {
        // Desplazamientos aleatorios alrededor del transform
        float desplazamientoX = Random.Range(1.8f, 5.5f);
        Debug.Log("Desplazamiento X para mancha: " + desplazamientoX);
        float desplazamientoY = Random.Range(-3.7f, -1.9f);
        Debug.Log("Desplazamiento Y para mancha: " + desplazamientoY);

        Vector3 posicionFinal = new Vector3(desplazamientoX, desplazamientoY, 0f);
        Debug.Log("Posición final para mancha: " + posicionFinal);

        Instantiate(mancha, posicionFinal, Quaternion.identity);
    }
}