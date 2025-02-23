[toc]

# Windows PowerShell

## 1.PowerShell的执行策略

在Windows操作系统中，PowerShell的执行策略决定了哪些类型的脚本可以被执行。执行策略可以是以下几种之一：

- **Restricted**：不允许任何脚本执行。
- **AllSigned**：只允许执行已签名的脚本。
- **RemoteSigned**：本地脚本可以执行，但来自互联网的脚本必须已签名。
- **Unrestricted**：允许执行所有脚本。

如果你想要关闭远程脚本执行权限，可以将执行策略设置为 **Restricted**。以下是关闭远程脚本执行权限的步骤：

**打开Windows PowerShell作为管理员**：

- 在开始菜单中搜索“PowerShell”。
- 右键点击“Windows PowerShell”，选择“以管理员身份运行”。

**查看当前的执行策略**：

- 在PowerShell窗口中输入以下命令并回车：

  ```powershell
  Get-ExecutionPolicy
  ```

- 这将显示当前的执行策略。

**更改执行策略**：

- 如果当前执行策略为“RemoteSigned”或“Unrestricted”，你可以通过以下命令将执行策略设置为“Restricted”：

  ```powershell
  Set-ExecutionPolicy Restricted
  ```

- 系统将提示你确认是否要更改执行策略。输入“Y”然后按 Enter 确认。

**确认更改**：

- 如果你确定要更改执行策略，输入“Y”然后按 Enter 确认。

更改执行策略后，只有本地脚本文件可以执行，而来自互联网的脚本将被阻止执行。这有助于提高系统的安全性，防止潜在的恶意脚本执行。

请注意，更改执行策略可能会影响某些脚本的执行，特别是那些需要远程执行的脚本。在更改执行策略之前，请确保你了解可能的影响，并且只在必要时更改执行策略。如果你需要执行远程脚本，可以考虑将执行策略更改为“RemoteSigned”或“AllSigned”，并确保你信任的脚本都已签名。

# Git_Api

## 1.初始化仓库

```
 git init     在当前目录创建一个新的Git仓库。 
```



## 2.设置全局邮箱和用户名

```bash
git config --global user.name “你在GitHub上的用户名”
git config --global user.email “你的邮箱”
```



## 3.ssh相关操作

### 3.1.检查是否存在ssh

```bash
cd ~/.ssh
```



### 3.2.生成ssh

```bash
ssh-keygen -t rsa -C "你的邮箱"
```



### 3.3.测试和仓库的ssh连接

```bash
ssh -T git@github.com
```



## 4.与远程仓库的操作



### 4.1.连接远程仓库

```bash
git remote add origin "你的仓库SSH地址"
```



### 4.2.取消连接

```bash
git remote remove <remote-name>
git remote remove origin
```



### 4.3.拉取代码

```bash
git pull origin master
```



### 4.4.提交相关

```bash
# 检查暂存区文件
git status

# 添加到暂存区
git add .

# 提交到本地仓库 
git commit -m "你的备注信息"

# 提交到远程仓库
git push -u origin master
```



## 5.分支操作

### 5.1.修改要提交的分支

```bash
git checkout <branch-name>
```



### 5.2.合并分支到主分支（前提条件：你现在是主分支）

```bash
git merge "你要合并的分支名"
```



# Unity_Api

## 1.Input [输入类]

### 1.1.获取鼠标按键&位置

```c#
/*获取鼠标按键三种状态.[0:左键  1:右键  2:中键]*/

[s][bool] GetMouseButtonDown(int)  //按下某键的一瞬间,返回true.

[s][bool] GetMouseButton(int)    //按下某键后,持续返回true.

[s][bool] GetMouseButtonUp(int)   //抬起某键的一瞬间,返回true.
    
[s][Vector3] mousePosition          //只读属性,鼠标在屏幕上的位置.
```



### 1.2.获取键盘按键

