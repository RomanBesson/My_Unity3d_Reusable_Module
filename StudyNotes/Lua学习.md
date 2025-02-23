[toc]

# 基础语法

## Lua语言注意事项

1. **；**可有可无
2. 数组角标是从1开始
3. Lua 语言中实例对象调用自身的方法要用`：`号，静态变量或者属性用`.`
4. Lua 语言中的小数不需要加“f”后缀。



## 注释

### 多行注释

```lua
--[[

这是多行注释
这是多行注释
这是多行注释

--]]


--[[

这是多行注释
这是多行注释
这是多行注释

]]

--[[

这是多行注释
这是多行注释
这是多行注释

]]--
```



### 单行注释

```lua
-- 这是单行注释
```



## 变量

**number**：数值类型，可以存储整数和小数；

**boolean**：布尔类型，只有 true 和 false 两个值；

**string**：字符串类型，双引号，单引号都可以，lua 中无 char 类型。

```lua
name = "ash"

print(name)

print(type(name))
```



## 运算符

### 特殊符号

- C#和 Lua 语言中“=”**都是**赋值符

- C#语言中的“＋”号有两个含义：数学意义上的相加，字符串相连，Lua 语言中的“+”号**仅仅是数学意义上的相加；**

- Lua 语言中**字符串相连**需要用到一个新的符号   **“ .. ”**

- C#语言中：有++和--，Lua 语言中：**没有**

### 常用运算符

**1.算数运算符**

符号： **+ - * / %**

对比： C#与 Lua 算数运算符**相同**

**2.复合赋值运算符**

符号： +=  -=  *=  /= %= 

对比： Lua 语言中**无复合赋值运算符**

**3.关系运算符**

符号： > < >= <= == != 

对比： C#当中的不等于是!=，**Lua 当中的不等于是~=**

**4.逻辑运算符**

符号： && || !

对比： 在 Lua 语言中，没有这三个符号，而是三个单词 **and，or，not。**



## 分支结构

### if 语句

```lua
num = 3;

if(num>4)
then
  print("大于4")
else
  print("小于4")
end
```

### if...else if...语句

```lua
num = 4;

if(num > 10)
then

  print("大于10")

elseif(num > 3)
then

  print("大于3")

else

  print("小于等于3")

end
```

### [无]switch 语句

没有。



## 循环结构

### for 语句

```lua
--  初始值, <=10, 每次加几
for i = 0, 10, 1
do

  print(i)

end
```

### while 语句

```lua
while(true)
do

  print(1)

end
```

### [伪]do...while 语句

没有，但是有do  .... notwhile.
         也就是假的时候才执行。

```lua
repeat
    
--假的时候才一直执行，条件为真只执行一次
  print("1")

until(false)
```

### break

立刻结束当前循环；C#和 Lua 中都有. 

### [无]continue

立刻结束本次循环；

C#中有，但是 lua 中没有.



## 数组



数组名 = {数据 1，数据 2，数据 3，数据 N}



> **注意：**
>
> - for 循环遍历数组，数组的下标是从 1 开始.
> - Lua 版本的数组可以存放多种不同类型的数据.
> - C#版本的数组是固定长度的；而 Lua 版本的数组的长度则是不固定的，声明完毕数组后，我们依然是可以往后续的下标位置上添加值.



```lua
array = {"dada", 1, true}

--取数组长度需要用到一个方法：table.getn(数组名)
for i = 1, table.getn(array), 1
do

  print(array[i])

end
```



## 函数

```lua
--无参
function Hello()

print("hellop")

end


Hello()

--有参
function Add(a, b)

return a+b;

end

print(Add(1,2))

--把无参函数当方法传递
function Event(fuc)

  fuc()

end

Event(Hello)

--把有参函数当方法传递
function Event_New(a, b, func)

  return func(a, b)

end

print(Event_New(1,2,Add))

```

## Local 函数变量作用域

### c#中的全局和局部变量的区别

