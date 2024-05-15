using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using System.Threading.Tasks;

//UNITY ICIN FIREBASE BAGLANTI KODU
//FIREBASE SDK IMPORT EDILDIKTEN SONRA KULLANILABILIR
//SAVEDATA FONKSIYONU ILE ISTENILEN TURDE VERILER KAYDEDILEBILIR
//LOADDATA FONKSIYONU ILE KAYDEDILEN VERILERE ERISILEBILIR
[Serializable]
public class DataToSave//verilerin tutuldugu class
{
    //ornek veriler
    public string userName;
    public int userCoin;
}
public class FirebaseConnect : MonoBehaviour
{
    public string userID;//her kullanici icin bir id numarasi
    public string databaseURL;//projenin veritabani url adresi

    public DataToSave dts;//verilere ulasmak icin class referansi

    private bool isFirebaseInitialized = false;//firebase baglantisini kontrol eden bool

    private DatabaseReference reference;//veritabani referansi

    private void Awake()
    {
        //firabase yapilandir ve baglanti sirasinda hata olursa hatayi rapor et

        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(innerTask =>
        {
            FirebaseApp app = FirebaseApp.DefaultInstance;
            FirebaseDatabase database = FirebaseDatabase.GetInstance(app, databaseURL);

            if (innerTask.IsFaulted || innerTask.IsCanceled)
            {
                Debug.LogError("Failed to initialize Firebase Database : " + innerTask.Exception);
            }
            else
            {
                InitializeFirebase();
            }
            if (database == null)
            {
                Debug.LogError("Failed to initialize Firebase Database");
                return;
            }
            reference = database.RootReference;
        });
    }
    private void InitializeFirebase()
    {
        //baglantiyi gerceklestir

        FirebaseApp app = FirebaseApp.DefaultInstance;
        if (app == null)
        {
            app = FirebaseApp.Create();
        }

        reference = FirebaseDatabase.DefaultInstance.RootReference;
        isFirebaseInitialized = true;

        Debug.Log("Firebase Connection Was Successful");
    }
    public void SaveData()
    {
        //class icindeki verilerde bir degisiklik yapilirsa bu metod cagirilir ve veriler veritabaninda da guncellenmis olur

        string json = JsonUtility.ToJson(dts);
        reference.Child("users").Child(userID).SetRawJsonValueAsync(json);

        Debug.Log("Data Saved Successfully");
    }
    public void LoadData()
    {
        StartCoroutine(LoadDataEnum());
    }
    IEnumerator LoadDataEnum()
    {
        var serverData = reference.Child("users").Child(userID).GetValueAsync();
        yield return new WaitUntil(predicate: () => serverData.IsCompleted);

        DataSnapshot snapshot = serverData.Result;
        string jsonData = snapshot.GetRawJsonValue();

        if (jsonData != null)
        {
            dts = JsonUtility.FromJson<DataToSave>(jsonData);
            Debug.Log("Data Loaded Successfully");

        }
        else
        {
            Debug.LogError("No Data Found");
        }
    }
}