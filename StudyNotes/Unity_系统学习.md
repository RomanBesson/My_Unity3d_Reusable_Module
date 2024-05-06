[toc]

# 1.基础组件的认识

## 1.0.组件继承关系图

![1.继承关系](../Img/1.%E7%BB%A7%E6%89%BF%E5%85%B3%E7%B3%BB.png)



## 1.1.项目工程文件结构，各个文件夹都是做什么的？

- **Assets** [资产]：存放项目开发过程中所用到的资源（模型, UI, 声音, 特效...）；

  (在 Unity 项目开发中，Assets 文件夹是需要程序员手动管理的文件夹。)

- **Library [库]**：存放项目核心库，扩展库，以及动态生成的缓存文件；

- **Logs [日志]**：存放项目日志文件；

- **Packages [包]**：存放当前项目扩展库的引用目录；

- **ProjectSettings [项目设置]**：存放当前项目的设置文件（输入,导航,编辑器...）；

- Temp [临时]：存放当前项目的临时资源；

- **UserSettings [用户设置]**：存放当前项目用户相关的自定义设置。



## 1.2.物体变化组件

### 1.2.3.三维向量表示方向

1. 在 Unity 场景视图中，主要有两个坐标系：**世界坐标系**，**物体自身坐标系**；

2. 这两个坐标系都有六个方向：前-后-左-右-上-下；

3. 在 `Vector3` 结构体内，有**六个静态只读属性，用于表示世界坐标系六个方向**，这六个属性分别是：`forward`，`back`，`right`，`left`，`up`，`down`；

4. 在 Transform 类中，有**三个对象可读可写属性，用于表示三个“箭头方向”**，这三个属性分别是：`forward`，`right`，`up`。

5. `position` 是读写属性，直接 new 一个新的 Vector3 数据赋值；

6. Vector3 有三个公开的字段：x，y，z，我们可以分别获取使用；

   

```c#
    //查找持有对象引用.
    m_Transform = gameObject.GetComponent<Transform>();

    //打印输出位置信息.
    Debug.Log("Cube的位置:" + m_Transform.position);

    //修改位置信息.
    m_Transform.position = new Vector3(5, 5, 5);

    //单独打印x轴向位置数据.
    Debug.Log("x:" + m_Transform.position.x);

    //Vector3 三个字段不可以单独赋值，你的游戏物体只需要在单个轴向发生位置改变，你也需要构造一个 Vector3 数据进行整体赋值
    m_Transform.position.x = 10; //不能这样用.

    m_Transform.position = new Vector3(10, m_Transform.position.y, m_Transform.position.z); //应该这样用.

    //向前方移动.
    m_Transform.Translate(Vector3.forward, Space.Self);
```



### 1.2.4.移动物体位置

```c#
[void] m_Transform.Translate(Vector3, Space)
```

对象方法 `Translate( )`可以控制游戏物体往指定的方向移动。	

> 参数说明

- `Vector3` 参数指的是移动方向；

- `Space `参数是一个枚举类型，`World`[世界坐标系空间]，`Self`[自身坐标系空间]。

  

### 附录：使用变换组件实现物体WASD移动

```c#
    //向前.
    if (Input.GetKey(KeyCode.W))
    {
    m_Transform.Translate(Vector3.forward * 0.02f, Space.Self);
    }

    //向后.
    if (Input.GetKey(KeyCode.S))
    {
    m_Transform.Translate(Vector3.back * 0.02f, Space.Self);
    }

    //向左.
    if (Input.GetKey(KeyCode.A))
    {
    m_Transform.Translate(Vector3.left * 0.02f, Space.Self);
    }

    //向右.
    if (Input.GetKey(KeyCode.D))
    {
    m_Transform.Translate(Vector3.right * 0.02f, Space.Self);
    }
```



## 1.3.游戏物体和组件的显示和禁用

### 1.3.1.界面上的操作

- 显示与隐藏游戏物体：选中某个游戏物体，Inspector 视图最上方，游戏物体名称的左边有一个复选框；
- 启用与禁用组件：选中某个游戏物体，Inspector 视图可以看到该游戏物体所有的组件，组件标题栏的前边有一个复选框；
- 组件禁用之后，该组件就处于无效状态； [关闭房间内的灯，灯就处于无效状态。]
- 游戏物体隐藏后，该游戏物体同样处于无效状态。

### 1.3.2.代码上的操作

```c#
[void] gameObject.SetActive(bool)
```

- 设置游戏物体是显示还是隐藏，true 是显示，false 是隐藏；
- 所有的游戏物体都可以进行 SetActive（）操作。

```c#
[bool] 组件对象.enabled 
```

- //可读写属性

- 设置组件是启用还是禁用，true 是启用，false 是禁用；

- 大部分组件对象都可以进行 enabled 属性操作，但是一些核心组件除外。

  

## 1.4.网格组件

- **什么是 Mesh[网格]？**

网格就是三维模型的数据文件，美术人员三维建模，主要就是完成模型的网格制作；

三维模型由点，线，面组成，最终形成一个网格的形态。

- **Mesh Filter**

Mesh Filter [网格过滤器]组件：用于指定当前模型游戏物体的网格数据。

