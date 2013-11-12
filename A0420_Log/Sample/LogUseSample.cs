using System;
using System.IO;
using System.IO.Log;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0420_Log.Sample
{


    /// <summary>
    /// 使用 System.IO.Log 实现日志的写入
    /// 
    /// 由于 其写入的文件格式， 不是简单的文本方式的写入
    /// 
    /// 而是附加一定格式的二进制信息
    /// 
    /// 导致 必须还要使用 System.IO.Log 实现日志的读取。
    /// 
    /// 因此在某些情况下，不推荐使用。
    /// </summary>
    class LogUseSample
    {
        /// <summary>
        /// 日志文件名.
        /// </summary>
        string logName = "test.log";

        /// <summary>
        /// 基于文件系统中的单一日志文件的记录序列。
        /// </summary>
		FileRecordSequence sequence = null;


		bool delete = true;


        /// <summary>
        /// 将字符串 转换为 字节数组
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static IList<ArraySegment<byte>> CreateData(string str)
        {
            Encoding enc = Encoding.Unicode;

            byte[] array = enc.GetBytes(str);

            ArraySegment<byte>[] segments = new ArraySegment<byte>[1];
            segments[0] = new ArraySegment<byte>(array);

            return Array.AsReadOnly<ArraySegment<byte>>(segments);
        }


        public LogUseSample()
		{
            // 创建一个 单一日志文件的记录序列。
			sequence = new FileRecordSequence(logName, FileAccess.ReadWrite);
		}



        /// <summary>
        /// 新增日志记录.
        /// </summary>
		public void AppendRecords()
		{
            Console.WriteLine("新增日志记录...");

            // SequenceNumber 表示记录序列中分配给日志记录的序列号。
            //   Invalid 表示 获取用于表示无效序列号默认值的序列号。
			SequenceNumber previous = SequenceNumber.Invalid;

            // 将日志记录写入 FileRecordSequence。
            //     第一个参数为 将连接在一起并以记录形式追加的字节数组段的列表。
            //     第二个参数为 用户指定顺序中下一条记录的序列号。
            //     第三个参数为 “上一个”顺序中下一条记录的序列号。
            //     第四个参数为 指定应如何写入数据。
            //                  RecordAppendOptions.ForceFlush 表示：追加此记录后，记录序列应刷新所有内部缓冲区。在追加操作完成时，已持久写入指定的记录。


			previous = sequence.Append(CreateData("Hello World!"), SequenceNumber.Invalid, SequenceNumber.Invalid, RecordAppendOptions.ForceFlush);
			previous = sequence.Append(CreateData("This is my first Logging App"), SequenceNumber.Invalid, SequenceNumber.Invalid, RecordAppendOptions.ForceFlush);
			previous = sequence.Append(CreateData("Using FileRecordSequence..."), SequenceNumber.Invalid, SequenceNumber.Invalid, RecordAppendOptions.ForceFlush);

			Console.WriteLine("Done...");
		}
		


	    /// <summary>
	    /// 读取日志信息
	    /// </summary>
		public void ReadRecords()
		{
			Encoding enc = Encoding.Unicode;

			Console.WriteLine();

			Console.WriteLine("Reading Log Records...");
			try
			{
				foreach (LogRecord record in this.sequence.ReadLogRecords(this.sequence.BaseSequenceNumber, LogRecordEnumeratorType.Next))
				{
					byte[] data = new byte[record.Data.Length];
					record.Data.Read(data, 0, (int)record.Data.Length);
					string mystr = enc.GetString(data);
					Console.WriteLine("    {0}", mystr);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception {0} {1}", e.GetType(), e.Message);
			}

			Console.WriteLine();
		}



	    /// <summary>
	    /// 删除日志文件.
	    /// </summary>
		public void Cleanup()
		{
	        // Dispose the sequence.
			sequence.Dispose();

	        // Delete the log file.
			if (delete)
			{
				try
				{
					File.Delete(this.logName);
				}
				catch (Exception e)
				{
					Console.WriteLine("Exception {0} {1}", e.GetType(), e.Message);
				}
			}
		}







    }

}
