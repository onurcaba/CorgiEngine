using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoreMountains.CorgiEngine
{
    public class GetElectric : CharacterAbility
    {
        public GameObject door;
        public GameObject testGameObject;

        public void Update()
        {
            testGameObject = GameObject.FindGameObjectWithTag("Player");
            if (Mathf.Abs(testGameObject.transform.position.x - door.transform.position.x)<0.1)
            {
                testGameObject.GetComponent<test>().Q = 1.0f;
            }
        }
    }
}