- 全局变量声明完毕后，就算不手动初始化赋值，也是有默认值的；
- 但是局部变量声明完毕后，如果不给它手动赋值，是无法直接使用这个变量的。

### Lua中的作用域

如果想在 Lua 中声明局部变量，需要使用“**local**”关键字明确标示出来，否则Lua默认变量都是全局的（函数里的也是）。

不过在同一个类不在函数里的变量，即使用**local**修饰了，也是全局的。（private）

同一个类里只有函数里的变量用 local 修饰才是局部的。

## 字符串

**在 Lua 语言中，字符串有三种表现形式：**

①用双引号包裹，**“Monkey”**

②用单引号包裹，**‘Monkey’**

③用两个中括号包裹，**[[Monkey]]**

在 Lua 中双引号，单引号效果几乎是一样的，中括号比较特殊，中括号包裹的字符串是原格式输出；(可以换行，类似于js ``)


### 常用转义符

**常用转义符：**

`\n`：换行

`\\`：一个\

`\”`：一个”

`\’`:一个’

### 常用函数

#### 字母大小写转换

```lua
string.upper( 字符串变量 )：字母全部转大写格式；

string.lower( 字符串变量 )：字母全部转小写格式；
```



#### 字符串反转

```lua
string.reverse( 字符串变量 )：将字符串进行位置反转。
```



#### 字符串长度

```lua
string.len( 字符串变量 )：返回字符串的长度. 
```

**注意：单个字母，数字，符号长度都为 1；单个汉字长度为 2。**

#### 字符串替换

```lua
string.gsub（原始字符串，旧字符串，新字符串，[替换次数]）
```

在原始字符串中查找旧字符串，如果找到了，就用新字符串把旧的替换掉；替换次数可以不写，则表示全部替换。

#### 字符串格式化

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

```lua
table1 = {}
--数组结构
table1[1] = 1
table1[2] = 2
table1[3] = "s"
--键值对结构
table1["sda"] = "das"

print(table1[3]) -- 输出 s

--第一种迭代器 遍历方法或者用for 只能遍历数组结构，键值对结构的不会输出
for key, value in ipairs(table1) do
	print(key, value)
end

--第二种 可以遍历键值对和数组结构 table.getn（）不能获取键值对结构的长度，要用以下迭代器获取
index = 0
for key, value in pairs(table1) do
	print(key, value)
	index = index + 1
end

print("键值对模式:" .. index)

```

### table 相关方法

#### <1>**增加元素**

```lua
table.insert(表名, [位置], 值)
```

往指定的位置增加元素，如果不写位置，默认往最后一个位置增加。

这个方式适合“数组模式”，不太适合“键值对模式”。

键值对就用：表名[‘键’] = 值 的方式添加即可。

#### <2>移除元素

```lua
table.remove(表名, [位置])
```

如果不写位置，默认移除最后一个元素，如果位置值超出范围，不会报错，也不

会有元素被移除。

这个方式适合“数组模式”，不能用于“键值对模式”。

键值对就用：表名[‘键’] = nil 的方式移除即可。

#### <3>table 长度

```lua
table.getn(表名)
```

返回 table 表的长度。

这个方式适合“数组模式”，不能用于“键值对模式”。

键值对就用：迭代器迭代，然后累加一个变量的方式获得长度。



### 模块

**Lua 语言中的模块在功能上其实类似于 C#当中我们写一个静态的工具类**

table可以作为模块输出给其他类。

```lua
table1 = {}
table1[1] = 1
table1[2] = 2
table1[3] = "s"
table1["sda"] = "das"


return table1

```

其他类可以通过 require 引用

```lua
--require("calc") --引入指定模块.
require ("1")


--访问模块中的变量.

print(table1[1])

```

又或者

```lua
calc = {} --初始化模块.

--定义一个变量.
calc.name = "Monkey计算器模块"

--定义函数.
function calc.jia(a, b)
	return a + b
end

function calc.jian(a, b)
	return a - b
end

function calc.cheng(a, b)
	return a * b
end

function calc.chu(a, b)
	return a / b
end

return calc --结束模块.

```

