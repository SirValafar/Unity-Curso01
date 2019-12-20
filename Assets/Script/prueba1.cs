using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prueba1 : MonoBehaviour
{

    public Transform camaraTransform;
    public Light DireccionaLight;
    public Transform LightTransform;

    void Start()
    {

        Personaje hero = new Personaje();
        hero.ImprimirCaracteristicas();

        Personaje hero2 = hero;
        hero2.ImprimirCaracteristicas();

        hero2.name = "Mano";
        hero2.ImprimirCaracteristicas();
        Personaje heroina = new Personaje("Lara Croft");
        heroina.ImprimirCaracteristicas();

        Arma espada = new Arma("Espada roma", 5);
        espada.ImprimirArma();
        Arma espada2 = espada;
        espada2.ImprimirArma();

        espada2.name = "Exalibur";
        espada2.damage = 10;
        espada2.ImprimirArma();

        Paladin p2 = new Paladin("Uter");
        p2.ImprimirCaracteristicas();
    }

}
