using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    /*
    Entra en colision
    private void OnCollisionEnter(Collision collision)
    
    Cuando estan en colision
    private void OnCollisionStay(Collision collision)

    Cuando sale de la colision
    private void OnCollisionExit(Collision collision)
*/

    public GameManager adminGame;

    private void Start()
    {
        adminGame = GameObject.Find("AdminGameManager").GetComponent<GameManager>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            //Item desaparece ya que consulta 
            /*
            this este objeto
            transform donde esta
            parent quien es el padre
            gameObject de este objeto
            */
            Destroy(this.transform.parent.gameObject);
            Debug.Log("Objetos Recolectado");
            adminGame.Items++;
        }
    }
}
