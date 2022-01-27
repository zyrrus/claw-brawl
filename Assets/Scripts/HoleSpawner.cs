using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClawBrawl
{
    public class HoleSpawner : MonoBehaviour
    {
        // For Gizmos
        [SerializeField] private BoxCollider bc;
        [SerializeField] private bool showBoxGizmo;

        [SerializeField] private GameObject holePrefab;
        [SerializeField] private int maxPoints;

        private void Awake()
        {
            bc = GetComponent<BoxCollider>();
        }

        private void Start()
        {
            SpawnNHoles(maxPoints);
        }

        private void OnDrawGizmos()
        {
            if (!showBoxGizmo) return;

            Gizmos.color = new Color(1, 1, 0, 0.5f);
            Gizmos.DrawCube(bc.center, bc.size);
        }

        private void SpawnNHoles(int n)
        {
            for (int i = 0; i < maxPoints; i++)
                SpawnHole();
        }

        private void SpawnHole()
        {
            GameObject hole = GameObject.Instantiate(holePrefab, Vector3.zero, Quaternion.identity);
            hole.transform.SetParent(transform);
        }
    }
}
