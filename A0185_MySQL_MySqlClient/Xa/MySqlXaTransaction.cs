using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

using MySql.Data.MySqlClient;


namespace A0185_MySQL_MySqlClient.Xa
{


    public class MySqlXaTransaction : IDisposable
    {

        private bool open;
        private bool disposed = false;


        /// <summary>
        /// XA START 后， 如果不执行 XA END.
        /// 将无法做 PREPARE 、 COMMIT、ROLLBACK 的操作。
        /// </summary>
        private bool isEnd;


        /// <summary>
        /// XA 事务所使用的 xid.
        /// </summary>
        private readonly string _xid;

        /// <summary>
        /// 数据库连接.
        /// </summary>
        private readonly MySqlConnection _MySqlConnection;



        public MySqlXaTransaction(MySqlConnection c, string xid)
        {
            this._MySqlConnection = c;
            this._xid = xid;
            this.open = true;
        }


        ~MySqlXaTransaction()
        {
            Dispose(false);
        }




        public void XaStart()
        {
            if (_MySqlConnection == null || (_MySqlConnection.State != ConnectionState.Open))
                throw new InvalidOperationException("Connection must be valid and open to commit transaction");

            if (!open)
                throw new InvalidOperationException("Transaction has already been committed or is not pending");

            string sql = string.Format("XA START '{0}'", this._xid);

            MySqlCommand cmd = new MySqlCommand(sql, _MySqlConnection);

            cmd.ExecuteNonQuery();


            //  XA START 后， 如果不执行 XA END.
            // 将无法做 PREPARE 、 COMMIT、ROLLBACK 的操作。
            isEnd = false;
        }



        public void XaEnd()
        {
            if (_MySqlConnection == null || (_MySqlConnection.State != ConnectionState.Open))
                throw new InvalidOperationException("Connection must be valid and open to commit transaction");

            if (!open)
                throw new InvalidOperationException("Transaction has already been committed or is not pending");

            string sql = string.Format("XA END '{0}'", this._xid);

            MySqlCommand cmd = new MySqlCommand(sql, _MySqlConnection);

            cmd.ExecuteNonQuery();


            //  XA START 后， 如果不执行 XA END.
            // 将无法做 PREPARE 、 COMMIT、ROLLBACK 的操作。
            isEnd = true;
        }




        /// <summary>
        /// 准备.
        /// </summary>
        public void XaPrepare()
        {
            if (_MySqlConnection == null || (_MySqlConnection.State != ConnectionState.Open))
                throw new InvalidOperationException("Connection must be valid and open to commit transaction");

            if (!open)
                throw new InvalidOperationException("Transaction has already been committed or is not pending");

            string sql = string.Format("XA PREPARE '{0}'", this._xid);

            MySqlCommand cmd = new MySqlCommand(sql, _MySqlConnection);

            cmd.ExecuteNonQuery();
        }





        /// <summary>
        /// 提交.
        /// </summary>
        public void XaCommit()
        {
            if (_MySqlConnection == null || (_MySqlConnection.State != ConnectionState.Open ))
                throw new InvalidOperationException("Connection must be valid and open to commit transaction");

            if (!open)
                throw new InvalidOperationException("Transaction has already been committed or is not pending");

            string sql = string.Format("XA COMMIT '{0}'", this._xid);

            MySqlCommand cmd = new MySqlCommand(sql, _MySqlConnection);
            cmd.ExecuteNonQuery();
            open = false;
        }



        /// <summary>
        /// 回滚.
        /// </summary>
        public void XaRollback()
        {
            if (_MySqlConnection == null || (_MySqlConnection.State != ConnectionState.Open))
                throw new InvalidOperationException("Connection must be valid and open to commit transaction");

            if (!open)
                throw new InvalidOperationException("Transaction has already been committed or is not pending");


            if (!isEnd)
            {
                //  XA START 后， (在这个时间点上，发生了异常)  如果不执行 XA END.
                // 将无法做 PREPARE 、 COMMIT、ROLLBACK 的操作。
                this.XaEnd();
            }

            string sql = string.Format("XA ROLLBACK '{0}'", this._xid);

            MySqlCommand cmd = new MySqlCommand(sql, _MySqlConnection);
            cmd.ExecuteNonQuery();
            open = false;
        }




        public void Dispose()
        {
            Dispose(disposing: true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;


            if (disposing)
            {
                if ((_MySqlConnection != null && _MySqlConnection.State == ConnectionState.Open) && open)
                    XaRollback();
            }

            disposed = true;
        }



    }
}
