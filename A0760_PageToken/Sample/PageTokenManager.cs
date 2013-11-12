using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;




namespace A0760_PageToken.Sample
{

    /// <summary>
    /// 页面令牌管理.
    /// 
    /// 用于避免画面重复提交的处理。
    /// 
    /// 每个画面初始化的时候， 系统产生一个令牌。
    /// 
    /// 如果画面处理完毕，那么结束。
    /// 
    /// 如果发生一个画面， 多次提交了，由于令牌是唯一的。
    /// 那么后续的提交，将失败。
    /// 
    /// </summary>
    public class PageTokenManager
    {

        /// <summary>
        /// 令牌最大有效秒数.
        /// </summary>
        public static readonly int Max_Token_Keep_Second = 3;

        /// <summary>
        /// 令牌列表.
        /// </summary>
        private List<PageToken> tokenList = new List<PageToken>();




        /// <summary>
        /// 内部单例.
        /// </summary>
        private static PageTokenManager me;


        /// <summary>
        /// 私有构造函数.
        /// 避免外部直接序列化.
        /// </summary>
        private PageTokenManager()
        {
        }


        /// <summary>
        /// 取得实例.
        /// </summary>
        /// <returns></returns>
        public static PageTokenManager GetInstance()
        {
            if (me == null)
            {
                me = new PageTokenManager();
            }

            // 返回.
            return me;
        }



        /// <summary>
        /// 清除掉超时的 令牌.
        /// </summary>
        private void ClearTimeoutToken()
        {
            this.tokenList.RemoveAll(p => p.CreateTime.AddSeconds(Max_Token_Keep_Second) < DateTime.Now);
        }



        /// <summary>
        /// 加入令牌列表.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public bool PushToken(string token)
        {
            // 清除超时的令牌.
            ClearTimeoutToken();

            // 查询令牌是否已存在！
            PageToken myToken = tokenList.FirstOrDefault(p => p.Token == token);

            if (myToken != null)
            {
                // 令牌已存在，不能重复加入.
                return false;
            }

            // 创建新令牌.
            myToken = new PageToken()
            {
                Token = token,
                CreateTime = DateTime.Now
            };

            // 加入列表.
            tokenList.Add(myToken);
            // 返回.
            return true;
        }


    }


}