```c#
/*获取键盘按键三种状态.*/
[s][bool] GetKeyDown(KeyCode)       //按下某键的一瞬间,返回true.
[s][bool] GetKey(KeyCode)           //按下某键后,持续返回true.
[s][bool] GetKeyUp(KeyCode)         //抬起某键的一瞬间,返回true.
```



## 2.MonoBehaviour[Mono行为类]

### 2.1.一些生命周期函数

```c#
[void] Awake()                        //对象被创建时,执行一次.
[void] OnEnable()                     //脚本组件启用时,执行一次[多次].
[void] Start()                        //项目运行之后,执行一次.
[void] FixedUpdate()                 //固定更新,0.02秒执行一次.
[void] Update()                       //每帧执行一次,一秒钟大约60次.
[void] LateUpdate()                  //在Update之后,延迟执行.
[void] OnDisable()                   //脚本组件禁用时,执行一次[多次].
[void] OnDestroy()                   //脚本组件被销毁时,执行一次.
```



### 2.2.碰撞函数

```c#
[void] OnCollisionEnter(Collision)	 //碰撞开始，执行一次.
[void] OnCollisionStay(Collision)	 //碰撞进行中，每帧都会执行.
[void] OnCollisionExit(Collision)	 //碰撞结束，执行一次.
```



### 2.3.触发函数

```c#
[void] OnTriggerEnter(Collder)	    //触发开始，执行一次.
[void] OnTriggerStay(Collder)	    //触发进行中，每帧都会执行.
[void] OnTriggerExit(Collder)	    //触发结束，执行一次.
```



### 2.4.GameObject对象

```c#
[GameObject] gameObject  //只读属性,当前脚本组件所挂载到的游戏物体对象.
```



### 2.5.组件启用和禁用

```c#
[bool] 组件对象.enabled   //读写属性,控制组件启用[true]与禁用[false].
```



### 2.6.延迟调用 Invoke() 

```c#
[void] Invoke(string, float)	    //延迟调用,延迟x秒,调用某方法.
[void] InvokeRepeating(string, float, float)	 //延迟并重复调用.
[void] CancelInvoke()	          //取消当前脚本中所有的延迟调用.
[void] CancelInvoke(string)	    //取消当前脚本中指定的延迟调用.
// 在5秒后调用isActive方法
// Invoke("isActive", 5f, gameObject);
// 在5秒后调用isActive方法，并且在调用后再次延迟5秒
// InvokeRepeating("isActive", 5f, 5f, gameObject);
```



### 2.7.协程方法

```c#
IEnumerator   //迭代器接口,协程方法的返回值类型.
yield return  //协程方法返回.
new WaitForSeconds(float)   //延迟等待x秒.
[Coroutine] StartCoroutine(string)	        //开启指定协程方法.
[Coroutine] StartCoroutine(string, object) //开启协程,并传递参数.
[void] StopCoroutine(string)	      //停止指定协程方法.
[void] StopAllCoroutines()	      //停止当前脚本中所有协程方法.
```



### 2.8.发送消息

```c#
[void] SendMessage(string)	            //给自身游戏物体发送消息.
[void] SendMessage(string, object)        //方法名 + 参数.
[void] BroadcastMessage(string)	         //给自身和子物体发送消息.
[void] BroadcastMessage(string, object)  //方法名 + 参数.
[void] SendMessageUpwards(string)	      //给父物体发送消息.
[void] SendMessageUpwards(string, object)	//方法名 + 参数.
```



## 3.GameObject[游戏物体类]

### 3.1.[string] name 名字字段

```c#
[string] name        //读写属性,获取当前游戏物体的名称,修改游戏物体名称.
```



### 3.2.查找GameObject对象的函数

```c#
[s][GameObject] Find(string)   //通过名称查找获取场景内的游戏物体对象.
[s][GameObject[]] FindGameObjectsWithTag(string)   //Tag标签查找.
[s][void] Destroy(Object)         //销毁游戏物体,组件.
[s][void] Destroy(Object, float) //定时销毁游戏物体,组件.
```



### 3.3.获取当前游戏物体上的某个组件对象

