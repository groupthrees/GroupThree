(function(e) {
    var f = e(window);
    var a = [];
    a.push(".back_to_top{display:none;width:61px;overflow:hidden;right:40px;position:fixed;z-index:100;bottom:50px;_position:absolute;_top:expression(eval(document.documentElement.scrollTop+document.documentElement.clientHeight-134));}");
    a.push(".back_to_top a{position: fixed;width: 72px;height: 72px;z-index: 299;right: 100px;bottom: 10px;cursor: pointer;background: url(/themes/ojo/images/img.png) no-repeat;background-position: 0 -950px;}");
    a.push(".back_to_top a:hover{background-position: 0 -878px;}");
    a.push(".back_to_top a.back_to_top_lottery{background-position:0 0;margin-bottom:4px;}");
    a.push(".back_to_top a.back_to_top_lottery:hover{background-position:-65px 0;}");
    a.push(".back_to_top a.back_to_top_quiz{background-position:0 -50px;margin-bottom:4px;}");
    a.push(".back_to_top a.back_to_top_quiz:hover{background-position:-65px -50px;}");
    e.insertStyle(a.join(""));
    var d = e('<div id="JS_back_to_top" class="back_to_top"><a href="javascript:;" title="返回顶部"></a></div>');
    e("body").append(d);
    
    window._gaq = window._gaq || [];
    if (window._QUIZ) {
        var c = e("<a class=\"back_to_top_quiz\" onclick=\"_gaq.push(['_trackEvent','buyerShowFloat',$.cookie('region_pinyin'),location.href]);\" href=\"" + window._QUIZ + '" target="_blank" title="问卷调查"></a>');
        d.prepend(c);
    }
    if (e.cookie("region_pinyin")) {
        var b = e("<a class=\"back_to_top_lottery\" onclick=\"_gaq.push(['_trackEvent','buyerShowFloat',$.cookie('region_pinyin'),location.href]);\" href=\"/" + e.cookie("region_pinyin") + '/buyershow.html?ref=prize_click1" target="_blank" title="抽优惠券"></a>');
        d.prepend(b);
    }
})(jQuery);
$(function() {
	$(window).scroll(function(){
		var scrolltop=$(this).scrollTop();		
		if(scrolltop>=300){		
			$("#JS_back_to_top").show();
		}else{
			$("#JS_back_to_top").hide();
		}
	});		
	$("#JS_back_to_top").click(function(){
		$("html,body").animate({scrollTop: 0}, 500);	
	});		
	
});
/*LDZ:2013-10-23 16:37:13*/