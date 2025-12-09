namespace GoogleARCore.HelloAR
{
    using UnityEngine;
    using GoogleARCore;
    using UnityEngine.UI;

    public class MainController : MonoBehaviour
    {

        // 메인 컨트롤러 
        Button btn;


        public Text camPoseText;

        public Camera threedCamera;

        public Camera m_firstPersonCamera; //posetracking
        public GameObject cameraTarget;   //SpherePointer
        public GameObject Plane;
        public GameObject Real_cameraTarget;   //SpherePointer

        private Vector3 m_prevARPosePosition;
        private bool trackingStarted = false;
        public bool isOnclick = false;

        public LineDrawing LD;
        float sX, sY, sZ;

        public void Start()
        {
            m_prevARPosePosition = Vector3.zero;

            btn = GameObject.Find("StartButton").GetComponent<Button>();
            btn.onClick.AddListener(TaskOnClick);

            Plane.gameObject.SetActive(false);



        }

        private void TaskOnClick()
        {
            isOnclick = true;
        }

        public void Update()
        {
            _QuitOnConnectionErrors();
            if (isOnclick == true)
            {
                isOnclick = false;

                sX = LD.init_x;
                sY = LD.init_y - 0.5f;
                sZ = LD.init_z;
                cameraTarget.transform.position = new Vector3(sX, sY, sZ);
                Real_cameraTarget.transform.position = new Vector3(sX, sY, sZ);
                threedCamera.transform.position = new Vector3(sX, 50.0f, sZ);
            }



            if (Session.Status != SessionStatus.Tracking)
            {
                trackingStarted = false;                      // if tracking lost or not initialized
                if (camPoseText != null)
                    camPoseText.text = "Lost tracking, wait ...";
                const int LOST_TRACKING_SLEEP_TIMEOUT = 15;
                Screen.sleepTimeout = LOST_TRACKING_SLEEP_TIMEOUT;
                return;
            }
            else
            {
                camPoseText.text = "" + cameraTarget.transform.position;
                //시작시에 50,50,50 찍히는 거

            }

            



            Screen.sleepTimeout = SleepTimeout.NeverSleep;
            Vector3 currentARPosition = Frame.Pose.position;

            if (!trackingStarted)
            {
                trackingStarted = true;
                m_prevARPosePosition = Frame.Pose.position;
            }
            //Remember the previous position so we can apply deltas
            Vector3 deltaPosition = currentARPosition - m_prevARPosePosition;
            m_prevARPosePosition = currentARPosition;
            if (cameraTarget != null)
            {
                // The initial forward vector of the sphere must be aligned with the initial camera direction in the XZ plane.
                // We apply translation only in the XZ plane.

                //cameraTarget.transform.Translate(deltaPosition.x, 0.0f, deltaPosition.z, Space.World);
                //m_firstPersonCamera.transform.Translate(deltaPosition.x, 0.0f, deltaPosition.z, Space.World);
                Real_cameraTarget.transform.Translate(deltaPosition.x, deltaPosition.y, deltaPosition.z, Space.World);
                //m_firstPersonCamera.transform.Translate(deltaPosition.x, 0.0f, deltaPosition.z);
                // Set the pose rotation to be used in the CameraFollow script
                //

                //m_firstPersonCamera.GetComponent<FollowTarget>().targetRot = Frame.Pose.rotation;
            }
        }
        private void _QuitOnConnectionErrors()
        {
            /*
            // Do not update if ARCore is not tracking.
            if (Session.ConnectionState == SessionConnectionState.DeviceNotSupported)
            {
                camPoseText.text = "This device does not support ARCore.";
                Application.Quit();
            }
            else if (Session.ConnectionState == SessionConnectionState.UserRejectedNeededPermission)
            {
                camPoseText.text = "Camera permission is needed to run this application.";
                Application.Quit();
            }
            else if (Session.ConnectionState == SessionConnectionState.ConnectToServiceFailed)
            {
                camPoseText.text = "ARCore encountered a problem connecting.  Please start the app again.";
                Application.Quit();
            }*/
        }
    }
}