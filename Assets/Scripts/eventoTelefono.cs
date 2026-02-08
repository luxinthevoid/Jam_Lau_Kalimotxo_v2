using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class eventoTelefono : MonoBehaviour
{
    [SerializeField] BoxCollider2D cajaTelefono;
    [SerializeField] GameObject telefono;
    [SerializeField] Button bueno;
    [SerializeField] Button malo;
    [SerializeField] TextMeshProUGUI txt1;
    [SerializeField] TextMeshProUGUI txt2;

    [SerializeField] bool responder;
    [SerializeField] bool colgar;
    [SerializeField] int iteracion;

    bool oscilar = false;

    public bool completado = false;

    List<string> txt2Lista = new List<string>() { "Estoy bien", "Ya he comido", "No, no tengo anemia", "Mañana llueve" };

    void OnEnable()
    {
        iteracion = 0;
        responder = false;
        colgar = false;
        bueno.gameObject.SetActive(false);
        malo.gameObject.SetActive(false);
        bueno.onClick.AddListener(Colgar);
        malo.onClick.AddListener(BucleTxt);
        completado = false;
        txt1.text = "Luego te llamo mam�";
        txt2.text = txt2Lista[iteracion];
    }

    void OnDisable()
    {
        bueno.onClick.RemoveListener(Colgar);
        malo.onClick.RemoveListener(BucleTxt);
        bueno.gameObject.SetActive(false);
        malo.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!responder)
        {
            if(oscilar)
            {
                telefono.transform.Rotate(0f,0f,-7f);
                oscilar = false;
            }
            else
            {
                telefono.transform.Rotate(0f, 0f, 7f);
                oscilar = true;
            }
        }
        if (colgar)
        {
            //Debug.Log("Evento completado");
            completado = true;
        }
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && !responder)
        {
            responder = true;
            bueno.gameObject.SetActive(true);
            malo.gameObject.SetActive(true);
            txt1.text = "'Colgar'";
            txt2.text = "'Responder'";
        }
    }

    void Colgar()
    {
        colgar = true;
    }

    void BucleTxt()
    {
        txt1.text = "Luego te llamo mam�";
        txt2.text = txt2Lista[iteracion];
        if(iteracion >= txt2Lista.Count - 1)
            iteracion=0;
        else
            iteracion++;
    }
}