```c#
[T] GetComponent<T>()          //获取当前游戏物体上的某个组件对象.
[T] AddComponent<T>()          //给当前游戏物体添加某个组件对象.
```



### 3.4.控制游戏物体显示

```c#
[void] SetActive(bool)          //控制游戏物体显示[true]与隐藏[false].
```



### 3.5.实例化生成

```c#
[s][T]Instantiate<T>(GameObject, Vector3, Quaternion) //实例化.
[s][T]Instantiate<T>(GameObject, Vector3, Quaternion, Transform) //实例化.最后一个参数指定父物体
```



## 4.Debug

### 4.1.在控制台输出信息.

```C#
[s][void] Log(object)                  //在控制台输出信息.
```

### 4.2.两点之间画线 DrawLine()

```c#
[s][void] DrawLine(Vector3, Vector3, Color, float)//两点之间画线
```



## 5.Transform[变换组件]

### 5.1.位置

```c#
[Vector3] position              //读写属性,获取位置,修改位置.
```



### 5.2.旋转

```c#
[Quaternion] rotation           //读写属性,获取旋转数据,修改旋转数据.
```



### 5.3.获取物体自身坐标系的三个正方向

```c#
[Vector3] forward, right, up   //读写属性,正前方,右方向,正上方.
```



### 5.4.旋转和移动的函数

```c#
[void] Translate(Vector3, Space)    //选择坐标系,按指定的方向移动. space(wprld/self)代表参考世界/自身坐标系
[void] Rotate(Vector3, float)       //沿固定轴向旋转固定角度.
```



### 5.5.获取子物体

```c#
[Transform] Find(string)             //在子物体中查找指定物体.
[T[]] GetComponentsInChildren<T>()  //在子物体中查找指定组件
```

> **注意**：GetComponentsInChildren 会将父物体的 Transform 也一同获取，要从1开始遍历
>
> Transform 组件查找子物体身上的 Transform 组件：
>
> <1>常用格式：
>
> m_Transform.GetComponentsInChildren<Transform>()
>
> 这个 API 默认会查找所有的子物体，**包括孙子级别**的子物体。且这个 API 不会查找到隐藏的游戏物体。
>
> <2>重载格式：
>
> m_Transform.GetComponentsInChildren<Transform>(bool)
>
> 该方法有一个重载形式，bool 类型，如果填写 true，则该 API 可以查找到隐藏的子物体。
>
> 
>
> **如果我们只想查找获取“儿子级别”的子物体，应该如何操作?**
>
> m_Transform.childCount:获取当前游戏物体子物体的个数
>
> m_Transform.GetChild(i):以角标的形式获取子物体

### 5.6.更改角色面部朝向

```csharp
[void] LookAt(Vector3); //看向输入位置
```

### 5.7.绕某个点旋转

```csharp
[void]RotateAround(Boss 位置, Y 轴, 角度)；
```



## 6.Rigidbody[刚体组件]

```c#
[void] MovePosition(Vector3)      //移动到指定位置[当前位置+方向].
[void] AddForce(Vector3)          //世界坐标系方向添加力[方向*力度].
[void] AddRelativeForce(Vector3) //物体坐标系方向添加力[方向*力度].
```

### 刚体睡眠

```csharp
[void]Rigidbody.Sleep()：//可以让刚体睡眠,也就是立刻停止运动。
```



## 7.Vector3[三维向量]

```csharp
[float]x, y, z                 //公开字段,可以单个读取,不可以单个修改.
/*获取世界坐标系的六个方向*/
[s][Vector3] forward, right, up   //只读属性,前,右,上.
[s][Vector3] back, left, down     //只读属性,后,左,下.
[s][Vector3] zero                  //只读属性,世界原点位置[0,0,0].
[s][Vector3] Lerp(a, b, float t)  //在两个Vector3数据之间插值.
[s][float]magnitude               //向量的模长
[s][Vector]normalized             //标准化向量
//effect.transform.rotation = Quaternion.LookRotation(hit.normal); 一般这么用
[s][float]Distance(v1, v2)       //向量间的距离
```



## 8.Quaternion

