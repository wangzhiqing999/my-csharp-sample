var gulp = require('gulp');

// 引入组件
var //htmlmin = require('gulp-htmlmin'), //html压缩
    minifycss = require('gulp-minify-css'),//css压缩
    uglify = require('gulp-uglify'),//js压缩
    concat = require('gulp-concat'),//文件合并
    rename = require('gulp-rename'),//文件更名
    notify = require('gulp-notify');//提示信息


// css 的路径.
var cssPath = ['Content/Site.css'];

// js 的路径.
var jsPath = ['Scripts/modernizr-2.6.2.js'];


// 合并、压缩、重命名css
gulp.task('css', function () {
    return gulp.src(cssPath)
        .pipe(concat('main.css'))
        .pipe(rename({ suffix: '.min' }))
        .pipe(minifycss())
        .pipe(gulp.dest('dest/css'));
    //.pipe(notify({ message: 'css task ok' }));
});

// 合并、压缩js文件
gulp.task('js', function () {
    return gulp.src(jsPath)
        .pipe(concat('main.js'))
        .pipe(rename({ suffix: '.min' }))
        .pipe(uglify())
        .pipe(gulp.dest('dest/js'));
    //.pipe(notify({ message: 'js task ok' }));
});


// 默认任务
gulp.task('default', function () {
    gulp.run('css', 'js');

    // 监听 .css files 改变则会重新压缩
    // gulp.watch(cssPath, ['css']);

    // 监听 .js files 改变则会重新压缩
    // gulp.watch(jsPath, ['js']);
});