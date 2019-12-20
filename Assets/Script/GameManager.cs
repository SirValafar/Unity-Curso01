using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public string labelText = "Recolecta los 4 items y ganate la libertad";

    public int maxItems = 4;
    public int _itemsCollected = 0;

    public bool Win = false;

    public int Items
    {
        get
        {
            return _itemsCollected;
        }
        set
        {
            _itemsCollected = value;

            if (_itemsCollected >= maxItems)
            {
                labelText = "Has entontrado todos los items";
                Win = true;
                Time.timeScale = 0;
                /* Este ultimo frena las acciones en el juego.*/
            }
            else
            {
                labelText = "items encontrado, te faltan: " 
                    + (maxItems - _itemsCollected);
            }
            Debug.LogFormat("Items: {0}", _itemsCollected);
        }
    }

    private int _playerHP = 100;
    public int HP
    {
        get
        {
            return _playerHP;
        }
        set
        {
            _playerHP = value;
            Debug.LogFormat("Vida: {0}", _playerHP);
        }
    }


    private string _fistName;

    public string _FirstName {
        get{
            //aqui pones codigo cuando se consulta una variable
            return _fistName;
        }
        set{
            //aqui pones codigo cuando se modifica una variable
            _fistName = value;
        }
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(/*Dist x izda*/25,
                        /*Dist y arriba*/25,
                        /*anchura*/ 180,
                        /*altura*/ 25), "Vida: " + _playerHP);

        GUI.Box(new Rect(25, 65, 180, 25), "Items Recogidos: " + _itemsCollected);

        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 200, 50),
            labelText);

        if (Win == true)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100,
                Screen.height / 2 - 100, 400, 200),"Has ganado"));
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1;
        }
    }

}
