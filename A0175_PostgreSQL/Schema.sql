-- 建表
CREATE TABLE sale_report (
     sale_date  DATE NOT NULL ,
     sale_item  VARCHAR(2) NOT NULL ,
     sale_money DECIMAL(10,2) NOT NULL,
     PRIMARY KEY(sale_date, sale_item)
);


-- 测试数据

CREATE OR REPLACE FUNCTION InitQueryTestData() RETURNS void AS
$$
DECLARE
  v_begin_day  DATE;
  v_end_day  DATE;
BEGIN
  v_begin_day := '2009-01-01';
  v_end_day := '2013-01-01';

  WHILE v_begin_day < v_end_day LOOP
    INSERT INTO SALE_REPORT VALUES(v_begin_day,  'A',  EXTRACT(year FROM v_begin_day) );
    INSERT INTO SALE_REPORT VALUES(v_begin_day,  'B',  EXTRACT(month FROM v_begin_day) );
    INSERT INTO SALE_REPORT VALUES(v_begin_day,  'C',  EXTRACT(day FROM  v_begin_day) );
    v_begin_day := v_begin_day + 1;
  END LOOP;
END;
$$
LANGUAGE plpgsql;

SELECT InitQueryTestData();



-- 测试函数
CREATE OR REPLACE FUNCTION HelloWorld() RETURNS varchar AS
$$
BEGIN
  RETURN 'Hello World!';
END;
$$
LANGUAGE plpgsql;


-- 测试 IN/OUT 参数.
CREATE OR REPLACE FUNCTION HelloWorld2 (
  IN vUserName VARCHAR,
  OUT vOutValue VARCHAR
) AS
$$
BEGIN
  vOutValue := 'A' || vUserName;
END;
$$
LANGUAGE plpgsql;





-- 测试返回结果集的函数
CREATE OR REPLACE FUNCTION TestReturnList() RETURNS setof sale_report AS $$
  SELECT * FROM sale_report LIMIT 10;
$$ 
LANGUAGE SQL;



----- 服务器配置 -----
-- 如果 C# 客户端， 与 PostgreSQL 服务器， 不在同一台计算机的情况下。
-- 可能 Connection  Open 的时候， 会发生异常。

/**********

1、需要修改 服务器下的  pg_hba.conf   文件

在
# IPv4 local connections:
host    all             all             127.0.0.1/32            md5

后面， 追加一行
host    all             all             192.168.56.0/24         md5

注：192.168.56.0 这个网段， 需要根据世纪情况填写。  
测试环境下， PostgreSQL 数据库服务器的 ip 地址是 192.168.56.101 。 因此就填写 192.168.56.0 这个网段



2、查看 postgresql.conf 文件。
里面的  
listen_addresses = 

如果是  listen_addresses = '*'	， 那么没有问题。
如果是  listen_addresses = 'localhost'  ， 那么需要修改为 listen_addresses = '*'

**********/