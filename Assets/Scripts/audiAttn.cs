
namespace GoogleVR.HelloVR
{
    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.EventSystems;

    /// <summary>Controls interactable teleporting objects in the Demo scene.</summary>
    [RequireComponent(typeof(Collider))]
    public class audiAttn : MonoBehaviour
    {
        private Vector3 startingPosition;
        private bool firstTime;
        public int score;
        /// <summary>Sets this instance's GazedAt state.</summary>
        /// <param name="gazedAt">
        /// Value `true` if this object is being gazed at, `false` otherwise.
        /// </param>
        public void SetGazedAt(bool gazedAt)
        {
            //if (inactiveMaterial != null && gazedAtMaterial != null)
            //{
            //    myRenderer.material = gazedAt ? gazedAtMaterial : inactiveMaterial;
            //    return;
            //}
            if(gazedAt)
            {
                if(score!=0)
                    GameObject.Find("Encourage").GetComponent<Text>().text = "";
            }
            else
            {
                if(score!=0)
                    GameObject.Find("Encourage").GetComponent<Text>().text = "Be confident and Look at audience\nYou can do it!";
                if (!firstTime && score>0)
                {
                    score -= 10;
                    GameObject.Find("Score").GetComponent<Text>().text = "Score: "+score.ToString();
                    if(score==0)
                    {
                        GameObject.Find("Encourage").GetComponent<Text>().text = "Restart And Try Again!";
                    }
                }
                else
                {
                    firstTime = !firstTime;
                }
            }
        }

        public void Reset()
        {
            //int sibIdx = transform.GetSiblingIndex();
            //int numSibs = transform.parent.childCount;
            //for (int i = 0; i < numSibs; i++)
            //{
            //    GameObject sib = transform.parent.GetChild(i).gameObject;
            //    sib.transform.localPosition = startingPosition;
            //    sib.SetActive(i == sibIdx);
            //}
        }

        public void Recenter()
        {
#if !UNITY_EDITOR
            GvrCardboardHelpers.Recenter();
#else
            if (GvrEditorEmulator.Instance != null)
            {
                GvrEditorEmulator.Instance.Recenter();
            }
#endif  // !UNITY_EDITOR
        }

        private void Start()
        {
            score = 100;
            firstTime = true;
            SetGazedAt(false);
        }
    }
}
