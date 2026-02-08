using UnityEngine;

public class fregona : MonoBehaviour
{
    [SerializeField] public int limpias = 0;

    public bool limpio = false;
    void OnEnable()
    {
        limpias = 0;
        limpio = false;
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = -1f;
            transform.position = mousePosition;
        }

        if (limpias >= 3)
        {
            limpio = true;
            Debug.Log("todas limpias");
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("colision");
        if (collider.CompareTag("mancha"))
        {
            Destroy(collider.gameObject);
            Debug.Log("Mancha limpiada");
            limpias++;
        }
    }
}