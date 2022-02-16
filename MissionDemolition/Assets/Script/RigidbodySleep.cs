/***
 * Created By: Xingzhou Li
 * Date Created: 2/15/2022
 * 
 * Last Edited: 2/15/2022
 * Edited by: Xingzhou Li
 * 
 * Description: Castle
 */
using UnityEngine;

public class RigidbodySleep : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null) rb.Sleep();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
