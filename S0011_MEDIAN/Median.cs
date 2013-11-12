using System;
using System.Collections.Generic;
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
public struct Median : Microsoft.SqlServer.Server.IBinarySerialize
{
    public void Init()
    {
        // 初始化.
        dataList = new List<Decimal>();
    }

    public void Accumulate(SqlDecimal Value)
    {
        // 新增一个数据
        dataList.Add(Value.Value);
    }

    public void Merge(Median Group)
    {
        // 新增一组数据.
        dataList.AddRange(Group.dataList);
    }

    public SqlDecimal Terminate()
    {
        // 首先排序.
        dataList.Sort();

        decimal middleVal = 0;

        if (dataList.Count > 0)
        {
            if (dataList.Count % 2 == 1)
            {
                // 当数量为奇数的时候.
                // 中位数为中间的那个数字.
                // 例如
                // 1个数字， 中位为第1个
                // 3个数字， 中位为第2个
                // 5个数字， 中位为第3个
                // 7个数字， 中位为第4个
                middleVal = dataList[dataList.Count / 2];
            }
            else
            {
                // 当数量为偶数的时候.
                // 中位数为 中间2个数的 算数平均
                // 例如
                // 2个数字， 中位为 (第1个 + 第2个) / 2
                // 4个数字， 中位为 (第2个 + 第3个) / 2
                // 6个数字， 中位为 (第3个 + 第4个) / 2
                // 8个数字， 中位为 (第4个 + 第5个) / 2
                middleVal =
                    (dataList[dataList.Count / 2 - 1]
                    + dataList[dataList.Count / 2]) / 2;
            }
        }

        return new SqlDecimal(middleVal);
    }

    // 这是分组的所有数据.
    private List<Decimal> dataList;


    /// <summary>
    /// 使用 UserDefined 序列化格式
    /// 通过 IBinarySerialize.Read 方法完全控制二进制格式。
    /// 从用户定义类型 (UDT) 或用户定义聚合的二进制格式生成用户定义的类型或用户定义的聚合。 
    /// </summary>
    /// <param name="r"></param>
    public void Read(System.IO.BinaryReader r)
    {
        // 初始化数据.
        dataList = new List<decimal>();
        // 先读取总数量.
        int size = r.ReadInt32();
        // 依次读取数据，加入列表.
        for (int i = 0; i < size; i++)
        {
            dataList.Add(r.ReadDecimal());
        }
    }

    /// <summary>
    /// 使用 UserDefined 序列化格式
    /// 通过 IBinarySerialize.Read 方法完全控制二进制格式。
    /// 将用户定义的类型 (UDT) 或用户定义的聚合转换为其二进制格式，以便保留。 
    /// </summary>
    /// <param name="w"></param>
    public void Write(System.IO.BinaryWriter w)
    {
        // 先写入一个 总数量
        w.Write(dataList.Count);
        // 依次写入每一个数据.
        foreach (Decimal data in dataList)
        {
            w.Write(data);
        }
    }
}
