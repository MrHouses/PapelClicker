using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour
{

    [SerializeField] public ShopItem[] ShopItems;
    public GameObject Contadores;
    public Text Papel;
    public Text PapelxSegundos;
    public GameObject BotonSkinActual;
    public Image SkinActual;
    public AudioClip audioComprar; 

    public AudioClip audioCompra2;
    private AudioSource audioPlayer2;
    [SerializeField] public Transform shopContainer;
    [SerializeField] public GameObject shopItemPrefab;

    public GameObject NoCompletas;
    

    // Start is called before the first frame update

    private void OnDisable() {
    audioPlayer2.clip = null;
    }
    void Start()
    {
        audioPlayer2 = GetComponent<AudioSource>();
        audioPlayer2.clip = audioCompra2;
        audioPlayer2.Play();
        PopulateShop();   
//        SkinActual.GetComponent<Image>().sprite = BotonSkinActual.GetComponent<Image>().sprite;
    }


    void Update()
    {
        //Papel.text = "Papel: " +   Contadores.GetComponent<IdleController>().papel.ToString("F0");
    }

    
    private void PopulateShop()
    {
         for(int i=0;i< ShopItems.Length;i++)
        {
            ShopItem si = ShopItems[i];
            GameObject itemObject = Instantiate(shopItemPrefab,shopContainer);

            itemObject.transform.GetChild(0).GetComponent<Text>().text= si.Precio.ToString();
            itemObject.transform.GetChild(1).GetComponent<Image>().sprite = si.Sprite;

            itemObject.GetComponent<Button>().onClick.AddListener(()=> OnButtonClick(si,itemObject));
            itemObject.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(()=> OnButtonClickPoner(si,BotonSkinActual));

            if(si.Comprado)
            {
                itemObject.transform.GetChild(1).GetComponent<Image>().color = Color.white;
                itemObject.transform.GetChild(0).GetComponent<Text>().enabled = false;
                itemObject.transform.GetChild(2).gameObject.SetActive(true);
            }
            else 
            {
                itemObject.transform.GetChild(1).GetComponent<Image>().color = Color.black;
                itemObject.transform.GetChild(2).gameObject.SetActive(false);
            }

            
        }
    }

    private void OnButtonClick(ShopItem Item,GameObject GO)
    {

        if(Contadores.GetComponent<IdleController>().papel >= Item.Precio)
        {
            if(Item.Comprado)
            {
                Debug.Log("Ya lo compraste");
            }
            else 
            {
                GO.transform.GetChild(1).GetComponent<Image>().color = Color.white;
                GO.transform.GetChild(0).GetComponent<Text>().enabled = false;
                Item.Comprado = true;
                Contadores.GetComponent<IdleController>().papel -= Item.Precio;
                GO.transform.GetChild(2).gameObject.SetActive(true);
                audioPlayer2.clip = audioComprar;
                audioPlayer2.Play();

            }
         
         } else {

                Debug.Log("No tienes suficiente papel.");
                NoCompletas.gameObject.SetActive(true);
         }
    }


    private void OnButtonClickPoner(ShopItem Item2,GameObject GO3){
        Debug.Log("CLICK POINER");
        Debug.Log(GO3.GetComponent<Image>().sprite);
        Debug.Log(Item2.Sprite);
        GO3.GetComponent<Image>().sprite = Item2.Sprite;
        audioPlayer2.clip = audioComprar;
        audioPlayer2.Play();
    }

    
    public void ClickCerrar()
    {
        NoCompletas.gameObject.SetActive(false);
    }


}