```lua
--require("calc") --引入指定模块.
require "calc"


--访问模块中的变量.
print(calc.name)
--calc.name = "擅码网"
--print(calc.name)


--访问模块中的函数.
a = 10
b = 2
print(calc.jia(a, b))
print(calc.jian(a, b))

```

## Metatable 元表

**元表（metatable）就是让两个表之间产生“附属”关系，只需要操作主表，就可以间接的操作元表**

![Lua元表](../Img/Lua%E5%85%83%E8%A1%A8.png)

### 元表基本语法

<1>实例化两个普通表[表 A 和表 B]；

<2>关联两个表[将表 B 设置成表 A 的元表]，需要用一个新的函数：

**setmetatable(表 A, 表 B) [见图]**

**<3>getmetatable(表名)**

如果表名有元表，就返回元表的类型和地址；如果没有元表，则返回一个 nil。

### 使用__index访问元表

一般来说，元表内的成员，我们是访问不到的，会返回 nil。要想访问就要设置__index。



**元表名.__index = 元表名**

```lua

--[[
tableA = {} --表A [主表]
tableB = {} --表B [元表/子表]

setmetatable(tableA, tableB) -- tableB就是tableA的元表.

print(getmetatable(tableA)) -- 判断tableA是否有元表

--]]


tableA = {name = "Monkey", age = 100}
tableB = {gender = "男", address = "山东济宁"}

setmetatable(tableA, tableB)
tableB.__index = tableB -- 设置元表的__index索引.

print(tableA.name, tableA.age)
--print(tableA["name"])
print(tableA.gender, tableA.address)


```

## 类与对象

### 类和对象

```lua
--类
Person = {name = "kkk", age = 12}

--构造方法 （self 也都可以换成 Person）
function Person:New()
	local obj = {}
	setmetatable(obj, self)
	self.__index = self
	return obj
end

P1 = Person:New()

print(P1.name)

--有参构造方法
function Person:New(name, age)
	local obj = {}
	setmetatable(obj, self)
	self.__index = self
	self.age = age
	self.name = name
	return obj
end

--对象
P1 = Person:New("aa", 1)

print(P1.name)

```

### 继承

```lua
--类
Person = {name = "kkk", age = 12}

--有参构造方法
function Person:New(name, age)
	local obj = {}
	setmetatable(obj, self)
	self.__index = self
	self.age = age
	self.name = name
	return obj
end

function Person:ToString()
	print (string.format("姓名: %s  年龄：%s", self.name, self.age))
end


--继承
Man = Person:New()

function Man:New(name, age)
	local obj = Person:New(name, age)
	setmetatable(obj, self)
	self.__index = self
	return obj
end

function Man:say()
	print("男的")
end

man = Man:New("nan", 18)

man:ToString()
man:say()


```

### 类和实际对象分离

```lua
dofile("..\\myp\\Person.lua") --Person.lua文件在该文件的父文件夹的myp文件夹里

p1 = Man:New("ss",22)

p1:ToString()

```



# Lua和c#交互

## LuaInterface的配置和使用

**LuaInterface** 是一个开源的项目工程，内部有两个核心的 DLL 文件：

①**LuaInterface.dll**：在 C#代码中操作 Lua 代码需要依赖该文件；

②**luanet.dll**：在 Lua 代码中访问 C#的类库脚本需要依赖该文件。

> **环境配置细节**
>
> ①将两个 dll 文件拷贝到项目工程中；
>
> ②项目工程设置“引用”导入 LuaInterface.dll；
>
> **③将两个 dll 的属性都设置成“如果较新则复制”。**



LuaInterface 开启了一块lua解析代码空间，所有lua相关代码都被转化在那里与逆行

![两块代码空间](../Img/%E4%B8%A4%E5%9D%97%E4%BB%A3%E7%A0%81%E7%A9%BA%E9%97%B4.png)

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

# Unity资源包管理热更新

## AssetBundle

### AssetBundle介绍