Mesh [网格]：持有网格数据文件的引用。

- **Mesh Renderer**

**Mesh Renderer** [网格渲染器]组件：用于完成当前模型游戏物体的网格渲染。

网格过滤器组件和网格渲染器组件需要配合使用，一个组件持有网格数据，另外一个组件负责网格数据的渲染。

**组件核心控制参数：**

①**Materials** [材质球引用]：往游戏物体上拖拽挂载的材质球资源，其实就是拖拽

赋值给了该属性。 [见图 1, 2]

②**Cast** **Shadows** [投射阴影]：On 开启阴影投射，Off 关闭阴影投射。

[该属性可以控制单个模型物体的阴影，Light 组件可以控制整个场景内的阴影。]

③**Receive Shadows** [接收阴影]：是否接收另外的游戏物体投射的阴影。

![2.资源关系图](../Img/2.%E8%B5%84%E6%BA%90%E5%85%B3%E7%B3%BB%E5%9B%BE.jpg)

## 1.5.Resources

### 1.5.1.基础介绍

Resources [资源]类：主要用途就是资源加载；

在项目工程中，需要手动创建名为“Resources”的文件夹，相关资源存放到该文件夹内，在代码中即可通过 Resources 类相关的 API 实现资源加载。

### 1.5.2.常用资源类型

- 预制体资源 [Prefab]：GameObject
- 材质球资源 [Material]：Matirial
- 音频剪辑资源 [AudioClip]：AudioClip
- 模型贴图资源 [Texture]：Texture2D

### 1.5.3.单个资源加载

```c#
[s][T] Resources.Load<T>(string)
```

- Load( )是 Resources 类的静态泛型方法, 返回值类型和填写的泛型一致；
- Load( )参数是字符串类型，填写资源在 Resources 文件夹中的路径；
  - |--资源在根目录，直接写文件名即可[名称不需要带后缀]，比如：“Cube”；
  - |--资源在子目录，写“完整路径”，比如：“Player/Cube”；
- 拼凑出资源在项目中的完整路径：Assets/Resources/ + Player/Cube

### 1.5.4.多个资源加载

```c#
[s][T[]] Resources.LoadAll<T>(string)
```

- LoadAll( )静态泛型方法, 返回值类型和填写的泛型一致，返回数组；
- Load( )方法是加载单一资源，参数是具体资源的“文件名路径”；
- LoadAll( )方法是加载多个资源，参数是具体资源的“文件夹路径”，将文件夹内的资源全部加载，返回一个数组格式，文件夹内的资源，保持类型一致

### 例子：资源的加载

```c#
   private GameObject m_GameObject;    //预制体.
    private Material m_Material;        //材质球.
    private AudioClip m_AudioClip;      //音频剪辑.
    private Texture2D m_Texture2D;      //模型贴图.

    private GameObject[] player;         //多个角色.


    void Start()
    {
        m_GameObject = Resources.Load<GameObject>("Player/Cube");
        m_Material = Resources.Load<Material>("ColorA");
        m_AudioClip = Resources.Load<AudioClip>("ddz");
        m_Texture2D = Resources.Load<Texture2D>("Line");

        Debug.Log(m_GameObject.name);
        Debug.Log(m_Material.name);
        Debug.Log(m_AudioClip.name);
        Debug.Log(m_Texture2D.name);

        player = Resources.LoadAll<GameObject>("Player");
        Debug.Log(player.Length);
        for (int i = 0; i < player.Length; i++)
        {
            Debug.Log(player[i].name);
        }

        

    }
```



## 1.6.音频组件

### 1.6.1.PlayClipAtPoint() 像特效一样播放一次的方法

```c#
[s][void]AudioSource.PlayClipAtPoint(AudioClip, Vector3)
```

> 参数说明：

- **PlayClipAtPoint( )**：在场景内指定的位置，播放音频剪辑，静态无返回值；
- **AudioClip** 参数：代码中加载持有的音频剪辑；
- **Vector3** 参数：场景中播放音频剪辑的位置； 
- PlayClipAtPoint( )方法，每执行一次，就会在场景内创建一个 AudioSource游戏物体，名称为：One shot audio [一次性音频]，当音频播放完毕之后，该游戏物体会自动销毁。

## 1.7.实例化物体和销毁游戏物体

### 1.7.1.前情提要

- 使用 Resources 类加载到内存中的资源，比如音频剪辑，材质球，模型贴图，在组件对象属性上，可以直接赋值使用；
- 预制体资源，相较而言比较特殊，因为预制体本身是游戏物体类型，在场景内, 游戏物体是“顶级”场景元素，无法通过赋值的方式来使用。

### 1.7.2.实例化游戏物体

**代码：**

```c#
[s][T]GameObject.Instantiate<T>(GameObject, Vector3, Quaternion)
```

**参数说明：**

- **Instantiate** [实例化]方法：使用预制体资源作为模板，在场景内指定的位置，生成一个游戏物体，额外还可以控制生成的游戏物体的旋转信息；
- **Vector3.zero**：只读属性，位置在世界原点，XYZ 都为零；
- **Quaternion.identity**：只读属性，表示无旋转，XYZ 都为零[欧拉角]。

### 1.7.3.销毁游戏物体

