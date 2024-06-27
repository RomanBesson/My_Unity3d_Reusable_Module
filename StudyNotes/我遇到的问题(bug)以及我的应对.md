[toc]



# Git

## 1.明明连接成功了，为什么显示仓库不存在？

> **报错信息**：\342\200\234git@github.com: Permission denied (publickey). fatal: Could not read from remote repository. Please make sure you have the correct access rights and the repository exists.

看看你引号大小写对不对。`" "`还是`“ ”`。

# UI

## 1.从Resources加载图片：路径没错却加载为空？

```csharp
private Image item_Image;       //物品图标.
item_Image.sprite = Resources.Load<Sprite>("Demo/SignPanel/TexTures/item/" + itemName);
```

一定要查找Sprite，赋值给sprite属性，别弄错了。否则会出现查找为空。

还有别忘了写末尾的`/`;

## 2.滚动页面想让他只在纵向或者横向滚动怎么办？

![1716116558312](../Img/1716116558312.png)

勾下这俩。

## 3.滚动页面的元素是从中间向两边生成怎么办？

调整布局组件设置，或者把元素的锚点调整到对应位置。

## 4.如何让ui物体不受射线检测

添加CanvasGroup 组件，控制 `blocksRaycasts` 属性

或者代码控制

```csharp
m_CanvasGroup.blocksRaycasts = false 
```

## 5.如何让物体上的贴图和某些特效贴图融合（背景贴图和弹痕贴图融合）

1. 需要对导入到项目中的模型贴图，弹痕贴图进行属性设置。
   - ①勾选 Read/Write Enabled 属性；
   - ②Format 属性设置成 RGBA 32 bit。
2. 将模型身上的 BoxCollider 组件移除掉，添加 MeshCollider 组件用于碰撞检测。（因为物理射线hit只能获取MeshCollider 上的点。

然后融合方只需要和它射线检测时，把射线对象传过去就可以。（m_BulletMark：素材贴图       m_MainTexture：主贴图）

> 注意：
>
> - 有时候需要设置下射线检测的层，避免获取的uv不正确
> - 同时要处理预制体bug（都使用同一张贴图的话，枪痕会一起生成，所以使用前要复制一份原有贴图，然后去改复制的那份）

详细代码见`ExampleScripts`下的`UI_5`文件夹。

## 6.Screen position out of view frustum (screen pos 0.000000, 0.000000, 2210299.750000) (Camera rect 0 0 256 256)

这个错误会在编译时一直显示，可能是版本错误，常见于3D场景切换到2D场景时。解决办法就是暂时关闭有问题的场景，调整完UI，切换3D再切换回来。

# 网络相关

## 1.如何看自己电脑的ip地址

查看本机 IP 地址

①Win + R 打开运行界面，输入 cmd，进入命令行模式；

②输入 ipconfig 命令，查看本机 ip 相关信息；

③找到“无线局域网适配器 WLAN:”，将该组信息内的“IPv4 地址”复制。

[鼠标光标框选住要复制的信息，然后按快捷键 Ctrl + C 即可复制]

# 组件方面

## 1.如何控制摄像机视野，实现模拟开镜？

FOV：Field of View，是 Camera 组件上的一个控制属性；

用于控制摄像机的视野，该属性默认值是 60。

改变 FOV 值的效果：

值越大看的区域越广，看到的物体会显得越远，越小；

值越小看的区域越窄，看到的物体会显得越近，越大。

常见用途：

枪械模拟开镜效果可以通过调整 FOV 属性来实现。	



## 2.如何使用多相机，让一个相机观察主角，其他相机观察别的？

### 调整可观察的物体

首先，让角色摄像机只能观察到角色模型，通过 Camera 组件上的 Culling

Mask（剔除遮挡）属性来设置。该属性设置了摄像机能看到那些层的物体。

该属性的列表里的值是是 Layer 层的名称。

①添加一个新的层；

②把角色模型设置到该层；

③设置角色摄像机只看该层。

然后，创建一个环境摄像机，该摄像机作为角色摄像机的子物体存在。

### 调整相机观察优先级

<1>Camera 组件的 Depth 属性表示摄像机的深度，值越大，该摄像机的画面越靠前。所以说角色摄像机的 Depth 值要大于环境摄像机的 Depth。

<2>在前面渲染的角色摄像机的 Clear Flags 属性需要更改为 Depth Only。

<3>分别调整角色，环境摄像机的 FOV 值，你会发现它们只会影响自己看的的层的模型物体。

## 3.动作切换后下个动作比较慢怎么办？（射击的动作感觉比较缓慢，没有力度）

选中过渡线->右侧属性 Settings->Transition Duration(过渡时间)。

