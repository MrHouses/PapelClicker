using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class IdleController : MonoBehaviour
{

    public Text PapelText;
    public Text PapelXSegundosText;
    public double papel;
    public double TouchValue = 1;
    public double TouchUpdgradesLevel = 1;
    public double TouchUpdgradeCost = 50;
    public AudioClip audioClick;
    private AudioSource audioPlayer;

    public ParticleSystem ClickParticles;

    public GameObject SkinActual;

    public Image SkinInicial;
    public GameObject Tienda;

    public double PapelxSecond = 0;
    
    //Compadres

    //--- COMPADRE 1---//
    public GameObject Compadre1;
    public Text CostoCompadre1;
    public Text GeneracionCompadre1;
    public Text NumCompadre1;
    
    //--- COMPADRE 2---//
    public GameObject Compadre2;
    public Text CostoCompadre2;
    public Text GeneracionCompadre2;
    
    //--- COMPADRE 3---//
    public GameObject Compadre3;
    public Text CostoCompadre3;
    public Text GeneracionCompadre3;
    
    //--- COMPADRE 4---//
    public GameObject Compadre4;
    public Text CostoCompadre4;
    public Text GeneracionCompadre4;
    
    //--- COMPADRE 5---//
    public GameObject Compadre5;
    public Text CostoCompadre5;
    public Text GeneracionCompadre5;
    
    //--- COMPADRE 6---//
    public GameObject Compadre6;
    public Text CostoCompadre6;
    public Text GeneracionCompadre6;
    
    //--- COMPADRE 7---//
    public GameObject Compadre7;
    public Text CostoCompadre7;
    public Text GeneracionCompadre7;
    
    //--- COMPADRE 8---//
    public GameObject Compadre8;
    public Text CostoCompadre8;
    public Text GeneracionCompadre8;
    
    //--- COMPADRE 9---//
    public GameObject Compadre9;
    public Text CostoCompadre9;
    public Text GeneracionCompadre9;
    
    //--- COMPADRE 10---//
    public GameObject Compadre10;
    public Text CostoCompadre10;
    public Text GeneracionCompadre10;
    


    // Paneles de Configuracion
    public GameObject PanelMuseo;
    public GameObject PanelCompadres;
    public GameObject PanelTienda;

        void Awake() {

       Sprite myFruit = Resources.Load<Sprite>("Papel");
       SkinActual.GetComponent<Image>().sprite = myFruit ;
    
       }
    // Start is called before the first frame update
    void Start()
    {
           audioPlayer = GetComponent<AudioSource>();
        papel = 0;
        Cargar();
       
    }

    // Update is called once per frame
    void Update()
    {

        PapelText.text = "Papel: " + papel.ToString("F0");
        PapelXSegundosText.text = (PapelxSecond + (Compadre1.GetComponent<CompadreScript>().papelXSegundoCompadre * Compadre1.GetComponent<CompadreScript>().numeroComapadres)).ToString("F1") + " PAPEL/SEG";
        
        papel +=PapelxSecond + (Compadre1.GetComponent<CompadreScript>().papelXSegundoCompadre * Compadre1.GetComponent<CompadreScript>().numeroComapadres) * Time.deltaTime;

        GeneracionCompadre1.text = Compadre1.GetComponent<CompadreScript>().papelXSegundoCompadre.ToString("F1") + " PAPEL/SEG";
        CostoCompadre1.text = Compadre1.GetComponent<CompadreScript>().precioCompadre.ToString("F0") + " PAPELES";

        Guardar();
    }

    public void Click()
    {
        papel= papel + TouchValue;
        audioPlayer.clip = audioClick;
        audioPlayer.Play();
    }

     public void ClickUpdgrades()
    {
        PanelCompadres.gameObject.SetActive(true);
    }

    public void ClickCompadres()
    {
        PanelCompadres.gameObject.SetActive(true);
    }

     public void CloseCompadres()
    {
        PanelCompadres.gameObject.SetActive(false);
    }

    public void ClickTienda()
    {
        PanelTienda.gameObject.SetActive(true);
    }

     public void CloseTienda()
    {
        PanelTienda.gameObject.SetActive(false);
    }
    public void ClickMuseo()
    {
        PanelMuseo.gameObject.SetActive(true);
    }

     public void CloseMuseo()
    {
        PanelMuseo.gameObject.SetActive(false);
    }


    // TIENDA DE UPDATES
    // COMPRA UPDATE TOUCH
    public void BuyUpdateTouch()
    {
        if(papel > TouchUpdgradeCost)
        {
            TouchUpdgradesLevel++;
            papel -=TouchUpdgradeCost;
            TouchUpdgradeCost *=2;
            TouchValue++;
        }
        
    }

    // TIENDA DE COMPADRES
    // COMPRA DE COMPADRES 1
    public void BuyCompadre1()
    {
        if(papel > Compadre1.GetComponent<CompadreScript>().precioCompadre)
        {
            Compadre1.GetComponent<CompadreScript>().numeroComapadres++;
            papel -= Compadre1.GetComponent<CompadreScript>().precioCompadre;
            Compadre1.GetComponent<CompadreScript>().precioCompadre *=1.3;
        }  
    }


    //GUARDAR
    public void Guardar()
    {
       PlayerPrefs.SetString("PapelGeneral",papel.ToString());
       //
       PlayerPrefs.SetString("PapelXSegundoCompadre1",Compadre1.GetComponent<CompadreScript>().papelXSegundoCompadre.ToString());
       PlayerPrefs.SetString("numeroCompadres1",Compadre1.GetComponent<CompadreScript>().numeroComapadres.ToString());
       PlayerPrefs.SetString("PrecioCompadre1",Compadre1.GetComponent<CompadreScript>().precioCompadre.ToString());
       //Prueba
       int lenghtShopItems = Tienda.GetComponent<ShopScript>().ShopItems.Length;
       for(int i=0 ;i < Tienda.GetComponent<ShopScript>().ShopItems.Length ;i++)
       {
              PlayerPrefs.SetString("ObjTiendaPrecio"+i.ToString(),Tienda.GetComponent<ShopScript>().ShopItems[i].Precio.ToString());
              //PlayerPrefs.SetString("ObjTiendaSprite"+i.ToString(),Tienda.GetComponent<ShopScript>().ShopItems[i].Sprite.ToString());
              PlayerPrefs.SetString("ObjTiendaComprado"+i.ToString(),Tienda.GetComponent<ShopScript>().ShopItems[i].Comprado.ToString());
              PlayerPrefs.SetString("ObjTiendaNombre"+i.ToString(),Tienda.GetComponent<ShopScript>().ShopItems[i].Nombre.ToString());
       
       }

       Debug.Log(SkinActual.GetComponent<Image>().sprite.ToString());
       PlayerPrefs.SetString("Skin",SkinActual.GetComponent<Image>().sprite.ToString());     
       
       

      //
      /*
       Compadre2.GetComponent<CompadreScript>().papelXSegundoCompadre
       Compadre2.GetComponent<CompadreScript>().numeroComapadres
       Compadre2.GetComponent<CompadreScript>().precioCompadre
       //
//
       Compadre3.GetComponent<CompadreScript>().papelXSegundoCompadre
       Compadre3.GetComponent<CompadreScript>().numeroComapadres
       Compadre3.GetComponent<CompadreScript>().precioCompadre
       //
//
       Compadre.GetComponent<CompadreScript>().papelXSegundoCompadre
       Compadre1.GetComponent<CompadreScript>().numeroComapadres
       Compadre1.GetComponent<CompadreScript>().precioCompadre
       //
//
       Compadre1.GetComponent<CompadreScript>().papelXSegundoCompadre
       Compadre1.GetComponent<CompadreScript>().numeroComapadres
       Compadre1.GetComponent<CompadreScript>().precioCompadre
       //
//
       Compadre1.GetComponent<CompadreScript>().papelXSegundoCompadre
       Compadre1.GetComponent<CompadreScript>().numeroComapadres
       Compadre1.GetComponent<CompadreScript>().precioCompadre
       //
//
       Compadre1.GetComponent<CompadreScript>().papelXSegundoCompadre
       Compadre1.GetComponent<CompadreScript>().numeroComapadres
       Compadre1.GetComponent<CompadreScript>().precioCompadre
       //
//
       Compadre1.GetComponent<CompadreScript>().papelXSegundoCompadre
       Compadre1.GetComponent<CompadreScript>().numeroComapadres
       Compadre1.GetComponent<CompadreScript>().precioCompadre
       //
//
       Compadre1.GetComponent<CompadreScript>().papelXSegundoCompadre
       Compadre1.GetComponent<CompadreScript>().numeroComapadres
       Compadre1.GetComponent<CompadreScript>().precioCompadre
       //
//
       Compadre1.GetComponent<CompadreScript>().papelXSegundoCompadre
       Compadre1.GetComponent<CompadreScript>().numeroComapadres
       Compadre1.GetComponent<CompadreScript>().precioCompadre
       //

       */



    }

    //GUARDAR
    public void Cargar()
    {
       papel = double.Parse(PlayerPrefs.GetString("PapelGeneral","0"));
       //
       int lenghtShopItems = Tienda.GetComponent<ShopScript>().ShopItems.Length;
       Compadre1.GetComponent<CompadreScript>().papelXSegundoCompadre = double.Parse(PlayerPrefs.GetString("PapelXSegundoCompadre1","0.1"));
       Compadre1.GetComponent<CompadreScript>().numeroComapadres =  double.Parse(PlayerPrefs.GetString("numeroCompadres1","0"));
       Compadre1.GetComponent<CompadreScript>().precioCompadre = double.Parse(PlayerPrefs.GetString("PrecioCompadre1","15"));
       //JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString("ObjTienda1"),Tienda.GetComponent<ShopScript>().ShopItems[0]);
       for(int i=0 ;i < lenghtShopItems ;i++)
       {
             Tienda.GetComponent<ShopScript>().ShopItems[i].Precio  = double.Parse(PlayerPrefs.GetString("ObjTiendaPrecio"+i.ToString(),Tienda.GetComponent<ShopScript>().ShopItems[i].Precio.ToString()));
            // Tienda.GetComponent<ShopScript>().ShopItems[i].Sprite  = PlayerPrefs.GetString("ObjTiendaSprite"+i.ToString(),Tienda.GetComponent<ShopScript>().ShopItems[i].Sprite.ToString());
             Tienda.GetComponent<ShopScript>().ShopItems[i].Comprado = bool.Parse(PlayerPrefs.GetString("ObjTiendaComprado"+i.ToString(),Tienda.GetComponent<ShopScript>().ShopItems[i].Comprado.ToString()));
             Tienda.GetComponent<ShopScript>().ShopItems[i].Nombre   = PlayerPrefs.GetString("ObjTiendaNombre"+i.ToString(),Tienda.GetComponent<ShopScript>().ShopItems[i].Nombre.ToString());
       
       }

       string skinGuardo =PlayerPrefs.GetString("Skin","Papel");       
       int index = skinGuardo.IndexOf(" ");
       if (index > 0)
       skinGuardo = skinGuardo.Substring(0, index);

       Debug.Log(skinGuardo);
       Sprite myFruit = Resources.Load<Sprite>(skinGuardo);
       SkinActual.GetComponent<Image>().sprite = myFruit;



              //
      //
      /*
       Compadre2.GetComponent<CompadreScript>().papelXSegundoCompadre
       Compadre2.GetComponent<CompadreScript>().numeroComapadres
       Compadre2.GetComponent<CompadreScript>().precioCompadre
       //
//
       Compadre3.GetComponent<CompadreScript>().papelXSegundoCompadre
       Compadre3.GetComponent<CompadreScript>().numeroComapadres
       Compadre3.GetComponent<CompadreScript>().precioCompadre
       //
//
       Compadre.GetComponent<CompadreScript>().papelXSegundoCompadre
       Compadre1.GetComponent<CompadreScript>().numeroComapadres
       Compadre1.GetComponent<CompadreScript>().precioCompadre
       //
//
       Compadre1.GetComponent<CompadreScript>().papelXSegundoCompadre
       Compadre1.GetComponent<CompadreScript>().numeroComapadres
       Compadre1.GetComponent<CompadreScript>().precioCompadre
       //
//
       Compadre1.GetComponent<CompadreScript>().papelXSegundoCompadre
       Compadre1.GetComponent<CompadreScript>().numeroComapadres
       Compadre1.GetComponent<CompadreScript>().precioCompadre
       //
//
       Compadre1.GetComponent<CompadreScript>().papelXSegundoCompadre
       Compadre1.GetComponent<CompadreScript>().numeroComapadres
       Compadre1.GetComponent<CompadreScript>().precioCompadre
       //
//
       Compadre1.GetComponent<CompadreScript>().papelXSegundoCompadre
       Compadre1.GetComponent<CompadreScript>().numeroComapadres
       Compadre1.GetComponent<CompadreScript>().precioCompadre
       //
//
       Compadre1.GetComponent<CompadreScript>().papelXSegundoCompadre
       Compadre1.GetComponent<CompadreScript>().numeroComapadres
       Compadre1.GetComponent<CompadreScript>().precioCompadre
       //
//
       Compadre1.GetComponent<CompadreScript>().papelXSegundoCompadre
       Compadre1.GetComponent<CompadreScript>().numeroComapadres
       Compadre1.GetComponent<CompadreScript>().precioCompadre
       //

       */



    }
    


}
