
function _dmpTJclick(actionName){
	_CWiQ.push(['_trackPdmp', actionName, 1]);
}
$(function(){	
	$('.xcy_action_prtlt').bind('click',function(){
		_dmpTJclick('加入购物车');
	})
	$('.xcy_action_prtlt_list').bind('click',function(){
		var goodsId=$(this).siblings('span').find('input').attr('gid');
		
		_dmpTJclick('加入购物车');
        ga('send', 'event', 'addcart_list', 'button', 'goods');
	})
	$('.xcy_action_prtlt_search').bind('click',function(){
		var goodsId=$(this).siblings('span').find('input').attr('gid');
		
		_dmpTJclick('加入购物车');
        ga('send', 'event', 'addcart_search', 'button', 'goods');
	})
})

// 宣传易 统计代码 end

//一个汉字相当于2个字符
    function get_length(s){
        var char_length = 0;
        for (var i = 0; i < s.length; i++){
            var son_char = s.charAt(i);
            encodeURI(son_char).length > 2 ? char_length += 1 : char_length += 0.5;
        }
        return char_length;
    }
    function cut_str(str, len){
        var char_length = 0;
		var sub_len = 0;
        for (var i = 0; i < str.length; i++){
            var son_str = str.charAt(i);
            encodeURI(son_str).length > 2 ? char_length += 1 : char_length += 0.5;
            if (char_length >= len){
                sub_len = char_length == len ? i+1 : i;
               // return str.substr(0, sub_len);
                break;
            }
        }
		var rstr = str;
		if(sub_len>0){
			rstr = str.substr(0, sub_len);
		}
		return rstr;
    }
$(function(){
	$("[loadfrom]").each(function(){
		var e = $(this);	
		e.load(e.attr("loadfrom"));
	});
	// 异步加载图片
	var gbox = $("body .lazyload img");
	if(gbox.length>0){
		gbox.lazyload({
			placeholder : "http://img01.jiuxian.com/img1/loading.gif",     
			threshold : 180, 
			failurelimit : 10, 
			effect : "fadeIn"
		});
	}

	//价格异步加载
	var page_proids = new Array();
	$("[_data='price']").each(function(){
		var e = $(this);	
		var proId = e.attr("_proid");
		if(/^\d+$/.test(proId)){page_proids.push(proId);}
	});
	getProductActPrice(page_proids.join(),function(data){
		for(var item in data){
			$("[_data='price'][_proid='"+item+"']").text(data[item].np);
		}
	});
});

$(function(){
/***********返回顶部开始***********/
window.onscroll=function(){
	try{
		var scrollTop = document.documentElement.scrollTop||document.body.scrollTop;
		var toTopImg=document.getElementById("ftop");
		if(scrollTop > 500){
			toTopImg.style.display='block';
			toTopImg.onclick=function(){
				window.scroll(0,-10000);
			}
		}
		else{
				toTopImg.style.display = 'none';
		}
	}catch(e){}
}

$("#ftop").bind({
	mouseover:function(){
		$(this).attr("class","top2");
	},
	mouseout:function(){
		$(this).attr("class","top1");
	}
})
})
//输入下拉框
$(function(){
	$(".seo_bg").bind('keyup',function(event){
		event = event || window.event;
		var keyCode = event.keyCode;
		if(keyCode=='40' || keyCode=='38'){
			return;
		}
		var value = $(".seo_bg").val();
		var keywords=$.trim(value);
		if(keywords==''){
			$('#searBox').hide();
		}else{
			$('#searBox').slideDown();
		}
	});
$("body").click(function(e){ 
	$("#searBox").css("display","none"); 
});
/***********移动设备二维码显隐**********/
	$('.hd_mobile_devic').mouseover(function(){
		$(this).css('border','solid 1px #CCCCCC');
		$(this).addClass('hd_mobile_devichover');
		$('.hd_mobile_list').show();
	}).mouseout(function(){
		$(this).css('border','solid 1px #fafafa');
		$(this).removeClass('hd_mobile_devichover');
		$('.hd_mobile_list').hide();
	})
})

