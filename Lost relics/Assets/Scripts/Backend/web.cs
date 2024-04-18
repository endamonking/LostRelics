using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
public class web : MonoBehaviour
{

    void Start()
    {

    }

    IEnumerator addUser()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost/lost_relics/addData.php"))
        {
            yield return www.Send();
            
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);

                byte[] results = www.downloadHandler.data;
            }

        }
    }

    public IEnumerator login(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUsername", username);
        form.AddField("loginPassword", password);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/lost_relics/login.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                if (www.downloadHandler.text == "LoginSuccess")
                    SceneManager.LoadScene("MainMenu");
            }
        }
    }
    public IEnumerator sendJson(string jsonString)
    {
        WWWForm form = new WWWForm();
        form.AddField("json", jsonString);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/lost_relics/createRunLog.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }
    public IEnumerator sendJson(string jsonString, string jsonString2)
    {
        WWWForm form = new WWWForm();
        form.AddField("json", jsonString);
        form.AddField("json2", jsonString2);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/lost_relics/createRunLog2.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }

}
