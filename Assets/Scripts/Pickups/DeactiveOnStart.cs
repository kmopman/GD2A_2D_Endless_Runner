using UnityEngine;
using System.Collections;

public class DeactiveOnStart : MonoBehaviour
{
    void Start()
    {
        this.gameObject.SetActive(false);
    }
}
