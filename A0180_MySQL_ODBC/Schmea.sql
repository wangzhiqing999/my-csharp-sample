CREATE TABLE SALE_REPORT (
      SALE_DATE  DATETIME NOT NULL ,
      SALE_ITEM  VARCHAR(2) NOT NULL ,
      SALE_MONEY DECIMAL(10,2) NOT NULL
);

ALTER TABLE sale_report
  ADD CONSTRAINT pk_sale_report PRIMARY KEY(sale_date, sale_item);
  
  
DELIMITER //
CREATE PROCEDURE CreateReportData()
BEGIN
  DECLARE  v_begin_day  DATE;
  DECLARE  v_end_day  DATE;

  SET v_begin_day = STR_TO_DATE('2009-01-01', '%Y-%m-%d');
  SET v_end_day = STR_TO_DATE('2010-01-01', '%Y-%m-%d');

  WHILE v_begin_day < v_end_day DO
    INSERT INTO SALE_REPORT VALUES
      (v_begin_day,  'A',
          Year(v_begin_day) );
    INSERT INTO SALE_REPORT VALUES
      (v_begin_day,  'B',
          Month(v_begin_day) );
    INSERT INTO SALE_REPORT VALUES
      (v_begin_day,  'C',
          DAY(v_begin_day) );
    SET v_begin_day = DATE_ADD(v_begin_day, INTERVAL 1 DAY);
  END WHILE;
END;
//


mysql> call CreateReportData() //
