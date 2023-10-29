/*
 * - Name : TTS.cs
 * - Content : Text to Speech Class using the Singleton pattern. This class communicates with the Google TTS API to convert text to speech. It's designed to reuse a single instance to optimize performance since it's a relatively heavy class.
 * 
 * - How to Use -
 * 1. Create a prefab called VoiceManager, which is used to play text-to-speech audio.
 * 2. Declare a TTS class, e.g., TTS mtts_testTTS.
 * 3. Inside the VoiceManager class:
 * 4. The TTS class is implemented using the Singleton pattern, so you can check if an instance is already in use and return that instance, or create a new instance if none exists. For example: mtts_textTTS = TTS.getInstance();
 * 5. VoiceManager receives voice data and returns it in the form of a float array through Google TTS API.
 * 6. VoiceManager stores the audio data as an AudioClip and plays it in the scene using the playVoice(id or name) function.

 * - History -
 * 2021-07-19: Implementation
 * 2021-07-20: Added comments
 * 2021-07-22: Changed the return value of the createAudio() function from AudioClip to float array.
 * 2021-07-27: Modified comments based on feedback.
 * 2021-08-10: Implemented additional features based on feedback (support for various languages - English, Korean, Japanese, Chinese) and updated comments.
 *
 * - TTS Member Variables -
 *
 * ms_UseApiURL: The URL for communication with the Google TTS API server.
 * mstts_SetTtsApi: Data format for communication with the Google TTS API server. It contains voice type, pitch, and text to be converted to speech.
 * instance: This function is a communication class, and it may be heavy. To avoid creating multiple instances, the Singleton design pattern is used to ensure that only one instance is created and reused by various object classes.

 * - TTS Member Functions -
 *
 * TextToSpeechPost(): This function contains the code for communicating with the Google TTS API server using REST API.
 * ConvertByteToFloat(): This function converts the received byte array to a float array and returns it.
 * setInput(): This function sets information needed for communication, such as the text to be converted to speech.
 * setAudioConfig(): This function sets audio configuration options needed for communication, such as pitch and speaking rate.
 * setVoice(): This function sets voice configuration options needed for communication, such as the desired voice type (e.g., Korean, English, Japanese).
 * CreateAudio(): This function converts the byte data received from the Google TTS API server to a float array, which is later used to create an AudioClip. The return value has been changed to a float array to offload the communication to a separate thread, as handling AudioClip on the main thread can cause freezing. 

 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Net;
using System;

// TTS class that communicates with the Google TTS API server and returns audio data as a float array.
public class TTS {
    // An enum defining voice options provided by Google TTS for better clarity.
    public enum Voice {
        KR_FEMALE_A,
        KR_FEMALE_B,
        KR_MALE_A,
        KR_MALE_B,
        EN_FEMALE_A,
        EN_FEMALE_B,
        EN_MALE_A,
        EN_MALE_B,
        JP_FEMALE_A,
        JP_FEMALE_B,
        JP_MALE_A,
        JP_MALE_B,
        CN_FEMALE_A,
        CN_FEMALE_B,
        CN_MALE_A,
        CN_MALE_B
    }

    // Class for defining data format sent to the Google TTS API server. It contains input text, voice settings, and audio configuration.
    [System.Serializable]
    public class SetTextToSpeech {
        public SetInput input;
        public SetVoice voice;
        public SetAudioConfig audioConfig;
    }

    // Class for setting the input text to be converted to speech, which is part of the SetTextToSpeech class.
    [System.Serializable]
    public class SetInput {
        public string text;
    }

    // Class for configuring audio options, which is part of the SetTextToSpeech class.
    [System.Serializable]
    public class SetVoice {
        public string languageCode;
        public string name;
        public string ssmlGender;
    }

    // Class for audio configuration, which is part of the SetTextToSpeech class.
    [System.Serializable]
    public class SetAudioConfig {
        public string audioEncoding;
        public float speakingRate;
        public float pitch;
        public int volumeGainDb;
    }

    // Class for receiving the response from the API server in string format, which is converted to a float array and then to an AudioClip.
    [System.Serializable]
    public class GetContent {
        public string audioContent;
    }

    private string ms_UseApiURL = "https://texttospeech.googleapis.com/v1beta1/text:synthesize?key=YOUR_API_KEY";
    private SetTextToSpeech mstts_SetTtsApi;
    private static TTS instance = null;

    // TTS constructor.
    public TTS() {
        mstts_SetTtsApi = new SetTextToSpeech();
    }

    // Get an instance of the TTS class using the Singleton pattern.
    public static TTS GetInstance() {
        if (instance is null) {
            instance = new TTS();
        }
        return instance;
    }

    // Convert the received byte array to a float array. Then, return the float array.
    private static float[] ConvertByteToFloat(byte[] baArray) {
        float[] fa_ResultFloatArr = new float[baArray.Length / 2];

        for (int i = 0; i < fa_ResultFloatArr.Length; i++) {
            fa_ResultFloatArr[i] = BitConverter.ToInt16(baArray, i * 2) / 32768.0f;
        }
        return fa_ResultFloatArr;
    }

    
    // REST API를 통해 Google TTS API서버와 통신하는 코드이다.
    /// <summary>
    /// Google TTS API서버 통신을 수행하는 과정을 정의한 함수로, Google TTS API 서버에 우리가 원하는 음성 데이터 정보를 정의한 클래스를 Json 형태로 보내면, string 형태의 Json 음성 데이터를 API 서버에서 보내주게 된다.
    /// </summary>
    /// <returns> 사용자가 원했던 오디오 Json 데이터 </returns>
    private string TextToSpeechPost(object oSettingData) {
        //use JsonUtility. convert byte[] to send this string..
        // 제이슨 직관성있게 oSendDate 수정. (PostMan)
        string s_ConvertSettingDataToJson = JsonUtility.ToJson(oSettingData);
        var b_ConvertSettingJsonDataToBytes = System.Text.Encoding.UTF8.GetBytes(s_ConvertSettingDataToJson);

        //set address to request..
        HttpWebRequest hwr_RequestApi = (HttpWebRequest)WebRequest.Create(ms_UseApiURL);
        hwr_RequestApi.Method = "POST";
        hwr_RequestApi.ContentType = "application/json";
        hwr_RequestApi.ContentLength = b_ConvertSettingJsonDataToBytes.Length;

        //send this data in Stream form.
        try {
            using (var stream = hwr_RequestApi.GetRequestStream()) {
                stream.Write(b_ConvertSettingJsonDataToBytes, 0, b_ConvertSettingJsonDataToBytes.Length);
                stream.Flush();
                stream.Close();
            }

            //receiving the response data to request data in StreamReader format. 
            HttpWebResponse hwr_ReceiveResponse = (HttpWebResponse)hwr_RequestApi.GetResponse();
            //read stream to StreamReader
            StreamReader sr_ReadStream = new StreamReader(hwr_ReceiveResponse.GetResponseStream());
            //convert stream data to string format.
            string s_OutputJson = sr_ReadStream.ReadToEnd();
            Debug.Log(s_OutputJson);
            return s_OutputJson;
        } catch (WebException e) {
            using (WebResponse response = e.Response) {
                HttpWebResponse httpResponse = (HttpWebResponse) response;
                Debug.Log(httpResponse.StatusCode);
                using (Stream data = response.GetResponseStream())
                using (var reader = new StreamReader(data)) {
                    string text = reader.ReadToEnd();
                }
            }
            return null;
        }
    }

// This code communicates with the Google TTS API server via REST API.
/// <summary>
/// Defines the process for communicating with the Google TTS API server. When we send a class defining the desired voice data to the Google TTS API server in JSON format, it returns the audio data in the form of a JSON string.
/// </summary>
/// <returns> The audio JSON data that the user requested. </returns>
private string TextToSpeechPost(object oSettingData) {
    // Use JsonUtility to convert the byte array into a JSON string.
    // For the sake of clarity, modify oSendDate to a more intuitive name (Postman).
    string s_ConvertSettingDataToJson = JsonUtility.ToJson(oSettingData);
    var b_ConvertSettingJsonDataToBytes = System.Text.Encoding.UTF8.GetBytes(s_ConvertSettingDataToJson);

    // Set the address for the request.
    HttpWebRequest hwr_RequestApi = (HttpWebRequest)WebRequest.Create(ms_UseApiURL);
    hwr_RequestApi.Method = "POST";
    hwr_RequestApi.ContentType = "application/json";
    hwr_RequestApi.ContentLength = b_ConvertSettingJsonDataToBytes.Length;

    // Send this data in Stream form.
    try {
        using (var stream = hwr_RequestApi.GetRequestStream()) {
            stream.Write(b_ConvertSettingJsonDataToBytes, 0, b_ConvertSettingJsonDataToBytes.Length);
            stream.Flush();
            stream.Close();
        }

        // Receive the response data from the request in StreamReader format.
        HttpWebResponse hwr_ReceiveResponse = (HttpWebResponse)hwr_RequestApi.GetResponse();
        // Read the stream into a StreamReader.
        StreamReader sr_ReadStream = new StreamReader(hwr_ReceiveResponse.GetResponseStream());
        // Convert the stream data to a string format.
        string s_OutputJson = sr_ReadStream.ReadToEnd();
        Debug.Log(s_OutputJson);
        return s_OutputJson;
    } catch (WebException e) {
        using (WebResponse response = e.Response) {
            HttpWebResponse httpResponse = (HttpWebResponse) response;
            Debug.Log(httpResponse.StatusCode);
            using (Stream data = response.GetResponseStream())
            using (var reader = new StreamReader(data)) {
                string text = reader.ReadToEnd();
            }
        }
        return null;
    }
}

// The code below defines functions that set the voice parameters seen at the beginning of the class.

/// <summary>
/// Defines the data to be sent to the TTS API server. In this function, the text to be converted to speech is added.
/// </summary>
private void setInput(string sTargetSpeech) {
    SetInput si_setInputData = new SetInput();
    si_setInputData.text = sTargetSpeech;
    mstts_SetTtsApi.input = si_setInputData;
}

/// <summary>
/// Defines the data to be sent to the TTS API server. In this function, audio characteristics like pitch and speaking rate are configured for customizing the voice.
/// </summary>
private void setAudioConfig(float fSetPitch, float fSpeakRate) {
    SetAudioConfig sa_setAudioConf = new SetAudioConfig();
    sa_setAudioConf.audioEncoding = "LINEAR16";
    sa_setAudioConf.speakingRate = fSpeakRate;
    sa_setAudioConf.pitch = fSetPitch;
    sa_setAudioConf.volumeGainDb = 0;
    mstts_SetTtsApi.audioConfig = sa_setAudioConf;
}

/// <summary>
/// Defines the data to be sent to the TTS API server. In this function, the base nationality of the voice is set. Currently, only Korean, Japanese, Chinese, and English voices are defined here.
/// </summary>
private void setVoice(Voice srcVoice) {
    SetVoice sv_setVoiceConf = new SetVoice();
    // Define the customization settings for the TTS API voice, specifying nationality and gender.
    switch(srcVoice) {
        // Define the Korean Female A voice.
        case Voice.KR_FEMALE_A:
            sv_setVoiceConf.languageCode = "ko-KR";
            sv_setVoiceConf.name = "ko-KR-Wavenet-A";
            sv_setVoiceConf.ssmlGender = "FEMALE";
            break;
        // Define the Korean Female B voice.
        case Voice.KR_FEMALE_B:
            sv_setVoiceConf.languageCode = "ko-KR";
            sv_setVoiceConf.name = "ko-KR-Wavenet-B";
            sv_setVoiceConf.ssmlGender = "FEMALE";
            break;
        // Define the English Female A voice.
        case Voice.EN_FEMALE_A:
            sv_setVoiceConf.languageCode = "en-US";
            sv_setVoiceConf.name = "en-US-Wavenet-C";
            sv_setVoiceConf.ssmlGender = "FEMALE";
            break;
        // Define the English Female B voice.
        case Voice.EN_FEMALE_B:
            sv_setVoiceConf.languageCode = "en-US";
            sv_setVoiceConf.name = "en-US-Wavenet-E";
            sv_setVoiceConf.ssmlGender = "FEMALE";
            break;
        // Define the Japanese Female A voice.
        case Voice.JP_FEMALE_A:
            sv_setVoiceConf.languageCode = "ja-JP";
            sv_setVoiceConf.name = "ja-JP-Wavenet-A";
            sv_setVoiceConf.ssmlGender = "FEMALE";
            break;
        // Define the Japanese Female B voice.
        case Voice.JP_FEMALE_B:
            sv_setVoiceConf.languageCode = "ja-JP";
            sv_setVoiceConf.name = "ja-JP-Wavenet-B";
            sv_setVoiceConf.ssmlGender = "FEMALE";
            break;
        // Define the Chinese Female A voice.
        case Voice.CN_FEMALE_A:
            sv_setVoiceConf.languageCode = "cmn-CN";
            sv_setVoiceConf.name = "cmn-CN-Wavenet-A";
            sv_setVoiceConf.ssmlGender = "FEMALE";
            break;
        // Define the Chinese Female B voice.
        case Voice.CN_FEMALE_B:
            sv_setVoiceConf.languageCode = "cmn-CN";
            sv_setVoiceConf.name = "cmn-CN-Wavenet-D";
            sv_setVoiceConf.ssmlGender = "FEMALE";
            break;
        // Define the Korean Male A voice.
        case Voice.KR_MALE_A:
            sv_setVoiceConf.languageCode = "ko-KR";
            sv_setVoiceConf.name = "ko-KR-Wavenet-C";
            sv_setVoiceConf.ssmlGender = "MALE";
            break;
        // Define the Korean Male B voice.
        case Voice.KR_MALE_B:
            sv_setVoiceConf.languageCode = "ko-KR";
            sv_setVoiceConf.name = "ko-KR-Wavenet-D";
            sv_setVoiceConf.ssmlGender = "MALE";
            break;
        // Define the English Male A voice.
        case Voice.EN_MALE_A:
            sv_setVoiceConf.languageCode = "en-US";
            sv_setVoiceConf.name = "en-US-Wavenet-A";
            sv_setVoiceConf.ssmlGender = "MALE";
            break;
        // Define the English Male B voice.
            case Voice.EN_MALE_B:
                sv_setVoiceConf.languageCode = "en-US";
                sv_setVoiceConf.name = "en-US-Wavenet-B";
                sv_setVoiceConf.ssmlGender = "MALE";
                break;   
// Defines the Japanese male A voice.
            case Voice.JP_MALE_A:
                sv_setVoiceConf.languageCode = "ja-JP";
                sv_setVoiceConf.name = "ja-JP-Wavenet-C";
                sv_setVoiceConf.ssmlGender = "MALE";
                break;
            // Defines the Japanese male B voice.
            case Voice.JP_MALE_B:
                sv_setVoiceConf.languageCode = "ja-JP";
                sv_setVoiceConf.name = "ja-JP-Wavenet-D";
                sv_setVoiceConf.ssmlGender = "MALE";
                break;
            // Define the Chinese male A voice.
            case Voice.CN_MALE_A:
                sv_setVoiceConf.languageCode = "cmn-CN";
                sv_setVoiceConf.name = "cmn-CN-Wavenet-B";
                sv_setVoiceConf.ssmlGender = "MALE";
                break;
            // Define the Chinese male B voice.
            case Voice.CN_MALE_B:
                sv_setVoiceConf.languageCode = "cmn-CN";
                sv_setVoiceConf.name = "cmn-CN-Wavenet-C";
                sv_setVoiceConf.ssmlGender = "MALE";
                break;
        }
        mstts_SetTtsApi.voice = sv_setVoiceConf;
    }
}
