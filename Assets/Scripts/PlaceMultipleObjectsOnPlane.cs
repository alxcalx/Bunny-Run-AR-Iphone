using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace UnityEngine.XR.ARFoundation.Samples
{
    [RequireComponent(typeof(ARRaycastManager))]
    public class PlaceMultipleObjectsOnPlane : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Instantiates this prefab on a plane at the touch location.")]
        GameObject m_PlacedPrefab;
        public static Pose hitPose;

        public static float k_ModelRotation = 180.0f;


        
        /// <summary>
        /// The prefab to instantiate on touch.
        /// </summary>
        /// 
      

        public GameObject placedPrefab

   
        {
            get { return m_PlacedPrefab; }
            set { m_PlacedPrefab = value; }
        }



        /// <summary>
        /// The object instantiated as a result of a successful raycast intersection with a plane.
        /// </summary>
        public static GameObject spawnedObject { get; private set; }

        [SerializeField]

        GameObject m_Enemy;



        public GameObject enwmy


        {
            get { return m_Enemy; }
            set { m_Enemy = value; }
        }

        public static GameObject spawnedEnemy { get; private set; }
        




        public GameObject BunnyController;



        


        /// <summary>
        /// Invoked whenever an object is placed in on a plane.
        /// </summary>
        public static event Action onPlacedObject;

       

        ARRaycastManager m_RaycastManager;
        ARPlaneManager m_PlaneManger;
        ARPointCloudManager aRPoint;

        static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();



        void Start()
        {
            m_RaycastManager = GetComponent<ARRaycastManager>();
            BunnyController.SetActive(false);
            m_PlaneManger = GetComponent<ARPlaneManager>();
            aRPoint = GetComponent<ARPointCloudManager>();


            

        }

        void Update()
        {


           

            if (Input.touchCount > 0 && spawnedObject == null)
            {

                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    if (m_RaycastManager.Raycast(touch.position, s_Hits, TrackableType.PlaneWithinPolygon))
                    {
                       hitPose = s_Hits[0].pose;

                       Vector3 newPos = hitPose.position + new Vector3(1, 0, 0);

                       spawnedObject = Instantiate(m_PlacedPrefab, hitPose.position, hitPose.rotation);

                       spawnedObject.transform.Rotate(0, 0, 0, Space.World);

                       spawnedEnemy = Instantiate(m_Enemy, newPos, hitPose.rotation);

                       spawnedEnemy.transform.Rotate(0, 0, 0, Space.World);

                      


                        //Enable movement controller for the bunny 
                        BunnyController.SetActive(true);

                        aRPoint.enabled = !aRPoint.enabled;
                        m_PlaneManger.enabled = !m_PlaneManger.enabled;



                        

                       



                        if (onPlacedObject != null)
                        {
                            onPlacedObject();
                        }
                    }

                    
                }

            }

         
        }

      

    
    }

}