$(function(){
	$('.top_don').mouseover(function(){
		$(this).css('border','solid 1px #CCCCCC');
		$(this).addClass('top_don2');
		$('.top_drop').show();
	}).mouseout(function(){
		$(this).css('border','solid 1px #fafafa');
		$(this).removeClass('top_don2');
		$('.top_drop').hide();
	})
})

$(document).ready(function() {
	$('.dd').hover(function(){
	$(this).css('border-left','solid 1px #ffffff');
		var a =$(this).text();
		if(a.indexOf('iP')>=0){
			$('.hd_mobile_pix').show();
			
			$('.hd_mobile_pix').find('img').attr('src',domain_img01+'/img1/tit/iPhone.png');
		}else if(a.indexOf('An')>=0){
		$('.hd_mobile_pix').show();
			$('.hd_mobile_pix img').attr('src',domain_img01+'/img1/tit/android.png');
		}else if(a.indexOf('wa')>=0){
		$('.hd_mobile_pix').show();
			$('.hd_mobile_pix').find('img').attr('src',domain_img01+'/img1/tit/wap.png');
		}
	},
	function (){
		$('.hd_mobile_pix').hide();
		$(this).css('border-left','solid 1px #cccccc');
		});
	
	$('.hd_mobile_pix').mouseover(function(){
		$(".hd_mobile_list").show();
		$(this).show();
	});
	$('.hd_mobile_pix').mouseout(function(){
		$(".hd_mobile_list").hide();
		$(this).hide();
	});

})


//收藏
function saves(goodsIds){//4,5,6,7
		var proxy_url = "/httpProxyAccess.htm?t="+new Date().getTime();
   jQuery.ajax({
		 type:'post',
		 url:proxy_url,
		 data:{target:domain_detail+'/pro/selectLoginSession.htm'},
		 dataType:'json',
		 async:true,
		 success:function(data){
			 if(data && data.code == 0 && data.loginUser){
				 $.getJSON(proxy_url,{target:domain_detail+"/pro/saveCollects.htm?proIds="+goodsIds},function(data){
					if(data){
						if(data.code == -1){
							alert('收藏失败!');
							return false;
						}else if(data.code == 0){
							alert('收藏成功!');
							return false;
						}else if(data.code == 1){
							alert("您还没有登录，请先登录！");
							return false;
						}else if(data.code == 2){
							alert("您之前已经收藏过这件商品！");
							return false;
						}else if(data.code == 3){
							alert("部分已收藏！");
							return false;
						}
					}
				 });
			 }else{
			     alert("您还没有登录，请先登录！");
			 }
		 }
    });
}

function getProductActPrice(proIds,callback){
	if(proIds != ""){
		var proxy_url = "/httpProxyAccess.htm?t="+new Date().getTime();
		$.post(proxy_url,{target:ACT_REQUEST_URL,ids:proIds},
			function(result){
				if(result != null){
					if(result.status == 1){
							callback(result.data);
					}else{
						//alert(result.msg);
					}
				}
		 }, 'JSON');
	}
} 

function getCookie(objName) {
	var arrStr = document.cookie.split("; ");
	for ( var i = 0; i < arrStr.length; i++) {
		var temp = arrStr[i].split("=");
		if (temp[0] == objName) {
			return unescape(temp[1])
		}
	}
	return ""
}

function getUserId(){
	var userId = getCookie("jx_user_id");
	if(userId == ''){
		return "0";
	}
	return userId;
}

function getCookie(objName) {
	var arrStr = document.cookie.split("; ");
	for ( var i = 0; i < arrStr.length; i++) {
		var temp = arrStr[i].split("=");
		if (temp[0] == objName) {
			return unescape(temp[1])
		}
	}
	return ""
}
function setCookie(c_name, value, expiredays) {
	var exdate = new Date();
	exdate.setDate(exdate.getDate() + expiredays);
	document.cookie = c_name + "=" + escape(value)
			+ ((expiredays == null) ? "" : ";expires=" + exdate.toGMTString())
			+ ";path=/;domain=jiuxian.com"
}