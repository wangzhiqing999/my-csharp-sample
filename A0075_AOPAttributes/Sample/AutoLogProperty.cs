using System;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;

namespace A0075_AOPAttributes.Sample
{
	public class AutoLogProperty : IContextProperty, IContributeObjectSink
	{
		public AutoLogProperty()
		{
		}

		/// <summary>
		/// IContributeObjectSink的接口方法，实例化消息接收器
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="next"></param>
		/// <returns></returns>
		public IMessageSink GetObjectSink(MarshalByRefObject obj, IMessageSink next)
		{
			return new AutoLogSink(next);
		}

		/// <summary>
		/// IContextProperty接口方法，如果该方法返回ture,在新的上下文环境中激活对象
		/// </summary>
		/// <param name="newCtx"></param>
		/// <returns></returns>
		public bool IsNewContextOK(Context newCtx)
		{
			return true;
		}

		/// <summary>
		/// IContextProperty接口方法，提供高级使用
		/// </summary>
		/// <param name="newCtx"></param>
		public void Freeze(Context newCtx)
		{
		}

		/// <summary>
		/// IContextProperty接口属性
		/// </summary>
		public string Name
		{
			get { return "AutoLog"; }
		}
	}
}
