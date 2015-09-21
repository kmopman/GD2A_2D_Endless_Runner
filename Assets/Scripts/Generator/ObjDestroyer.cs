using UnityEngine;
using System.Collections;

public class ObjDestroyer : MonoBehaviour 
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.transform.parent)
        {
            Destroy(other.gameObject.transform.parent.gameObject);
        }

        else
        {
            Destroy(other.gameObject);
        }
    }
}