```c#
[Vector3] eulerAngles      //读写属性,将当前四元数转换成向Vector3.
[s][Quaternion] identity   //只读属性,表示无旋转,对应欧拉角[0,0,0].
[s][Quaternion] Euler(Vector3)    //将Vector3转换成四元数.
[s][Quaternion] Lerp(a, b, float t) //在两个Quaternion数据之间插值.
```



## 9.Collision

```c#
[GameObject] gameObject           //只读属性,物理碰撞到的游戏物体.
```



## 10.Collider

```c#
[GameObject] gameObject           //只读属性,物理触发到的游戏物体.
```



## 11.Text & TMP_Text

```c#
/*UGUI组件命名空间:using UnityEngine.UI;  TMP命名空间:using TMPro;*/
[string] text          //读写属性,可以读取以及修改文本组件的显示内容.
[Color] color          //读写属性,获取和修改组件的颜色.
```



## 12.Button

### 12.1.点击绑定事件

```c#
/*事件处理方法的格式:私有,无参,无返回值*/
[void] onClick.AddListener(事件处理方法) //按钮点击绑定事件处理方法.
```



## 13.Color

```c#
[s][Color] red, green, blue  //只读属性,返回对应的颜色.
[Color] Color(r, g, b, a)    //构造方法,参数取值范围是0~1,float类型.
```



## 14.Color32

```c#
[Color32] Color32(r, g, b, a) //构造方法,参数取值范围是0~255,byte类型.
```



## 15.LineRenderer

```c#
[int] positionCount                //读写属性,获取和修改位置点的个数.
[void] SetPosition(int, Vector3) //给位置数组对应下标的元素赋值.
```



## 16.AudioSource

### 1.播放和停止

```c#
[void] Play()                      //播放音频.
[void] Stop()                      //停止播放.

```



### 2.在某个地方播放

```csharp
[s][void] PlayClipAtPoint(AudioClip, Vector3) //在指定位置播放音效.
```



## 17.资源加载 Application

### Resources

```c#
[s][T] Load<T>(string)            //指定文件路径,加载单个资源.
[s][T[]] LoadAll<T>(string)       //指定文件夹路径,加载多个资源.
```

### persistentDataPath

```csharp
[string]Application.persistentDataPath
```

### streamingAssetsPath

```Csharp
[string]Application.streamingAssetsPath,
```

### 目前是否是编译器，不是打包后

```csharp
[bool]Application.isEditor 
```



## 18.Camera

```c#
[s][Camera] main          //只读属性,获取“主摄像机”的Camera组件对象.
[Ray] ScreenPointToRay(Vector3) //使用屏幕上的一个位置点创建射线对象.
```



## 19.物理射线

```c#
Ray                                //结构体,物理射线.
RaycastHit                        //结构体,存放物理射线碰撞信息.
[Collider] collider  //RaycastHit对象只读属性,射线碰撞到的碰撞体组件.
[Vector3] point       //RaycastHit对象读写属性,获取碰撞位置点.
[s][bool] Physics.Raycast(Ray, out RaycastHit) //物理射线检测方法.
[s][float] Random.Range(float, float)   //在最小值最大值之间取随机数.
```



## 20.Time

```c#
[s][float] time         //只读属性,时间,项目从开始运行到现在的总时长.
[s][float] deltaTime   //只读属性,增量时间,渲染完一帧所需要的时长.
[s][float] timeScale   //读写属性,时间缩放,控制虚拟时间中的时间流速.
```



## 21.Mathf

```c#
[float] Deg2Rad        //角度转弧度常量. 值:0.0174.
[float] Rad2Deg        //弧度转角度常量. 值:57.295.
[s][float] Lerp(float a, float b, float t)  //数学类插值运算.
```

### 平滑阻尼

```csharp
[float]Mathf.SmoothDamp(current, target, ref currentVelocity, smoothTime);
//Current：动画的运动范围；
//Target：动画的最终位置，也就是 0；
//currentVelocity：这个数据我们保持为 0 即可；
//smoothTime:用当前动画时长，减去当前时长。
```

