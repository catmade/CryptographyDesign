# 密码学大作业
自定义一种加密算法

## 性能

## 加密原理

|明文空间|明文长度|密文空间|密文长度
|:-:|:-:|:-:|:-:
|a-z|大于1|a-z|大于明文

|符号|a|b|c|d|e|f|g|h|i|j|k|l|m|n|o|p|q|r|s|t|u|v|w|x|y|z|
|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|
|值|0|1|2|3|4|5|6|7|8|9|10|11|12|13|14|15|16|17|18|19|20|21|22|23|24|25|
|频率||||||||||||||||||||||||||||||||||||||||||||||||||||

E 12.25
T 9.41
A 8.19
O 7.26
I 7.10
N 7.06
R 6.85
S 6.36
H 4.57
D 3.91
C 3.83
L 3.77
M 3.34
P 2.89
U 2.58
F 2.26
G 1.71
W 1.59
Y 1.58
B 1.47
V 1.09
K 0.41
X 0.21
J 0.14
Q 0.09
Z 0.08

|顺序|加密方法|限制
|-|-|-|
|1|维吉尼亚密码|
|2|仿射密码|
|3|希尔密码|加密矩阵的阶数大于3小于|
解密方法相反

### 1.维吉尼亚密码

e(x1, x2, ... xm) = (x1 * k1, ... xm * km)  

若分组长度为`L`，当明文分组后，最后一组长度不足时，只加密部分数据

### 2.仿射密码

### 3.希尔密码
#### 加密

设有如下明文：

|明文序号|1|2|3|4|5|6|7|8|9|10
|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:
|对应的值|12|0|1|6|18|25|6|20|25|25

- 先对明文进行处理，加上终结符

    根据统计，词频最低的为z = 0.08，z对应的是25，即在明文中z出现的频率比较低，将采用25作为明文的终结符。所以，加密时如果遇到25，需要将其转义，将其换成2个连续的25。

    分析如上明文，将所有的25都换成两个25，得到如下明文：
    |明文|1|2|3|4|5|6|7|8|9|10|11|12|13
    |:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:
    |值|12|0|1|6|18|25|25|6|20|25|25|25|25|

    在明文的最后加上一个25，作为终结符，得到如下密文：
    |明文|1|2|3|4|5|6|7|8|9|10|11|12|13|14
    |:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:
    |值|12|0|1|6|18|25|25|6|20|25|25|25|25|25

- 分组

    对明文进行分组，最后一组不足的补充0（也可以填充随机值，但是不便于分析，这里就先简单填充相同的字符），如果分组长度位8，则得到如下密文：

    |明文|1|2|3|4|5|6|7|8|9|10|11|12|13|14|15|16
    |:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:
    |值|12|0|1|6|18|25|25|6|20|25|25|25|25|25|0|0

- 加密

    直接分组加密

#### 解密

- 解密

    如果密文分组后，最后一组不是完整的组，说明密文和密钥不匹配，无法解密。否则正常解密

- 去冗余，得到明文

    假如解密后得到如下密文：

    |明文|1|2|3|4|5|6|7|8|9|10|11|12|13|14|15|16
    |:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:
    |值|12|0|1|6|18|25|25|6|20|25|25|25|25|25|0|0

    首先去除填充的数据和终结符，得到如下密文：

    |明文|1|2|3|4|5|6|7|8|9|10|11|12|13
    |:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:
    |值|12|0|1|6|18|25|25|6|20|25|25|25|25

    将两个连续的25合并为一个，得到如下明文：
    |明文|1|2|3|4|5|6|7|8|9|10
    |:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:
    |值|12|0|1|6|18|25|6|20|25|25|
