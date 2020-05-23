using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using UnityEditor;
using UnityEngine.UI;

public class IdleController : MonoBehaviour
{
    RewardBasedVideoAd ad;
     public Text PapelText;
      public Text PapelxClick;
    public Text PapelXSegundosText;
    public double papel;
    public double TouchValue = 1;
    public double TouchUpdgradesLevel = 1;
    public double TouchUpdgradeCost = 50;
    public AudioClip audioClick;
    public AudioClip audioClickComprarCompadre;
    public AudioClip audioCompadre;



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


       //--- COMPADRE 6---//
    public GameObject Compadre6;
    public Text CostoCompadre6;
    public Text GeneracionCompadre6;
    public Text NumCompadre6;
    
      //--- COMPADRE 7---//
    public GameObject Compadre7;
    public Text CostoCompadre7;
    public Text GeneracionCompadre7;
    public Text NumCompadre7;

      //--- COMPADRE 8---//
    public GameObject Compadre8;
    public Text CostoCompadre8;
    public Text GeneracionCompadre8;
    public Text NumCompadre8;

      //--- COMPADRE 9---//
    public GameObject Compadre9;
    public Text CostoCompadre9;
    public Text GeneracionCompadre9;
    public Text NumCompadre9;

      //--- COMPADRE 10---//
    public GameObject Compadre10;
    public Text CostoCompadre10;
    public Text GeneracionCompadre10;
    public Text NumCompadre10;

    //
    public Text CostoUpdate;
    public Text ClickValue;
    


    // Paneles de Configuracion
    public GameObject PanelMuseo;
    public GameObject PanelCompadres;
    public GameObject PanelTienda;

    public GameObject PanelNoCompadre;


    //Anuncios
    public GameObject PanelAnuncio;
    public GameObject PanelReward;
    public AudioSource BonusAudio;
    public AudioClip clipBonus;
    public Text Reward;
    public GameObject BotonGeneralReward;
    public GameObject FondoGeneralReward;

    public Sprite DefaultButton;
    public Sprite DisableButton;
    public Button BotonCompadres;

    public Button BotonReward;
    public GameObject BotonRewardGO;
    public Text Textiempo;
    public GameObject PanelTutorialPapel;

    public GameObject PanelTutorialTienda;
    
    public GameObject PanelTutorialCompadres;
    



    string appUnitId = "ca-app-pub-4609727598306757~3512860401";
        void Awake() {

       TiempoActual = System.DateTime.Now;
       Sprite myFruit = Resources.Load<Sprite>("Papel");
       SkinActual.GetComponent<Image>().sprite = myFruit ;
       MobileAds.Initialize(appUnitId);
       
    
    }
    // Start is called before the first frame update

