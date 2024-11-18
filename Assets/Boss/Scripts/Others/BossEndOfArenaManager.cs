using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEndOfArenaManager : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponentInParent<BossStats>())
        {
            collider.GetComponentInParent<BossStats>().IsOutsideArena = true;
        }
    }
    void OnTriggerExit(Collider collider)
    {
        if (collider.GetComponentInParent<BossStats>())
        {
            collider.GetComponentInParent<BossStats>().IsOutsideArena = false;
        }
    }
}
