using UnityEngine;
using System.Collections;

namespace SS
{
    public class Bullet : MonoBehaviour {

      
    void OnCollisionEnter()
    {
        Destroy(gameObject);
    }
}
}


