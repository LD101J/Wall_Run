using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Section_Trigger : MonoBehaviour
{
    [SerializeField] private GameObject wall_Prefab;
    [SerializeField] private float level_Module;

        private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Level_Generator"))
        {
            Instantiate(wall_Prefab, new Vector3 (0, level_Module, 0), Quaternion.identity);
        }
    }
}