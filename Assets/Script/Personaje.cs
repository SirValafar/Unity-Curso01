using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct Arma
{
    public string name;
    public int damage;

    public Arma(string name, int damage)
    {
        this.name = name;
        this.damage = damage;
    }
    public void ImprimirArma()
    {
        Debug.LogFormat("El del arma {0} y su daño es {1}", this.name, this.damage);
    }
}

public class Personaje
{
    public string name;
    public int exp = 0;

    public Personaje()
    {
        name = "toto";
    }

    public Personaje (string name)
    {
        this.name = name;
    }

    public void ImprimirCaracteristicas()
    {
        Debug.LogFormat("El personaje se llama {0} y su experiencia es {1}", this.name, this.exp);
    }

}

public class Paladin : Personaje
{

    public Paladin() : base()
    {

    }
    public Paladin(string name) : base(name)
    {

    }
}
