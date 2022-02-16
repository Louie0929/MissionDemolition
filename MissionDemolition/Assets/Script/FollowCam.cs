/***
 * Created By: Xingzhou Li
 * Date Created: 2/15/2022
 * 
 * Last Edited: 2/15/2022
 * Edited by: Xingzhou Li
 * 
 * Description: Camera Countrol
 */
using System.Collections;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    static public GameObject POI; // The static point of interest

    [Header("Set in Inspector")]
    public float easing = 0.05f;
    public Vector2 minXY = Vector2.zero;

    [Header("Set Dynamically")]
    public float camZ; // The desired Zpos of the camera

    void Awake()
    {
        camZ = this.transform.position.z;
    }

    void FixedUpdate()
    {
        //if (POI == null) return; // return if there is no poi
        //Vector3 destination = POI.transform.position; // Force destination.z to be camZ
        //                                              // to keepthe camera far enough away
        Vector3 destination;
        if (POI == null)
        {
            destination = Vector3.zero;
        }
        else
        {
            destination = POI.transform.position; // Get the position of the poi
            if (POI.tag == "Projectile")
            {
                if (POI.GetComponent<Rigidbody>().IsSleeping())
                {
                    POI = null;
                    return;
                }
            }
        }
        destination.x = Mathf.Max(minXY.x, destination.x); // Limit the X to minimum values
        destination.y = Mathf.Max(minXY.y, destination.y); // Limit the Y to minimum values
        destination = Vector3.Lerp(transform.position, destination, easing);
        destination.z = camZ; // set the camera to the destination
        transform.position = destination;
        Camera.main.orthographicSize = destination.y + 10; // set the orthographicsize of the camera to keep ground in view
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
