using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class fogones : MonoBehaviour
{
    float offsetAngle;
    bool rotando = false;
    [SerializeField] CircleCollider2D caja;

    void Awake()
    {
        float randomAngle = Random.Range(15f, 360f);
        transform.rotation = Quaternion.Euler(0f, 0f, randomAngle);
    }

    // Update is called once per frame
    void Update()
    {
        float anguloCorrecto = Vector3.Angle(transform.up, Vector3.up);

        if (Input.GetMouseButtonUp(0) )
        {
            rotando = false;
        }
        if (rotando)
        {
            Vector3 mousePos=Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 dir=mousePos-transform.position;
            float angle=Mathf.Atan2(dir.y,dir.x)*Mathf.Rad2Deg;
            transform.rotation=Quaternion.AngleAxis(angle + offsetAngle, Vector3.forward);
        }

        if (anguloCorrecto < 5f || anguloCorrecto > 355f)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            caja.enabled = false;
        }
    }

    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos=Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 dir = mousePos - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            offsetAngle = transform.eulerAngles.z - angle;

            rotando =true;
        }
    }
}
