using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirDespuesDeUnTiempo : MonoBehaviour
{
    public float TiempoDeDestruccion = 1.5f;

    // Update is called once per frame
    void Start()
    {
        Destroy(this.gameObject, TiempoDeDestruccion);
    }
}
