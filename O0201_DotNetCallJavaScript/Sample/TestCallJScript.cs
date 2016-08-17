using System;
using Microsoft.JScript;
using Microsoft.JScript.Vsa;


namespace O0201_DotNetCallJavaScript.Sample
{
    class TestCallJScript
    {
        static VsaEngine engine = VsaEngine.CreateEngine();
        static object EvalJScript(string jscript)
        {
            object result = null;
            try
            {
                result = Microsoft.JScript.Eval.JScriptEvaluate(jscript, engine);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            Console.WriteLine("执行：{0}  ---> 返回结果：{1}", jscript, result);
            return result;
        } 

        public static void TestCallJs()
        {
            EvalJScript("1+1");
            EvalJScript("Math.sin(3)");
            EvalJScript("Math.E");
            EvalJScript("Math.LN2");
            EvalJScript("Math.LN10");
            EvalJScript("Math.LOG2E");
            EvalJScript("Math.LOG10E");
            EvalJScript("Math.PI");
            EvalJScript("Math.pow(2,4)");
            EvalJScript("Math.pow(Math.E,4)");
        }
    }
}
