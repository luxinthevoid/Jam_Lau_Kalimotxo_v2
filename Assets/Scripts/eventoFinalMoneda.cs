using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class eventoFinalMoneda : MonoBehaviour
{
    [SerializeField] Button cara;
    [SerializeField] Button cruz;
    [SerializeField] GameObject monedaGiratoria;
    [SerializeField] int probGanar = 5;
    [SerializeField] public bool ganar = false;
    [SerializeField] public bool perder = false;
    [SerializeField] bool animacion = false;
    [SerializeField] int resultado = -1;
    [SerializeField] string txt = "";
    [SerializeField] TextMeshProUGUI txtObj;
    [SerializeField] GameObject button;
    bool continuar = false;


    void OnEnable()
    {
        cara.gameObject.SetActive(true);
        cruz.gameObject.SetActive(true);
        monedaGiratoria.SetActive(false);
        ganar = false;
        perder = false;
        string txt = "";
        resultado = -1;
        animacion = false;
        continuar = false;
        txtObj.gameObject.SetActive(false);
        button.SetActive(false);


    }
    public void Click()
    {
        continuar = true;
        
    }

    void Update()
    {
        if (animacion) //cuando se acabe la animación se cambia a true para ejecutar esto
        {
            if (continuar)
            {
                if (resultado == 0)
                {
                    Debug.Log("Ha salido" + txt);
                    ganar = true;
                }
                else
                {
                    Debug.Log("No ha salido" + txt);
                    perder = true; //se puede hacer que cuando la animación de girar la moneda termine
                                   //cambie los bool ganar o perder, para que los devuelva después de la animación.
                    if (probGanar > 1)
                        probGanar--;
                    else
                        probGanar = 1;

                }

            }
        }
    }

    public void elección(string eleccion)
    {
        Debug.Log("execute eleccion" + eleccion);
        if (!animacion)
        {
            resultado = Random.Range(0, probGanar);
            Debug.Log(resultado);
            //monedaGiratoria.SetActive(true);
            cara.gameObject.SetActive(false);
            cruz.gameObject.SetActive(false);
            txtObj.gameObject.SetActive(true);
            button.SetActive(true);
            txt = eleccion;
            animacion = true;   //temporal para probar que va
            if (resultado == 0)
            {
                txtObj.text = "¡Has abierto el bote!";
            }
            else
            {
                txtObj.text = "¡Se te resbalo el bote!";
            }
        }
    }
}
