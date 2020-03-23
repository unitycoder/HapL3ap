using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetData : MonoBehaviour
{
    // Start is called before the first frame update
    
    public static int fingerValue;
    [Range(0, 100)]
    public int Value;

    private void Start()
    {

    }

 

    // Update is called once per frame
    void Update()
    {
        fingerValue = Value;
        
    }

    


    
}
