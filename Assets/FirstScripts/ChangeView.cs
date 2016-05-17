using UnityEngine;
using System.Collections;


namespace UnityStandardAssets.Characters.FirstPerson
{
    public class ChangeView : MonoBehaviour
    {
        public int frameRate;
        public Animator ani;
        public bool up = false;
        // Use this for initialization
        public FirstPersonController FPSC;
        public GameObject Character;
        public bool gravityOn;
        public bool inAnimation;
        float goToSideTime;
        void Awake()
        {
            inAnimation = false;
            gravityOn = true;
            frameRate = 60;
            Application.targetFrameRate = frameRate;

        }
        void Start()
        {
            ani = GetComponent<Animator>();
            

        }

        // Update is called once per frame
        void Update()
        {

            if (!inAnimation)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    FPSC.up = !up;
                    ani.SetBool("Up", !up);
                    up = !up;
                    if (up)
                    {
                        
                        Physics.gravity = Vector3.zero;
                        StartCoroutine(CharacterAlignSideToUp());
                        //zıplamayı kesen
                        FPSC.m_MoveDir.y = 0f;

                    }
                    else
                    {
                        goToSideTime = Time.time;
                        StartCoroutine(CharacterAlignUpToSide());
                        StartCoroutine(MakeCameraSide());

                    }

                }
            }

        }

        IEnumerator MakeCameraSide()
        {
            float startUpTime = goToSideTime;
            for (int i = 0; i < frameRate; i++)
            {
                
                yield return new WaitForEndOfFrame();
                
            }
            if (!up) 
            {
                if (startUpTime == goToSideTime)
                {
                    Physics.gravity = new Vector3(0f, -9.8f, 0f);
                }
               }
        }
        IEnumerator CharacterAlignSideToUp()
        {
            // yield return new WaitForSeconds(1f);
            inAnimation = true;
            Vector3 firstpos = Character.transform.position;
            Vector3 temp = Character.transform.position;
            float tempz = temp.z;
            temp.z = temp.y - 0.5f;
            temp.y = tempz + 0.5f;
            //Character.transform.position = temp;
            Vector3 dest = temp;
            Vector3 road = dest - firstpos;
            //  Character.transform.position = temp;


            for (int i = 0; i < frameRate/4; i++) {
                Character.transform.position += (road / (float)frameRate*4f);
                yield return new WaitForEndOfFrame();

            }
            inAnimation = false;
            
        }
        IEnumerator CharacterAlignUpToSide()
        {
            inAnimation = true;
            // yield return new WaitForSeconds(1.5f);
            Vector3 firstpos = Character.transform.position;
            Vector3 temp = Character.transform.position;
            float tempy = temp.y;
            temp.y = temp.z + 0.5f;
            temp.z = tempy - 0.5f;
         
             Vector3 dest = temp;
             Vector3 road = dest - firstpos;
             


             for (int i = 0; i < frameRate/4; i++)
             {
                 Character.transform.position += (road / (float)frameRate*4f);
                yield return new WaitForEndOfFrame();

             }
            inAnimation = false;
             

        }

      
    }
}
