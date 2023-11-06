using System;
using System.Collections;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Serialization;

namespace Hints
{
    public class HintCreator : MonoBehaviour
    {
        public GameObject user; 
        public GameObject createHintMenuWindow;
        public GameObject hintBase;
        private bool _isOpened = false;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                createHintMenuWindow.SetActive(!_isOpened);
                _isOpened = !_isOpened;
            }
        }

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


        public void CreateDogHint()
        {
            var created = new HintCreate(user.transform.position.x,
                user.transform.position.y, "впереди собака", GetUserToken());
            StartCoroutine(CreateHint(created));
            createHintMenuWindow.SetActive(false);
            _isOpened = !_isOpened;
            var createdObj = Instantiate(hintBase, new Vector3(created.x, created.y, 0), Quaternion.identity);
            createdObj.GetComponent<HintController>().InitFromMapping(created);
        }

        public void CreateHoleHint()
        {
            var created = new HintCreate(user.transform.position.x,
                user.transform.position.y, "дыра?", GetUserToken());
            StartCoroutine(CreateHint(created));
            createHintMenuWindow.SetActive(false);
            _isOpened = !_isOpened;
            var createdObj = Instantiate(hintBase, new Vector3(created.x, created.y, 0), Quaternion.identity);
            createdObj.GetComponent<HintController>().InitFromMapping(created);
        }

        public void CreateClockHint()
        {
            var created = new HintCreate(user.transform.position.x,
                user.transform.position.y, "впереди часы", GetUserToken());
            StartCoroutine(CreateHint(created));
            createHintMenuWindow.SetActive(false);
            _isOpened = !_isOpened;
            var createdObj = Instantiate(hintBase, new Vector3(created.x, created.y, 0), Quaternion.identity);
            createdObj.GetComponent<HintController>().InitFromMapping(created);
        }

        public void CreateRightHint()
        {
            var created = new HintCreate(user.transform.position.x,
                user.transform.position.y, "ты не имеешь права", GetUserToken());
            StartCoroutine(CreateHint(created));
            createHintMenuWindow.SetActive(false);
            _isOpened = !_isOpened;
            var createdObj = Instantiate(hintBase, new Vector3(created.x, created.y, 0), Quaternion.identity);
            createdObj.GetComponent<HintController>().InitFromMapping(created);
        }

        public void CreateRoadHint()
        {
            var created = new HintCreate(user.transform.position.x,
                user.transform.position.y, "скрытая дорога", GetUserToken());
            StartCoroutine(CreateHint(created));
            createHintMenuWindow.SetActive(false);
            _isOpened = !_isOpened;
            var createdObj = Instantiate(hintBase, new Vector3(created.x, created.y, 0), Quaternion.identity);
            createdObj.GetComponent<HintController>().InitFromMapping(created);
        }

        public void CreateJumpHint()
        {
            var created = new HintCreate(user.transform.position.x,
                user.transform.position.y, "требуется прыгнуть", GetUserToken());
            StartCoroutine(CreateHint(created));
            createHintMenuWindow.SetActive(false);
            _isOpened = !_isOpened;
            var createdObj = Instantiate(hintBase, new Vector3(created.x, created.y, 0), Quaternion.identity);
            createdObj.GetComponent<HintController>().InitFromMapping(created);
        }

        public IEnumerator CreateHint(HintCreate hintCreate)
        {
            var json = JsonConvert.SerializeObject(hintCreate);
            using (UnityWebRequest webRequest =
                   UnityWebRequest.Post("https://twoics.fvds.ru/api/hint/", json, "application/json"))
            {
                yield return webRequest.SendWebRequest();
                Debug.Log("webRequest.result" + webRequest.result);

                switch (webRequest.result)
                {
                    case UnityWebRequest.Result.ConnectionError:
                    case UnityWebRequest.Result.DataProcessingError:
                        Debug.LogError("Something went wrong while make call");
                        break;
                    case UnityWebRequest.Result.Success:
                        Debug.Log("Success");
                        break;
                }
            }
        }
    }
}