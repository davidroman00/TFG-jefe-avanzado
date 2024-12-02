using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEndOfArenaManager : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponentInParent<BossReferences>())
        {
            collider.GetComponentInParent<BossReferences>().IsOutsideArena = true;
        }
    }
    void OnTriggerExit(Collider collider)
    {
        if (collider.GetComponentInParent<BossReferences>())
        {
            collider.GetComponentInParent<BossReferences>().IsOutsideArena = false;
        }
    }
}
