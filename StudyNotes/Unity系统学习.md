[toc]

# 1.基础组件的认识



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

# ![2.资源关系图](../Img/2.%E8%B5%84%E6%BA%90%E5%85%B3%E7%B3%BB%E5%9B%BE.jpg)

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



### 2.2.碰撞体和碰撞

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
