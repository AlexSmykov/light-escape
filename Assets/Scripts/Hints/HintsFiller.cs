using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

namespace Hints
{
    public class HintsFiller: MonoBehaviour
    {
        public GameObject obj;
        private const string GetHintURL = "https://twoics.fvds.ru/api/hint/?user_token=";

        public IEnumerator FillHints(string userToken)
        {
            using (UnityWebRequest webRequest = UnityWebRequest.Get(GetHintURL + userToken))
            {
                yield return webRequest.SendWebRequest();
                switch (webRequest.result)
                {
                    case UnityWebRequest.Result.ConnectionError:
                    case UnityWebRequest.Result.DataProcessingError:
                        Debug.LogError("Something went wrong while make call");
                        break;
                    case UnityWebRequest.Result.Success:
                        var hints = JsonConvert.DeserializeObject<List<HintGet>>(webRequest.downloadHandler.text);
                        foreach (var hint in hints)
                        {
                            var created = Instantiate(obj, new Vector3(hint.x, hint.y, 0), Quaternion.identity);
                            created.GetComponent<HintController>().InitFromMapping(hint);
                        }

                        break;
                }
            }
        }
    }
}