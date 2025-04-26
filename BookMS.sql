-- ��������Ա��
CREATE TABLE t_admin (
    id VARCHAR(20) PRIMARY KEY,
    psw VARCHAR(20) NOT NULL
);

-- �����û���
CREATE TABLE t_user (
    id VARCHAR(20) NOT NULL PRIMARY KEY,
    name VARCHAR(50) NOT NULL,
    sex CHAR(2) CHECK (sex IN ('��', 'Ů')), -- �����Ա�����
    psw VARCHAR(20) NOT NULL
);

-- ����ͼ���
CREATE TABLE t_book (
    id VARCHAR(50) PRIMARY KEY,
    name VARCHAR(50) NOT NULL,
    author VARCHAR(20) NOT NULL,
    press VARCHAR(20) NOT NULL,
    number INT NOT NULL CHECK (number >= 0) -- ��治��Ϊ����
);

-- ���������֧��ͬһ�û���ν���ͬһ���飩  *����������������
--CREATE TABLE t_lend (
--    uid INT NOT NULL,
--    bid INT NOT NULL,
--    datetime DATETIME NOT NULL
--);

-- ��������
-- �����Ա�����һ������
INSERT INTO t_admin (id, psw)
VALUES ('admin', '123456');
SELECT * FROM t_admin;
-- ���û��������������
INSERT INTO t_user (id, name, sex, psw)
VALUES 
  ('1001', '����', '��', '123'),
  ('1002', '����', 'Ů', '456');
SELECT * FROM t_user;
-- ����һ��ͼ�����ݣ�ʾ����
INSERT INTO t_book (id, name, author, press, number)
VALUES (
    'ISBN978-7-123-45678-0', 
    '�����������ϵͳ', 
    '���¶���E����������', 
    '��е��ҵ������', 
    10
);
-- ����ڶ���ͼ�����ݣ�ʾ����
INSERT INTO t_book (id, name, author, press, number)
VALUES (
    'ISBN978-7-123-45679-0', 
    '�㷨����', 
    '����˹��H���ƶ���', 
    '��ʡ��������', 
    5
);
SELECT * FROM t_book;
-- �޸�����
UPDATE t_book SET id = '2',name = '2',author = '2',press = '2',number = '2' WHERE id = '1';
-- ��ѯ����
select * from t_book WHERE name LIKE '%�㷨%';
-- ���¶�t_lend���������
INSERT INTO t_lend values('1001','ISBN978-7-123-45678-3',getdate());
SELECT * FROM t_lend;
update t_book set number = 2 where id = '3';
-- �黹ͼ��
SELECT no,bid,name,datetime FROM t_lend,t_book WHERE uid = '1001';
DELETE FROM t_lend WHERE no = 3;
UPDATE t_book SET number = number + 1 WHERE id = 'ISBN978-7-123-45678-0';