# Maple Leaf Student Information System （WebAPI）
这是专为枫叶国际高中教育体系制定的学生信息管理系统，旨在解决各领事之间对于学生管理的问题。
本系统类似于PowerSchool，并尽量模拟PowerSchool的操作逻辑。
本程序基于重庆枫叶国际学校高中部的现实情况开发，可能不适用于其他校区的情况。

## API
### [GET] /student
返回类型：List<[Student](#student)>
返回示例：
```json
[
  {
    "student_id": "XXXXXXXX",
    "student_name": "Zhang, San Sam",
    "student_class": "1001",
    "student_dorm": "D101"
  },
  ...
]
```

## 类
### Student
#### 参数
##### `string student_id`
学生ID
##### `string student_name`
学生姓名，一般根据中文姓名+英文名命名（与PowerSchool一致）
> 例：Zhang, San Sam
##### `string student_class`
学生行政班级，一般使用年级+班级的**全数字形式**
> 例：1001
##### `string student_dorm`
学生宿舍门牌号
#### 使用本类的接口
- 


