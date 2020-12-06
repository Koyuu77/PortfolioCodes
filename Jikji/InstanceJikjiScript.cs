using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

namespace FirstFloor
{
    public class InstanceJikjiScript : MonoBehaviour
    {
        private float timer = 0;
        private bool startTime = false;
        private AudioSource MaintainAudioSource = null;
        private List<Vector3> ResetContactedShapes = null;

        public static int G_GameCount = 0;
        public static int NotContactRandomObject = 0;
        public static bool CheckContactJikji = false;
        public static bool check = false;
        public static bool StartGame = false;
        public static bool ChangeImageBool;
        public static Texture[] TextureCollect = null;
        public static AudioClip[] audioClips = null;
        public static GameObject[] Jikji = null;
        public static GameObject[] JikjisTag = null;
        public static List<GameObject> ContactJikjisTag = null;
        public static List<GameObject> RandomJikjies = null;
        public static List<GameObject> ContactedObjects = null;


        // Start is called before the first frame update
        void Start()
        {
            ResetContactedShapes = new List<Vector3>();
            ContactJikjisTag = new List<GameObject>();
            Jikji = Resources.LoadAll<GameObject>("NewObj");
            TextureCollect = Resources.LoadAll<Texture>("Images");
            audioClips = Resources.LoadAll<AudioClip>("Music");
            JikjisTag = GameObject.FindGameObjectsWithTag("Jikji_F");
            StartGame = true;
            for (int i = 1; i < 5; i++)
            {
                string num = i.ToString();
                GameObject TagName = GameObject.Find("Cube_" + num);
                ContactJikjisTag.Add(TagName);
                ResetContactedShapes.Add(TagName.gameObject.transform.position);
            }
            /*CreateJikji(G_GameCount);
            CheckContactJikji = true;*/
        }


        // Update is called once per frame
        void Update()
        {
            if (startTime)
            {
                timer += Time.deltaTime;
                if (timer > MaintainAudioSource.clip.length)
                {
                    startTime = false;
                    timer = 0;
                    InvisibleOfGameObjectMethod();
                    G_GameCount++;
                    CreateJikji(G_GameCount);
                }
            }
            
            if (CheckContactJikji)
            {
                MaintainAudioSource = GameObject.Find("MainSwitch_F").GetComponent<AudioSource>();
                startTime = true;
                CheckContactJikji = false;
                MaintainAudioSource.Play();
            }
            
        }

        private void ResetPositionObejct()
        {
            BoxCollider collide;
            string ShapeNumber = ((NotContactRandomObject % 4) + 1).ToString();
            GameObject.Find("Shape_" + ShapeNumber).GetComponent<MeshRenderer>().enabled = false;
            for (int i = 0; i < ResetContactedShapes.Count; i++)
            {
                ContactJikjisTag[i].gameObject.transform.position = ResetContactedShapes[i];
                collide = ContactJikjisTag[i].GetComponent<BoxCollider>();
                ContactJikjisTag[i].GetComponent<ConTactMethod>().enabled = false;
                collide.enabled = false;
                collide.isTrigger = false;
            }
        }

        private void InvisibleOfGameObjectMethod()
        {
            ChangeImageBool = false;
            ResetPositionObejct();
            for (int i = 0; i < RandomJikjies.Count; i++)
            {
                RandomJikjies[i].gameObject.SetActive(false);
                //Destroy(RandomJikjies[i]);//
            }
            for (int i = 0; i < ContactedObjects.Count; i++)
            {
                ContactedObjects[i].gameObject.SetActive(false);
                //Destroy(ContactedObjects[i]);//
            }
        }

        public static void CreateJikji(int G_Variable)
        {
            BoxCollider collide;
            OVRGrabbable grab;
            List<AudioClip> AudioSourceList = new List<AudioClip>();
            RandomJikjies = new List<GameObject>();
            ContactedObjects = new List<GameObject>();
            NotContactRandomObject = Random.Range(G_Variable * 4, G_Variable * 4 + 4);
            ChangeImageBool = true;
            for (int i = G_Variable * 4; i < G_Variable * 4 + 4; i++)
            {
                GameObject BasicContactJikji;
                GameObject DownObejct;
                if(G_GameCount == 0)
                {
                ContactJikjisTag[i % 4].GetComponent<Rigidbody>().useGravity = false;
                ContactJikjisTag[i % 4].AddComponent<ConTactMethod>();
                ContactJikjisTag[i % 4].GetComponent<ConTactMethod>().enabled = false;
                }

                if (i == NotContactRandomObject)
                {
                    DownObejct = Instantiate(Jikji[i]);
                    int number = G_Variable * 5 + NotContactRandomObject % 4;
                    AudioSourceList.Add(audioClips[number]);
                    RandomJikjies.Add(DownObejct);
                    ContactJikjisTag[i % 4].transform.position += new Vector3(-0.26f, 0.25f, -0.11f);
                    collide = ContactJikjisTag[i % 4].GetComponent<BoxCollider>();
                    collide.enabled = true;
                    ContactJikjisTag[i % 4].GetComponent<ConTactMethod>().enabled = true;
                    collide.isTrigger = true;
                    string ShapeNumber = ((NotContactRandomObject % 4) + 1).ToString();
                    GameObject.Find("Shape_" + ShapeNumber).GetComponent<MeshRenderer>().enabled = true;
                }
                else
                {
                    BasicContactJikji = Instantiate(Jikji[i]);
                    ContactedObjects.Add(BasicContactJikji);
                    BasicContactJikji.transform.position = ContactJikjisTag[i % 4].transform.position;
                    BasicContactJikji.transform.rotation = Quaternion.Euler(0, -20, 0);
                    BasicContactJikji.transform.localScale = new Vector3(75f, 75f, 75f);//
                }
            }
            for (int i = 0; i < JikjisTag.Length - 1; i++)
            {
                GameObject RandomGameObject;
                int RandomObj = Random.Range(G_Variable * 4 + 4, Jikji.Length);
                int numberDivi = RandomObj / 5 + 1;
                RandomGameObject = Instantiate(Jikji[RandomObj]);
                // FInalInstanceObjects.Add(RandomGameObject);
                AudioSourceList.Add(audioClips[numberDivi * 5 + RandomObj % 4]);
                RandomJikjies.Add(RandomGameObject);
            }
            for (int i = 0; i < RandomJikjies.Count; i++)
            {
                RandomJikjies[i].transform.position = JikjisTag[i].transform.position;
                RandomJikjies[i].transform.rotation = Quaternion.Euler(0, -20, 0);
                RandomJikjies[i].transform.localScale = new Vector3(75f, 75f, 75f);
                RandomJikjies[i].AddComponent<AudioSource>();
                collide = RandomJikjies[i].AddComponent<BoxCollider>();
                RandomJikjies[i].GetComponent<AudioSource>().clip = AudioSourceList[i];
                RandomJikjies[i].GetComponent<AudioSource>().volume = 1.0f;
                RandomJikjies[i].AddComponent<Rigidbody>().useGravity = true;
                grab = RandomJikjies[i].AddComponent<OVRGrabbable>();
                grab.CustomGrabCollider(collide);
            }
            GameObject.Find("MainSwitch_F").GetComponent<AudioSource>().clip = audioClips[(G_Variable + 1) * 5 - 1];
        }
    }

}
