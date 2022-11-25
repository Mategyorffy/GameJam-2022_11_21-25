using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{

    public class ProjectileFalling : MonoBehaviour
    {
        private void OnEnable()
        {
            StartCoroutine(DestroyAfterAWhile());
        }
        private void OnDisable()
        {
            StopCoroutine(DestroyAfterAWhile());
        }

        public IEnumerator DestroyAfterAWhile()
        {
            yield return new WaitForSeconds(3f);

            Destroy(gameObject);
        }
    }
}