using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ShopItem", menuName = "PapelClicker/ShopItem", order = 0)]
public class ShopItem : ScriptableObject 
{
   
    public double Precio;
    public Sprite Sprite;
    public bool Comprado;
    public string Nombre;
    public string Descripcion;

}
