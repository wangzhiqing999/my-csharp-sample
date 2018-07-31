Visual Studio 2017 Community 中使用 Gulp.

前置安装需求.
先安装好 node.js


创建 Web 项目，并在项目根目录下新建 gulpfile.js.
编写相关的 gulp 脚本.


然后在当前项目的目录下

运行下面的命令， 安装 gulp
npm install gulp

运行下面的命令， 安装 gulp 插件.
npm install gulp-minify-css gulp-uglify gulp-concat gulp-rename gulp-notify


gulp 插件列表： https://gulpjs.com/plugins/


在 Visual Studio 2017 中， 鼠标点中 gulpfile.js 文件， 右键，选择 “任务运行程序资源管理器”
鼠标选择指定的任务，右键，选择 “运行”。



注意事项： 
1. gulpfile.js 中，css 文件路径 和 js 文件路径，不要简单的用 ['Content/*.css'] 与  ['Scripts/*.js'] 这种操作. 因为这些目录下，已经存在有 min.css 和 min.js 了。

2. 假如项目中的 css 与 js， 是通过类似 @Styles.Render("~/Content/css") 与 @Scripts.Render("~/bundles/jquery") 这种方式引用的。 那就不必再通过 gulp 去压缩合并了。



