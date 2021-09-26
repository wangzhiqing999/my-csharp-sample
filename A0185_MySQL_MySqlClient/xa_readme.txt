XA

xa_start
负责开启或者恢复一个事务分支，并且管理XID到调用线程

xa_end
负责取消当前线程与事务分支的关联

xa_prepare
负责询问RM 是否准备好了提交事务分支

xa_commit
通知RM提交事务分支

xa_rollback
通知RM回滚事务分支




MYSQL XA
先检查服务器是否支持 XA
SHOW VARIABLES LIKE '%xa%'




测试表.

CREATE TABLE test_xa (
  id      INT   NOT NULL,
  value   INT,
  PRIMARY KEY(id)  
);



单机测试操作.

-- 测试最终提交的操作.

XA START 'xid_001';

INSERT INTO test_xa (id, value) VALUES (1, 100);

XA END 'xid_001';

XA PREPARE 'xid_001';

XA COMMIT 'xid_001';




-- 测试最终回滚的操作.

XA START 'xid_002';

INSERT INTO test_xa (id, value) VALUES (2, 200);

XA END 'xid_002';

XA PREPARE 'xid_002';

XA ROLLBACK 'xid_002';





-- 测试语句部分失败的情况.

XA START 'xid_003';

-- 插入重复主键的数据，直接失败.
INSERT INTO test_xa (id, value) VALUES (1, 200);

XA END 'xid_003';

-- 返回 0 行数据.
xa recover;


-- 结束掉事务. 否则后面没法开新的测试.
XA ROLLBACK 'xid_003';






-- 测试其它会话的情况. （其它会话未开启事务，自动提交）


-- 初始数据.
select * from test_xa;
id  value
1	100




XA START 'xid_004';

UPDATE 
  test_xa
SET 
  value = value + 10
WHERE 
  id = 1;

XA END 'xid_004';
XA PREPARE 'xid_004';




-- 这里，开个新的 MySQL 客户端
-- 执行查询. 正常返回.
select * from test_xa;

id  value
1	100


-- 执行更新. （由于数据已经在前面锁定， 这里被卡死，超时后报错返回）
-- 但是由于这里没有主动开启事务， 也就是 自动提交的。 导致后面的数据还是有问题。
UPDATE 
  test_xa
SET 
  value = value + 11
WHERE 
  id = 1;

Error Code: 2013. Lost connection to MySQL server during query	30.016 sec





-- 正式提交事务.

XA COMMIT 'xid_004';


-- 核对数据： （前面的那个 卡死报错的， 最终也执行了）
select * from test_xa;
id  value
1	121








-- 测试其它会话的情况. （其它会话 开启事务）


-- 初始化测试数据.
UPDATE 
  test_xa
SET 
  value = 100
WHERE 
  id = 1;


-- 客户端1.


XA START 'xid_005';

UPDATE 
  test_xa
SET 
  value = value + 10
WHERE 
  id = 1;

XA END 'xid_005';
XA PREPARE 'xid_005';





-- 客户端2.


XA START 'xid_006';

UPDATE 
  test_xa
SET 
  value = value + 11
WHERE 
  id = 1;

XA END 'xid_006';

-- 由于前面更新语句发生异常， 这里需要做回滚操作.
XA XA ROLLBACK  'xid_006';







-- 客户端1.

XA COMMIT 'xid_005';





-- 核对数据： 符合预期.
select * from test_xa;
id  value
1	110















多服务器测试。

服务器 A，  与服务器 B。

都使用前面的那个  test_xa  测试表.
都有一行  id = 1 , value  = 100 的数据.



CASE1. 都成功的情况.
A 先 PREPARE 成功， 然后，B 也 PREPARE 成功， 最后 A 与 B 都提交.
A: 
UPDATE 
  test_xa
SET 
  value = value + 10
WHERE 
  id = 1
;

B:  
UPDATE 
  test_xa
SET 
  value = value + 10
WHERE 
  id = 1
;






CASE2. A失败的情况.
A PREPARE 失败， 然后，B 就直接跳过处理了。






CASE3. A成功，B失败的情况.

A 先 PREPARE 成功， 然后，B PREPARE 失败，  然后， A 需要做回滚.















