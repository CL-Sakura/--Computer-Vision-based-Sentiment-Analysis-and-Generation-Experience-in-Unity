# 绘意-Computer Vision-based Sentiment Analysis and Generation Experience in Unity

## Description
本项目是基于URP渲染管线开发的VR场景

## Preview


**主要场景：**
![image](https://user-images.githubusercontent.com/62274988/207063299-34145f7a-c645-46ac-ae5a-702b2fd414ce.png)

## **Asset**

| Asset Type | Explanation                                                  |
| ---------- | ------------------------------------------------------------ |
| Fonts      | This folder contains the fonts used in the project.   此文件夹包含项目中使用的字体。 |
| Materials  | These assets contain the materials used in the development process.这些资产包含了开发过程中使用的材质。 |
| MLModels   | The ONNX model used for machine learning.机器学习所用到的ONNX模型。 |
| Prefabs    | These are reusable GameObjects with prebuilt Components.Add them to a scene to build.这些是预制件游戏对象，可以直接将它们添加到要构建的场景中。 |
| Scripts    | All user-developed code for gameplay appears here. 所有整理后的项目代码都在这里。 |
| Settings   | These assets store render pipeline settings,such as UniversalRender Pipeline (URP).这些资产存储渲染管道设置：UniversalRender管道(URP)。 |
| Shaders    | These programs run on the GPU as part of thegraphics pipeline. 这些Shader作为图形管道的一部分在GPU上运行。 |
| Scenes     | Runnable Unity scenarios that store test cases generated during development and final integration scenarios. 可运行的Unity场景，存储开发中产生的测试案例以及最后的整合场景。 |
| Textures   | lmage files can consist of texture files for materials andsurfacing, UI overlay elements for user interface, andlightmaps to store lighting information.图像文件:由材质和表面处理的纹理文件、用户界面的UI覆盖元素以及用于存储照明信息的光图组成。 |
| ThirdParty | Assets from external sources, development plug-ins, etc. 来自外部的资产、开发包等。 |



## Getting Started

### Environment:

安装Unity 2021.3 最新版本，启动时如有报错请忽略


### Scene:

![image](https://user-images.githubusercontent.com/62274988/207064824-90c271c0-abbb-4c2f-829c-3f6406f7b8bf.png)

> **其中，Final文件夹包含最终呈现场景，其他文件夹包含开发中的测试场景。**



- InteractionWithCameraSwitcher：测试交互以及相机切换场景
- MachineLearning：测试机器学习场景
- MediaPlayer：测试媒体播放器场景
- PaintingEffect：测试绘画系统场景
- Room：房间布置场景
- WebRequest：测试WebServe以及API调用场景




## Script:


![image](https://user-images.githubusercontent.com/62274988/207063821-775ee591-a337-48c3-87ab-ab6e726cfd71.png)


- InteractionWithCameraSwitcher: UI交互以及相机切换相关代码
- MarchineLearning: 机器学习相关代码
- MediaPlayer: 媒体播放器相关代码
- Paintable: 绘画系统相关代码
- Utils: 开发工具代码
- WebRequest: Web Service以及API调用相关代码





## Shading

### Skybox:
**AssetLocation:**
Assets\Scenes\Upload2PICO\HDRI

![image](https://user-images.githubusercontent.com/62274988/191507723-784ba39c-31d5-46c0-a30a-3ed9f2475cf1.png)

### Lighting:
**LightingSetting:**

![image](https://user-images.githubusercontent.com/62274988/191510506-f2ab09e9-e432-4d55-a83b-99739b0a69a8.png)
![image](https://user-images.githubusercontent.com/62274988/191507464-56c89d34-2528-46eb-a14d-ae14bf7f0c6c.png)


### PostProcess:
**PostProcessetting:**

![image](https://user-images.githubusercontent.com/62274988/191510612-691558a4-68d4-4c80-94a8-4ebd7b575c4a.png)









## Build
本项目仍使用Windows平台开发中，烧录到VR设备请切换成安卓平台。

### BuildSetting:

![image](https://user-images.githubusercontent.com/62274988/191506994-923b844c-afcb-4e06-b338-e54ce4a59896.png)
![image](https://user-images.githubusercontent.com/62274988/191507181-ad5bc943-faf8-4b0d-9772-3cd84111f1d0.png)
![image](https://user-images.githubusercontent.com/62274988/191507249-c110cccf-7fce-46b9-a38d-f5fafcaa169e.png)
![image](https://user-images.githubusercontent.com/62274988/191507289-b7d7e840-6e38-4e85-a648-82fc40d5f561.png)

















