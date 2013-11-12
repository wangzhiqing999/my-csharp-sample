using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;


[Serializable]
[SqlUserDefinedAggregate(
  Format.UserDefined,               // 使用 UserDefined 序列化格式
  IsInvariantToNulls = true,        // 指示聚合是否与空值无关。
  IsInvariantToDuplicates = false,  // 指示聚合是否与重复值无关。
  IsInvariantToOrder = false,       // 指示聚合是否与顺序无关。
  MaxByteSize = 8000)               //  聚合实例的最大大小（以字节为单位）。
  ]
public struct GROUP_CONCAT : Microsoft.SqlServer.Server.IBinarySerialize
{
    /// <summary>
    /// 这是分组的所有数据.
    /// </summary>
    private string dataResult;

    /// <summary>
    /// 初始化.
    /// </summary>
    public void Init()
    {
        // 初始化.
        dataResult = String.Empty;
    }

    /// <summary>
    /// 新增一个数据
    /// </summary>
    /// <param name="Value"></param>
    public void Accumulate(SqlString Value)
    {
        // 新增一个数据
        if (String.IsNullOrEmpty(dataResult))
        {
            // 首次追加.
            dataResult = Value.Value;
        }
        else
        {
            // 二次追加.
            dataResult = dataResult + "," + Value.Value;
        }
    }

    /// <summary>
    /// 新增一组数据.
    /// </summary>
    /// <param name="Group"></param>
    public void Merge(GROUP_CONCAT Group)
    {
        // 新增一组数据.
        if (String.IsNullOrEmpty(dataResult))
        {
            // 首次追加.
            dataResult = Group.dataResult;
        }
        else
        {
            // 二次追加.
            dataResult = dataResult + "," + Group.dataResult;
        }
    }

    /// <summary>
    /// 处理结束.
    /// </summary>
    /// <returns></returns>
    public SqlString Terminate()
    {
        return new SqlString(dataResult);
    }



    /// <summary>
    /// 使用 UserDefined 序列化格式
    /// 通过 IBinarySerialize.Read 方法完全控制二进制格式。
    /// 从用户定义类型 (UDT) 或用户定义聚合的二进制格式生成用户定义的类型或用户定义的聚合。
    /// </summary>
    /// <param name="r"></param>
    public void Read(System.IO.BinaryReader r)
    {
        this.dataResult = r.ReadString();
    }

    /// <summary>
    /// 使用 UserDefined 序列化格式
    /// 通过 IBinarySerialize.Read 方法完全控制二进制格式。
    /// 将用户定义的类型 (UDT) 或用户定义的聚合转换为其二进制格式，以便保留。
    /// </summary>
    /// <param name="w"></param>
    public void Write(System.IO.BinaryWriter w)
    {
        w.Write(dataResult);
    }

}
