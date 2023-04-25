# Maple Leaf Student Information System （WebAPI）

这是专为枫叶国际高中教育体系制定的学生信息管理系统，旨在解决各领事之间对于学生管理的问题。
本系统类似于PowerSchool，并尽量模拟PowerSchool的操作逻辑。
本程序基于重庆枫叶国际学校高中部的现实情况开发，可能不适用于其他校区的情况。

## API

### [GET] /student

返回类型：List<[Student](#student)>

返回示例：Ok(200)

```json
[
  {
    "student_id": "XXXXXXXX",
    "student_name": "Zhang, San Sam",
    "student_class": "1001"
  },
  ...
]
```

### [GET] /student/{id}

返回类型：[Student](#student)

返回示例：Ok(200)

```json
{
  "student_id": "XXXXXXXX",
  "student_name": "Zhang, San Sam",
  "student_class": "1001"
}
```

#### 内联参数

##### string id

提供学生ID以用于数据库查找

### [POST] /student

返回类型：[Student](#student)

返回示例：Created(201)

```json
{
  "student_id": "XXXXXXXX",
  "student_name": "Zhang, San Sam",
  "student_class": "1001"
}
```

#### Body

提供类型：[Student](#student)

HTTP类型：application/json

### [PUT] /student/{id}

返回类型：[Student](#student)

**注意：student_id条目不可修改**

返回示例：Ok(200)

```json
{
  "student_id": "XXXXXXXX",
  "student_name": "Zhang, San Sam",
  "student_class": "1001"
}
```

#### 内联参数

##### string id

提供学生ID以用于数据库查找

### [DELETE] /student/{id}

返回类型：无

返回示例：Ok(200)

#### 内联参数

##### string id

提供学生ID以用于数据库查找

### [GET] /counselor

返回类型：List<[Counselor](#counselor)>

返回示例：Ok(200)

```json
[
  {
  	"counselor_name": "Zhang, San Sam",
  	"counselor_type": 1,
  	"classe": ["1001", "1002"]
	},
  ...
]
```

### [GET] /counselor/{name}

返回类型：[Counselor](#counselor)

返回示例：Ok(200)

```json
{
  "counselor_name": "Zhang, San Sam",
  "counselor_type": 1,
  "classe": ["1001", "1002"]
}
```

#### 内联参数

##### string name

提供领事姓名以用于数据库查找

### [POST] /counselor

返回类型：[Counselor](#counselor)

返回示例：Created(201)

```json
{
  "counselor_name": "Zhang, San Sam",
  "counselor_type": 1,
  "classe": ["1001", "1002"]
}
```

#### Body

提供类型：[Counselor](#counselor)

HTTP类型：application/json

### [PUT] /student/{id}

返回类型：[Counselor](#counselor)

**注意：counselor_name条目不可修改**

返回示例：Ok(200)

```json
{
  "counselor_name": "Zhang San",
  "counselor_type": 1,
  "classe": ["1001", "1002"]
}
```

#### 内联参数

##### string id

提供领事姓名以用于数据库查找

### [DELETE] /counselor/{name}

返回类型：无

返回示例：Ok(200)

#### 内联参数

##### string name

提供领事姓名以用于数据库查找



## 类

### Student

#### 参数

##### [Key] string student_id

学生ID

##### string student_name

学生姓名，一般根据中文姓名+英文名命名（与PowerSchool一致）

> 例：Zhang, San Sam

##### string student_class

学生所在班级，一般使用年级+班级的**全数字形式**

> 例：1001

#### 使用本类的接口

- [[GET] /student](#get-student)
- [[GET] /student/{id}](#get-studentid)
- [[POST] /student](#post-student)
- [[PUT] /student/{id}]($put-studentid)
- [[DELETE] /student/{id}](#delete-studentid)

### Counselor

#### 参数

##### [Key] string counselor_name

领事姓名

##### [CounselorType](#counselortype) counselor_type

领事类型

##### List\<string> classes

领事所管辖的班级

> 总领事管理拥有所有班级的管理权，此项留空

#### 使用本类的接口

- [[GET] /student](#get-counselr)
- [[GET] /student/{id}](#get-counselorid)
- [[POST] /student](#post-counselor)
- [[PUT] /student/{id}]($put-counselorid)
- [[DELETE] /student/{id}](#delete-counselorid)

### Class

#### 参数

##### [Key] string class_name

班级名称，一般使用年级+班级的**全数字形式**

> 例：1001

##### string  counselor_name

负责管理本班领事的姓名

##### List\<string> students

本行政班级内的学生列表，使用学生的ID进行编录


## 枚举

### CounselorType

继承自：Int32

定义：

```
GeneralCounselor = 0,
Counselor = 1,
CounselorAssitant = 2
```

#### 使用本枚举的类

- [Counselor](#counselor)
