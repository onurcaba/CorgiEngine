using UnityEngine;
using System.Collections;
using MoreMountains.Tools;
using System.Collections.Generic;
using System;

namespace MoreMountains.CorgiEngine
{
    public class test : CharacterAbility
    {

        public GameObject testGameObject;
        public GameObject testElectricField;
        public GameObject levelManager;
        public float potentialPowerMax;
        public Vector3 lastPosition;
        public Vector3 position;
        public float heightOfBottom;
        public float originalPower;
        public float potentialPower;
        public float powerOfVelocity;
        public float powerOfGravity;
        public float powerOfElectricity;
        public float powerOfHeat;
        public float M;
        public float V;
        public float Q;
        public float C;
        public float U;
        public float temprature;
        public bool disappearElectricField;


        public void initialize()
        {
            testGameObject = GameObject.FindGameObjectWithTag("Player");
            testElectricField = GameObject.FindGameObjectWithTag("ElectricField");
            levelManager = GameObject.FindGameObjectWithTag("LevelManager");
            heightOfBottom = -4.5f;
            temprature = 0f;
            M = 1.0f;
            V = 0.15f;
            Q = -1.0f;
            C = 3.0f;
            U = 3.0f;
            originalPower = 25f;
            powerOfVelocity = 0f;
            powerOfGravity = 0f;
            powerOfElectricity = 0f;
            powerOfHeat = 0f;
            disappearElectricField = false;
        }

        public void run()
        {
            powerOfGravity = (position.y - heightOfBottom) * M;
            powerOfVelocity = (Math.Abs(getSpeed())) * V;
            powerOfHeat = temprature * C;
            powerOfElectricity = U * Q;
            position = testGameObject.transform.position;
            potentialPower = originalPower - powerOfGravity - powerOfVelocity - powerOfElectricity - powerOfHeat;
            if(testElectricField.GetComponent<ElectricField>() != null)
            {
                if (testElectricField.GetComponent<ElectricField>().isInElctricField)
                {
                    potentialPower = originalPower - powerOfGravity - powerOfVelocity - powerOfElectricity - powerOfHeat - testElectricField.GetComponent<ElectricField>().passedDistance / (testElectricField.GetComponent<ElectricField>().halfLength * 2) * testElectricField.GetComponent<ElectricField>().needPower;
                }
                if (testElectricField.GetComponent<ElectricField>().isRightElectricField)
                {
                    potentialPower = originalPower - powerOfGravity - powerOfVelocity - powerOfElectricity - powerOfHeat - testElectricField.GetComponent<ElectricField>().needPower;
                }
            }        
            if(testElectricField.GetComponent<ElectricField1>() != null)
            {
                if (testElectricField.GetComponent<ElectricField1>().isInElctricField)
                {
                    potentialPower = originalPower - powerOfGravity - powerOfVelocity - powerOfElectricity - powerOfHeat + testGameObject.GetComponent<test>().Q*testElectricField.GetComponent<ElectricField1>().passedYDistance / testElectricField.GetComponent<ElectricField1>().verticalLength * testElectricField.GetComponent<ElectricField1>().needPower;
                }
                if (testElectricField.GetComponent<ElectricField1>().isRightElectricField && testElectricField.GetComponent<ElectricField1>().passedYDistance>17f)
                {
                    potentialPower = originalPower - powerOfGravity - powerOfVelocity - powerOfElectricity - powerOfHeat + testElectricField.GetComponent<ElectricField1>().needPower;
                    disappearElectricField = true;
                }
            }

        }

        public float getSpeed()
        {
            float speed = (position.x - lastPosition.x) / Time.deltaTime;
            lastPosition = position;
            return speed;
        }

        public void Start()
        {
            initialize();
        }


        public void Update()
        {
            run();
            if (disappearElectricField)
            {
                testElectricField.SetActive(false);
            }
            if (potentialPower < 3.0f)
            {
                GetComponent<CharacterJump>().enabled = false;
            }
            else
            {
                GetComponent<CharacterJump>().enabled = true;
            }

            if (potentialPower < 0f)
            {
                GetComponent<CharacterHorizontalMovement>().enabled = false;
            }
            else
            {
                GetComponent<CharacterHorizontalMovement>().enabled = true;
            }

            if (Input.GetKey(KeyCode.C) && Q == 0f && levelManager.GetComponent<LevelManager>().LoadingSceneName == "level_4")
            {
                Q += 1.0f;
            }
            

            if (Input.GetKey(KeyCode.C) && Q == -1f && levelManager.GetComponent<LevelManager>().LoadingSceneName == "level_4")
            {
                Q += 2.0f;
            }

            if (Input.GetKey(KeyCode.X) && Q == 1f && levelManager.GetComponent<LevelManager>().LoadingSceneName == "level_4")
            {
                Q -= 2.0f;
            }

            if (Input.GetKey(KeyCode.H) && temprature == 0f)
            {
                temprature += 1.0f;
            }

            if (Input.GetKey(KeyCode.J) && temprature == 1f)
            {
                temprature -= 1.0f;
            }

        }

    }
}
