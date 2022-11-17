using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample08
{
    public class RotationSample : MonoBehaviour
    {
        // Start is called before the first frame update

        void Start()
        {
            //QuaternionÇÃçáê¨
            Quaternion rotation1 = Quaternion.AngleAxis(-90f, new Vector3(0f, 0f, 1f));
            Quaternion rotation2 =Quaternion.AngleAxis(45f,new Vector3(0f,1f, 0f));

            Quaternion rotation3 = rotation1 * rotation2;
            Quaternion rotation4 = rotation2 * rotation1;

            //ÉxÉNÉgÉãÇÃâÒì]
            Vector3 v=new Vector3(0f,0f,3f);
            Vector3 v2=rotation2 * v;
            Debug.Log("defore:" + v + ",after:" + v2);

        }

        private float YAxisRotation { get; set; } = 0f;
        private void Update()
        {
            Handson04Update();
        }

        private void Handson04()
        {
            Quaternion rotation = Quaternion.AngleAxis(-90f, new Vector3(0f, 0f, 1f));

            transform.rotation = rotation;

        }

        private void Handson04Update()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                YAxisRotation += 1f;
                Quaternion updateRotation = Quaternion.AngleAxis
                    (YAxisRotation, new Vector3(0f, 1f, 0f));
                transform.rotation = updateRotation;
            }

        }

    }


}