```c#
[s][void]GameObject.Destroy(Object)
[s][void]GameObject.Destroy(Object, float)
Destroy( )方法有两种重载形式，销毁游戏物体和定时销毁游戏物体。
```

销毁方法也可以销毁游戏物体上某个组件。

### 1.7.4.给游戏物体上添加组件

```c#
[T]gameObject.AddComponent<T>()
//AddComponent [添加组件]方法：泛型格式的对象方法，这里的泛型要写 Unity引擎内的组件类型，以及我们自己编写的脚本组件名称。
```

### 例子：实例化和销毁游戏物体以及游戏物体上的组件操作

```c#
public class Demo10 : MonoBehaviour
{
    private GameObject m_GameObject;    //预制体.
    private Material m_Material;        //材质球.
    private AudioClip m_AudioClip;      //音频剪辑.
    private Texture2D m_Texture2D;      //模型贴图.

    private GameObject[] player;         //多个角色.

    private GameObject cubeA;

    void Start()
    {
        m_GameObject = Resources.Load<GameObject>("Player/Cube");
        m_Material = Resources.Load<Material>("ColorA");
        m_AudioClip = Resources.Load<AudioClip>("ddz");
        m_Texture2D = Resources.Load<Texture2D>("Line");

        Debug.Log(m_GameObject.name);
        Debug.Log(m_Material.name);
        Debug.Log(m_AudioClip.name);
        Debug.Log(m_Texture2D.name);

        player = Resources.LoadAll<GameObject>("Player");
        Debug.Log(player.Length);
        for (int i = 0; i < player.Length; i++)
        {
            Debug.Log(player[i].name);
        }

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //实例化
            cubeA = GameObject.Instantiate<GameObject>(m_GameObject, Vector3.zero, Quaternion.identity);
            GameObject cubeB = GameObject.Instantiate<GameObject>(
                m_GameObject, 
                new Vector3(0, 0, 10), 
                Quaternion.Euler(new Vector3(0, 0, 90))
            );

            cubeA.name = "CubeA";
            cubeB.name = "CubeB";

            //将组件添加到游戏物体上
            AudioSource audioSource = cubeA.AddComponent<AudioSource>();
            audioSource.clip = m_AudioClip;
            audioSource.Play();
            //摧毁游戏物体的组件
            GameObject.Destroy(cubeA.GetComponent<MeshRenderer>());

        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            //摧毁游戏物体
            //GameObject.Destroy(cubeA, 3);
        }

    }

}

```

## 1.8.Unity的生命周期方法们

### 1.8.1.开始状态

- **Awake** [唤醒]：当对象被创建时，执行一次；
- **OnEnable** [启用时]：脚本组件被启用，执行一次；
- **Start** [开始]：项目运行之后，执行一次；

> 细节说明：

1. 在运行之后，场景内存在的游戏物体会首先被**实例化成对象**，然后执行这些对象脚本中的生命周期方法，执行到实例化游戏物体的代码，实例化成对象，**然后在执行这些对象脚本中的生命周期方法**；
2. **Awake**：脚本组件挂载到游戏物体上，并**没有启用，也会执行**；
3. **OnEnable**：当脚本组件处于启用状态时，执行一次，后续的生命周期依赖于该状态； [使用组件面板，以及代码，分别启用禁用脚本组件。]
4. **Start**：在 Awake 和 OnEnable 之后执行，正式的开始。

### 1.8.2.进行中状态

- **FixedUpdate** [固定更新]：固定时间更新，0.02 秒执行一次；
- **Update** [更新]：每帧执行一次，一秒钟大约 60 次；
- **LateUpdate** [延迟更新]：在 Update 之后执行，同样每帧执行一次；

> 细节说明：

1. **FixedUpdate**：物理组件控制的持续运动，比如：刚体运动；
2. **Update**：需要每帧都执行的代码，比如：按键检测代码；
3. **LateUpdate**：在 Update 之后执行，比如：摄像机跟随； 

### 1.8.3.结束状态

- **OnDisable** [禁用时]：脚本组件被禁用，执行一次；
- **OnDestroy** [销毁时]：脚本组件被销毁，执行一次；

> 细节说明：

1. **OnEnable** 和 **OnDisable** 分别对应脚本组件的启用状态，禁用状态；
2. 在代码中，当游戏物体/脚本组件，被销毁时，**先执行 OnDisable**，再执行OnDestroy，在引擎界面上退出项目运行状态，等同于销毁操作。

## 1.9.GameObject 查找 & Transform 查找

### 1.9.1.GameObject 

#### 1.全局名称查找

```c#
[GameOjbect] GameOjbect.Find(string)
//在场景中查找指定名称的游戏物体
```



#### 2.未激活游戏物体

> 场景内的游戏物体有两种状态，Find( )通过名称查找，也有两种结果：

1. **激活**[显示]状态：能查找到，返回游戏物体对象；
2. 未**激活**[隐藏]状态：查找不到，报错“空引用异常”。

> **注意**：在开发过程中，某些游戏物体需要默认隐藏，同时又需要查找持有它的对象引用。
>
> 这种情况，场景中的游戏物体需要默认保持显示状态，然后代码查找持有，再修改成隐藏状态，场景运行后，代码操作瞬间完成。

