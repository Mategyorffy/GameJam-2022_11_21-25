
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{
    public class ShopTrigger : MonoBehaviour
    {
        [SerializeField] private Store storeHolder;
    // Start is called before the first frame update
    void Start()
        {
            storeHolder = GameObject.Find("Manager").GetComponent<Store>();
            
        }

        // Update is called once per frame
        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.tag == "Player")
            {
                if (Store.wasShopOpened)
                {
                    return;
                }
                storeHolder.shopsCanvas.SetActive(true);
                storeHolder.shopRoll = Random.Range(1, 4);
                Debug.Log("Rolled " + storeHolder.shopRoll);
                storeHolder.OpenShop();

            }
        }

        private void OnTriggerExit2D(Collider2D collider)
        {
            if (collider.gameObject.tag == "Player")
            {
                storeHolder.CloseShops();
                storeHolder.wasShopUsed = false;
            }
        }
    }
}