例子：

```csharp
 /// <summary>
    /// 尾巴颤动动画.
    /// </summary>
    private IEnumerator TailAnimation()
    {
        //动画执行时长.
        float stopTime = Time.time + 1.0f;

        //动画的颤动范围.
        float range = 1.0f;

        float vel = 0;

        //长矛动画开始的角度.
        Quaternion startRot = Quaternion.Euler(new Vector3(Random.Range(-5.0f, 5.0f), Random.Range(-5.0f, 5.0f), 0));

        while (Time.time < stopTime)
        {
            //动画的核心.
            m_Pivot.localRotation = Quaternion.Euler(new Vector3(Random.Range(-range, range), Random.Range(-range, range), 0)) * startRot;

            //平滑阻尼.
            range = Mathf.SmoothDamp(range, 0, ref vel, stopTime - Time.time);

            yield return null;
        }
```



## 22.Character Controller

### 移动

```c#
 SimpleMove（Vector3）：//简单移动
 Move（Vector3）：移动 //更为复杂的一种运动，每次都绝对运动，不会应用重力。
```

## 23.Iput控制面板上的操作

```c#
[float]Input.GetAxis（“轴向名称”）; //取得轴向的值
```

## 24.Animator动画控制面板

### 1.过度条件的获取和赋值

```csharp
Animator.Set。。。（name, value）; //通过 Animator 给过渡条件赋值
Animator.Get。。。（name, value）; //获取某过渡条件的值
```



### 2.Ik

```csharp
[void] OnAnimatorIK（int index）//类似于我们之前的 start（） OnTriggerEnter（），都是 Unity 内置的事件函数，由引擎自己维护和调用，这个函数主要用于处理 IK 相关的逻辑
//设置权重
Animator.SetIKPostionWeight（AvatarIKGoal，int）；
Animator.SetIKRotationWeight（AvatarIKGoal，int）；
//绑定要Ik的物体的位置
Animator.SetIKPosition（AvatarIKGoal，Vector3）；
Animator.SetIKRotation（AvatarIKGoal，Quaternion）；
```



### 3.转换成哈希码

```csharp
[int]Animator.StringToHash(string);  //Unity引擎中Animator组件的一个方法，它用于将一个字符串转换为一个整数哈希值。这个哈希值是基于字符串内容的，用于在动画系统中唯一标识一个动画状态或参数。
```

在Unity中，当你使用Animator组件来控制角色动画时，你通常会引用动画状态机中的状态或参数。这些状态和参数在Animator组件中是以字符串形式定义的。为了提高性能和效率，Unity内部会将这些字符串转换为整数哈希值，因为整数比较比字符串比较要快得多。

当你使用 `Animator.StringToHash(string)` 方法时，你需要传入一个字符串参数，该方法会返回一个整数哈希值。这个哈希值可以用于以下场景：

```csharp
Animator animator;
string stateName = "Walk"; // 假设这是动画状态机中的一个状态名称

// 获取状态的哈希值
int stateHash = Animator.StringToHash(stateName);

// 触发状态
animator.SetTrigger(stateHash);
```

## 25.Unity的特性

```csharp

[HideInInspector] //这个特性用于隐藏字段或属性，使其在Unity编辑器的Inspector面板中不可见。这对于不想让某些字段被编辑器直接访问的私有变量非常有用。

[SerializeField] //这个特性用于将私有字段序列化并显示在Inspector面板中，即使它是私有的。这允许开发者在不公开字段的情况下，仍然可以在编辑器中修改它的值。

[Header] //这个特性用于在Inspector面板中为字段添加一个标题，以提高代码的可读性。

[Range(min, max)] //这个特性用于限制一个浮点数或整数字段的值在指定的最小值和最大值之间。

[Tooltip] //这个特性用于为字段添加一个工具提示，当鼠标悬停在Inspector面板中的字段上时显示。

[Space] //这个特性用于在Inspector面板中添加垂直空间，以分隔不同的字段。

[ContextMenu] //这个特性用于为字段或方法添加一个上下文菜单项，可以在编辑器中通过右键点击来调用。

[ExecuteInEditMode] //这个特性用于在编辑模式下执行脚本，允许在编辑器中测试脚本的行为。

[RequireComponent] //这个特性用于确保GameObject在添加脚本时，也自动添加所需的组件。

[AddComponentMenu] //这个特性用于将自定义组件添加到Unity编辑器的组件菜单中。

[CreateAssetMenu] //这个特性用于创建自定义的Asset菜单项，允许用户通过Unity编辑器创建自定义的资源。
```

