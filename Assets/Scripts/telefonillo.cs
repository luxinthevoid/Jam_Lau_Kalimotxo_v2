using UnityEngine;

public class telefonillop : MonoBehaviour
{
    [SerializeField] botonAbrir abrir;

    public bool completado = false;

    void OnEnable()
    {
        completado = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (abrir.colgar)
        {
            Debug.Log("fin de evento interfono");
            completado = false;
        }
    }
}