#### 3.查找的时候出现重名

1. 在场景中如果有两个游戏物体的名称完全一样，通过 Find()方法查找，**返回的是层级视图靠后的那一个**；
2. Find()方法通过名称查找到第一个游戏物体之后，并没有直接返回，而是继续向下遍历，找到了最后一个然后返回，这是因为 Find()方法的逻辑是“**递归遍历**”，它会将整个层级视图内的游戏物体全部遍历一遍。

#### 4.路径查找

1. Find()方法内的字符串参数，除了填写游戏物体的名称之外，还可以填写“路径”；

2. 路径可以是相对路径，也可以是绝对路径：

   - 相对路径：游戏物体路径的一部分，比如：Cube5/Cube6；

   - 绝对路径：从根游戏物体一直到具体物体，比如：Cube4/Cube5/Cube6；

3. 注意事项：

   - 路径中的最后一个名字，必须是你要查找的具体的游戏物体的名字；
   - 如果是相对路径，在路径的开头就不要写“/”，否则空引用异常；
   - “/”开头的路径，表示绝对路径，必须是从根游戏物体开始的路径。

#### 5.标签查找 （ 一次性查找多个对象）

```c#
[GameOjbect[]] GameOjbect.FindGameObjectsWithTag(string)
//在场景中查找被赋予了特定标签的游戏物体，查找结果以数组形式返回
```

### 1.9.2.Transform 查找

#### 1.查找子物体

```c#
[Transform] m_Transform.Find(string)
//Transform 组件对象方法 Find()，在子物体当中查找指定名称的游戏物体，返回该游戏物体的 Transform 组件对象。
```

1. 得到 Transform 组件对象，就相当得到了 gameObject 游戏物体对象，因为组件和游戏物体之间有从属关系，可以直接“**点出游戏物体**”；
2. Transform 组件对象方法 Find()可以直接以名称查找子物体，但是不能直接以名称查找**孙物体**(空引用异常)，如果需要查找多层嵌套的子物体，**需要写完整路径**；
3. Find()方法的“前身”是 **FindChild()方法**(被官方弃用)，两个方法的用途完全一样，如果你使用旧版本的 Unity 引擎，可能看到的就只有 FindChild()方法。

## 1.10.时间，数学运算 & 插值运算

### 1.10.1.Time 时间类

```c#
[float] Time.time //时间. 
```

静态只读属性，项目从开始运行到现在的总时长，以秒为单位；

```c#
[float] Time.deltaTime //增量时间. 
```

静态只读属性，当前游戏画面渲染完一帧，所需要的时长，以秒为单位；

```c#
[float] Time.timeScale //时间缩放. 
```

静态读写属性，控制虚拟游戏世界中的时间流速，可以用来实现游戏暂停；

- 1：时间正常； 

- 0：时间暂停； 

- 0.5：时间 0.5 倍慢放；

### 1.10.2.Mathf 数学类

Mathf“数学类”其实是一个结构体类型，提供了一些基础的数学运算 API, 比如：最大值，最小值，三角函数，角度，弧度...

#### 角度与弧度互相转换

**角度 [Degree]**：两条线段之间的夹角； [变换组件的旋转属性]

**弧度 [Radian]**：弧度也是一个角度单位，1 弧度≈57.3 度 1 度≈0.0174 弧度。

```c#
[float] Mathf.Deg2Rad //角度转弧度常量. 0.0174. 

[float] Mathf.Rad2Deg //弧度转角度常量. 57.295. 
```

在项目开发过程中，经常会遇到“角度”与“弧度”互相转换的情况；

- 50 度转弧度：50 * Mathf.Deg2Rad ≈ 0.872
- 0.75 弧度转角度：0.75 * Mathf.Rad2Deg ≈ 42.97

### 1.10.3.插值运算

确定两个参数 A 和 B，然后从 A 平滑过渡到 B的过程；

```c#
[s][float] Mathf.Lerp(float a, float b, float t)
```

**参数说明**：

- **a**：起始值，例如：0；

- **b**：目标值，例如：20；
- **t**：插值系数，表示 a 和 b 之间的比例，取值范围是 0 ~ 1 之间。
  - t=0，返回 a 参数的值，t=1，返回 b 参数的值；
  - t=0.5，返回 a 和 b 的中间值。

- **Lerp**（）插值方法，我们最终使用的是 a 值，b 值是相对固定的，在插值运算的过程中，a 值会逐渐递增[也可能是递减]“变成”b 值，插值运算宣告结束。

**注意：**

- Lerp()插值方法需要**放到 Update 语句块中执行**(一般来说，如果不放进去的话，就执行一次就失去了意义)。
- 将插值运算的结果**重新存储到 a 中**，再插值的时候就是在新的 a和原有的 b 之间继续插值，a 值才能实现递增。
- 在插值运算过程中，a 值会逐渐靠近 b 值，当两个值非常近的时候，依然在继续插值，每一次插值的累加步长非常小，但是插值运算不会停止；所以，到达一个**很接近的值的时候要停止插值运算**，之后进行赋值结束。
- **插值系数一般用一个很小的数值**，这样可以实现 a 值到 b 值之间的平滑过渡，在实际使用过程中，**插值系数经常使用“增量时间”：Time.deltaTime。**

