using Leap.Unity;
using Leap.Unity.Interaction;
using Leap.Unity.Query;
using UnityEngine;

public class QueryHand : MonoBehaviour
{

    public InteractionManager intManager;
    public GameObject LeftHand;
    public float hoverDistance = 0.1f;
    public InteractionBehaviour[] InteractionObjects;
   
    private SerialWrapper serial;


    private void Start()
    {
        serial = GetComponent<SerialWrapper>();
    }
    void FixedUpdate()
    {


        if (LeftHand.activeInHierarchy)
        {
            serial.IsHandActive = 1;
            foreach (var contactingHand in intManager.interactionControllers
                                                 .Query()
                                                 .Select(controller => controller.intHand)
                                                 .Where(intHand => intHand != null)
                                                 .Select(intHand => intHand.leapHand))
            {
                if (contactingHand.IsLeft)
                {

                    foreach (var intObj in InteractionObjects)
                    {


                        if (intObj.isGrasped)
                        {

                            serial.IsHandGrap = 1;
                            serial.IndexContact = 0;

                        }
                        else if (intObj.isHovered)
                        {

                            var PalmPosition = contactingHand.PalmPosition.ToVector3();
                            if (intObj.GetHoverDistance(PalmPosition) < hoverDistance)
                            {
                                serial.IsHandGrap = 0;
                                serial.IndexContact = 1;
                                MaterialAndTemp mat_temp = intObj.GetComponent<MaterialAndTemp>();
                                serial.ObjectTemp = mat_temp.temp;
                                serial.SurfaceType = mat_temp.mat;
                            }
                            else
                            {
                                serial.IndexContact = 0;
                                serial.ObjectTemp = 0;
                                serial.SurfaceType = 0;
                            }
                        }
                        else
                        {
                            serial.IsHandGrap = 0;
                            serial.IndexContact = 0;
                            serial.ObjectTemp = 0;
                            serial.SurfaceType = 0;

                        }


                    }

                }
            }
        }
        else
        {
            serial.IsHandActive = 0;
        }

    }
}


