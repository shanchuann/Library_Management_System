# BookMS - 图书管理系统

## 项目简介
BookMS 是一个基于 C# 开发的图书管理系统，提供了完整的图书管理、用户管理和借阅管理功能。系统采用 Windows Forms 开发，使用 SQL Server 作为数据库。

## 功能特性
- 用户管理
  - 管理员登录
  - 用户登录
- 图书管理
  - 图书信息录入
  - 图书信息修改
  - 图书信息查询
  - 图书库存删除
- 借阅管理
  - 图书借阅
  - 图书归还
  - 借阅记录查询

## 技术栈
- 开发语言：C#
- 开发框架：.NET Framework
- 数据库：SQL Server
- 界面框架：Windows Forms

## 数据库设计
系统包含以下主要数据表：
- `t_admin`: 管理员信息表
- `t_user`: 用户信息表
- `t_book`: 图书信息表
- `t_lend`: 图书借阅表

## 系统要求
- Windows 操作系统
- .NET Framework 4.0 或更高版本
- SQL Server 数据库

## 安装说明
1. 克隆项目到本地
2. 使用 Visual Studio 打开 `BookMS.sln` 解决方案
3. 还原 NuGet 包
4. 执行 `BookMS.sql` 脚本创建数据库
5. 编译并运行项目

## 使用说明
1. 管理员默认账号：admin
2. 管理员默认密码：123456
3. 用户可以通过修改t_user内容创建新账号，注册功能尚未实现

## 项目结构
- `Program.cs`: 程序入口
- `Dao.cs`: 数据库访问层
- `Data.cs`: 数据模型
- `login.cs`: 登录界面
- `admin*.cs`: 管理员相关功能界面
- `user*.cs`: 用户相关功能界面

## 许可证
本项目采用 MIT 许可证，详情请参见 LICENSE.txt 文件。