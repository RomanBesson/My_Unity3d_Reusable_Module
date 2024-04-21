[toc]

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
ssh-keygen -t rsa -C “你的邮箱”
```



### 3.3.测试和仓库的ssh连接

```bash
ssh -T git@github.com
```



## 4.与远程仓库的操作



### 4.1.连接远程仓库

```bash
git remote add origin “你的仓库SSH地址”
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
git commit -m “你的备注信息”

# 提交到远程仓库
git push -u origin master
```



## 5.分支操作

### 5.1.修改要提交的分支

```bash
git checkout <branch-name>
```



### 5.2.合并分支到主分支（前提条件：你现在是主分支）

```
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
[T[]] GetComponentsInChildren<T>()  //在子物体中查找指定组件.
```



## 6.Rigidbody[刚体组件]

```c#
[void] MovePosition(Vector3)      //移动到指定位置[当前位置+方向].
[void] AddForce(Vector3)          //世界坐标系方向添加力[方向*力度].
[void] AddRelativeForce(Vector3) //物体坐标系方向添加力[方向*力度].
```



## 7.Vector3[三维向量]

```c#
[float]x, y, z                 //公开字段,可以单个读取,不可以单个修改.
/*获取世界坐标系的六个方向*/
[s][Vector3] forward, right, up   //只读属性,前,右,上.
[s][Vector3] back, left, down     //只读属性,后,左,下.
[s][Vector3] zero                  //只读属性,世界原点位置[0,0,0].
[s][Vector3] Lerp(a, b, float t)  //在两个Vector3数据之间插值.
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

```c#
[void] Play()                      //播放音频.
[void] Stop()                      //停止播放.
[s][void] PlayClipAtPoint(AudioClip, Vector3) //在指定位置播放音效.
```



## 17.Resources

```c#
[s][T] Load<T>(string)            //指定文件路径,加载单个资源.
[s][T[]] LoadAll<T>(string)       //指定文件夹路径,加载多个资源.
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

