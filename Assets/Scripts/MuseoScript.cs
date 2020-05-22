using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuseoScript : MonoBehaviour
{
    [SerializeField] public ShopItem[] ShopItems;
    [SerializeField] public Transform shopContainer;
    [SerializeField] public GameObject shopItemPrefab;

    public GameObject PanelCreditos;

    GameObject[] enemies;
    // Start is called before the first frame update
    void Start()
    {
    
//        SkinActual.GetComponent<Image>().sprite = BotonSkinActual.GetComponent<Image>().sprite;
    }

    void OnEnable() {
        PopulateMuseo();       
         enemies = GameObject.FindGameObjectsWithTag("Museo");
    }
    
    void OnDisable() {
          
          foreach(GameObject enemy in enemies)
          {
              GameObject.Destroy(enemy);
              
          }
            
        
    }

    public void OpenCredits(){
        PanelCreditos.SetActive(true);
    }

    
    public void CloseCredits(){
        PanelCreditos.SetActive(false);
    }


    void Update()
    {
        //Papel.text = "Papel: " +   Contadores.GetComponent<IdleController>().papel.ToString("F0");
    }

    private void PopulateMuseo()
    {
         for(int i=0;i< ShopItems.Length;i++)
        {
            ShopItem si = ShopItems[i];
            GameObject itemObject = Instantiate(shopItemPrefab,shopContainer);

            itemObject.transform.GetChild(0).GetComponent<Image>().sprite = si.Sprite;
            

            if(si.Comprado)
            {
                itemObject.transform.GetChild(0).GetComponent<Image>().color = Color.white;
                itemObject.transform.GetChild(1).GetComponent<Text>().text= si.Nombre.ToString();
                itemObject.transform.GetChild(2).GetComponent<Text>().text= si.Descripcion.ToString();

            }
            else 
            {
                itemObject.transform.GetChild(0).GetComponent<Image>().color = Color.black;

            }

            
        }
    }

    private void OnButtonClick(ShopItem Item,GameObject GO)
    {
        GO.transform.GetChild(3).gameObject.SetActive(true);

    }


    private void OnButtonClickPoner(ShopItem Item2,GameObject GO3){


    }

}