> 注意，上述属性属于控制动画是否平稳过渡，而Has Exit Time用于条件满足后控制是否立马切换。

## 4.游戏物体在场景视图显示，在游戏视图不显示，这是为什么？

查看物体是否在摄像机未遮罩的层（layer），可能你忘记设置它的layer了，它被设置在了无法被摄像机渲染的层上。

## 5.设置刚体的游戏物体，使用代码没法通过transform组件改变他的位置，怎么办？

添加了刚体的游戏物体，直接通过 Transform 修改位置，很多时候是无法修改的，这个时候可以先将刚体身上的 Is Kinematic 属性勾选，然后再修改位置。

最后将 Is Kinematic 属性还原。

**Is Kinematic：勾选之后表示当前刚体不在受力的影响。**

## 6.空物体放到枪械模型下方，模型运动，空物体并不会跟随动作改变位置，怎么办？

这个时候，应该放到对应的模型骨骼结构上。

## 7.装有刚体的物体速度太快，其他碰撞体检测不到，怎么办？

把 刚体组件的**Collision Detection**属性改为  **Continuous Dynamic** 。

> Collision Detection（碰撞检测）
>
> 碰撞检测是物理引擎用来确定两个或多个对象是否相交的过程。在Unity中，刚体组件的碰撞检测属性可以设置为以下几种模式：
>
> **Discrete（离散）**：
>
> - 这是默认的碰撞检测模式。
> - 它适用于大多数情况，特别是当游戏对象的移动速度不是非常快时。
> - 在这种模式下，物理引擎会在每一帧结束时检测碰撞。
>
> **Continuous（连续）**：
>
> - 这种模式适用于快速移动的对象，如子弹或高速移动的车辆。
> - 它会尝试在每一帧中进行多次碰撞检测，以更精确地模拟碰撞。
> - 连续碰撞检测可以减少快速移动对象穿过其他对象的情况，但会增加计算量。
>
> **Continuous Dynamic（连续动态）**：
>
> - 这种模式是连续碰撞检测的变种，专为动态对象设计。
> - 它会为动态对象（即受力影响的对象）启用连续碰撞检测，而静态对象则使用离散碰撞检测。
> - 这种模式可以减少动态对象穿过静态对象的情况，同时保持较低的计算成本。
>
> **Continuous Speculative（连续投机性）**：
>
> - 这种模式是Unity 2018.3及以后版本中引入的。
> - 它使用一种投机性方法来预测和处理碰撞，可以更有效地处理快速移动的对象。
> - 这种模式旨在提供连续碰撞检测的性能优势，同时减少连续碰撞检测可能带来的问题。

## 8.使用射线检测碰撞在对应物体身上生成特效时，特效在某些角度显示不清楚怎么办？

使用hit.nolmal()（法线）作为生成特效的旋转角度。

## 9.没有报错，却没实现想要的功能

1. 检查函数是否调用
2. 脚本是否挂载
3. 资源的路径是否写对，是不是没加载进来
4. 逻辑错误

## 10.使用Resources反复存储读取json时，出现数据不同步的情况

使用Resources反复存储读取json时，会有缓存出现，引起的数据不同步情况，这时候用io读写就好了。

## 11.使用io读写resources里的文件，打包后找不到路径怎么办？

### gpt的处理方式

在Unity中，使用 `Resources` 文件夹来存储数据（如JSON文件）确实可以方便地在开发过程中访问这些资源，但确实存在一些潜在的问题，包括数据不同步的情况。这是因为 `Resources` 文件夹中的资源在构建后会被Unity打包到最终的发布包中，而不会反映在 `Resources` 文件夹中的任何更改。

如果你在开发过程中修改了 `Resources` 文件夹中的JSON文件，这些更改不会自动反映到构建后的应用中。因此，如果你在开发过程中频繁修改这些数据文件，可能会导致数据不同步的问题。

为了解决这个问题，你可以采取以下几种策略：

1. **使用 `Resources.UnloadUnusedAssets`**：
    在加载新的数据之前，调用 `Resources.UnloadUnusedAssets` 方法可以卸载不再使用的资源，包括之前加载的JSON数据。这样可以确保下次加载时，Unity会从 `Resources` 文件夹中读取最新的数据。

    ```csharp
    Resources.UnloadUnusedAssets();
    ```

2. **使用 `Resources.Load` 时指定资源的版本**：
    如果你担心数据不同步，可以在加载资源时指定资源的版本号或时间戳，这样可以确保加载的是最新的资源。

    ```csharp
    TextAsset jsonData = Resources.Load<TextAsset>("jsonData/myDataFile", typeof(TextAsset));
    ```