### 1.10.4.插值运算的几个实际应用

#### 单轴向位移和旋转

```c#
public class CubeLerp : MonoBehaviour
{
    private float startPos = 0;
    private float endPos = 20;

    private float startRot = 0;
    private float endRot = 50;

    private float tPos = 0;
    private float tRot = 0;

    private Vector3 startVector3;
    private Vector3 endVector3;

    private Quaternion startQua;
    private Quaternion endQua;

    private Transform m_Transform;
    private Transform endCube;

    void Start()
    {
        m_Transform = gameObject.GetComponent<Transform>();
        endCube = GameObject.Find("EndCube").GetComponent<Transform>();

        startQua = m_Transform.rotation;
        endQua = endCube.rotation;
    }


    void Update()
    {
        //单向位移
        MoveLerp();
        //单向旋转
        RotationLerp();
    }


    private void MoveLerp()
    {
        if (startPos < 19.7f)
        {
            startPos = Mathf.Lerp(startPos, endPos, Time.deltaTime);
            m_Transform.position = new Vector3(0, 0, startPos);
        }

    }


    private void RotationLerp()
    {
        if (startRot < 49.5f)
        {
            startRot = Mathf.Lerp(startRot, endRot, Time.deltaTime);
            m_Transform.rotation = Quaternion.Euler(new Vector3(0, 0, startRot));
        }
    }



}
```

**上面演示的“单轴向位移”和“单轴向旋转”两个效果，存在两个共有的问题：**

-  插值运算前面快，后面慢； [插值系数固定，前面肯定快，后面肯定慢。]
- 无法精准的插值到结束值； [临界值的 if 判断语句，停止继续插值。]

 能不能让插值运算匀速插值，且“精准”的插值到结束值呢？？

**优化版：**

```c#
public class CubeLerp : MonoBehaviour
{
    private float startPos = 0;
    private float endPos = 20;

    private float startRot = 0;
    private float endRot = 50;

    private float tPos = 0;
    private float tRot = 0;

    private Vector3 startVector3;
    private Vector3 endVector3;

    private Quaternion startQua;
    private Quaternion endQua;

    private Transform m_Transform;
    private Transform endCube;

    void Start()
    {
        m_Transform = gameObject.GetComponent<Transform>();
        endCube = GameObject.Find("EndCube").GetComponent<Transform>();

        startQua = m_Transform.rotation;
        endQua = endCube.rotation;
    }


    void Update()
    {
        //单向位移
        MoveLerp();
        //单向旋转
        RotationLerp();
    }


    private void MoveLerp()
    {
       if(tPos < 1.0f)
        {
            tPos += 0.5f * Time.deltaTime;
            m_Transform.position = new Vector3(0, 0, Mathf.Lerp(startPos, endPos, tPos));

        }

    }


    private void RotationLerp()
    {
       if (tRot < 1.0f)
        {
            tRot += 0.5f * Time.deltaTime;
            m_Transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Lerp(startRot, endRot, tRot)));

        }
    }

}
```

1. 每次插值运算完毕，将插值结果存入到起始值中，第二次，在新的起始值和固定结束值之间继续插值，且重复上方操作，改进方案是：起始值和结束值都固定不变，我们改变插值系数；
2. 插值系数初始值为 0，在 Update 语句块中，每帧累加 Time.deltaTime,插值系数每帧都会“变大”，起始值和结束值是固定不变的，但是插值系数在慢慢变大，一样可以实现插值结果的变大。

#### 其他插值 API

1. 借助于 Mathf.Lerp()方法，我们可以实现单轴向上的位移动画和旋转动画，但是局限性很大，比如：[3，8, 10]插值移动到[34, 19, 78]；
2. Unity 引擎中，很多类都有自己专用的 Lerp()插值运算方法，接下来我们就演示“向量插值”和“四元数插值”。

```c#
[s][Vector3] Vector3.Lerp(a, b, float t)//向量插值
[s][Quaternion] Quaternion.Lerp(a, b, float t)//四元数插值
```

#### 示例

```c#
public class CubeLerp : MonoBehaviour
{
    private float startPos = 0;
    private float endPos = 20;

    private float startRot = 0;
    private float endRot = 50;

    private float tPos = 0;
    private float tRot = 0;

    private Vector3 startVector3;
    private Vector3 endVector3;

    private Quaternion startQua;
    private Quaternion endQua;

    private Transform m_Transform;
    private Transform endCube;

    void Start()
    {
        m_Transform = gameObject.GetComponent<Transform>();
        endCube = GameObject.Find("EndCube").GetComponent<Transform>();

        startVector3 = m_Transform.position;
        endVector3 = endCube.position;

        startQua = m_Transform.rotation;
        endQua = endCube.rotation;
    }


    void Update()
    {
        MoveLerp();
        RotationLerp();
    }


    private void MoveLerp()
    {

        if(tPos < 1.0f)
        {
            tPos += 0.5f * Time.deltaTime;
            m_Transform.position = Vector3.Lerp(startVector3, endVector3, tPos);

        }

    }


    private void RotationLerp()
    {
        if (tRot < 1.0f)
        {
            tRot += 0.5f * Time.deltaTime;
            m_Transform.rotation = Quaternion.Lerp(startQua, endQua, tRot);
        }


    }

}
```