AssetBundle 是 Unity 引擎提供的一种资源打包方式，可以对 Unity 内除了“C#脚本文件”以外的任何资源类型进行打包处理，可以将一个或者多个资源进行打包管理，顺带还可以对资源的体积进行压缩。

### AssetBundle使用

点击要打包的资源，在它的信息面板的下方就有对应的 AssetBundle 打包设置。

### DLC: 编辑器扩展特性

就是可以把方法显示到unity上方工具栏的特性，点击对应工具栏选项卡即可调用对应方法。

使用起来也十分简单

```csharp
在方法的上方添加一个“特性”：[MenuItem("menu/itemName")]
```

### AssetBundle常用Api	

#### 打包

```csharp
BuildPipeline.BuildAssetBundles(路径, 选项, 平台);
```

参数分析：

- BuildAssetBundles：打包所有设置了 AssetLabels 的资源；

- 路径：打包出来的 AssetBundle 文件存放的位置；
- 选项：设置 AssetBundle 打包过程中的选项，None 表示忽略该选项；
- 平台：AssetBundle 是平台之间不兼容的，IOS，Android 是两套资源；

#### 打包压缩选项

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

#### 加载 AB 资源到内存

```csharp
AssetBundle ab = AssetBundle.LoadFromFile("AB 包完整路径")
```

从一个完整的路径位置加载 AB 资源包到内存，返回一个 AssetBundle 对象. 

#### 从 AB 资源中获取资源

```csharp
T resName = ab.LoadAsset<T>("游戏资源名称")
```

通过获取到的 AssetBundle 对象的“加载资源”方法，从 AssetBundle 对象内获取对应的游戏物体资源，并且返回该资源. 

**备注：这句话的效果类似于使用 Resources.Load 加载一个资源.**



### manifest文件相关介绍

manifest 文件和.meta 文件作用类似。

manifest 文件是用于专门存储打包后的 AssetBundle 文件的基本信息的。

**主要包含以下信息：**

**CRC 校验码**：类似于 MD5，用于计算出该资源的一个特殊信息标示；

**ClassTypes 列表**：当前资源关联使用到了 Unity 中的哪些类（组件），这些类是以编号索引的形式存在的，每个编号都对应一个类文件。



#### 目录 manifest 文件

在我们打包出来的 AssetBundle 文件中，有一个特殊的 manifest （`AssetBundles.manifest`）文件。

这个 manifest 文件是和用于存储 AssetBundle 的文件夹同名的文件，且只在根文件夹下有唯一的一个。

这个 manifest 文件可以称之为“AssetBundle 目录文件”，因为这个文件中内存储了打包出来的所有的 AssetBundle 的文件的索引信息。通过这个目录文件，可以找到所有的 AssetBundle 文件。

### AssetBundle 使用场景：将 AssetBundle资源 留在项目工程中使用

1. #### 加载 AB 资源到内存

```csharp
AssetBundle ab = AssetBundle.LoadFromFile("AB 包完整路径")
```

从一个完整的路径位置加载 AB 资源包到内存，返回一个 AssetBundle 对象. 

2. #### 从 AB 资源中获取资源

```csharp
T resName = ab.LoadAsset<T>("游戏资源名称")
```

通过获取到的 AssetBundle 对象的“加载资源”方法，从 AssetBundle 对象内获取对应的游戏物体资源，并且返回该资源. 

**但是要注意，我们尽量不要使用 `Application.dataPath `+ 某个路径 来当做AssetBundle 资源的储存位置。**

因为Unity打包后，它会压缩这些文件夹，到时候会出现找不到文件的情况。

此时，就要使用 `streamingAssetsPath`。

```csharp
Application.streamingAssetsPath + "fileName"
```

**StreamingAssets** 文件夹不会被压缩，所以可以储存一些需要更新的加载文件，或者是一些需要存在本地的json数据。使用的时候需要在 **Assets **文件夹下创建 **StreamingAssets** 文件夹。



### AssetBundle 使用场景：从服务器端下载AssetBundle 资源并且使用

#### 获取服务器中的资源

先引入网络相关命名空间。

