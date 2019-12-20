using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraSigue : MonoBehaviour
{
    public Vector3 CamaraOffset = new Vector3(0.0f, 1.3f, -5.0f);
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        //Esta variable busca atrabes de GameObject.Find y lo que se ponga a continuacion debe estar en la herarquia 
        target = GameObject.Find("Player").transform;
    }

    private void LateUpdate()
    {
        /*
         this referencia a la misma camara en este caso
         transform.position referencia que se quiere cambiar la posicion
         target.TransformPoint(CamaraOffset)
        LookAt referencia la direccion donde mira
         */
        this.transform.position = target.TransformPoint(CamaraOffset);
        this.transform.LookAt(target);
    }
}