# 2.物理系统的初步认识

Unity 引擎内有两套内置的物理系统组件，菜单路径位置如下：

- 3D 物理组件：Component --> Physics [基于 PhysX 引擎]
- 2D 物理组件：Component --> Physics 2D [基于 Box2D 引擎]

## 2.1.刚体组件

### 2.1.1.刚体的几个属性

- **Mass [质量]**
  1. 控制物体的质量，默认值为 1，单位是千克；
  2. 两个物体的质量差距很大，但是下落速度是一样的； [“两个铁球同时着地”]
  3. 两个物体的质量差距很大，在发生碰撞时，会有明显效果。 [各种交通事故]

- **Drag [阻力]**
  1. 控制空气阻力，默认值为 0，表示没有空气阻力；
  2. 将该参数值调大，可以降低物体的下落速度。

- **Angular Drag [角阻力]**
  1. 当物体发生旋转时的空气阻力，默认值为 0.05；

- **Use Gravity [使用重力]**
  1. 当前刚体组件是否开启重力效果，默认是勾选，重力开启状态；
  2. 如果取消勾选，则当前游戏物体关闭重力效果。

- **Is Kinematic [运动学]**
  1. 在物理运动和“运动学”运动[Transform]之间切换，默认是不勾选状态；
  2. 勾选该属性，运行之后，物体同样没有重力效果。

### 2.1.2.刚体的移动

#### 无动力情况

```c#
    //刚体组件对象方法 MovePosition（）控制当前物体移动到指定位置,Vector3 参数指的是目标位置。
    [void] m_Rigidbody.MovePosition(Vector3)
```

#### 有动力情况

- 使用刚体组件控制游戏物体，主要目的是进行两种运动：平稳运动，剧烈运动。

  - 平稳运动：游戏角色行走，奔跑； 

  - 剧烈运动：枪械武器发射子弹，炮弹

这里指的就是剧烈运动。

```c#
    //给刚体组件添加力，让刚体组件所在的游戏物体，向某个方向发射出去。
    Vector3 参数指的是目标方向的力度。
    [void] m_Rigidbody.AddForce(Vector3) //世界坐标系方向
    [void] m_Rigidbody.AddRelativeForce(Vector3) //物体坐标系方向
```



#### 例子

```c#
    m_Transform = gameObject.GetComponent<Transform>();
    m_Rigidbody = gameObject.GetComponent<Rigidbody>();

    //向上移动位置.
    m_Rigidbody.MovePosition(new Vector3(0, 5, 0));

    //向上方发射.[世界方向.]
    m_Rigidbody.AddForce(Vector3.up * 1000);

    //向上方发射.[物体自身方向.]
    m_Rigidbody.AddRelativeForce(Vector3.up * 1000);
```



#### WASD移动

```c#
    /// <summary>
    /// 世界坐标系四方向移动.
    /// </summary>
    private void WorldDirMove()
    {
        //向前.
        if (Input.GetKey(KeyCode.W))
        {
            m_Rigidbody.MovePosition(m_Transform.position + Vector3.forward * 0.2f);
        }
        //向后.
        if (Input.GetKey(KeyCode.S))
        {
            m_Rigidbody.MovePosition(m_Transform.position + Vector3.back * 0.2f);
        }
        //向左.
        if (Input.GetKey(KeyCode.A))
        {
            m_Rigidbody.MovePosition(m_Transform.position + Vector3.left * 0.2f);
        }
        //向右.
        if (Input.GetKey(KeyCode.D))
        {
            m_Rigidbody.MovePosition(m_Transform.position + Vector3.right * 0.2f);
        }
    }

    /// <summary>
    /// 自身坐标系四方向移动.
    /// </summary>
    private void SelfDirMove()
    {
        //向前.
        if (Input.GetKey(KeyCode.W))
        {
            m_Rigidbody.MovePosition(m_Transform.position + m_Transform.forward * 0.2f);
        }
        //向后.
        if (Input.GetKey(KeyCode.S))
        {
            m_Rigidbody.MovePosition(m_Transform.position - m_Transform.forward * 0.2f);
        }
        //向左.
        if (Input.GetKey(KeyCode.A))
        {
            m_Rigidbody.MovePosition(m_Transform.position - m_Transform.right * 0.2f);
        }
        //向右.
        if (Input.GetKey(KeyCode.D))
        {
            m_Rigidbody.MovePosition(m_Transform.position + m_Transform.right * 0.2f);
        }
    }
```



## 2.2.碰撞体和碰撞

#### 2.2.1.组合效果

在模型游戏物体上使用物理组件，有四种常见的组合方式：

![1.四种组合方式](../Img/1.%E5%9B%9B%E7%A7%8D%E7%BB%84%E5%90%88%E6%96%B9%E5%BC%8F.png)

**组合 A: 网格 + 刚体 + 碰撞体**

最常用的一种组合方式，游戏内的玩家角色，各种小怪，Boss 都是这种组合方式；

角色游戏物体可以推着“组合 A”移动。

**组合 B: 网格 + 碰撞体**

