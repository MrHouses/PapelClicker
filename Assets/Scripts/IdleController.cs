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
    public Text NumCompadre2;

      //--- COMPADRE 3---//
    public GameObject Compadre3;
    public Text CostoCompadre3;
    public Text GeneracionCompadre3;
    public Text NumCompadre3;

      //--- COMPADRE 4---//
    public GameObject Compadre4;
    public Text CostoCompadre4;
    public Text GeneracionCompadre4;
    public Text NumCompadre4;

      //--- COMPADRE 5---//
    public GameObject Compadre5;
    public Text CostoCompadre5;
    public Text GeneracionCompadre5;
    public Text NumCompadre5;
    


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
        PapelXSegundosText.text = (PapelxSecond + (Compadre1.GetComponent<CompadreScript>().papelXSegundoCompadre * Compadre1.GetComponent<CompadreScript>().numeroComapadres) + 
         (Compadre2.GetComponent<CompadreScript>().papelXSegundoCompadre * Compadre2.GetComponent<CompadreScript>().numeroComapadres) + 
         (Compadre3.GetComponent<CompadreScript>().papelXSegundoCompadre * Compadre3.GetComponent<CompadreScript>().numeroComapadres) +
         (Compadre4.GetComponent<CompadreScript>().papelXSegundoCompadre * Compadre4.GetComponent<CompadreScript>().numeroComapadres) + 
         (Compadre5.GetComponent<CompadreScript>().papelXSegundoCompadre * Compadre5.GetComponent<CompadreScript>().numeroComapadres)).ToString("F1") + " PAPEL/SEG";
        
        papel += (PapelxSecond + (Compadre1.GetComponent<CompadreScript>().papelXSegundoCompadre * Compadre1.GetComponent<CompadreScript>().numeroComapadres) +
         (Compadre2.GetComponent<CompadreScript>().papelXSegundoCompadre * Compadre2.GetComponent<CompadreScript>().numeroComapadres) + 
         (Compadre3.GetComponent<CompadreScript>().papelXSegundoCompadre * Compadre3.GetComponent<CompadreScript>().numeroComapadres) +
         (Compadre4.GetComponent<CompadreScript>().papelXSegundoCompadre * Compadre4.GetComponent<CompadreScript>().numeroComapadres) + 
         (Compadre5.GetComponent<CompadreScript>().papelXSegundoCompadre * Compadre5.GetComponent<CompadreScript>().numeroComapadres) )* 
         Time.deltaTime;

//COMPADRE 1
        GeneracionCompadre1.text = Compadre1.GetComponent<CompadreScript>().papelXSegundoCompadre.ToString("F1") + " PAPEL/SEG";
        CostoCompadre1.text = Compadre1.GetComponent<CompadreScript>().precioCompadre.ToString("F0") + " PAPELES";
        NumCompadre1.text = "Num :"+Compadre1.GetComponent<CompadreScript>().numeroComapadres.ToString();

//COMPADRE 2
        GeneracionCompadre2.text = Compadre2.GetComponent<CompadreScript>().papelXSegundoCompadre.ToString("F1") + " PAPEL/SEG";
        CostoCompadre2.text = Compadre2.GetComponent<CompadreScript>().precioCompadre.ToString("F0") + " PAPELES";
        NumCompadre2.text = "Num :"+Compadre2.GetComponent<CompadreScript>().numeroComapadres.ToString();

//COMPADRE 1
        GeneracionCompadre3.text = Compadre3.GetComponent<CompadreScript>().papelXSegundoCompadre.ToString("F1") + " PAPEL/SEG";
        CostoCompadre3.text = Compadre3.GetComponent<CompadreScript>().precioCompadre.ToString("F0") + " PAPELES";
        NumCompadre3.text = "Num :"+Compadre3.GetComponent<CompadreScript>().numeroComapadres.ToString();

//COMPADRE 1
        GeneracionCompadre4.text = Compadre4.GetComponent<CompadreScript>().papelXSegundoCompadre.ToString("F1") + " PAPEL/SEG";
        CostoCompadre4.text = Compadre4.GetComponent<CompadreScript>().precioCompadre.ToString("F0") + " PAPELES";
        NumCompadre4.text = "Num :"+Compadre4.GetComponent<CompadreScript>().numeroComapadres.ToString();

