using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompadreScript : MonoBehaviour
{
    public double precioCompadre;
    public double papelXSegundoCompadre;
    public double numeroComapadres;
    

    public double GeneracionDePapel()
    {
        return papelXSegundoCompadre * numeroComapadres;
    }

}