游戏场景相关元素，大多使用这种组合方式，比如场景内的各种建筑，墙壁，石头；

角色游戏物体可以和“组合 B”发生碰撞，但是“组合 B”无法移动。

**组合 C: 网格**

这种组合方式没有使用任何物理相关的组件；

角色游戏物体可以直接穿透“组合 C”，在物理运算角度，“组合 C”不存在。

**组合 D: 网格 + 刚体**

这种组合方式没有使用碰撞体组件，也就意味着项目运行之后，“组合 D”不会停

留在“地面”上，而是直接穿透地面进行自由落体运动	

## 2.3.物理射线

### 2.3.1.概述

在 Unity 引擎中，还存在一个名为“射线”的东西，它也可以和碰撞体组件产生物理碰撞，因此“射线”也称之为“物理射线”；

### 2.3.2.使用射线

1. 在 Unity 引擎中，射线没有对应的组件，只有一个结构体：**Ray** [射线]；
2. 在脚本中以 Ray 为类型创建字段，字段的用途是用于持有对象引用；
3. 射线对象的创建方式主要有如下两种：
   1. 直接 new 关键字构造射线对象；
   2. 通过摄像机相关 API 构造射线对象。

####  **通过摄像机相关 API 构造射线对象：**

```c#
[Ray] Camera.main.ScreenPointToRay(Vector3)
//摄像机组件对象方法，接收“屏幕上的一个点”作为参数，创建并返回一个射线对象，Vector3 参数指的就是“屏幕上的一个点”；
[Vector3] Input.mousePosition; 
//只读属性,鼠标在屏幕上的位置. 从摄像机所在的位置，向鼠标在屏幕上的位置(方向)，创建一根射线。
```



1. 场景中默认存在的“Main Camera”称之为：主摄像机；
2. 之所以能被称之为“主摄像机”，不是因为游戏物体名称的中文翻译，而是因为这个 Main Camera 游戏物体身上默认设置了一个专用的 Tag 标签；
3. [Camera]**Camera.main**：只读属性，用于获取设置了 MainCamera 标签的游戏物体身上的 Camera 组件对象；
4. 该属性在项目工程中任意一个脚本中，都可以直接书写调用。

#### 检测物理射线:

```c#
[bool] Physics.Raycast(Ray, out RaycastHit)
```

**物理类中的静态方法 Raycast()，主要用于射线检测，方法接收两个参数：**

- **Ray**：需要被检测的射线对象；
- **RaycastHit**：结构体，用于存放射线与碰撞体组件的碰撞信息；
  - 使用 out 关键字返回数据对象；
  - 结构体对象只读属性 collider，可以获取与射线发生碰撞的碰撞体组件；
- **bool**：射线碰撞到了游戏物体(碰撞体组件)返回真，没有发生碰撞返回假。

#### 使用例子

```c#
    private Ray ray;            //物理射线.
    private RaycastHit hit;     //射线碰撞信息.

    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit))
            {
                GameObject.Destroy(hit.collider.gameObject);
            }
        }
        

    }
```



## 2.4.角色控制器（Character Controller）

### 2.4.1.常用Api

1.  **SimpleMove（Vector3）：简单移动**

   以一定的速度移动角色，会自动应用重力。[角色控制器不是刚体，但是具备刚体的一些属性]

2. **Move（Vector3）：移动**

   更为复杂的一种运动，每次都绝对运动，不会应用重力。

3. **OnControllerColliderHit（ControllerColliderHit hit）**：可以通过 hit 获取到角色碰撞器碰撞到的物体的信息。

### 2.4.2.相关属性

1. **Slope Limit**

   斜率限制，控制角色最大的爬坡斜度。[演示：角色爬坡]

2. **Step Offset**

   台阶高度，控制角色可以迈上最大的台阶高度。[演示：角色上台阶]

3. **Skin Width [默认即可]**

   皮肤厚度，在角色的外围包裹着一层“皮肤”，设置这层皮肤的厚度。数值调大，最明显的就是角色和地面之间的间距变大，也就是角色皮肤变厚了。

4. **Min Move Distance [默认即可]**

   最小移动距离，默认是 0.001，也就是 1 毫米。如果该数值调大，但代码中单位移动速度很慢，角色就不会动。

5. **Center/Radius/Height**角色控制器组件在 Scene 面板中体现为一个“胶囊碰撞器”的形状。

**Center**：控制中心点的位置；

**Radius**：控制半径；

**Height**：控制高度。

### 实例使用

```c#
using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private CharacterController m_CC;

	void Start () {
        m_CC = gameObject.GetComponent<CharacterController>();
        //m_CC.slopeLimit = 10;
	}
	
	void Update () {
        //Debug.Log(Input.GetAxis("Horizontal"));
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        m_CC.SimpleMove(new Vector3(horizontal, 0, vertical) * 3);
        //m_CC.Move(new Vector3(horizontal, 0, vertical) * 0.3f);
	}

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log(hit.gameObject.name);
    }
}

```



# 3.UI系统

## 3.1.文字组件

### 3.1.1TMP 字体文件

