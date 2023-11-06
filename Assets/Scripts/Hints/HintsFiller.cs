using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Serialization;

namespace Hints
{
    public class HintsFiller : MonoBehaviour
    {
        public GameObject hintToCloneObj;
        private const string GetHintURL = "https://twoics.fvds.ru/api/hint/?user_token=";

        private string GetUserToken()
        {
            if (PlayerPrefs.HasKey("user_token"))
            {
                return PlayerPrefs.GetString("user_token");
            }

            var guid = Guid.NewGuid();
            PlayerPrefs.SetString("user_token", guid.ToString());
            return guid.ToString();
        }

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
                            Debug.Log("LSKJDFHLKSJDFH");
                            var created = Instantiate(hintToCloneObj, new Vector3(hint.x, hint.y, 0), Quaternion.identity);
                            created.GetComponent<HintController>().InitFromMapping(hint);
                            Debug.Log("БЛЯТБ");

                        }

                        break;
                }
            }
        }

        private void Start()
        {
            StartCoroutine(FillHints(GetUserToken()));
        }
    }
}