    string rewardID ="ca-app-pub-3940256099942544/5224354917";
    public void PedirReward()
    {
        ad = RewardBasedVideoAd.Instance;
        ad.OnAdRewarded +=  HandleRewardBasedVideoRewarded;

        AdRequest pedir = new AdRequest.Builder().AddTestDevice("C5FFE9677FA0E0EBAA6D10D89F35E1A1").Build();
        ad.LoadAd(pedir,rewardID);
    }

    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
    BotonReward.interactable = false;
    PanelReward.gameObject.SetActive(true);
    }

    IEnumerator returne(){
        BonusAudio.clip = clipBonus;
        BonusAudio.Play();
        double touch_anterior = TouchValue;
        BotonGeneralReward.GetComponent<Image>().color =   new Color(0.9607844f, 0.8313726f, 0.15294121f);
        FondoGeneralReward.GetComponent<Image>().color =  new Color(0.9686275f, 0.8901961f, 0.4117647f);
        TouchValue = TouchValue*2;
        BotonCompadres.interactable = false;
        yield return new WaitForSeconds(20);
       
       //QuitarCancion
        BotonGeneralReward.GetComponent<Image>().color = Color.white;
        FondoGeneralReward.GetComponent<Image>().color = Color.white;
        BotonCompadres.interactable = true;
        TouchValue = touch_anterior;
        OnWheelSpun();
    }


    bool ShowWheelToPlayer()
    {
        if (Tiempo  <=  0)
            return true;
        else
            return false;
    }

    System.DateTime TiempoActual = System.DateTime.Now;
    System.DateTime TiempoDesbloqueo;

    float Tiempo ;
    void OnWheelSpun()
    {
    Debug.Log((System.DateTime.Now.AddMinutes(15)-TiempoActual).ToString()+ "Minutos");
    TiempoDesbloqueo = System.DateTime.Now.AddMinutes(15);
    float TiempoDel = float.Parse((TiempoDesbloqueo.Minute-TiempoActual.Minute).ToString());
    Debug.Log(TiempoDel+"Minutos");
    Tiempo = TiempoDel*60;
    PlayerPrefs.SetString("TiempoDesbloqueo", System.DateTime.Now.AddMinutes(15).ToString());
    }





    public void closeReward()
    {
        StartCoroutine("returne");
        PanelReward.gameObject.SetActive(false);
    }

    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
        papel = 0;
        //Cargar();
        PedirReward();
       
    }

    void Update()
    {

         
        //FECHAS AUNCIOS
        TiempoActual = System.DateTime.Now;
        if(ShowWheelToPlayer())
        {
            Debug.Log("Mostrar Boton");
            BotonRewardGO.GetComponent<Image>().sprite = DefaultButton;
            Textiempo.text = "";
            BotonReward.interactable = true;

        }
        else {
            Debug.Log("No Mostrar Boton");
            BotonRewardGO.GetComponent<Image>().sprite = DisableButton;
            float TiempoDel = float.Parse((TiempoDesbloqueo.Minute-TiempoActual.Minute).ToString());
            float TimeSeconds = float.Parse((TiempoDesbloqueo.Second-TiempoActual.Second).ToString()); 
            Debug.Log(TiempoDel+"Minutos");
            Tiempo = (TiempoDel*60) + TimeSeconds;
             int min = Mathf.FloorToInt(Tiempo / 60);
             int sec = Mathf.FloorToInt(Tiempo % 60);
            Textiempo.text = min+":"+sec;
            BotonReward.interactable = false;
        }



        //---------------

        PapelxClick.text = "Por Click: "+ TouchValue.ToString();
        PapelText.text = "Papel: " + papel.ToString("F0");
        PapelXSegundosText.text = (PapelxSecond + (Compadre1.GetComponent<CompadreScript>().papelXSegundoCompadre * Compadre1.GetComponent<CompadreScript>().numeroComapadres) + 
         (Compadre2.GetComponent<CompadreScript>().papelXSegundoCompadre * Compadre2.GetComponent<CompadreScript>().numeroComapadres) + 
         (Compadre3.GetComponent<CompadreScript>().papelXSegundoCompadre * Compadre3.GetComponent<CompadreScript>().numeroComapadres) +
         (Compadre4.GetComponent<CompadreScript>().papelXSegundoCompadre * Compadre4.GetComponent<CompadreScript>().numeroComapadres) + 
         (Compadre5.GetComponent<CompadreScript>().papelXSegundoCompadre * Compadre5.GetComponent<CompadreScript>().numeroComapadres) +
         (Compadre6.GetComponent<CompadreScript>().papelXSegundoCompadre * Compadre6.GetComponent<CompadreScript>().numeroComapadres) + 
         (Compadre7.GetComponent<CompadreScript>().papelXSegundoCompadre * Compadre7.GetComponent<CompadreScript>().numeroComapadres) + 
         (Compadre8.GetComponent<CompadreScript>().papelXSegundoCompadre * Compadre8.GetComponent<CompadreScript>().numeroComapadres) +
         (Compadre9.GetComponent<CompadreScript>().papelXSegundoCompadre * Compadre9.GetComponent<CompadreScript>().numeroComapadres) + 
         (Compadre10.GetComponent<CompadreScript>().papelXSegundoCompadre * Compadre10.GetComponent<CompadreScript>().numeroComapadres)
         ).ToString("F1") + " PAPEL/SEG";
        
        papel += (PapelxSecond + (Compadre1.GetComponent<CompadreScript>().papelXSegundoCompadre * Compadre1.GetComponent<CompadreScript>().numeroComapadres) +
         (Compadre2.GetComponent<CompadreScript>().papelXSegundoCompadre * Compadre2.GetComponent<CompadreScript>().numeroComapadres) + 
         (Compadre3.GetComponent<CompadreScript>().papelXSegundoCompadre * Compadre3.GetComponent<CompadreScript>().numeroComapadres) +
         (Compadre4.GetComponent<CompadreScript>().papelXSegundoCompadre * Compadre4.GetComponent<CompadreScript>().numeroComapadres) + 
         (Compadre5.GetComponent<CompadreScript>().papelXSegundoCompadre * Compadre5.GetComponent<CompadreScript>().numeroComapadres) +
         (Compadre6.GetComponent<CompadreScript>().papelXSegundoCompadre * Compadre6.GetComponent<CompadreScript>().numeroComapadres) + 
         (Compadre7.GetComponent<CompadreScript>().papelXSegundoCompadre * Compadre7.GetComponent<CompadreScript>().numeroComapadres) + 
         (Compadre8.GetComponent<CompadreScript>().papelXSegundoCompadre * Compadre8.GetComponent<CompadreScript>().numeroComapadres) +
         (Compadre9.GetComponent<CompadreScript>().papelXSegundoCompadre * Compadre9.GetComponent<CompadreScript>().numeroComapadres) + 
         (Compadre10.GetComponent<CompadreScript>().papelXSegundoCompadre * Compadre10.GetComponent<CompadreScript>().numeroComapadres) )* 
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

//COMPADRE 1
        GeneracionCompadre6.text = Compadre6.GetComponent<CompadreScript>().papelXSegundoCompadre.ToString("F1") + " PAPEL/SEG";
        CostoCompadre6.text = Compadre6.GetComponent<CompadreScript>().precioCompadre.ToString("F0") + " PA";
        NumCompadre6.text = "Num :"+Compadre6.GetComponent<CompadreScript>().numeroComapadres.ToString();

//COMPADRE 2
        GeneracionCompadre7.text = Compadre7.GetComponent<CompadreScript>().papelXSegundoCompadre.ToString("F1") + " PAPEL/SEG";
        CostoCompadre7.text = Compadre7.GetComponent<CompadreScript>().precioCompadre.ToString("F0") + " PA";
        NumCompadre7.text = "Num :"+Compadre7.GetComponent<CompadreScript>().numeroComapadres.ToString();

//COMPADRE 1
        GeneracionCompadre8.text = Compadre8.GetComponent<CompadreScript>().papelXSegundoCompadre.ToString("F1") + " PAPEL/SEG";
        CostoCompadre8.text = Compadre8.GetComponent<CompadreScript>().precioCompadre.ToString("F0") + " PA";
        NumCompadre8.text = "Num :"+Compadre8.GetComponent<CompadreScript>().numeroComapadres.ToString();

//COMPADRE 1
        GeneracionCompadre9.text = Compadre9.GetComponent<CompadreScript>().papelXSegundoCompadre.ToString("F1") + " PAPEL/SEG";
        CostoCompadre9.text = Compadre9.GetComponent<CompadreScript>().precioCompadre.ToString("F0") + " PA";
        NumCompadre9.text = "Num :"+Compadre9.GetComponent<CompadreScript>().numeroComapadres.ToString();

//COMPADRE 1
        GeneracionCompadre10.text = Compadre10.GetComponent<CompadreScript>().papelXSegundoCompadre.ToString("F1") + " PAPEL/SEG";
        CostoCompadre10.text = Compadre10.GetComponent<CompadreScript>().precioCompadre.ToString("F0") + " PA";
        NumCompadre10.text = "Num :"+Compadre10.GetComponent<CompadreScript>().numeroComapadres.ToString();

    //TouchUpdate
        CostoUpdate.text = TouchUpdgradeCost.ToString() + " PAPEL";
        ClickValue.text = (TouchValue * 3).ToString() + " Por Click";
       

        Guardar();
    }

    public void Click()
    {
        papel= papel + TouchValue;
        audioPlayer.clip = audioClick;
        audioPlayer.Play();
    }

    public void CloseNoCompadre(){

            PanelNoCompadre.gameObject.SetActive(false);
        
    }

     public void ClickUpdgrades()
    {
        PanelCompadres.gameObject.SetActive(true);
    }

    public void ClickCompadres()
    {
        PanelCompadres.gameObject.SetActive(true);
        audioPlayer.clip = audioCompadre;
        audioPlayer.Play();
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

    public void ClickAnuncio()
    {
        ad.Show();
        PedirReward();
    }

    // TIENDA DE UPDATES
    // COMPRA UPDATE TOUCH
    public void BuyUpdateTouch()
    {
        if(papel >= TouchUpdgradeCost)
        {
            papel -=TouchUpdgradeCost;
            TouchUpdgradeCost *=4;
            TouchValue *=3;
        }
        
    }

    // TIENDA DE COMPADRES
    // COMPRA DE COMPADRES 1
    public void BuyCompadre1()
    {
        if(papel >= Compadre1.GetComponent<CompadreScript>().precioCompadre)
        {
            Compadre1.GetComponent<CompadreScript>().numeroComapadres++;
            papel -= Compadre1.GetComponent<CompadreScript>().precioCompadre;
            Compadre1.GetComponent<CompadreScript>().precioCompadre *=1.2;
            audioPlayer.clip = audioClickComprarCompadre;
            audioPlayer.Play();
        }  else {
            PanelNoCompadre.gameObject.SetActive(true);
        }
    }

        // COMPRA DE COMPADRES 1
    public void BuyCompadre2()
    {
        if(papel >= Compadre2.GetComponent<CompadreScript>().precioCompadre)
        {
            Compadre2.GetComponent<CompadreScript>().numeroComapadres++;
            papel -= Compadre2.GetComponent<CompadreScript>().precioCompadre;
            Compadre2.GetComponent<CompadreScript>().precioCompadre *=1.2;
            audioPlayer.clip = audioClickComprarCompadre;
            audioPlayer.Play();
        }  else {
            PanelNoCompadre.gameObject.SetActive(true);
        }
    }

        // COMPRA DE COMPADRES 1
    public void BuyCompadre3()
    {
        if(papel >= Compadre3.GetComponent<CompadreScript>().precioCompadre)
        {
            Compadre3.GetComponent<CompadreScript>().numeroComapadres++;
            papel -= Compadre3.GetComponent<CompadreScript>().precioCompadre;
            Compadre3.GetComponent<CompadreScript>().precioCompadre *=1.2;
            audioPlayer.clip = audioClickComprarCompadre;
            audioPlayer.Play();
        }  else {
            PanelNoCompadre.gameObject.SetActive(true);
        }
    }

        // COMPRA DE COMPADRES 1
    public void BuyCompadre4()
    {
        if(papel >= Compadre4.GetComponent<CompadreScript>().precioCompadre)
        {
            Compadre4.GetComponent<CompadreScript>().numeroComapadres++;
            papel -= Compadre4.GetComponent<CompadreScript>().precioCompadre;
            Compadre4.GetComponent<CompadreScript>().precioCompadre *=1.2;
            audioPlayer.clip = audioClickComprarCompadre;
            audioPlayer.Play();
        }  else {
            PanelNoCompadre.gameObject.SetActive(true);
        }
    }

        // COMPRA DE COMPADRES 1
    public void BuyCompadre5()
    {
        if(papel >= Compadre5.GetComponent<CompadreScript>().precioCompadre)
        {
            Compadre5.GetComponent<CompadreScript>().numeroComapadres++;
            papel -= Compadre5.GetComponent<CompadreScript>().precioCompadre;
            Compadre5.GetComponent<CompadreScript>().precioCompadre *=1.2;
            audioPlayer.clip = audioClickComprarCompadre;
            audioPlayer.Play();
        }  
        else {
            PanelNoCompadre.gameObject.SetActive(true);
        }
    }

        // COMPRA DE COMPADRES 1
    public void BuyCompadre6()
    {
        if(papel >= Compadre6.GetComponent<CompadreScript>().precioCompadre)
        {
            Compadre6.GetComponent<CompadreScript>().numeroComapadres++;
            papel -= Compadre6.GetComponent<CompadreScript>().precioCompadre;
            Compadre6.GetComponent<CompadreScript>().precioCompadre *=1.2;
            audioPlayer.clip = audioClickComprarCompadre;
            audioPlayer.Play();
        }
        else {
            PanelNoCompadre.gameObject.SetActive(true);
        }  
    }

        // COMPRA DE COMPADRES 1
    public void BuyCompadre7()
    {
        if(papel >= Compadre7.GetComponent<CompadreScript>().precioCompadre)
        {
            Compadre7.GetComponent<CompadreScript>().numeroComapadres++;
            papel -= Compadre7.GetComponent<CompadreScript>().precioCompadre;
            Compadre7.GetComponent<CompadreScript>().precioCompadre *=1.2;
            audioPlayer.clip = audioClickComprarCompadre;
            audioPlayer.Play();
        }  else {
            PanelNoCompadre.gameObject.SetActive(true);
        }
    }

        // COMPRA DE COMPADRES 1
    public void BuyCompadre8()
    {
        if(papel >= Compadre8.GetComponent<CompadreScript>().precioCompadre)
        {
            Compadre8.GetComponent<CompadreScript>().numeroComapadres++;
            papel -= Compadre8.GetComponent<CompadreScript>().precioCompadre;
            Compadre8.GetComponent<CompadreScript>().precioCompadre *=1.2;
            audioPlayer.clip = audioClickComprarCompadre;
            audioPlayer.Play();
        }  else {
            PanelNoCompadre.gameObject.SetActive(true);
        }
    }

        // COMPRA DE COMPADRES 1
    public void BuyCompadre9()
    {
        if(papel >= Compadre9.GetComponent<CompadreScript>().precioCompadre)
        {
            Compadre9.GetComponent<CompadreScript>().numeroComapadres++;
            papel -= Compadre9.GetComponent<CompadreScript>().precioCompadre;
            Compadre9.GetComponent<CompadreScript>().precioCompadre *=1.2;
            audioPlayer.clip = audioClickComprarCompadre;
            audioPlayer.Play();
        }  else {
            PanelNoCompadre.gameObject.SetActive(true);
        }
    }

        // COMPRA DE COMPADRES 1
    public void BuyCompadre10()
    {
        if(papel >= Compadre10.GetComponent<CompadreScript>().precioCompadre)
        {
            Compadre10.GetComponent<CompadreScript>().numeroComapadres++;
            papel -= Compadre10.GetComponent<CompadreScript>().precioCompadre;
            Compadre10.GetComponent<CompadreScript>().precioCompadre *=1.2;
            audioPlayer.clip = audioClickComprarCompadre;
            audioPlayer.Play();
        }  else {
            PanelNoCompadre.gameObject.SetActive(true);
        }
    }


    //GUARDAR
    public void Guardar()
    {
       PlayerPrefs.SetString("PapelGeneral",papel.ToString());
       PlayerPrefs.SetString("TouchValue",TouchValue.ToString());
       PlayerPrefs.SetString("TouchCost",TouchUpdgradeCost.ToString()); 



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

        //GuardarCompadre 1
       PlayerPrefs.SetString("PapelXSegundoCompadre6",Compadre6.GetComponent<CompadreScript>().papelXSegundoCompadre.ToString());
       PlayerPrefs.SetString("numeroCompadres6",Compadre6.GetComponent<CompadreScript>().numeroComapadres.ToString());
       PlayerPrefs.SetString("PrecioCompadre6",Compadre6.GetComponent<CompadreScript>().precioCompadre.ToString());

 //GuardarCompadre 1
       PlayerPrefs.SetString("PapelXSegundoCompadre7",Compadre7.GetComponent<CompadreScript>().papelXSegundoCompadre.ToString());
       PlayerPrefs.SetString("numeroCompadres7",Compadre7.GetComponent<CompadreScript>().numeroComapadres.ToString());
       PlayerPrefs.SetString("PrecioCompadre7",Compadre7.GetComponent<CompadreScript>().precioCompadre.ToString());

 //GuardarCompadre 1
       PlayerPrefs.SetString("PapelXSegundoCompadre8",Compadre8.GetComponent<CompadreScript>().papelXSegundoCompadre.ToString());
       PlayerPrefs.SetString("numeroCompadres8",Compadre8.GetComponent<CompadreScript>().numeroComapadres.ToString());
       PlayerPrefs.SetString("PrecioCompadre8",Compadre8.GetComponent<CompadreScript>().precioCompadre.ToString());

 //GuardarCompadre 1
       PlayerPrefs.SetString("PapelXSegundoCompadre9",Compadre9.GetComponent<CompadreScript>().papelXSegundoCompadre.ToString());
       PlayerPrefs.SetString("numeroCompadres9",Compadre9.GetComponent<CompadreScript>().numeroComapadres.ToString());
       PlayerPrefs.SetString("PrecioCompadre9",Compadre9.GetComponent<CompadreScript>().precioCompadre.ToString());

 //GuardarCompadre 1
       PlayerPrefs.SetString("PapelXSegundoCompadre10",Compadre10.GetComponent<CompadreScript>().papelXSegundoCompadre.ToString());
       PlayerPrefs.SetString("numeroCompadres10",Compadre10.GetComponent<CompadreScript>().numeroComapadres.ToString());
       PlayerPrefs.SetString("PrecioCompadre10",Compadre10.GetComponent<CompadreScript>().precioCompadre.ToString());


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
       TiempoDesbloqueo = System.DateTime.Parse(PlayerPrefs.GetString("TiempoDesbloqueo",System.DateTime.Now.ToString()));
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
       
       Compadre6.GetComponent<CompadreScript>().papelXSegundoCompadre = double.Parse(PlayerPrefs.GetString("PapelXSegundoCompadre6","1200"));
       Compadre6.GetComponent<CompadreScript>().numeroComapadres =  double.Parse(PlayerPrefs.GetString("numeroCompadres6","0"));
       Compadre6.GetComponent<CompadreScript>().precioCompadre = double.Parse(PlayerPrefs.GetString("PrecioCompadre6","1400120"));

       Compadre7.GetComponent<CompadreScript>().papelXSegundoCompadre = double.Parse(PlayerPrefs.GetString("PapelXSegundoCompadre7","5500"));
       Compadre7.GetComponent<CompadreScript>().numeroComapadres =  double.Parse(PlayerPrefs.GetString("numeroCompadres7","0"));
       Compadre7.GetComponent<CompadreScript>().precioCompadre = double.Parse(PlayerPrefs.GetString("PrecioCompadre7","15000500"));

       Compadre8.GetComponent<CompadreScript>().papelXSegundoCompadre = double.Parse(PlayerPrefs.GetString("PapelXSegundoCompadre8","10000"));
       Compadre8.GetComponent<CompadreScript>().numeroComapadres =  double.Parse(PlayerPrefs.GetString("numeroCompadres8","0"));
       Compadre8.GetComponent<CompadreScript>().precioCompadre = double.Parse(PlayerPrefs.GetString("PrecioCompadre8","150000000"));

       Compadre9.GetComponent<CompadreScript>().papelXSegundoCompadre = double.Parse(PlayerPrefs.GetString("PapelXSegundoCompadre9","45000"));
       Compadre9.GetComponent<CompadreScript>().numeroComapadres =  double.Parse(PlayerPrefs.GetString("numeroCompadres9","0"));
       Compadre9.GetComponent<CompadreScript>().precioCompadre = double.Parse(PlayerPrefs.GetString("PrecioCompadre9","1500000000"));

       Compadre10.GetComponent<CompadreScript>().papelXSegundoCompadre = double.Parse(PlayerPrefs.GetString("PapelXSegundoCompadre10","102000"));
       Compadre10.GetComponent<CompadreScript>().numeroComapadres =  double.Parse(PlayerPrefs.GetString("numeroCompadres10","0"));
       Compadre10.GetComponent<CompadreScript>().precioCompadre = double.Parse(PlayerPrefs.GetString("PrecioCompadre10","15000000000"));






       
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

       TouchValue = double.Parse(PlayerPrefs.GetString("TouchValue","1"));

        TouchUpdgradeCost = double.Parse(PlayerPrefs.GetString("TouchCost","500"));


        float TiempoDel = float.Parse((TiempoDesbloqueo.Minute-TiempoActual.Minute).ToString());
        float TimeSeconds = float.Parse((TiempoDesbloqueo.Second-TiempoActual.Second).ToString()); 
        Debug.Log(TiempoDel+"Minutos");
        Tiempo = (TiempoDel*60) + TimeSeconds;


    }
    


}
