using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chngeimg1 : MonoBehaviour
{
    public GameObject storypanel;
    public GameObject activeCheck;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activeCheck.activeInHierarchy)
        {
            if (Input.AnyKeyDown)
            {
                storypanel.SetActive(true);
               
                activeCheck.SetActive(false);
            }
            


            
        }
    }
}
