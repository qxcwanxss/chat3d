using System.Runtime.CompilerServices;
using System.Globalization;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ChangeSkin : MonoBehaviour {
	public GameObject model1;
    public GameObject model2;

	private string  mModelType;
	private Material mat;//要创建的material

	//设置模型类型
	public void setModelType(string  modelType){
		mModelType = modelType;
	}

	//设置模型皮肤
	public void setModelSkin(string path){
		if(path == null || path.Length == 0){
			Debug.Log("setModelSkin: path is null");
			return;
		}
		Debug.Log("setModelSkin: path ="+path);
		string skinFilePath = "";
		//获得路径：对应android的该应用的sd卡目录
		string persistentDataPath = Application.persistentDataPath;
		//组织路径
		skinFilePath = persistentDataPath + "/" +path;
		Debug.Log("setModelSkin: skinFilePath ="+skinFilePath);
		//读取皮肤文件图片，并生成材质
		readSkinFile(skinFilePath);
		//设置模型材质
		setMaterials();
	}

	//读取皮肤文件图片，并生成材质	
	private void readSkinFile(string skinFilePath){
		Debug.Log("setModelSkin: readSkinFile start... "+skinFilePath);
		// path =======  "/storage/emulated/0/ProjectName/xxx/xxx.jpg"
        FileStream fileStream = new FileStream(skinFilePath, FileMode.Open, FileAccess.Read);
		//指定读写位置
        fileStream.Seek(0, SeekOrigin.Begin);
        //创建文件长度缓冲区
        byte[] bytes = new byte[fileStream.Length];
        //读取文件
        fileStream.Read(bytes, 0, (int)fileStream.Length);
        //释放文件读取流
        fileStream.Close();
        fileStream.Dispose();
        fileStream = null;
 
        //创建Texture
        int width = 2048;
        int height = 2048;
        Texture2D texture = new Texture2D(width, height);
        texture.LoadImage(bytes);

		//创建mat
        mat = new Material (Shader.Find ("Standard"));
		//mat的texture
        mat.mainTexture = texture;
		Debug.Log("setModelSkin: readSkinFile success... "+skinFilePath);
	}

	//设置模型材质
	private void setMaterials(){
		if(mModelType == null){
			Debug.Log("setMaterials: mModelType is null");		
			return;
		}
		if(mat == null){
			Debug.Log("setMaterials: mat is null");
			return;
		}
		//查找子物体的所有Renderer组件
		Renderer[] renderers = null;
		//设置模型可见性，并获得Renderers
		model1.SetActive(false);
        model2.SetActive(false);
        if (mModelType.Equals("1"))
        {
            model1.SetActive(true);
			renderers =  model1.gameObject.GetComponentsInChildren<Renderer>();
        }
        else if (mModelType.Equals("2"))
        {
            model2.SetActive(true);
			renderers =  model2.gameObject.GetComponentsInChildren<Renderer>();
        }
		//判断Renderers
		if(renderers == null){
			Debug.Log("setMaterials: Renderer[] is null");
			return;
		}
        //设置material
		foreach(Renderer renderer in renderers){
			renderer.material = mat;
		}
		Debug.Log("setMaterials: success");
	}
}
