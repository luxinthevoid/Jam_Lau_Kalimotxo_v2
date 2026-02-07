using UnityEngine;
using UnityEngine.UI;


public class barraPepinillo : MonoBehaviour
{
    [SerializeField] Slider barra;
    [SerializeField] float valorClick = 1f;
    [SerializeField] float valorPerdida = -1f;
    public bool esClickable = true;

    void awake()
    {
        barra = gameObject.GetComponent<Slider>();
        barra.value = 0;
    }
    void Update()
    {
        if (esClickable && Input.GetMouseButtonDown(0))
        {
            Progreso(valorClick);
        }
        Progreso(valorPerdida * Time.deltaTime);
    }

    public void Progreso(float valor)
    {
        barra.value += valor;
    }
}
