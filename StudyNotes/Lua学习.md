[toc]

# 基础语法

## Lua语言注意事项

1. **；**可有可无
2. 数组角标是从1开始



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
