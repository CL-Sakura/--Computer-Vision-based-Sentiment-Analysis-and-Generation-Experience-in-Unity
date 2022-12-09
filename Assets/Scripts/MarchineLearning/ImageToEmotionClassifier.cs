using UnityEngine;
using OpenCVForUnity.CoreModule;
using Unity.Barracuda;
using System.Linq;
using System;
using OpenCVForUnity.ImgprocModule;
using Rect = UnityEngine.Rect;


public class ImageToEmotionClassifier : MonoBehaviour
{
    
    
    string[] LabelMap = {
        "敬畏",
        "娱乐",
        "满足",
        "兴奋",
        "愤怒",
        "厌恶",
        "恐惧",
        "悲伤",
        "其他"
    };

    public int LabelIndex;
    public string result;
    const int IMAGE_SIZE = 256;

    private Texture2D texture;
    
    [Header("Model")] [SerializeField] private NNModel model;
    [SerializeField] private RenderTexture renderTexture;
    

    [Serializable]
    public struct Prediction
    {
        public int predictValue;
        public float[] predicted;

        public void SetPrediction(Tensor tensor)
        {
            predicted = tensor.AsFloats();
            predictValue = Array.IndexOf(predicted, predicted.Max());
            //Debug.Log($"Predicted {predictValue}");

        }

        public void SetPrediction(float[] score)
        {
            predicted = score;
            predictValue = Array.IndexOf(predicted, predicted.Max());
        }
        
    }
    
    
    public Prediction prediction;

    private Model _runtimeModel;
    private IWorker _engine;
    private ReferenceComputeOps m_Ops;

    


    /// <summary>
    /// 执行模型
    /// </summary>
    public void ExecuteModel()
    {
        
        _runtimeModel = ModelLoader.Load(model);
        _engine = WorkerFactory.CreateWorker(_runtimeModel, WorkerFactory.Device.GPU);
        prediction = new Prediction();
        Texture2D texture2 = new Texture2D(IMAGE_SIZE, IMAGE_SIZE);

        int text_rows = texture.height;
        int text_cols = texture.width;
        var channelCount = 3;

        Mat dstImge = new Mat(IMAGE_SIZE, IMAGE_SIZE, CvType.CV_32FC3);
        Mat OutputImage_chw = new Mat(IMAGE_SIZE, IMAGE_SIZE, CvType.CV_32FC3);
        Mat Rgb_image = new Mat();
        Mat OutputImage = new Mat(IMAGE_SIZE, IMAGE_SIZE, CvType.CV_32FC3);

        Mat image = new Mat(text_rows, text_cols, CvType.CV_8UC3);
        OpenCVForUnity.UnityUtils.Utils.texture2DToMat(texture, image);

        Imgproc.cvtColor(image, Rgb_image, Imgproc.COLOR_BGR2RGB);

        Imgproc.resize(Rgb_image, dstImge, dstImge.size(), IMAGE_SIZE, IMAGE_SIZE, Imgproc.INTER_LANCZOS4);

        Scalar mean = new Scalar(124.96, 115.97, 106.13);
        OutputImage_chw = OpenCVForUnity.DnnModule.Dnn.blobFromImage(dstImge, 1.0, dstImge.size(), mean);

        OutputImage.copyTo(OutputImage_chw);

        for (int i = 0; i < OutputImage_chw.height(); i++)
        {
            for (int j = 0; j < OutputImage_chw.width(); j++)
            {
                double[] color = new double[3];
                color[0] = ((OutputImage_chw.get(i, j)[0] * 1.0f / 255.0f) / 0.229);
                color[1] = ((OutputImage_chw.get(i, j)[1] * 1.0f / 255.0f) / 0.224);
                color[2] = ((OutputImage_chw.get(i, j)[2] * 1.0f / 255.0f) / 0.225);
                OutputImage.put(i, j, color);
            }
        }

        OutputImage.convertTo(OutputImage, CvType.CV_8UC3);
        OpenCVForUnity.UnityUtils.Utils.matToTexture2D(OutputImage, texture2);

        var inputX = new Tensor(texture2, channelCount);

        Tensor outputY = _engine.Execute(inputX).PeekOutput();
        var scores = Enumerable.Range(0, 9).Select(i => outputY[i]).SoftMax().ToArray();

/*
        for (int i = 0; i < 9; i++)
            print("This is output:" + scores[i]);            
*/

        var AdjustScores = scores.Take(8).ToArray();
        prediction.SetPrediction(AdjustScores);
        
        LabelIndex = Array.IndexOf(AdjustScores, AdjustScores.Max());

        result = LabelMap[LabelIndex];       
        Debug.Log($"Result: {LabelMap[LabelIndex]}");
        
        inputX.Dispose();
        outputY.Dispose();
        
    }


    public static Mat processdata(Mat m)
    {
        double[] mean_rgb = new double[3] { 0.485, 0.456, 0.406 };
        double[] std_rgb = new double[3] { 0.229, 0.224, 0.225 };
        Mat normalize_rgb = new Mat(IMAGE_SIZE, IMAGE_SIZE, CvType.CV_32FC3);
        Mat normalize = new Mat(IMAGE_SIZE, IMAGE_SIZE, CvType.CV_8UC3);
        Imgproc.cvtColor(normalize, normalize_rgb, Imgproc.COLOR_BGR2RGB);
        normalize = OpenCVForUnity.DnnModule.Dnn.blobFromImage(normalize_rgb);



        for (int i = 0; i < m.height(); i++)
        {
            for (int j = 0; j < m.width(); j++)
            {
                double[] color = new double[3];
                //单独获取指定通道像素

                //color[0] = m.get(i, j)[0]; //R
                //color[1] = m.get(i, j)[1]; //G
                //color[2] = m.get(i, j)[2]; //B

                //color[0] = (byte)((m.get(i, j)[0] * 1.0f / 255.0f - 0.485 * 1.0f) / 0.229);
                //color[1] = (byte)((m.get(i, j)[1] * 1.0f / 255.0f - 0.456 * 1.0f) / 0.224);
                //color[2] = (byte)((m.get(i, j)[2] * 1.0f / 255.0f - 0.406 * 1.0f) / 0.225);
                color[0] = ((m.get(i, j)[0] * 1.0f / 255.0f) / 0.229);
                color[1] = ((m.get(i, j)[1] * 1.0f / 255.0f) / 0.224);
                color[2] = ((m.get(i, j)[2] * 1.0f / 255.0f) / 0.225);

                normalize.put(i, j, color);
            }
        }

        return normalize;
    }


    private void OnDestroy()
    {
        _engine?.Dispose();
    }

    
    private void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetResult();
        }
        */
    }
    
    
    Texture2D toTexture2D(RenderTexture rTex)
    {
        Texture2D tex = new Texture2D(IMAGE_SIZE, IMAGE_SIZE, TextureFormat.ARGB32, false);
        // ReadPixels looks at the active RenderTexture.
        RenderTexture.active = rTex;
        tex.ReadPixels(new Rect(0, 0, rTex.width, rTex.height), 0, 0);
        tex.Apply();
        return tex;
    }


    public void GetResult()
    {
        texture = toTexture2D(renderTexture);
        Rect rect = new Rect(0, 0, texture.width, texture.height);
        byte[] byteArray = texture.EncodeToPNG();
        System.IO.File.WriteAllBytes("Assets/Materials/MarchineLearning" + "/CameraScreenShot.png", byteArray);
        Debug.Log("Save CameraScreenShot.png");
            
        ExecuteModel();
    }
    
    
    
    
    
    
}



