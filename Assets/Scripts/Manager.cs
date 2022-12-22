using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;

public class Manager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI id_Txt, name_Txt, role_Txt, crew_type_Txt, credit_type_Txt, item_id_Txt, linked_item_id_Txt, created_at_Txt, updated_at_Txt, I_id_Txt, I_name_Txt, I_language_Txt, A_url_Txt, T_url_Txt;
    [SerializeField] Renderer adboard;


    List<Entries> entries = new List<Entries>();
    int counter = 0;

    Texture adTexture;
    Material[] mat;

    private void Start()
    {
        entries = JSONReader.ReadListFromJSON<Entries>("list.json");
        Debug.Log(entries.Count);

        mat = adboard.materials;
    }

    public void displayNext()
    {
        if (counter > entries.Count - 1)
        {
            counter = 0;
        }

        id_Txt.text = "ID : " + entries[counter].id.ToString();
        name_Txt.text = "Name : " + entries[counter].name;
        role_Txt.text = "Role : " + entries[counter].role;
        crew_type_Txt.text = "Crew Type : " + entries[counter].crew_type;
        credit_type_Txt.text = "Credit Type : " + entries[counter].credit_type;
        item_id_Txt.text = "Item ID : " + entries[counter].item_id.ToString();
        linked_item_id_Txt.text = "Linked Item ID : " + entries[counter].linked_item_id.ToString();
        created_at_Txt.text = "Created At : " + entries[counter].created_at;
        updated_at_Txt.text = "Updated At : " + entries[counter].updated_at;

        I_id_Txt.text = "ID : " + entries[counter].item.id.ToString();
        I_name_Txt.text = "Name : " + entries[counter].item.name;
        I_language_Txt.text = "Language : " + entries[counter].item.language;

        A_url_Txt.text = "URL : " + entries[counter].item.asset.url;

        T_url_Txt.text = "URL : " + entries[counter].item.asset.thumb.url;

        StartCoroutine(GetTexture(entries[counter].item.asset.url));

        counter++;
    }

    IEnumerator GetTexture(string webpath)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(webpath);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            adTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            mat[1].SetTexture("_MainTex", adTexture);
            adboard.materials = mat;
            yield break;
        }
    }
}
