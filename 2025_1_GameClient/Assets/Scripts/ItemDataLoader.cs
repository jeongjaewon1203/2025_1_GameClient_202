using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using Newtonsoft.Json;

public class ItemDataLoader : MonoBehaviour
{
    [SerializeField]
    private string jsonFileName = "items";      //Resources �������� ������ JSON ���� �̸�

    private List<ItemData> itemList;
    // Start is called before the first frame update
    void Start()
    {
        LoadItemData();
    }
    void LoadItemData()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>(jsonFileName);

        if(jsonFile != null)
        {
            //���� �ؽ�Ʈ���� UTF-8�� ��ȯ ó��
            byte[] bytes = Encoding.Default.GetBytes(jsonFile.text);
            string correntText = Encoding.UTF8.Getstring(bytes);

            itemList = JsonConvert.DeserializedObject<List<itemData>>(correntText);

            Debug.Log($"�ε�� ������ �� : {itemList.Count}");

            foreach(var item in itemList)
            {
                Debug.Log($"������: {EncodeKorean(item.ItemName)} ���� : {EncodeKorean(item.description)} "), 
            }
        }
        else
        {
            Debug.LogError($"JSON ������ ã�� �� �����ϴ� : {jsonFileName}")
        }
    }







    //�ѱ� ���ڵ��� ���� ���� �Լ�

    private string EncodeKorean(string text)
    {
        if (string.IsNullorEmpty(text))return "";           //�ؽ�Ʈ�� NULL ���̸� �Լ��� ������
        byte[] bytes = Encoding.Default.GetBytes(text);     //string ��
        return Encoding.UTF8.Getstring(bytes);              
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