- **字体文件**
  - Text 组件和 Text TMP 组件，都是用于文字显示，文字显示依赖字体文件；
    - Text 组件：TTF 格式字体文件； [Windows 系统拷贝字体文件]
    - Text TMP 组件：SDF 格式的 Asset 字体文件，默认无法显示中文。

- **制作 TMP 字体文件（TMP默认不显示中文）**
  1. Window --> TextMeshPro --> Font Asset Creator 打开功能面板；
  2. Source Font File [源字体文件]：支持中文显示的 TTF 字体文件；
  3. Character Set [字符集]：Custom Characters [自定义字符]；
  4. Custom Character List [自定义字符列表]：输入你需要显示的中文；
  5. Render Mode [渲染模式]：SDF； [和 TMP 自带的字体保持类型一致]
  6. 点击 Generate Font Atlas [生成字体图集]按钮；
  7. 点击 Save 按钮，将文件存储到指定路径位置；
  8. 当中英文并存时，会自动生成子物体，调用 TMP 默认的字体显示英文。

## 3.2.图片组件

### 3.2.1.导入UI 图片素材

1. 将素材图拖拽导入到 Textures 文件夹中；
2. Unity 项目工程中的图片，默认用途是“模型贴图”，如果想应用于 UI 界面，需要手动修改图片的属性；
3. 全选素材图，右侧属性栏参数：Texture Type 修改为 Sprite (2D and UI)，Sprite Mode 修改为 Single，参数修改之后，点击 Apply 按钮。

# 4.Invoke和协程

## 4.1.延迟方法Invoke()

### 4.1.1.基本介绍

- **Invoke** [调用]函数：它是 MonoBehaviour 类中定义的公开方法；

- 我们所编写的 Unity 项目脚本，默认都继承至 MonoBehaviour 父类，也就意味着在我们所编写的脚本中，可以直接使用 Invoke 相关 API；

- Invoke 函数的用途有两个：延迟调用某个方法，重复调用某个方法。

  

### 4.1.1.延迟调用

```c#
[void] Invoke(string, float) //延迟多少秒之后，调用某个方法. 
```

> 参数说明：

string 参数：需要被延迟调用的方法的名字；

float 参数：延迟的时间，单位是秒。



### 4.1.2.重复调用

```c#
[void] InvokeRepeating(string, float, float)
```

> 参数说明：

参数列表中前边的两个参数的用途和 Invoke 函数相同；

第三个 float 参数指的是之后每隔多少秒再调用一次该方法。



### 4.1.3.取消调用

```c#
[void] CancelInvoke() //取消当前脚本中所有的延迟调用. 
[void] CancelInvoke(string) //取消当前脚本中指定的延迟调用. 
```



## 4.2.协程

### 4.2.1.协程介绍

1. 协同程序，简称“协程”[Coroutine]；在代码中，协同程序是以“协程方法”的形式存在；
2. 在使用过程中，需要先创建具有特定功能的协程方法，然后使用对应的 API 对协程方法进行开启和停止。

> 协程的用途

1. Unity 引擎所开发的项目，默认是单线程，因为画面渲染，物理运算以及 Unity引擎核心 API 的运行，都需要在主线程内执行；
2. Unity 项目开发过程中，**可以使用 C#多线程相关代码开启子线程，但是在子线程内你无法使用任何 Unity 引擎相关的 API**，比如：实例化/销毁游游戏物体；
3. 协程的用途类似于开启子线程，辅助主线程完成一些额外的代码运行。

### 4.2.2.协程语法格式

#### 1.创建协程方法

1. 协程方法跟普通方法语法格式相同，不同点是协程方法会使用到特殊关键字；
2. 协程返回值类型为：**IEnumerator** [迭代器接口]
3. 协程返回数据方式：**yield** **return** [产出返回]
4. 延迟等待：**new** **WaitForSeconds**(**float**) [延迟等待指定秒数]

> **注意**：协程返回值类型是：IEnumerator [迭代器接口]，代码编写过程中输入“IEn”出现下拉菜单代码提示，其中有一个  类似的类型：IEnumerable [可枚举接口]，切记：协程方法的返回值是“tor”结尾，不是“ble”结尾；

#### 2.开启协程

```c#
[Coroutine] StartCoroutine(string)

//协程方法的名称作为参数,开启协程. 

[Coroutine] StartCoroutine(string, object)

//协程方法的名称作为参数,开启协程,以 object 为类型传递方法参数给协程. 
```

#### 3.停止协程

```c#
[void] StopCoroutine(string) //停止指定名称的协程方法. 
[void] StopAllCoroutines() //停止当前脚本中所有的协程方法.
```

## 4.3.协程与 Invoke 对比

### 4.3.1.相同之处

1. 都是 MonoBehaviour 父类中定义的公开方法，在我们自己编写的 Unity 项目脚本中，都可以直接使用；
2. 都可以延迟一段时间之后，在执行具体的代码。

### 4.3.2.不同之处

1. 协程在开启时，可以动态的传递参数，**Invoke 只能是无参方法**；
2. **协程方法体内，可以多次延迟**，Invoke 只能在方法开启时延迟；
3. **Invoke 能实现的效果，协程都能实现**，可以理解成一个是免费版，一个是 SVIP付费加强版，在项目实际开发过程中，按需使用即可。