### 该脚本挂载的同时挂载另一个组件

```csharp
[RequireComponent(typeof(ObjectPool))] //挂载该脚本的同时挂载ObjectPool组件
```



## 26.导航_NavMeshAgent

### 1.设置目的地

```csharp
[void] SetDestination(Vector)
```

### 2.目的地属性

```csharp
[Vector3] destination //读写属性，物体最终导航到的目的地
```

### 3.距离目标点剩余距离

```csharp
[float]remainingDistance
```

### 4.到距离目标点多远的距离停止

```csharp
[float]stoppingDistance
```

## 27.LayerMask

### 获取某层的序号

```csharp
[string]LayerMask.NameToLayer("Env") 
```

## 28.Cursor（鼠标指针操作）

### 鼠标锁定模式

```csharp
[CursorLockMode]lockState
```

### 鼠标是否显示

```csharp
[bool]visible
```



## UGUI

### 1.通过拖拽事件改变图片位置

```csharp
[Vector3]RectTransformUtility.ScreenPointToWorldPointInRectangle(m_RectTransform,eventData.position,eventData.enterEventCamera,out pos); //屏幕坐标点转化为世界坐标点；
```

>**其中：**
>
>`m_RectTransform`   //游戏物体的 RectTransform ;
>
>`eventData.position`  //当前坐标位置点；
>
>`eventData.enterEventCamera`  //事件摄像机；
>
>`out pos`  //最终计算得到的世界坐标位置；

### 2.Image

#### 填充属性

```csharp
[float]fillAmount
```

### 3.RectTransform

#### 将小怪的位置（3D 位置）转换为屏幕位置（2D 位置）；

```csharp
[Vecteo2]RectTransformUtility.WorldToScreenPoint(Camera.main, cubePos);//WorldToScreenPoint:世界位置转换为屏幕位置. 
```

#### UGUI 更改图片的宽和高

API：

```csharp
[void]RectTransform.SetSizeWithCurrentAnchors(轴向,值);
```

> 参数：RectTransform.Axis.Horizontal/Vertical ：对应宽和高.

#### 修改UI的位置（偏移量）

```csharp
[Vector2]offsetMin

[Vector2]offsetMax

//RectTransform.offsetMin = new Vector2(Left, Bottom)；
//RectTransform.offsetMax = new Vector2(Right, Top)。
//【EG】GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
```



### 4.Button

#### 不同状态的按钮图片

```csharp
[SpriteState]GetComponent<Button>().spriteState.xxxxx
//Button 组件的 spriteState 属性中，可以找到按钮的不同状态图片
```

### 5.eventData

**注意:必须导入命名空间using UnityEngine.EventSystems;改属性是对应接口的参数（IBeginDragHandler, IDragHandler, IEndDragHandler）**

#### 得到鼠标指针最终停留所在的游戏物体

```csharp
[GameObject]eventData.pointerEnter
//该属性会返回一个 GameObject，这个对象就是目标游戏物体。但最终“碰撞”到的就是我们拖拽中的物品
```

### 6.CanvasGroup 组件

#### 以控制当前的 UI 游戏物体是否接收射线的碰撞

```csharp
[bool]m_CanvasGroup.blocksRaycasts
```



## Socket

### 服务器端客户端通用方法

#### 创建socket对象

```csharp
Socket socket = new Socket(地址类型，Socket 类型，协议类型);
```

参数介绍：

地址类型：使用 IPv4 地址协议，AddressFamily.InterNetwork

