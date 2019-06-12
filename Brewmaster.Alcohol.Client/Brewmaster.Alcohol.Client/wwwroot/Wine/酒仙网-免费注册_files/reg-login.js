// JavaScript Document

$(function(){
	//帮助中心下拉框js
	$(".jx-head-nav").hover(function(){
		$(this).find(".jx-head-pop").show();
	},function(){
		$(this).find(".jx-head-pop").hide();
	})
	
	var fTop = $(".jx-footer").offset().top;
	//var sTop = fTop+$(".jx-footer").height()+30;
	var padTop = $(window).height()-fTop;

	if(padTop>90){
		$(".jx-footer").css('height',padTop+'px');
	}else
	{
		$(".jx-footer").css('height','90px');
	}
	$(window).resize(function(){
		fTop = $(".jx-footer").offset().top;
		//sTop = fTop+$(".jx-footer").height()+30;
		padTop = $(window).height()-fTop;
		if(padTop>90){
		$(".jx-footer").css('height',padTop+'px');
		}else
		{
			$(".jx-footer").css('height','90px');
		}
	})
	
})