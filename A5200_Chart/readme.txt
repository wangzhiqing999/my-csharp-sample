图表开发操作步骤.


1. 创建一个 WinForm 窗口。

2. 将 Chart 控件，拖入窗口中，并设置大小。

3. 点击 Chart 控件 的 Series 属性， 弹出对话框。 默认只有一个 Series1 ，类型为 柱状图 (Column).

可以在设计阶段， 设置图表的类型， 也可以在后面的代码里面设置类型。
这里的 Series 的名称很重要。
后续的操作代码， 依赖于这个 名称。



4. 点击 Chart 控件 的 ChartAreas 属性， 弹出对话框。  默认只有一个 ChartArea1。

可以在设计阶段， 设置 图表的 3D 效果，  也可以在后面的代码里面设置。
这里的 ChartAreas 的名称很重要。
后续的操作代码， 依赖于这个 名称。




--------------------------------------------------------------------------------
画区域的处理.
--------------------------------------------------------------------------------

// 可以通过下面的代码， 来手动 逐行增加数据。
chart1.Series["Series1"].Points.AddY( 数据 );


// 默认的 Area.
chart1.Series["Series1"].ChartType = SeriesChartType.Area;

// 平滑的 Area.
chart1.Series["Series1"].ChartType = SeriesChartType.SplineArea;

// 作合计的 Area.
chart1.Series["Series1"].ChartType = SeriesChartType.StackedArea;

// 作合计，计算百分比的  Area.
chart1.Series["Series1"].ChartType = SeriesChartType.StackedArea100;



--------------------------------------------------------------------------------
画柱状图的处理.
--------------------------------------------------------------------------------

// 可以通过下面的代码， 来手动 逐行增加数据。
chart1.Series["Series1"].Points.AddY( 数据 );

// 默认的 Bar （横向）.
chart1.Series["Series1"].ChartType = SeriesChartType.Bar;

// 默认的 Column  （纵向）.
chart1.Series["Series1"].ChartType = SeriesChartType.Column;

// 作合计的 Bar （横向）.
chart1.Series["Series1"].ChartType = SeriesChartType.StackedBar;

// 作合计的 Column  （纵向）.
chart1.Series["Series1"].ChartType = SeriesChartType.StackedColumn;

// 作合计，计算百分比的 Bar （横向）.
chart1.Series["Series1"].ChartType = SeriesChartType.StackedBar100;

// 作合计，计算百分比的 Column  （纵向）.
chart1.Series["Series1"].ChartType = SeriesChartType.StackedColumn100;




--------------------------------------------------------------------------------
画线的处理.
--------------------------------------------------------------------------------

// 可以通过下面的代码， 来手动 逐行增加数据。
chart1.Series["Series1"].Points.AddY( 数据 );

// 设置 图表的类型为 线.  SeriesChartType.Line
chart1.Series["Series1"].ChartType = SeriesChartType.Line;

// SeriesChartType.Spline 也是线，但是更平滑一些
chart1.Series["Series2"].ChartType = SeriesChartType.Spline;

// SeriesChartType.StepLine 也是线， 一格一格跳动的。
chart1.Series["Series2"].ChartType = SeriesChartType.StepLine;

// 设置 图表的类型为 FastLine  (线上不显示数据)
chart1.Series["Series1"].ChartType = SeriesChartType.FastLine;




--------------------------------------------------------------------------------
画饼图的处理.
--------------------------------------------------------------------------------

// 饼图需要设置 x 与 y.  也就是 数值 与 分类标题.
double[] yValues = { 65.62, 75.54, 60.45, 34.73, 85.42 };
string[] xValues = { "France", "Canada", "Germany", "USA", "Italy" };
chart1.Series["Series1"].Points.DataBindXY(xValues, yValues);


// 设置 图表的类型为 饼图  实心
chart1.Series["Series1"].ChartType = SeriesChartType.Pie;

// 设置 图表的类型为 饼图  空心
chart1.Series["Series1"].ChartType = SeriesChartType.Doughnut;









--------------------------------------------------------------------------------
画点的处理.
--------------------------------------------------------------------------------

// 可以通过下面的代码， 来手动 逐行增加数据。
chart1.Series["Series1"].Points.AddY( 数据 );

// 设置 图表的类型为 点  （点上将不显示数值）
chart1.Series["Series1"].ChartType = SeriesChartType.FastPoint;

// 设置 图表的类型为 点
chart1.Series["Series1"].ChartType = SeriesChartType.Point;

// 设置 图表的类型为 大点
chart1.Series["Series1"].ChartType = SeriesChartType.Bubble;







参考页面:

https://msdn.microsoft.com/zh-tw/library/dd456632.aspx


