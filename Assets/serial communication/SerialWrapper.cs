using UnityEngine;

public class SerialWrapper : MonoBehaviour
{

    #region Parameters
    private int surfaceType;
    private int isHandGrasp;
    private int isHandActive;
    private int indexContact;
    private int objectTemp;
    #endregion

    #region SettersAndGetters
    public int IsHandGrap { get => isHandGrasp; set => isHandGrasp = value; }
    public int IsHandActive { get => isHandActive; set => isHandActive = value; }
    public int IndexContact { get => indexContact; set => indexContact = value; }
    public int SurfaceType { get => surfaceType; set => surfaceType = value; }
    public int ObjectTemp { get => objectTemp; set => objectTemp = value; }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        surfaceType = 0;
        isHandGrasp = 0;
        isHandActive = 0;
        indexContact = 0;
        objectTemp = 0;
    }

    // Update is called once per frame
    void Update()
    {
       SerialCOM.Write(IsHandActive + ":" + isHandGrasp + ":"+indexContact+":"+objectTemp+":"+surfaceType+":");
    }


}