3. **将数据文件放在 `StreamingAssets` 文件夹**：
    将数据文件放在 `StreamingAssets` 文件夹中，然后在构建后通过 `Application.streamingAssetsPath` 访问这些文件。这样，你可以直接修改这些文件，并且在构建后这些更改会被包含在最终的发布包中。

    ```csharp
    string filePath = Path.Combine(Application.streamingAssetsPath, "myDataFile.json");
    string jsonData = File.ReadAllText(filePath);
    ```

4. **使用 `AssetBundle`**：
    如果你希望更灵活地管理资源，可以考虑使用 `AssetBundle`。`AssetBundle` 允许你将资源打包成独立的包，然后在运行时动态加载这些包。这样，你可以随时更新 `AssetBundle` 而不影响主应用。

    ```csharp
    AssetBundle myAssetBundle = AssetBundle.LoadFromFile("path/to/your/assetbundle");
    TextAsset jsonData = myAssetBundle.LoadAsset<TextAsset>("myDataFile");
    ```

5. **使用数据库或文件系统**：
    对于需要频繁更新的数据，使用数据库或文件系统来存储数据可能是一个更好的选择。这样，你可以直接在运行时更新数据，而不需要重新构建应用。

选择哪种策略取决于你的具体需求和项目情况。如果你的数据更新频率不高，使用 `Resources` 文件夹可能足够。如果数据更新频繁，考虑使用 `StreamingAssets` 文件夹或 `AssetBundle` 可能更合适。对于需要频繁更新的数据，使用数据库或文件系统可能是最佳选择。

### 解决方法

我们采用第二种方法，把文件存储到 StreamingAssets文件夹里（可以读写）。

1. 在 Assets下创建 StreamingAssets文件夹。
2. 路径使用  `Path.Combine(Application.streamingAssetsPath, fileName + ".txt");`

问题解决。

### DLC：关于 persistentDataPath（把数据存储到AppData文件夹下）

`Application.persistentDataPath` 是Unity提供的一个属性，它返回一个字符串，表示应用程序的持久化数据目录的路径。这个目录是应用程序用来存储用户数据、游戏进度等持久化信息的地方。在不同的平台上，这个目录的路径是不同的，例如：

- 在iOS上，它通常位于 `Documents` 文件夹。
- 在Android上，它可能位于 `Android/data/你的应用包名/files` 目录。
- 在Windows上，它可能位于 `C:\Users\用户名\AppData\LocalLow\你的应用包名` 目录。

关于 `Application.persistentDataPath` 打包时是否会被Unity压缩，答案是：不会。`Application.persistentDataPath` 指向的目录是应用程序的持久化数据目录，这个目录是用于存储应用程序运行时生成的数据，如用户设置、游戏进度等。这些数据需要在应用程序运行时被访问和修改，因此Unity不会对这个目录进行压缩。

然而，Unity在构建应用程序时会对 `Resources` 文件夹中的资源进行压缩。`Resources` 文件夹中的资源在构建时会被Unity打包到最终的应用程序包中，以减少应用程序的大小。这些资源在运行时可以通过 `Resources.Load` 方法加载。

总结来说，`Application.persistentDataPath` 指向的目录是用于存储应用程序的持久化数据，这些数据不会被Unity压缩。而 `Resources` 文件夹中的资源在构建时会被Unity压缩，以减少应用程序的大小。

# 动画

## 1.空物体放到人物模型下方，模型运动，空物体并不会跟随动作改变位置，怎么办？

这个时候，应该放到对应的模型骨骼结构上。

## 2.使用布娃娃系统模拟死亡效果，效果太夸张，怎么办？

刚体上加点重量。

# 导航

## 1.在导航的过程中，使用transform.lookAt()转向不够平滑，怎么优化？

​	把导航组件的 **Angular Speed** 属性（角速度）调到 360，就会平滑了。

## 2.导航物体默认会忽略物理系统，穿过碰撞体，怎么办？

给他加上 `Nav Mesh Obstacle`组件。

# 优化

## 1.当从重置场景跳转回游戏场景的时候场景变暗，怎么办？

**把自动烘焙改为一般烘焙**

当从重置场景跳转回游戏场景的时候，游戏场景内的灯光可能并没有渲染好，大部分区域是黑色的，我们需要在测试效果的时候，对游戏场景进行预先烘焙。

操作步骤：

①Window --> Lighting --> Settings 打开灯光烘焙面板；

②取消最下方的自动烘焙复选框，然后手动点击右侧的烘焙按钮。

# Lua

## 1.Scite 配置字体大小

①Options-->Open Global Options File，打开全局配置文件；

②第 10 行代码，**ont.base=font:xxxxxx,size:xx** 修改成需要的字体字号。

**注意事项：**

要修改 SciTE 的配置文件时，在打开 SciTE 的时候需要右键-->以管理员身份运行，如果不是管理员身份运行，你修改
