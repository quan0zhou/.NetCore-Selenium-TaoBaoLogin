using System;
using System.IO;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Interactions;

namespace TaoBaoLogin
{
    class Program
    {
        static void Main(string[] args)
        {
            //var driver = new ChromeDriver(Directory.GetCurrentDirectory());
            var driver = new EdgeDriver(Directory.GetCurrentDirectory());//当前运行目录下面（chromedriver/MicrosoftWebDriver）
            driver.Navigate().GoToUrl("https://login.taobao.com/member/login.jhtml");
            driver.Manage().Window.Maximize();//窗口最大化，便于脚本执行
            //设置超时等待(隐式等待)时间设置10秒
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            /**关键执行脚本(防止阿里反爬)**/
            driver.ExecuteScript("Object.defineProperties(navigator,{webdriver:{get:() => false}});");

            // 登陆页面
            driver.FindElementByClassName("J_Quick2Static").Click();

            ///**输入账号和密码***/
            driver.FindElement(By.Id("TPL_username_1")).SendKeys("000000");
            driver.FindElement(By.Id("TPL_password_1")).SendKeys("000000");


            Thread.Sleep(1000);
            var darg_block = driver.FindElement(By.Id("nc_1_n1z"));
            var darg_bg = driver.FindElement(By.Id("nc_1__scale_text"));
            var left = darg_bg.Size.Width - darg_block.Size.Width;//计算移动偏移量

            Actions actions = new Actions(driver);
            //actions.ClickAndHold(darg_bg).Build().Perform();
            //actions.DragAndDropToOffset(darg_bg, left, 0).Build().Perform();

            //只是简单的向右滑动，其实没必要计算准确的偏移量，给个稍微大一点的偏移量也可以的
            //由于edge滑动的偏移量有问题，所以加上一定的宽度（chrome偏移的是准确的）
            actions.DragAndDropToOffset(darg_block, left+200, 0).Build().Perform();

            //登录
            //driver.FindElement(By.Id("J_SubmitStatic")).Click();



        }
    }
}
