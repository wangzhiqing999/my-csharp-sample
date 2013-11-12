using System;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Activation;

namespace A0075_AOPAttributes.Sample
{

	[AttributeUsage(AttributeTargets.Class)]
	public class AutoLogAttribute : ContextAttribute
	{
		public AutoLogAttribute() : base("AutoLog")
		{
		}

		/// <summary>
		/// 覆盖 ContextAttribute方法，创建一个上下文环境属性
		/// </summary>
		/// <param name="ctorMsg"></param>
		public override void GetPropertiesForNewContext(IConstructionCallMessage ctorMsg)
		{
			ctorMsg.ContextProperties.Add(new AutoLogProperty());
		}
	}

}
