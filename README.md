# .NetCore-Selenium-TaoBaoLogin
C# (.NET Core)  Selenium（EdgeDriver）破解 阿里滑动验证
### 目前测试过chromedrvier(版本74.0.3729.6)无法进行滑动验证（已经被页面识别）,未找到解决方案
### 但是EdgeDriver(版本17.17134)是可以滑动验证，但是需要执行脚本：`Object.defineProperties(navigator,{webdriver:{get:() => false}});`
### 运行时要根据自己本地的chrome/edge版本环境选择安装chomedriver/MicrosoftWebDriver