//COMPADRE 1
        GeneracionCompadre5.text = Compadre5.GetComponent<CompadreScript>().papelXSegundoCompadre.ToString("F1") + " PAPEL/SEG";
        CostoCompadre5.text = Compadre5.GetComponent<CompadreScript>().precioCompadre.ToString("F0") + " PAPELES";
        NumCompadre5.text = "Num :"+Compadre5.GetComponent<CompadreScript>().numeroComapadres.ToString();
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
            Compadre1.GetComponent<CompadreScript>().precioCompadre *=1.2;
        }  
    }

        // COMPRA DE COMPADRES 1
    public void BuyCompadre2()
    {
        if(papel > Compadre2.GetComponent<CompadreScript>().precioCompadre)
        {
            Compadre2.GetComponent<CompadreScript>().numeroComapadres++;
            papel -= Compadre2.GetComponent<CompadreScript>().precioCompadre;
            Compadre2.GetComponent<CompadreScript>().precioCompadre *=1.2;
        }  
    }

        // COMPRA DE COMPADRES 1
    public void BuyCompadre3()
    {
        if(papel > Compadre3.GetComponent<CompadreScript>().precioCompadre)
        {
            Compadre3.GetComponent<CompadreScript>().numeroComapadres++;
            papel -= Compadre3.GetComponent<CompadreScript>().precioCompadre;
            Compadre3.GetComponent<CompadreScript>().precioCompadre *=1.2;
        }  
    }

        // COMPRA DE COMPADRES 1
    public void BuyCompadre4()
    {
        if(papel > Compadre4.GetComponent<CompadreScript>().precioCompadre)
        {
            Compadre4.GetComponent<CompadreScript>().numeroComapadres++;
            papel -= Compadre4.GetComponent<CompadreScript>().precioCompadre;
            Compadre4.GetComponent<CompadreScript>().precioCompadre *=1.2;
        }  
    }

        // COMPRA DE COMPADRES 1
    public void BuyCompadre5()
    {
        if(papel > Compadre5.GetComponent<CompadreScript>().precioCompadre)
        {
            Compadre5.GetComponent<CompadreScript>().numeroComapadres++;
            papel -= Compadre5.GetComponent<CompadreScript>().precioCompadre;
            Compadre5.GetComponent<CompadreScript>().precioCompadre *=1.2;
        }  
    }


    //GUARDAR
    public void Guardar()
    {
       PlayerPrefs.SetString("PapelGeneral",papel.ToString());
       //GuardarCompadre 1
       PlayerPrefs.SetString("PapelXSegundoCompadre1",Compadre1.GetComponent<CompadreScript>().papelXSegundoCompadre.ToString());
       PlayerPrefs.SetString("numeroCompadres1",Compadre1.GetComponent<CompadreScript>().numeroComapadres.ToString());
       PlayerPrefs.SetString("PrecioCompadre1",Compadre1.GetComponent<CompadreScript>().precioCompadre.ToString());

       //GuardarCompadre 2
       PlayerPrefs.SetString("PapelXSegundoCompadre2",Compadre2.GetComponent<CompadreScript>().papelXSegundoCompadre.ToString());
       PlayerPrefs.SetString("numeroCompadres2",Compadre2.GetComponent<CompadreScript>().numeroComapadres.ToString());
       PlayerPrefs.SetString("PrecioCompadre2",Compadre2.GetComponent<CompadreScript>().precioCompadre.ToString());

       //GuardarCompadre 1
       PlayerPrefs.SetString("PapelXSegundoCompadre3",Compadre3.GetComponent<CompadreScript>().papelXSegundoCompadre.ToString());
       PlayerPrefs.SetString("numeroCompadres3",Compadre3.GetComponent<CompadreScript>().numeroComapadres.ToString());
       PlayerPrefs.SetString("PrecioCompadre3",Compadre3.GetComponent<CompadreScript>().precioCompadre.ToString());

       //GuardarCompadre 1
       PlayerPrefs.SetString("PapelXSegundoCompadre4",Compadre4.GetComponent<CompadreScript>().papelXSegundoCompadre.ToString());
       PlayerPrefs.SetString("numeroCompadres4",Compadre4.GetComponent<CompadreScript>().numeroComapadres.ToString());
       PlayerPrefs.SetString("PrecioCompadre4",Compadre4.GetComponent<CompadreScript>().precioCompadre.ToString());

       //GuardarCompadre 1
       PlayerPrefs.SetString("PapelXSegundoCompadre5",Compadre5.GetComponent<CompadreScript>().papelXSegundoCompadre.ToString());
       PlayerPrefs.SetString("numeroCompadres5",Compadre5.GetComponent<CompadreScript>().numeroComapadres.ToString());
       PlayerPrefs.SetString("PrecioCompadre5",Compadre5.GetComponent<CompadreScript>().precioCompadre.ToString());


       //Guardar TIenda;
       int lenghtShopItems = Tienda.GetComponent<ShopScript>().ShopItems.Length;
       for(int i=0 ;i < Tienda.GetComponent<ShopScript>().ShopItems.Length ;i++)
       {
              PlayerPrefs.SetString("ObjTiendaPrecio"+i.ToString(),Tienda.GetComponent<ShopScript>().ShopItems[i].Precio.ToString());
              //PlayerPrefs.SetString("ObjTiendaSprite"+i.ToString(),Tienda.GetComponent<ShopScript>().ShopItems[i].Sprite.ToString());
              PlayerPrefs.SetString("ObjTiendaComprado"+i.ToString(),Tienda.GetComponent<ShopScript>().ShopItems[i].Comprado.ToString());
              PlayerPrefs.SetString("ObjTiendaNombre"+i.ToString(),Tienda.GetComponent<ShopScript>().ShopItems[i].Nombre.ToString());
       
       }

       
       Debug.Log(SkinActual.GetComponent<Image>().sprite.ToString());
       
       //GuardarSkin
       PlayerPrefs.SetString("Skin",SkinActual.GetComponent<Image>().sprite.ToString());     
       

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
       
       Compadre2.GetComponent<CompadreScript>().papelXSegundoCompadre = double.Parse(PlayerPrefs.GetString("PapelXSegundoCompadre2","1.0"));
       Compadre2.GetComponent<CompadreScript>().numeroComapadres =  double.Parse(PlayerPrefs.GetString("numeroCompadres2","0"));
       Compadre2.GetComponent<CompadreScript>().precioCompadre = double.Parse(PlayerPrefs.GetString("PrecioCompadre2","100"));
       
       Compadre3.GetComponent<CompadreScript>().papelXSegundoCompadre = double.Parse(PlayerPrefs.GetString("PapelXSegundoCompadre3","7.0"));
       Compadre3.GetComponent<CompadreScript>().numeroComapadres =  double.Parse(PlayerPrefs.GetString("numeroCompadres3","0"));
       Compadre3.GetComponent<CompadreScript>().precioCompadre = double.Parse(PlayerPrefs.GetString("PrecioCompadre3","1450"));
       
       Compadre4.GetComponent<CompadreScript>().papelXSegundoCompadre = double.Parse(PlayerPrefs.GetString("PapelXSegundoCompadre4","45.0"));
       Compadre4.GetComponent<CompadreScript>().numeroComapadres =  double.Parse(PlayerPrefs.GetString("numeroCompadres4","0"));
       Compadre4.GetComponent<CompadreScript>().precioCompadre = double.Parse(PlayerPrefs.GetString("PrecioCompadre4","15200"));
       
       Compadre5.GetComponent<CompadreScript>().papelXSegundoCompadre = double.Parse(PlayerPrefs.GetString("PapelXSegundoCompadre5","230.0"));
       Compadre5.GetComponent<CompadreScript>().numeroComapadres =  double.Parse(PlayerPrefs.GetString("numeroCompadres5","0"));
       Compadre5.GetComponent<CompadreScript>().precioCompadre = double.Parse(PlayerPrefs.GetString("PrecioCompadre5","150020"));
       




       
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

    }
    


}