Socket 类型：使用流式类型，SocketType.Stream

协议类型：使用 TCP 协议类型，ProtocolType.Tcp



# lua

## 基础语法

### 获取一个变量的类型

```lua
type()
```



## 字符串

### 字母大小写转换

```lua
string.upper( 字符串变量 )：字母全部转大写格式；

string.lower( 字符串变量 )：字母全部转小写格式；
```



### 字符串反转

```lua
string.reverse( 字符串变量 )：将字符串进行位置反转。
```



### 字符串长度

```lua
string.len( 字符串变量 )：返回字符串的长度. 
```

**注意：单个字母，数字，符号长度都为 1；单个汉字长度为 2。**

### 字符串替换

```lua
string.gsub（原始字符串，旧字符串，新字符串，[替换次数]）
```

在原始字符串中查找旧字符串，如果找到了，就用新字符串把旧的替换掉；替换次数可以不写，则表示全部替换。

### 字符串格式化

```lua
string.format（）
```

**string.format（字符串格式，变量 1，变量 2，变量 N）**

- %s：代表字符串. 

- %d：表示一个整数数字

- %f：表示一个小数

  **保留有效小数位数：%0.1f，0.1 是保留 1 位小数，%0.2f 是保留两位小数；**

  **e.g:**

```lua
print(string.format("显示：%0.1f",0.898989))
```

## table 表

### **增加元素**

```lua
table.insert(表名, [位置], 值)
```

往指定的位置增加元素，如果不写位置，默认往最后一个位置增加。

这个方式适合“数组模式”，不太适合“键值对模式”。

键值对就用：表名[‘键’] = 值 的方式添加即可。

### 移除元素

```lua
table.remove(表名, [位置])
```

如果不写位置，默认移除最后一个元素，如果位置值超出范围，不会报错，也不

会有元素被移除。

这个方式适合“数组模式”，不能用于“键值对模式”。

键值对就用：表名[‘键’] = nil 的方式移除即可。

### table 长度

```lua
table.getn(表名)
```

返回 table 表的长度。

这个方式适合“数组模式”，不能用于“键值对模式”。

键值对就用：迭代器迭代，然后累加一个变量的方式获得长度。

## Metatable 元表

### 关联两个表[将表 B 设置成表 A 的元表]，需要用一个新的函数：

```lua
setmetatable(表 A, 表 B) [见图]
```

### 是否存在元表

```lua
getmetatable(表名)
```

如果表名有元表，就返回元表的类型和地址；如果没有元表，则返回一个 nil。

## 引入资源

### require

```lua
require("path") --引入指定模块.
require "path"
```



### dofile (引入整个lua文件)

```lua
dofile("path")
--dofile("..\\myp\\Person.lua")
```

## LuaInterface（c#中调用lua）

> using LuaInterface;

###  实例化一个lua解析器对象

```csharp
Lua lua = new Lua();
```

###  变量的声明与访问.

```csharp
lua.DoString("LuaScripts")
//lua.DoString("name = 'Monkey' age = 72 address = 'BeiJing'");
```

### 读取Lua文件

```csharp
lua.DoFile("LuaFile");
//lua.DoFile("Monkey.lua");
```

### 获取各个类型数据

```csharp
string webName = lua.GetString("webName");
double num = lua.GetNumber("num");
LuaFunction LuaHello = lua.GetFunction("LuaHello");
LuaHello.Call();
```

## luanet （Lua 内访问 C#代码 ）同文件夹下

```lua
--导入luanet.dll，语法格式：require “luanet”
require "luanet"

--获取程序集，语法格式：luanet.load_assembly（“程序集名”）
luanet.load_assembly("three")
luanet.load_assembly("System")

--获取类型，语法格式：变量名= luanet.import_type（“程序集名.类名”）
Calc = luanet.import_type("three.Calc")
Console = luanet.import_type("System.Console")
```

## AssetBundle

### 打包

```csharp
BuildPipeline.BuildAssetBundles(路径, 选项, 平台);
```

参数分析：