```csharp
using UnityEngine.Networking;
```

创建一个获取 AssetBundle 文件的 web 请求. 

```csharp
UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(url);
```

发送这个 web 请求. 

```csharp
yield return request.Send();
```

从 web 请求中获取内容，会返回一个 AssetBundle 类型的数据. 

```csharp
AssetBundle ab = DownloadHandlerAssetBundle.GetContent(request);
```

从这个“目录 AssetBundle”中获取 manifest 数据. 

```csharp
AssetBundleManifest manifest = ab.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
```

获取这个 manifest 文件中所有的 AssetBundle 的名称信息.

```csharp
string[] assets = manifest.GetAllAssetBundles();
```

 

#### **服务器端下载所有文件**

通过获取到的 AssetBundle 对象获取内部所有的资源的名称，返回一个数组. 

```csharp
string[] names = ab.GetAllAssetNames();
```

截取路径地址中的文件名，且无后缀名. 需要引入 System.IO 命名空间

```csharp
[string]Path.GetFileNameWithoutExtension(path)
```

### 将服务器中的AssetBundle资源下载到本地 

#### WWW 下载资源

通过 WWW 类创建一个 web 请求，参数填写 AssetBundle 的 url 下载地址. 

```csharp
WWW www = new WWW(url);
```

将对象作为数据返回，这个 www 对象就是请求(下载）来的数据. 

```csharp
yield return www;
```

一个属性，表示下载状态是否完毕. 

```csharp
[bool]www.isDone 
```

再使用 if 语句块判断，当这个属性为真时，就可以使用 IO 技术把这个 www 对象作为AssetBundle 存储到本地。

#### IO 存储资源

创建一个文件信息对象. 

```csharp
FileInfo fileInfo = new FileInfo(文件完整路径+名称);
```

通过文件信息对象的“创建”方法，得到一个文件流对象. 

```csharp
FileStream fs = fileInfo.Create();
```

通过文件流对象，往这个文件内写入信息. 

```csharp
fs.Write(字节数组, 开始位置, 数据长度);	
```

文件写入存储到硬盘，关闭文件流对象，销毁文件对象.

```csharp
fs.Flush();

fs.Close();

fs.Dispose();
```

> 具体案例见`ExampleScripts/Lua`文件夹下的 `DownLoadAssetBundle.cs`文件。

# Xlua框架

## 基础介绍环境搭建

XLua 是腾讯开发分享出来的一个开源项目，主要用于 Unity 项目的热更新。

XLua 地址：https://github.com/Tencent/xLua

**XLua 分两个版本：**

- 完整版->用于学习和研究[Clone or download->download ZIP]；
- 开发版->用于项目的实际开发[releases->Downloads]。

### XLua 资源结构

#### Assets 资源

**Plugins：XLua 在各个平台运行需要使用到的 dll 库文件；**

XLua：XLua 核心文件夹；

**Doc：教程文档；**

Examples：XLua 官方自带示例工程；

**Resources：资源文件夹；**

**Scr：XLua 源码；**

Tutorial：教程示例场景；

#### 其他资源[源码]

build：支持库文件的源码；

docs：文档；

General：是 Tools 工具的源码；

Test：测试工程；

**Tools：工具；**

WebGLPlugins：webGL 支持库源码；

> 上面介绍的资源结构是 XLua 完整版所有的资源结构；**加深标示出来的是开发版具备的资源；**

**项目中使用XLua只需要将Plugins和XLua两个文件夹拷贝到U3D中即可**

## c#和lua的互相调用

**将 XLua 中的 Plugins 和 XLua 文件夹拷贝到项目中；**

### C#调用 Lua

#### C#代码内执行 Lua 代码

```csharp
LuaEnv luaEnv = new LuaEnv();

luaEnv.DoString("print('mkcode')");
```

**注意事项：**

①需要引入 XLua 的命名空间：**using XLua;**

②在 XLua 中，运行 Lua 代码的虚拟机是 LuaEnv；

**③一个 LuaEnv 实例就是一个 Lua 虚拟机，出于开销的考虑，建议全局唯一。**

#### C#调用外部的 Lua 代码文件

①在` Xlua/Resources `文件夹下**创建一个 lua 文件，文件的后缀是 txt**；XLua 中完整的 Lua 文件名格式如下：fileName.lua.txt。

②然后在 C#代码中用 Lua 虚拟机的 DoString 方法加载执行该 lua 文件；

```csharp
luaEnv.DoString("require 'fileName'")
```

#### C#获取 Lua 代码中的数据

```csharp
//获取 lua 中数值. 
luaEnv.Global.Get<int>("a"); 

//获取 lua 中字符串.
luaEnv.Global.Get<string>("b"); 

 //获取 lua 中布尔. 
luaEnv.Global.Get<bool>("c"); 

//获取 lua 中方法.
luaEnv.Global.Get<LuaFunction>("D"); //执行用Call
```

### Lua 调用 C#

```lua
//获取 C#中的类. 
CS.UnityEngine.GameObject 

//获取 C#中的方法. 
CS.UnityEngine.Debug.Log() 

//获取 C#中的方法.
CS.UnityEngine.GameObject.Find() 
```

**注意事项：Lua 调用 C#，需要在 C#的命名空间之前要加前缀：“CS.”。**

## 热更新 HotFix 热补丁

### 配置HotFix 

#### 添加宏信息

File--> Build Settings... --> Player Settings...--> Other Settings--> Script Compliation --> ConfigurationScripting Define Symbols：**HOTFIX_ENABLE**

**之后顶部就会由xlua的显示。**

#### 执行菜单生成命令

XLua->Generate Code，该命令执行完毕后会生成一堆 Wrap 文件，存放到 XLua/Gen 文件夹下。

#### 执行菜单注入命令

XLua->Hotfix Inject In Editor，成功之后，会在控制台输出：“hotfix inject finish!”或者“had injected!”。

> **Bug：如果出现红色警告提示“please install the Tools”，就需要把 Tools 文件夹拷贝到项目中，和 Assets 文件夹同级别位置。**

**完成这三步操作，HotFix 的开发环境就配置完毕了。**

### 热更新的使用

####  HotFix 特性标签

在使用 C#语言开发项目时，需要后续进行“热补丁修复”的类，需要在类的头部添加一个特性标签：[Hotfix]，表示该类可以被 XLua 热修复。

#### Hotfix 语法

```csharp
xlua.hotfix(CS.类名, '方法名', lua 方法)
```

说明：这个是 lua 代码结构，需要使用 Lua 虚拟机对象中的 DoString 方法执行。含义就是：某个类中的某个方法，你用 lua 方法进行修复。

> 注意：
>
> 1. **我们每次修改完毕 C#，都需要执行一次“注入命令”；**
> 2. 有参方法修复时，需要传递当前脚本对象 this，在 lua 中用 self 代替。

#### DLC: Lua 访问 C#脚本内的私有字段

##### 方法一：改成公有然后用self访问

可以在 lua 代码内通过“self.字段名”进行访问，但是这样有一个前提，就是该字段必须是 public 修饰的，private 修饰的访问不到。

**但是这样有一个弊端，破坏了 C#语言本身的“封装性”。**

##### 方法二：在 lua 语言中，使用代码获取 C#类中 private 成员的访问权（推荐）

```csharp
xlua.private_accessible(CS.类名)
```

加上这句话，就可以在 Lua 脚本中访问到 C#类当中的私有成员，同时不会破坏 C#原有的封装性和逻辑关系。

例如：

```lua
xlua.private_accessible(CS.CreateWall)
xlua.hotfix(CS.CreateWall, 'CreateCubeWall', function(self)
	for i = 0, 1, 1 do
		for j = 0, 1, 1 do
			GameObject.Instantiate(self.prefab_Cube, Vector3(i, j, 0), Quaternion.identity);
		end
	end
	print(self.webURL)
end)

```

之后就可以使用c#类 `CreateWall`的私有字段了。 



