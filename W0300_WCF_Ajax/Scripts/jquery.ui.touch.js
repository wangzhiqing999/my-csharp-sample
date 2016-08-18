(function($) {
	
  
     $.fn.lyhucTouchPad = function(options) {
		 //鼠标X位置
		var element=$(this);
		var draging = false;
		var touchPageWrapper=$("#" + element[0].id + "Wrapper");
		var touchPageContent=$("#"+element[0].id+"  ."+element[0].id+"Content");
		
		var marginleft=0;//父面板位置
		var touchPageContentWidth=touchPageContent.width();
		var startLeft,endLeft; 
		var startX,startY;  
		var point={X:0,Y:0};
		var currentIndex=0;
		var direction=0;
		
		var pageCount=touchPageContent.size();
		touchPageWrapper.width((pageCount+1)*touchPageContentWidth);

		 var defaults = {
			align:'center',
			pager:'#pager',
			showmousePoint:true
		};
		
		var options = $.extend(defaults, options);

		 //初始化
		(function init(){
						
			if(options.align=='center')
			{
				marginleft=($(window).width()-element.width())/2;
				element.css("left",marginleft);
				$(options.pager).css("width",marginleft);
			}
			if(options.align=='right')element.css("right",0);
			startLeft=0;
			
			
			for(var i=0;i<pageCount;i++)
			{
				if(i==0)
					$(options.pager+">div").before("<a href='#' class='current'> </a>");
				else
					$(options.pager+">div").before("<a href='#' class='point'> </a>");
			}
			
		})();
			
		clearEvent = function(){
			
		}
		
		startDrag = function(event)
		{
			var offset = $(this).offset();   
			startLeft = offset.left;
			
			startX = event.pageX;
			$(this)
			.stop(true, false)
			.mousemove(moveDrag)
			.css('cursor','move'); 
			;
			
			draging=true;  
		}
		
		/*
		* div随鼠标移动，由startDrag开启，由enddrag结束
		*/
		var moveDrag = function(event){
			var offset = $(this).offset();  
			var movepx=event.pageX-startX;
			endLeft= startLeft+movepx;
			
			direction=0;
			if(movepx>0 && movepx>=(touchPageContentWidth/6))
				direction=1;
			else if (movepx<0 && Math.abs(movepx)>=(touchPageContentWidth/6))
				direction=-1;
			
			if(options.showmousePoint)$("#mousePoint").text("X="+point.X+" Y="+point.Y+ " offset.left="+movepx+" direction="+direction);
			$(this).css("left", endLeft-marginleft );
			
			return true;
		}
		
		var endDrag = function(event){
			if(draging){
				$(touchPageWrapper)
					.unbind("mousemove",moveDrag)
					.css('cursor','auto'); 
				if(direction==1)
					currentIndex++
				else if(direction==-1)
					currentIndex--;
				
				if(currentIndex==1 && (direction==1)) currentIndex=0;
				if((Math.abs(currentIndex)+1)>=pageCount && (direction==-1)){currentIndex=(-pageCount+1);}
				
				$(touchPageWrapper).animate({ left: currentIndex*touchPageContentWidth }, "slow");
	
				var currentA=$(options.pager+" a");
				$(currentA).attr("class","");
				$(currentA).eq(Math.abs(currentIndex)).attr("class","current");
				
				direction=0;
				draging=false;
			}
		}
		
				
		//初始化事件
		return this.each(function(){
				var obj = $(this);
				
				obj.bind("mousemove",function(e){
					point.X = e.pageX;
					point.Y = e.pageY;
					
				}).bind("mouseup",endDrag);
				
				$(touchPageWrapper).bind("mousedown",startDrag)
				.bind("click",clearEvent)
				.bind("mouseup",endDrag).bind("mouseout",endDrag);
			
			});

    };
	

})(jQuery);