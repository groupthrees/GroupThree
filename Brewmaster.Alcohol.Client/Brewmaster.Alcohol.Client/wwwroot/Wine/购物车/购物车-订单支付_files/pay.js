// JavaScript Document
$(document).ready(function(e) {
    $(".paymentList label").bind('click',function(){
		var index = $(this).parent().index();
		var top = 60*index;
		$(this).parent().addClass("checked").siblings().removeClass("checked");
		$("#payAmount").css('top',top+'px');
	});
});