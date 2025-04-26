-- 创建管理员表
CREATE TABLE t_admin (
    id VARCHAR(20) PRIMARY KEY,
    psw VARCHAR(20) NOT NULL
);

-- 创建用户表
CREATE TABLE t_user (
    id VARCHAR(20) NOT NULL PRIMARY KEY,
    name VARCHAR(50) NOT NULL,
    sex CHAR(2) CHECK (sex IN ('男', '女')), -- 限制性别输入
    psw VARCHAR(20) NOT NULL
);

-- 创建图书表
CREATE TABLE t_book (
    id VARCHAR(50) PRIMARY KEY,
    name VARCHAR(50) NOT NULL,
    author VARCHAR(20) NOT NULL,
    press VARCHAR(20) NOT NULL,
    number INT NOT NULL CHECK (number >= 0) -- 库存不能为负数
);

-- 创建借书表（支持同一用户多次借阅同一本书）  *舍弃，需设置自增
--CREATE TABLE t_lend (
--    uid INT NOT NULL,
--    bid INT NOT NULL,
--    datetime DATETIME NOT NULL
--);

-- 插入数据
-- 向管理员表插入一条数据
INSERT INTO t_admin (id, psw)
VALUES ('admin', '123456');
SELECT * FROM t_admin;
-- 向用户表插入两条数据
INSERT INTO t_user (id, name, sex, psw)
VALUES 
  ('1001', '张三', '男', '123'),
  ('1002', '李四', '女', '456');
SELECT * FROM t_user;
-- 插入一条图书数据（示例）
INSERT INTO t_book (id, name, author, press, number)
VALUES (
    'ISBN978-7-123-45678-0', 
    '深入理解计算机系统', 
    '兰德尔·E·布莱恩特', 
    '机械工业出版社', 
    10
);
-- 插入第二条图书数据（示例）
INSERT INTO t_book (id, name, author, press, number)
VALUES (
    'ISBN978-7-123-45679-0', 
    '算法导论', 
    '托马斯·H·科尔曼', 
    '麻省理工出版社', 
    5
);
SELECT * FROM t_book;
-- 修改数据
UPDATE t_book SET id = '2',name = '2',author = '2',press = '2',number = '2' WHERE id = '1';
-- 查询数据
select * from t_book WHERE name LIKE '%算法%';
-- 重新对t_lend表插入数据
INSERT INTO t_lend values('1001','ISBN978-7-123-45678-3',getdate());
SELECT * FROM t_lend;
update t_book set number = 2 where id = '3';
-- 归还图书
SELECT no,bid,name,datetime FROM t_lend,t_book WHERE uid = '1001';
DELETE FROM t_lend WHERE no = 3;
UPDATE t_book SET number = number + 1 WHERE id = 'ISBN978-7-123-45678-0';