- BuildAssetBundles：打包所有设置了 AssetLabels 的资源；

- 路径：打包出来的 AssetBundle 文件存放的位置；
- 选项：设置 AssetBundle 打包过程中的选项，None 表示忽略该选项；
- 平台：AssetBundle 是平台之间不兼容的，IOS，Android 是两套资源；

### 打包压缩选项

```csharp
BuildAssetBundleOptions.None
```

使用 LZMA 压缩算法进行压缩，打包后的资源体积最小。

```csharp
BuildAssetBundleOptions.UncompressedAssetBundle
```

不使用压缩方式，打包后的 AssetBundle 体积最大，但是加载速度最快。

```csharp
BuildAssetBundleOptions.ChunkBasedCompression
```

使用 LZ4 压缩算法进行压缩，打包后的 AssetBundle 体积和加载速度介于二者之间。

### 加载 AB 资源到内存

```csharp
AssetBundle ab = AssetBundle.LoadFromFile("AB 包完整路径")
```

从一个完整的路径位置加载 AB 资源包到内存，返回一个 AssetBundle 对象. 

### 从 AB 资源中获取资源

```csharp
T resName = ab.LoadAsset<T>("游戏资源名称")
```

通过获取到的 AssetBundle 对象的“加载资源”方法，从 AssetBundle 对象内获取对应的游戏物体资源，并且返回该资源. 

**备注：这句话的效果类似于使用 Resources.Load 加载一个资源.**

### 从服务器下载，导入AssetBundle 的相关api

#### 网络相关命名空间。

```csharp
using UnityEngine.Networking;
```

#### 创建一个获取 AssetBundle 文件的 web 请求. 

```csharp
UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(url);
```

#### 发送web 请求. 

```csharp
yield return request.Send();
```

#### 从 web 请求中获取内容，返回一个 AssetBundle 类型的数据. 

```csharp
AssetBundle ab = DownloadHandlerAssetBundle.GetContent(request);
```

#### 从这个“目录 AssetBundle”中获取 manifest 数据. 

```csharp
AssetBundleManifest manifest = ab.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
```

#### 获取这个 manifest 文件中所有的 AssetBundle 的名称信息.

```csharp
string[] assets = manifest.GetAllAssetBundles();
```

#### **服务器端下载所有文件**

通过获取到的 AssetBundle 对象获取内部所有的资源的名称，返回一个数组. 

```csharp
string[] names = ab.GetAllAssetNames();
```

# C#

## iO

- path : 文件路径

### 读取文件

```csharp
[string]File.ReadAllText(string path);
```

### 删除文件

```csharp
[void]File.Delete(path);
```

### 写入文件

```csharp
StreamWriter sw = new StreamWriter(path);
[void]sw.Write(str);
[void]sw.Close();
```

### 变量组合成路径

```csharp
[string]Path.Combine(Application.streamingAssetsPath, fileName + ".txt")
 //项目位置/Assets/StreamingAssets\{fileName}.txt
```

### 截取路径地址中的文件名，且无后缀名

```csharp
[string]Path.GetFileNameWithoutExtension(path)
```

### 创建一个文件信息对象

```csharp
FileInfo fileInfo = new FileInfo(文件完整路径+名称);
```

### 通过文件信息对象的“创建”方法，得到一个文件流对象. 

```csharp
FileStream fs = fileInfo.Create();
```

### 通过文件流对象，往这个文件内写入信息. 

```csharp
fs.Write(字节数组, 开始位置, 数据长度);
```

### 文件写入存储到硬盘

```csharp
fs.Flush();
```

### 关闭文件流对象

```csharp
fs.Close();
```

### 销毁文件对象

```csharp
fs.Dispose();
```



# WWW 

### 创建一个 web 请求，参数填写文件的 url 下载地址. 

```csharp
WWW www = new WWW(url);
//WWW www = new WWW("file://" + Application.streamingAssetsPath + "/luaFix.lua.txt");
//要加上file://
```

### 是否下载完毕

```csharp
[bool]www.isDone 
```
