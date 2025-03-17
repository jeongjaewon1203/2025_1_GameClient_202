using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using Newtonsoft.Json;

public class ItemDataLoader : MonoBehaviour
{
    [SerializeField]
    private string jsonFileName = "items";      //Resources 폴더에서 가져올 JSON 파일 이름

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
            //원본 텍스트에서 UTF-8로 변환 처리
            byte[] bytes = Encoding.Default.GetBytes(jsonFile.text);
            string correntText = Encoding.UTF8.Getstring(bytes);

            itemList = JsonConvert.DeserializedObject<List<itemData>>(correntText);

            Debug.Log($"로드된 아이템 수 : {itemList.Count}");

            foreach(var item in itemList)
            {
                Debug.Log($"아이템: {EncodeKorean(item.ItemName)} 설명 : {EncodeKorean(item.description)} "), 
            }
        }
        else
        {
            Debug.LogError($"JSON 파일을 찾을 수 없습니다 : {jsonFileName}")
        }
    }







    //한글 이코딩을 위한 헬퍼 함수

    private string EncodeKorean(string text)
    {
        if (string.IsNullorEmpty(text))return "";           //텍스트가 NULL 값이면 함수를 끝낸다
        byte[] bytes = Encoding.Default.GetBytes(text);     //string 을
        return Encoding.UTF8.Getstring(bytes);              
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
